using System;
using System.IO;
using System.Threading;

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

            Menu();

            Console.ReadLine(); // SLET DET HER LORT EVENTUELT
        }

        private static void Add()
        {
            FileInfo inf = new FileInfo(@"test.txt");

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
                    Console.WriteLine("Findes allerde i databasen, tilbage til start!");
                    Thread.Sleep(2500);
                    Console.Clear();
                    Menu();
                }
            }

            for (int i = 1; i < inputArr.Length; i++)
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

        private static void CreateDB(FileInfo inf)
        {
            bool boolDatabase = false;

            string textDatabase = "Database over gæster: \n";
            using (StreamWriter sw = inf.AppendText())
            {
                sw.Write("");
                sw.Close();
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
                    using (StreamWriter sw = inf.AppendText()) // Hvis "Database over gæster" ikke findes i dokumentet tilføjes det
                    {
                        sw.Write(textDatabase);
                        sw.Close();
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

            Console.Clear();
            Header();
            string line;
            int counter = 0;
            StreamReader file = new System.IO.StreamReader(@"test.txt");
            Console.SetCursorPosition(23, 2);
            while ((line = file.ReadLine()) != null && counter <= 15)
            {
                Console.WriteLine(line);
                counter++;
            }

            if (counter >= 15)
            {

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

