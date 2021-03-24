using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTutorial.Entities
{
    public class TutorialContextFactory : IDesignTimeDbContextFactory<TutorialContext>
    {
        public static string ConnectionString = "Server=142.93.52.151;Port=3306;Database=tutorial;Uid=csharp;Pwd=chicken;Connection Timeout=30;SslMode=Preferred;";
        
        public TutorialContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TutorialContext>();

            optionsBuilder.UseMySql(ConnectionString);

            return new TutorialContext(optionsBuilder.Options);
        }
}
}
