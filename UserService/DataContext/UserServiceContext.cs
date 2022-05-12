using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.DataContext
{
    public class UserServiceContext : DbContext
    {

        public UserServiceContext(DbContextOptions<UserServiceContext> options) : base(options)
        {

        }

        public DbSet<UserRegistration> userRegistrations { get; set; }
    }
}
