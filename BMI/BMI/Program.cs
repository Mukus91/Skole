using System;

namespace BMI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(45, 30);
            Console.SetCursorPosition(12, 0);
            Console.WriteLine("Reverse BMI Calculator");
            Console.SetCursorPosition(0, 5);

            Console.Write("Your height in cm: ");
            double HeightPerson1 = Convert.ToDouble(Console.ReadLine()); // User input height

            Console.Write("Your weight in kg: ");
            double WeightPerson1 = Convert.ToDouble(Console.ReadLine()); // User input weight


            var BMI1 = Test(HeightPerson1, WeightPerson1); // Calculates BMI and rounds to 1 decimal.
            Console.WriteLine("Your BMI is: {0}", BMI1);

            Console.SetCursorPosition(0, 10);
            Console.Write("Second height in cm: ");
            double HeightPerson2 = Convert.ToDouble(Console.ReadLine()); // User input height

            Console.Write("Second weight in kg: ");
            double WeightPerson2 = Convert.ToDouble(Console.ReadLine()); // User input weight

            var BMI2 = Test(HeightPerson2, WeightPerson2); // Calculates BMI and rounds to 1 decimal.
            Console.WriteLine("Second BMI: {0}", BMI2);


            double BMIDif = Math.Round((BMI2 - BMI1), 1); // Calculates difference between BMIs
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Difference is: {0}", BMIDif);

            if (BMI1 > BMI2) // If you have to lose weight
            {
                double KgGoal = Math.Round(BMI2 * Math.Pow(HeightPerson1 / 100.0, 2));
                double KgDif = KgGoal - WeightPerson1;
                Console.Write("You need to lose {0}kg to weigh {1}kg and have a BMI of {2}", KgDif, KgGoal, BMI2);
            }

            if (BMI1 < BMI2) // If you have to gain weight
            {
                double KgGoal = Math.Round(BMI2 * Math.Pow(HeightPerson1 / 100.0, 2));
                double KgDif = KgGoal - WeightPerson1;
                Console.Write("You need to gain {0}kg to weigh {1}kg and have a BMI of {2}", KgDif, KgGoal, BMI2);
            }

            else 
            {
                Console.WriteLine("No change needed");
            }


            Console.ReadKey();

        }

        private static double Test(double Height, double Weight)
        {
            return Math.Round(Weight / Math.Pow(Height / 100.0, 2), 1);
        }

        private static void Options()
        {



            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Input secondary measurements to compare[A]");

            Console.SetCursorPosition(11, 28);
            Console.WriteLine("Compare to Ryan Reynolds[B]");

            Console.SetCursorPosition(20, 28);
            Console.WriteLine("Compare to Zac Efron[C]");

            Console.SetCursorPosition(59, 28);
            Console.WriteLine("Back to start[D]");



            ConsoleKeyInfo valg = Console.ReadKey();
            Console.CursorLeft--; Console.Write(" ");

            if (valg.Key == ConsoleKey.A)
            {
                //Opret();
            }

            if (valg.Key == ConsoleKey.B)
            {
                //Search();
            }

            if (valg.Key == ConsoleKey.C)
            {
                //Overview();

            }

            if (valg.Key == ConsoleKey.D)
            {
                //Intro();
            }
        }
    }
}


