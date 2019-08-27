using System;

namespace IncomeComparisonExercise
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Anonymous Income Comparison Program\n");

            Console.WriteLine("Person 1:\nHourly rate?");
            string person1RateStr = Console.ReadLine();
            double person1Rate = Convert.ToDouble(person1RateStr);
            Console.WriteLine("Hours worked per week?");
            string person1HoursStr = Console.ReadLine();
            double person1Hours = Convert.ToDouble(person1HoursStr);
            double person1Salary = person1Hours * person1Rate;

            Console.WriteLine("\nPerson 2:\nHourly rate?");
            string person2RateStr = Console.ReadLine();
            double person2Rate = Convert.ToDouble(person2RateStr);
            Console.WriteLine("Hours worked per week?");
            string person2HoursStr = Console.ReadLine();
            double person2Hours = Convert.ToDouble(person2HoursStr);
            double person2Salary = person2Hours * person2Rate;

            Console.WriteLine("\nWeekly salary of Person 1:\n" + person1Salary);
            Console.WriteLine("\nWeekly salary of Person 2:\n" + person2Salary);

            bool makesMoreMoney = person1Salary > person2Salary;
            Console.WriteLine("\nDoes Person 1 make more money than Person 2?\n" + makesMoreMoney);

            Console.ReadLine();
        }
    }
}
