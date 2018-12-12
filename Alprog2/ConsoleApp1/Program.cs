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

        }
        private static void Add()
        {
            Clear();

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
                Console.WriteLine("Findes allerde i databasen, prøv igen");
                Console.SetCursorPosition(59, 28);
                Thread.Sleep(2500);
                Clear();
                Add();
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

            StreamWriter W1 = new StreamWriter((@"DB.txt"), true); // Gemmer vores string i txt

            {
                W1.WriteLine(input);
                W1.Close();
            }

            W1.Close();
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
            Console.SetCursorPosition(21, 3);
            Console.WriteLine("Indhold af databasen:");
            Console.SetCursorPosition(0, 5);

            string[] txtArr = File.ReadAllLines(@"DB.txt");
            Console.SetCursorPosition(21, 3);
            int counter = 0;
            bool ShowMore = true;

            while (ShowMore == true)
            {
                
                Console.SetCursorPosition(0, 5);

                for (int i = 0; i < txtArr.Length; i++)
                {
                    if (i > 14)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine(txtArr[counter]);
                        counter += 1;
                    }


                    if (txtArr.Length == counter)
                    {
                        Console.WriteLine("Der er ikke mere at vise");
                        Console.ReadLine();
                        return;
                    }
                }

                Console.SetCursorPosition(12, 21);
                Console.WriteLine("Der er {0} linjer som ikke bliver vist",txtArr.Length - counter);

                Console.SetCursorPosition(40, 28);
                Console.Write("Se mere [p]");
                Console.SetCursorPosition(64, 28);
                ConsoleKeyInfo valg = Console.ReadKey();
                if (valg.Key != ConsoleKey.P)
                {

                    ShowMore = false;

                }
                else
                {
                    Clear();
                }
                
            }
            
        }

        private static void Clear()
        {
            for (int i = 1; i < 26; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r"); // Overskriver linjer fra 1-26 med tomme linjer, i stedet for console.clear
            }
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

            if (valg.Key == ConsoleKey.P)
            {

            }

        }

        private static void Search()
        {
            Clear();

            Console.SetCursorPosition(24, 3);
            Console.Write("Søg efter:");

            string Input = Console.ReadLine().ToLower();
            Clear();
            Console.SetCursorPosition(24, 3);
            Console.Write("Resultat for {0}", Input);
            Console.SetCursorPosition(0, 6);

            StreamReader R1 = new StreamReader(@"DB.txt");
            string line;


            while ((line = R1.ReadLine()) != null)
            {
                if (line.Contains(Input))
                {
                    Console.WriteLine(line);
                }
            }

            R1.Close();
            Menu();


        }

    }
}

