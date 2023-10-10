using GTI.Data.Mapping;
using GTI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
        }

        public DbSet<UserEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
