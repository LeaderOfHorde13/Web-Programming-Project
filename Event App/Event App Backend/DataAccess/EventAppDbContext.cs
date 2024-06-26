﻿using Models.ContentModels;
using Models.Friend;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EventAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NFN73G1;Initial Catalog=MyAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //Base
        public DbSet<User> Users { get; set; }

        //Friend
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendshipStatus> FriendshipStatuses { get; set; }
        public DbSet<Follow> Follows { get; set; }

        //Content Models
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentStatistics> ContentStatistics { get; set; }
        public DbSet<ContentComment> ContentComments { get; set; }
    }
}
