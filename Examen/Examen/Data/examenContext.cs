using Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Data
{
    public class examenContext:DbContext
    {
        public examenContext(DbContextOptions<examenContext>option):base(option)
        {

        }
        public DbSet<ciudad> ciudad { get; set; }
        public DbSet<user> user { get; set; }
    }
}
