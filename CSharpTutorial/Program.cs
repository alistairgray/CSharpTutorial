using CSharpTutorial.Entities;
using CSharpTutorial.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTutorial
{
    public class Program
    {
        public static ServiceProvider ServiceProvider { get; set; }

        private static TutorialContext _tutorialContext { get; set; }

        public static void Main(string[] args)
        {
            _registerServiceProvider();

            _tutorialContext = ServiceProvider.GetService<TutorialContext>();

            Person person = new Person();

            Console.WriteLine("Are you already in the database? Y or N");
            string givenValue = Console.ReadLine();

            PersonEntity foundPerson = null;

            if (givenValue == "Y")
            {
                foundPerson = person.AskForUserName(_tutorialContext);

                if(foundPerson == null)
                {
                    Console.WriteLine("We couldn't find you. Please create a new account");

                    person.AskForFullName();
                    person.AskForAge();

                    foundPerson = person.SavePersonInDatabase(_tutorialContext);
                }

                if(foundPerson != null)
                {
                    Console.WriteLine("Hello " + foundPerson.FullName + " nice to see you again. We know your age is: " + foundPerson.Age);
                    var carCompanyList = _tutorialContext.CarCompany.Where(x => x.PersonEntityID == foundPerson.PersonEntityID).ToList();

                    foreach(var carCompanyItem in carCompanyList)
                    {
                        Console.WriteLine("A car company you know is: " + carCompanyItem.CarCompanyName);
                    }

                    Console.WriteLine("Do you still want to be in our database? Y or N?");
                    var givenRemoveAnswer = Console.ReadLine();

                    if(givenRemoveAnswer == "N")
                    {
                        _tutorialContext.PersonEntity.Remove(foundPerson);
                        _tutorialContext.SaveChanges();
                    }
                    else 
                    {
                        foundPerson.Age = foundPerson.Age + 1;
                        _tutorialContext.PersonEntity.Update(foundPerson);
                        _tutorialContext.SaveChanges();
                    }
                }
            }
            else
            {
                person.AskForFullName();
                person.AskForAge();

                foundPerson = person.SavePersonInDatabase(_tutorialContext);
            }

            

            person.AskForCarCompany();
            person.AskForCarCompany();
            person.AskForCarCompany();

            person.SaveCarCompaniesInDatabase(_tutorialContext, foundPerson);

            person.ShowInformation();

            Console.ReadLine();
        }

        
        private static void _registerServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<TutorialContext>(options => options.UseMySql(TutorialContextFactory.ConnectionString));

            serviceCollection.AddTransient<TutorialContext>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        
    }
}
