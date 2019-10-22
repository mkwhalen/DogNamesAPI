using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogNames.Models
{
    public class DogNamesContext : DbContext
    {
        public DogNamesContext(DbContextOptions<DogNamesContext> options)
            : base(options)
        {
        }

        public DbSet<Name> DogNames { get; set; }
    }
}
