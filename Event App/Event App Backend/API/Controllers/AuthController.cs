﻿using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _service;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IMapper mapper, IConfiguration configuration)
        {
            _service = new UserManager();
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(/*UserAuthDto*/ UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = _mapper.Map<User>(request);
            user.CreatingDate = DateTime.Now;
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _service.CreateUser(user);

            return Ok(new { success = true });
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> Login(UserAuthDto request)
        {
            User user = _service.GetAllUsers().Where(x => x.Username == request.Username).FirstOrDefault();

            if (user == null)
            {
                return Ok(new { success = false, message = "User not found." });
            }
            else
            {
                if (!VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
                {
                    return Ok(new { success = false, message = "Wrong Password." });
                }
                else
                {
                    string token = CreateToken(user);
                    user.Token = token;
                    return Ok(new { userToken = token, id = user.Id, success = true });
                }
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes((string)password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Id",user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(365),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}