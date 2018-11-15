using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)

        {

            FileInfo inf = new FileInfo(@"test.txt");
            CreateDB(inf);

            Console.SetWindowSize(70, 30);
            Console.SetWindowPosition(0, 0);

            Header();

            string[] inputArr = new string[6];

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Telefonnummer :");

            Console.WriteLine("Navn          :");

            Console.WriteLine("Adresse       :");

            Console.WriteLine("Postnummer    :");

            Console.WriteLine("By            :");

            Console.WriteLine("Email         :");

            Console.SetCursorPosition(16, 4);

            inputArr[0] = Console.ReadLine();


            using (StreamReader sr = new StreamReader(@"test.txt"))
            {
                string contents = sr.ReadToEnd();
                if (contents.Contains(inputArr[0]))
                {
                    Console.SetCursorPosition(15, 4);
                    Console.WriteLine("Findes allerde i databasen");
                }
            }

            for (int i = 1; i < inputArr.Length; i++)
            {
                Console.SetCursorPosition(16, i + 4);

                inputArr[i] = Console.ReadLine();
            }

            SaveInputToDB(inf, inputArr);

            Console.ReadLine(); // SLET DET HER LORT EVENTUELT
        }

        private static void SaveInputToDB(FileInfo inf, string[] inputArr)
        {
            using (StreamWriter sw2 = inf.AppendText()) //Skriver mit array til fil
            {
                sw2.Write("\n");
                sw2.Write(inputArr[0] + ",");
                sw2.Write(inputArr[1] + ",");
                sw2.Write(inputArr[2] + ",");
                sw2.Write(inputArr[3] + ",");
                sw2.Write(inputArr[4] + ",");
                sw2.Write(inputArr[5]);

            }
        }

        private static void CreateDB(FileInfo inf)
        {
            bool boolDatabase = false;

            string textDatabase = "Database over gæster: \n";
            using (StreamWriter sw = inf.AppendText()) //Skriver mit array til fil
            {
                sw.Write("");
            }
            using (StreamReader sr = new StreamReader(@"test.txt"))
            {
                string contents = sr.ReadToEnd();
                if (contents.Contains(textDatabase))
                {
                    boolDatabase = true;
                }
            }

            if (boolDatabase == false)
            {
                {
                    using (StreamWriter sw = inf.AppendText()) //Skriver mit array til fil
                    {
                        sw.Write(textDatabase);
                    }
                }
            }
        }

        private static void Header()
        {
            Console.SetCursorPosition(8, 0);
            Console.WriteLine("Carlos Montana Information Systems - Gæste-registering");
        }

        private static void Overview()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Indholdet af databasen er: ");
            Console.SetCursorPosition(0, 4);

            string line;
            int counter = 0;
            StreamReader file = new System.IO.StreamReader(@"test.txt");
            while ((line = file.ReadLine()) != null && counter <= 15)
            {
                Console.WriteLine(line);
                counter++;
            }

            if (counter >= 15)
            {

                Console.WriteLine("Der er over 15 linjer i filen");
            }


            Console.ReadLine();

        }
        private static void Menu()
        {

            Header();
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Opret[A]");

            Console.SetCursorPosition(11, 28);
            Console.WriteLine("Søg[B]");

            Console.SetCursorPosition(20, 28);
            Console.WriteLine("Se Database[C]");

            Console.SetCursorPosition(59, 28);
            Console.WriteLine("Sluk pc[P]");

            Console.SetCursorPosition(51, 0);

            //Console.SetCursorPosition(30, 13);
            //Console.WriteLine("Valg: ");
            //Console.SetCursorPosition(35, 13);

            ConsoleKeyInfo valg = Console.ReadKey();

            if (valg.Key == ConsoleKey.A)
            {
               // Add();
            }

            if (valg.Key == ConsoleKey.B)
            {
                Search();
            }

            if (valg.Key == ConsoleKey.C)
            {
                Overview();
            }

           

            Console.ReadLine();
        }

        private static void Search()
        {

            Header();

            Console.SetCursorPosition(30, 12);
            Console.Write("Søg efter:");
            string input = Console.ReadLine();

            //string line = "";
            using (StreamReader sr = new StreamReader(@"test.txt"))
            {


                while ((input = sr.ReadLine()) != null)
                {

                    Console.WriteLine(input);
                }

                Menu();

            }
        }

    }
}

