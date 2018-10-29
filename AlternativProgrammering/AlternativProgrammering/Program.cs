using System;
using System.Diagnostics;
using System.IO;

namespace AlternativProgrammering
{
    class Program
    {


        static void Main(string[] args)
        {
            FileInfo inf = new FileInfo(@"test.txt");

            Console.SetWindowSize(70, 30);

            Console.SetWindowPosition(0, 0);


            Valgmuligheder();


        }

        private static void Opret()
        {



            FileInfo inf = new FileInfo(@"test.txt");


            // Console.SetCursorPosition(0, 28);
            string[] inputArr = new string[6];

            Console.SetCursorPosition(17, 15);
            Console.Write("Indtast dit telefonnummer:");

            inputArr[0] = Console.ReadLine();

            Console.Clear();

            Valgmuligheder();

            Console.SetCursorPosition(17, 15);
            Console.Write("Indtast dit navn:");
            inputArr[1] = Console.ReadLine();

            Console.Clear();

            Valgmuligheder();

            Console.SetCursorPosition(17, 15);
            Console.Write("Indtast din adresse:");
            inputArr[2] = Console.ReadLine();

            Console.Clear();

            Valgmuligheder();

            Console.SetCursorPosition(17, 15);
            Console.Write("Indtast dit postnr:");
            inputArr[3] = Console.ReadLine();

            Console.Clear();

            Valgmuligheder();

            Console.SetCursorPosition(17, 15);
            Console.Write("Indtast bynavn:");
            inputArr[4] = Console.ReadLine();

            Console.Clear();

            Valgmuligheder();

            Console.SetCursorPosition(17, 15);
            Console.Write("Indtast din email:");
            inputArr[5] = Console.ReadLine();


            //File.WriteAllText(@"test.txt", inputArr[0]);

            //using (var sw = new StreamWriter(@"test.txt"))
            //{
            //    for (var i = 2; i <= 75; i++)
            //    {
            //        sw.WriteLine("");
            //    }
            //}

            using (StreamWriter sw = inf.AppendText()) //Skriver til fil
            {
                sw.WriteLine(inputArr[1]);
                sw.WriteLine(inputArr[2]);
                sw.WriteLine(inputArr[3]);
                sw.WriteLine(inputArr[4]);
                sw.WriteLine(inputArr[5]);
            }





        }

        private static void Search()
        {

            
            Console.SetCursorPosition(17, 15);
            Console.Write("Søg efter:");
            string input = Console.ReadLine();

            
            string line = "";
            using (StreamReader sr = new StreamReader(@"test.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                Valgmuligheder();
            }
        }

        private static void Valgmuligheder()
        {

            Console.SetCursorPosition(17, 0);
            Console.WriteLine("Velkommen til CMIS gæsteregister!");

            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Opret[A]");

            Console.SetCursorPosition(11, 28);
            Console.WriteLine("Søg[B]");

            Console.SetCursorPosition(20, 28);
            Console.WriteLine("Overblik[C]");

            Console.SetCursorPosition(59, 28);
            Console.WriteLine("Sluk pc[P]");



            ConsoleKeyInfo valg = Console.ReadKey();
            Console.CursorLeft--; Console.Write(" ");

            if (valg.Key == ConsoleKey.A)
            {
                Opret();
            }

            if (valg.Key == ConsoleKey.B)
            {
                Search();
            }

            if (valg.Key == ConsoleKey.C)
            {
                Overview();

            }

            if (valg.Key == ConsoleKey.P)
            {
                Process.Start("shutdown", "/s /t 30");
            }
        }


        private static void Overview()
        {
            string[] ReadFile = File.ReadAllLines(@"test.txt");
            Console.SetCursorPosition(17, 10);
            Console.Write("Indholdet af databasen er: ");


            foreach (string line in ReadFile)
            {
                // Use a tab to indent each line of the file.

                Console.Write("\t" + line);
            }


            Console.ReadLine();
        }

       
    }
    
}
