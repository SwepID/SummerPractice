using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SummerPractice.Models
{
    public class Context :DbContext
    {
        public Context() : base("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}