﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public List<User> GetUserById(int userId);
        public List<User> GetUserByUsername(string username);
        public User CreateUser(User user);
        User UpdateUser(User user);
        public void DeleteUser(int id);
    }
}
