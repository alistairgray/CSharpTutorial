using System;
using System.Collections.Generic;

namespace CSharpTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            person.AskForFullName();
            person.AskForAge();

            person.AskForCarCompany();
            person.AskForCarCompany();
            person.AskForCarCompany();

            person.ShowInformation();

            Console.ReadLine();
        }

        
        
    }
}
