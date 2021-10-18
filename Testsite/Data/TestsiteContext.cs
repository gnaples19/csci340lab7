using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testsite.Models;

namespace Testsite.Data
{
    public class TestsiteContext : DbContext
    {
        public TestsiteContext (DbContextOptions<TestsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Testsite.Models.Motorcycle> Motorcycle { get; set; }
    }
}
