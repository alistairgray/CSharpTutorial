using CSharpTutorial.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTutorial.Entities
{
    public class TutorialContext : DbContext
    {
        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options) { }

        public DbSet<CarCompany> CarCompany { get; set; }

        public DbSet<FoodCompany> FoodComapny { get; set; }

        public DbSet<PersonEntity> PersonEntity { get; set; }
    }
}
