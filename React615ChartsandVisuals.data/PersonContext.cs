using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace React615ChartsandVisuals.data
{
    public class PersonContext : DbContext
    {

        private readonly string _conn;

        public PersonContext(string connectionString)
        {
            _conn = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);
        }

        //added to have the calculated "Age" property update in the db according to the calculation 
        //(see https://stackoverflow.com/questions/58116856/store-computed-property-with-entity-framework-core)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person>()
                .Property(e => e.Age)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
        public DbSet<Person> People { get; set; }

    }
}

