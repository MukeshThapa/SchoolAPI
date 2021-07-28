using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ScoolContext : DbContext
    {

        public ScoolContext(DbContextOptions<ScoolContext> options) : base(options)
        {

        }

        public DbSet<Student> tbl_Student { get; set; }

        public DbSet<Standard> tbl_Standards { get; set; }

    }
}
