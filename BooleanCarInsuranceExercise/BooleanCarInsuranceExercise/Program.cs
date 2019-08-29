using System;


namespace BooleanCarInsuranceExercise
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("What is your age?");
            string ageStr = Console.ReadLine();
            int age = Convert.ToInt32(ageStr);
            bool over15 = age >= 15;

            Console.WriteLine("Have you ever had a DUI? Please answer true or false.");
            string duiStr = Console.ReadLine();
            bool dui = Convert.ToBoolean(duiStr);

            Console.WriteLine("How many speeding tickets do you have?");
            string ticketsStr = Console.ReadLine();
            int tickets = Convert.ToInt32(ticketsStr);
            bool ticketLimit = tickets < 3;

            bool qualified = over15 && ticketLimit && (dui == false);
            Console.WriteLine(qualified);

            Console.ReadLine();
        }
    }
}
