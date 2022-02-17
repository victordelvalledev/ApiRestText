using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestTest.Models;

namespace RestTest.Models
{
    public class textDBContext:DbContext
    {
        public DbSet<Text> Texts { get; set; }

        public textDBContext(DbContextOptions<textDBContext> options)
            : base(options)
        {

        }

        public textDBContext() { }
    }
}
