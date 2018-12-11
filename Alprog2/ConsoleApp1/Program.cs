using System;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)

        {

            Console.SetWindowSize(70, 30); // Sætter konsol-vinduets dimensioner så alt ser godt ud
            Console.SetWindowPosition(0, 0); //
            Header();


            if (File.Exists(@"DB.txt") == false) // Hvis filen ikke eksisterer oprettes den, ellers fortsætter vi bare
            {
                StreamWriter sw = File.CreateText(@"DB.txt"); // Opretter fil database
                sw.Close(); // Lukker filen igen så vi kan tilføje ting til den senere
            }


            
            Menu();


            //Console.ReadLine(); // SLET DET HER LORT EVENTUELT
        }




        private static void Add()
        {
            Console.Clear();
            Header();

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Telefonnummer :");


            Console.WriteLine("Navn          :");

            Console.WriteLine("Adresse       :");

            Console.WriteLine("Postnummer    :");

            Console.WriteLine("By            :");

            Console.WriteLine("Email         :");

            Console.SetCursorPosition(16, 4);

            string[] inputArr = new string[6];

            inputArr[0] = Console.ReadLine();

            
            StreamReader R1 = new StreamReader(@"DB.txt");
            string contents = R1.ReadToEnd();

            if (contents.Contains(inputArr[0])) // Hvis telefonnummeret findes i databasen ryger vi tilbage til start
            {
                Console.SetCursorPosition(15, 4);
                Console.WriteLine("Findes allerde i databasen, tilbage til start!");
                Console.SetCursorPosition(59, 28);
                Thread.Sleep(2500);
                Console.Clear();
                Menu();
            }

            R1.Close();


            for (int i = 1; i < inputArr.Length; i++) // Loop der tager input fra brugeren, starter på 1, da vores [0] er telefonnummer
            {

                Console.SetCursorPosition(16, i + 4);

                inputArr[i] = Console.ReadLine();
            }


            string input = "";

            for (int i = 0; i < inputArr.Length; i++) // Loop der laver vores array om til en komma-sepereret string
            {
                input = input + "," + inputArr[i].ToLower();
            }
            input = input.TrimStart(' ', ',');


            StreamWriter W1 = new StreamWriter((@"DB.txt"), true);

            {
                W1.WriteLine(input);
                W1.Close();
            }

            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Gemmer oplysninger...");
            Thread.Sleep(2500);



            Console.Clear();
            Menu();
        }





        private static void Header()
        {
            Console.SetCursorPosition(8, 0);
            Console.Write("Carlos Montana Information Systems - Gæste-registering");
        }

        private static void Overview()
        {

            Console.Clear();

            Header();

            string line;
            int counter = 0;
            StreamReader R1 = new StreamReader(@"DB.txt");


            Console.SetCursorPosition(0, 5);

            while ((line = R1.ReadLine()) != null && counter <= 15)
            {
                Console.WriteLine(line);
                counter++;

            }

            if (counter >= 15)
            {

                Console.WriteLine("Der er over 15 linjer i filen");

                //Vis flere linjer
            }

            else
            {
                Menu();
            }

            R1.Close();



            /*Console.SetCursorPosition(15, 25);
            Console.Write("Tryk enter for at vende tilbage til menu");
            Console.ReadLine();
            Console.Clear();*/



        }
        private static void Menu()
        {
            
            Header();
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Opret[a]");

            Console.SetCursorPosition(11, 28);
            Console.WriteLine("Søg[b]");

            Console.SetCursorPosition(20, 28);
            Console.WriteLine("Se Database[c]");

            Console.SetCursorPosition(59, 28);
            Console.WriteLine("Valg[ ]");

            Console.SetCursorPosition(64, 28);

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

        }

        private static void Search()
        {

            Header();

            Console.SetCursorPosition(30, 12);
            Console.Write("Søg efter:");
            string Input = Console.ReadLine();


            StreamReader R1 = new StreamReader(@"DB.txt");

            while ((Input = R1.ReadLine()) != null)
            {

                Console.WriteLine(Input);

            }

            R1.Close();

            Menu();


        }

    }
}

