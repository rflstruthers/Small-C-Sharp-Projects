using System;
using System.Collections.Generic;


namespace DoWhileExercise
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, welcome to a math test!\nPlease answer the following questions correctly to pass.\nWhat is 23 X 43?");
            int answer1 = Convert.ToInt32(Console.ReadLine());
            bool correctAnswer1 = answer1 == 989;

            do
            {
                switch (answer1)
                {
                    case 989:
                        Console.WriteLine("Correct! Please answer the next question to pass!");
                        correctAnswer1 = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect, please answer correctly to continue.\nWhat is 23 X 43?");
                        answer1 = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            }
            while (!correctAnswer1);

            Console.WriteLine("What is the answer to the previous question minus 13?");
            int answer2 = Convert.ToInt32(Console.ReadLine());
            bool correctAswer2 = answer2 == 976;

            while (!correctAswer2)
            {
                switch (answer2)
                {
                    case 976:
                        Console.WriteLine("Correct! You passed the test!");
                        correctAswer2 = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect, please answer correctly to continue.\nWhat is the answer to the previous question minus 13?");
                        answer2 = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            }

            



            Console.ReadLine();
        }
    }
}
