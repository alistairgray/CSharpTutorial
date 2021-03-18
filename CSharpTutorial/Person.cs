using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTutorial
{
    public class Person
    {
        public string FullName { get; set; }

        public int Age { get; set; }
        public List<string> CarList { get; set;}

        public Person()
        {
            CarList = new List<string>();
        }

        public void AskForFullName()
        {
            Console.WriteLine("What is your name?");
            string fullName = Console.ReadLine();

            FullName = fullName;
        }

        public void AskForCarCompany()
        {
            Console.WriteLine("Can you name a car company?");
            var givenCar = Console.ReadLine();

            CarList.Add(givenCar);
        }

        public void AskForAge()
        {
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());

            Age = age;
        }

        public void ShowInformation()
        {
            Console.WriteLine("Your name is " + FullName + " and your age is " + Age);
            Console.WriteLine(CarList[0]);
            Console.WriteLine(CarList[1]);
            Console.WriteLine(CarList[2]);
        }
    }
}
