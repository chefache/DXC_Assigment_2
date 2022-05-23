using DXC_Assigment_2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXC_Assigment_2
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options)
               : base(options)
        {

        }


        public DbSet<Module> Modules { get; set; }

        public DbSet<Regular> Regulars { get; set; }

        public DbSet<RegularStage> regularStages { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<Supervisor> Supervisors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-AMLLGJ5;Database=DXC_Assigment2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
