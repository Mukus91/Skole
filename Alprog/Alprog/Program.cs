using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Alprog
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo inf = new FileInfo(@"test.txt");

            Console.SetWindowSize(70, 30);
            Console.SetWindowPosition(0, 0);

            Console.SetCursorPosition(17, 0);


            string Intro1 = "Carlos Montana Information Systems";
            foreach (char c in Intro1)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

            Console.SetCursorPosition(17, 15);

            string Intro2 = "Tryk Enter for at Fortsætte";
            foreach (char c in Intro2)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.ReadKey();
            Console.Clear();
            Header();

            Menu();
        }

        private static void Overview()
        {


            

            string[] ReadFile = File.ReadAllLines(@"test.txt");
            
            Console.SetCursorPosition(17, 10);
            Console.Write("Indholdet af databasen er: ");
            Console.SetCursorPosition(17, 11);



            string join = String.Join(" ",ReadFile);

            Console.WriteLine(join);

            Console.ReadLine();

            foreach (string word in ReadFile)
            {
                

                Console.Write(word);
            }

        }

        private static void Search()
        {
            Console.Clear();
            Header();

            Console.SetCursorPosition(30, 12);
            Console.Write("Søg efter:");
            string input = Console.ReadLine();

            string line = "";
            using (StreamReader sr = new StreamReader(@"test.txt"))
            {
               

                while ((line = sr.ReadLine()) != null)
                {
                    
                    Console.WriteLine(line);
                }

            }
        }

        private static void Menu()
        {
            Header();
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Opret[A]");

            Console.SetCursorPosition(11, 28);
            Console.WriteLine("Søg[B]");

            Console.SetCursorPosition(20, 28);
            Console.WriteLine("Overblik[C]");

            Console.SetCursorPosition(59, 28);
            Console.WriteLine("Sluk pc[P]");

            Console.SetCursorPosition(51, 0);

            //Console.SetCursorPosition(30, 13);
            //Console.WriteLine("Valg: ");
            //Console.SetCursorPosition(35, 13);

            ConsoleKeyInfo valg = Console.ReadKey();

            if (valg.Key == ConsoleKey.A)
            {
                Add();
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

            Console.ReadLine();
        }

        private static void Header()
        {

            Console.SetCursorPosition(17, 0);
            Console.WriteLine("Carlos Montana Information Systems");
        }

        private static void Add()
        {
            FileInfo inf = new FileInfo(@"test.txt");


            // Console.SetCursorPosition(0, 28);
            string[] inputArr = new string[6];

            Console.SetCursorPosition(0, 5);
            Console.Write("Indtast dit telefonnummer:");

            inputArr[0] = Console.ReadLine();


            Console.SetCursorPosition(0, 6);
            Console.Write("Indtast dit Navn:");
            inputArr[1] = Console.ReadLine();



            Console.SetCursorPosition(0, 7);
            Console.Write("Indtast din Adresse:");
            inputArr[2] = Console.ReadLine();


            Console.SetCursorPosition(0, 8);
            Console.Write("Indtast dit Postnr:");
            inputArr[3] = Console.ReadLine();


            Console.SetCursorPosition(0, 9);
            Console.Write("Indtast Bynavn:");
            inputArr[4] = Console.ReadLine();


            Console.SetCursorPosition(0, 10);
            Console.Write("Indtast din Email:");
            inputArr[5] = Console.ReadLine();


            
            using (StreamWriter sw = inf.AppendText()) //Skriver mit array til fil
            {
                sw.WriteLine(inputArr[0] + ",");
                sw.WriteLine(inputArr[1] + ",");
                sw.WriteLine(inputArr[2] + ",");
                sw.WriteLine(inputArr[3] + ",");
                sw.WriteLine(inputArr[4] + ",");
                sw.WriteLine(inputArr[5] + ",\n");
            }





        }

    }
}
