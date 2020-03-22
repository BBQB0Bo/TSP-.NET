using DatabaseNETCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseNETCore.ModelContext
{
    public class PersonContext : DbContext
    {
        public PersonContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Persons;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kind of Seed Method
            modelBuilder.Entity<Person>().HasData(
                Person.Create(1, "Robert", "Constantin", "Darabana", "0773823900"));
        }
    }
}
