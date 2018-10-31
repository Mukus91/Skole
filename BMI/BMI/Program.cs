using System;

namespace BMI
{
    class Program
    {
        static void Main(string[] args)
        {
            start1:
            Console.SetWindowSize(50, 30);
            Console.SetCursorPosition(12, 0);
            Console.WriteLine("Reverse BMI Calculator");
            Console.SetCursorPosition(0, 5);

            Console.Write("Your height in cm: ");
            double HeightPerson1 = Convert.ToDouble(Console.ReadLine()); // User input height

            Console.Write("Your weight in kg: ");
            double WeightPerson1 = Convert.ToDouble(Console.ReadLine()); // User input weight


            var BMI1 = BMI(HeightPerson1, WeightPerson1); // Calculates BMI and rounds to 1 decimal.
            Console.WriteLine("Your BMI is: {0}", BMI1);


            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Who do want to compare to?");

            Console.SetCursorPosition(0, 21);
            Console.Write("Input measurements manually[A]");

            Console.SetCursorPosition(0, 22);
            Console.Write("Compare to Ryan Reynolds[B]");

            Console.SetCursorPosition(0, 23);
            Console.Write("Compare to Arnold Schwarzeneggers[C]");

            Console.SetCursorPosition(0, 24);
            Console.Write("Back to start[D]");



            ConsoleKeyInfo valg = Console.ReadKey();
            Console.CursorLeft--; Console.Write(" ");

            if (valg.Key == ConsoleKey.A)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write("Second height in cm: ");
                double HeightPerson2 = Convert.ToDouble(Console.ReadLine()); // User input height

                Console.Write("Second weight in kg: ");
                double WeightPerson2 = Convert.ToDouble(Console.ReadLine()); // User input weight

                var BMI2 = BMI(HeightPerson2, WeightPerson2); // Calculates BMI and rounds to 1 decimal.
                Console.WriteLine("Second BMI: {0}", BMI2);


                double BMIDif = Math.Round((BMI2 - BMI1), 1); // Calculates difference between BMIs
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Difference is: {0}", BMIDif);

                if (BMI1 > BMI2) // If you have to lose weight
                {
                    double KgDif = BmiSam(HeightPerson1, WeightPerson1, BMI2);
                    Console.WriteLine("To get a BMI of {0} you need to lose {1} kg", BMI2, KgDif);
                }

                if (BMI1 < BMI2) // If you have to gain weight
                {
                    double KgDif = BmiSam(HeightPerson1, WeightPerson1, BMI2);
                    Console.WriteLine("To get a BMI of {0} you need to gain {1} kg", BMI2, KgDif);
                }

                if (BMI1 == BMI2)
                {
                    Console.WriteLine("No change needed");
                }

                Console.ReadKey();
            }

            if (valg.Key == ConsoleKey.B)
            {

                double HeightPerson2 = 188;
                double WeightPerson2 = 84;

                Console.SetCursorPosition(0, 10);
                Console.Write("Ryan Reynolds height in cm: {0}", HeightPerson2);

                Console.SetCursorPosition(0, 11);
                Console.Write("Ryan Reynolds in kg: {0} ", WeightPerson2);

                Console.SetCursorPosition(0, 12);
                var BMI2 = BMI(HeightPerson2, WeightPerson2); // Calculates BMI and rounds to 1 decimal.
                Console.Write("Ryan Reynolds BMI: {0}", BMI2);


                double BMIDif = Math.Round((BMI2 - BMI1), 1); // Calculates difference between BMIs
                Console.SetCursorPosition(0, 14);
                Console.WriteLine("Difference is: {0}", BMIDif);

                if (BMI1 > BMI2) // If you have to lose weight
                {
                    double KgDif = BmiSam(HeightPerson1, WeightPerson1, BMI2);
                    Console.WriteLine("To get a BMI of {0} you need to lose {1} kg", BMI2, KgDif);
                }

                if (BMI1 < BMI2) // If you have to gain weight
                {
                    double KgDif = BmiSam(HeightPerson1, WeightPerson1, BMI2);
                    Console.WriteLine("To get a BMI of {0} you need to gain {1} kg", BMI2, KgDif);
                }

                if (BMI1 == BMI2)
                {
                    Console.WriteLine("No change needed");
                }

                Console.ReadKey();
            }

            if (valg.Key == ConsoleKey.C)
            {
                double HeightPerson2 = 188;
                double WeightPerson2 = 107;

                Console.SetCursorPosition(0, 10);
                Console.Write("Arnold Schwarzeneggers height in cm: {0}", HeightPerson2);

                Console.SetCursorPosition(0, 11);
                Console.Write("Arnold Schwarzeneggers weight in kg: {0} ", WeightPerson2);

                Console.SetCursorPosition(0, 12);
                var BMI2 = BMI(HeightPerson2, WeightPerson2); // Calculates BMI and rounds to 1 decimal.
                Console.Write("Arnold Schwarzeneggers BMI: {0}", BMI2);


                double BMIDif = Math.Round((BMI2 - BMI1), 1); // Calculates difference between BMIs
                Console.SetCursorPosition(0, 14);
                Console.WriteLine("Difference is: {0}", BMIDif);

                if (BMI1 > BMI2) // If you have to lose weight
                {
                    double KgDif = BmiSam(HeightPerson1, WeightPerson1, BMI2);
                    Console.WriteLine("To get a BMI of {0} you need to lose {1} kg", BMI2, KgDif);
                }

                if (BMI1 < BMI2) // If you have to gain weight
                {
                    double KgDif = BmiSam(HeightPerson1, WeightPerson1, BMI2);
                    Console.WriteLine("To get a BMI of {0} you need to gain {1} kg", BMI2, KgDif);
                }

                if (BMI1 == BMI2)
                {
                    Console.WriteLine("No change needed");
                }

                Console.ReadKey();

            }

            if (valg.Key == ConsoleKey.D)
            {
                Console.Clear();
                goto start1;
            }

           

        }

        private static double BmiSam(double Height1, double Weight1, double BMI2)
        {
            double KgGoal = Math.Round(BMI2 * Math.Pow(Height1 / 100.0, 2));
            double KgDif = KgGoal - Weight1;
            return KgDif;
        }

        private static double BMI(double Height, double Weight)
        {
            return Math.Round(Weight / Math.Pow(Height / 100.0, 2), 1);
        }
    }
}


