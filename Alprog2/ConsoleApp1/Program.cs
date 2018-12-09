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

            string file = @"UserDB.txt";
            if (File.Exists(file) == false) // Hvis filen ikke eksisterer oprettes den, ellers fortsætter vi bare
            {
                StreamWriter sw = File.CreateText(@"UserDB.txt"); // Opretter fil database
                sw.Close(); // Lukker filen igen så vi kan tilføje ting til den senere
            }


            Header();
            Menu();


            Console.ReadLine(); // SLET DET HER LORT EVENTUELT
        }

        private static void Add()
        {
            FileInfo inf = new FileInfo(@"UserDB.txt");

            string[] inputArr = new string[6];

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Telefonnummer :");


            Console.WriteLine("Navn          :");

            Console.WriteLine("Adresse       :");

            Console.WriteLine("Postnummer    :");

            Console.WriteLine("By            :");

            Console.WriteLine("Email         :");

            Console.SetCursorPosition(16, 4);

            inputArr[0] = Console.ReadLine(); // Telefon nummeret gemmes så vi kan tjekke databasen for det, inden vi går videre.




            using (StreamReader sr = new StreamReader(@"UserDB.txt"))
            {
                string contents = sr.ReadToEnd();
                if (contents.Contains(inputArr[0]))
                {
                    Console.SetCursorPosition(15, 4);
                    Console.WriteLine("Findes allerde i databasen, tilbage til start!");
                    Console.SetCursorPosition(64, 28);
                    Thread.Sleep(2500);
                    Console.Clear();
                    Menu();
                }
            }

            for (int i = 1; i < inputArr.Length; i++) // Loop der tager imod readlines fra 1-6 til vores inputarray
            {
                Console.SetCursorPosition(16, i + 4);

                inputArr[i] = Console.ReadLine();

            }
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Gemmer oplysninger...");
            Thread.Sleep(2500);


            SaveInputToDB(inf, inputArr);
            Console.Clear();
            Menu();
        }

        private static void SaveInputToDB(FileInfo inf, string[] inputArr)
        {
            using (StreamWriter sw2 = inf.AppendText()) //Skriver mit array til fil, komma sepereret + linjeskift efter komplet indtastning
            {
                sw2.Write("\n");
                sw2.Write(inputArr[0] + ",");
                sw2.Write(inputArr[1] + ",");
                sw2.Write(inputArr[2] + ",");
                sw2.Write(inputArr[3] + ",");
                sw2.Write(inputArr[4] + ",");
                sw2.Write(inputArr[5]);
                sw2.Close();
            }
        }



        private static void Header()
        {
            Console.SetCursorPosition(8, 0);
            Console.WriteLine("Carlos Montana Information Systems - Gæste-registering");
        }

        private static void Overview()
        {

            Console.Clear();
            Header();
            string line;
            ConsoleKeyInfo valg = Console.ReadKey();
            int counter = 0;
            StreamReader file = new StreamReader(@"UserDB.txt");
            Console.SetCursorPosition(23, 3);
            while ((line = file.ReadLine()) != null && counter <= 15)
            {
                Console.WriteLine(line);
                counter++;
            }


            if (counter >= 15)
            {
                Console.WriteLine("Tryk på A for at se mere, og tryk B for at komme tilbage til start");
                //Console.ReadLine();
                

                if (valg.Key == ConsoleKey.A)
                {

                    while ((line = file.ReadLine()) != null)
                    {
                     Console.WriteLine(line);
                    }
                    
                }

                if (valg.Key == ConsoleKey.B)
                {
                    Menu();
                }

                Console.WriteLine("Der er over 15 linjer i filen");


            }

            file.Close();
            Console.SetCursorPosition(15, 30);
            Console.WriteLine("Tryk enter for at vende tilbage til menu");
            Console.ReadLine();
            Console.Clear();

            Menu();

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
            Console.SetCursorPosition(30, 12);
            Console.Write("Søg efter:");

            string input = Console.ReadLine();

            StreamReader file = new StreamReader(@"UserDB.txt");

            int counter = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(input))
                {
                    break;
                }

                counter++;
            }

            Console.Clear();
            Header();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Linje der indeholder din indtastning: \n{0}", line);

            file.Close();
            Menu();

        }
    }

}


