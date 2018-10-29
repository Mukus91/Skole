using System;

namespace BMI
{
    class Program
    {
        static void Main(string[] args)
        {
            double kg = 75;
            double m = 178;
            Console.SetWindowSize(60 , 30);
            Console.SetCursorPosition(23, 0);
            Console.WriteLine("BMI Udregner");


            Console.SetCursorPosition(0, 5);
            Console.Write("Din højde i cm: ");
            
            m = Convert.ToDouble(Console.ReadLine());
            

            Console.Write("Din vægt i kg: ");

            kg = Convert.ToDouble(Console.ReadLine());

            double BMI = kg / Math.Pow(m / 100.0, 2);
            double BMIr = Math.Round(BMI, 1);
            Console.WriteLine("Din BMI: {0}", BMIr);

            Console.WriteLine();

            Console.ReadKey();



        }
    }

}
