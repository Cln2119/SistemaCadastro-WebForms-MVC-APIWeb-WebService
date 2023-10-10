using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Data Source=LAPTOP-1P8P1N60\\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;";
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new UserContext(optionsBuilder.Options);
        }
    }
}
