using System;

namespace Loops
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Pick a number, any number.");
            int number = Convert.ToInt32(Console.ReadLine());
            bool isGuessed = number == 12;

            do
            {
                switch (number)
                {
                    case 62:
                        Console.WriteLine("Wrong number, try again!");
                        Console.WriteLine("Pick a number, any number.");
                        number = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 55:
                        Console.WriteLine("Wrong number, try again!");
                        Console.WriteLine("Pick a number, any number.");
                        number = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 12:
                        Console.WriteLine("Correct number!");
                        isGuessed = true;
                        break;
                    default:
                        Console.WriteLine("Wrong!");
                        Console.WriteLine("Pick a number, any number.");
                        number = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            }
            while (!isGuessed);
            

            Console.ReadLine();
        }
    }
}
