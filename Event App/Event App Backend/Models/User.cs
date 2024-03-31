using Models.ContentModels;
using Models.Friend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string? Gender { get; set; }

        public string? Token { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatingDate { get; set; }

        public string? BioText { get; set; }

        public ICollection<Friendship> Friendships { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
