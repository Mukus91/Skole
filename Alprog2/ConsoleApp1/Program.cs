using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 30); // Sætter konsol-vinduets dimensioner så alt ser godt ud
            Console.SetWindowPosition(0, 0); //


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



            StreamReader R1 = new StreamReader(@"DB.txt");
            string db = R1.ReadToEnd();
            R1.Close();
            string[] inputArr = new string[6];


            for (int i = 0; i < inputArr.Length; i++) // Loop der tager input fra brugeren
            {

                Console.SetCursorPosition(16, i + 4);
                Console.Write(new string(' ', 50)); //Rydder linjen for den eventuelle fejlbesked der stod fra før.
                Console.SetCursorPosition(16, i + 4);
                inputArr[i] = Console.ReadLine();


                if (i == 0) // Telefonnummer
                {

                    if (Regex.IsMatch(inputArr[0], @"^[0-9]+$") && i == 0) //Tjekker om inputtet er tal
                    {

                        if (inputArr[0].Length != 8 && i == 0) //Tjekker om tallet er på 8 cifre. Danske brugere only!
                        {
                            Console.SetCursorPosition(16, i + 4);
                            Console.WriteLine("Dit telefonnummer er for langt, prøv igen");
                            Thread.Sleep(1000);
                            i--;
                        }

                        if (db.Contains(inputArr[0]) && i == 0) // Tjekker om telefonnummeret allerede findes i databasen. 
                        {
                            Console.SetCursorPosition(16, i + 4);
                            Console.WriteLine("Findes allerede i databasen, prøv igen");
                            Thread.Sleep(1000);
                            i--;
                        }
                    }

                    else
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Din indtastning indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }

                }


                if (i == 2) // Adresse
                {
                    if (Regex.IsMatch(inputArr[2], @"^[a-zA-Z0-9' ']+$") == false)
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Din indtastning indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }

                }

                if (i == 3) // Postnr
                {
                    if (Regex.IsMatch(inputArr[3], @"^[a-zA-Z0-9]+$") == false && i == 3)
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Dit postnr indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }

                    if (inputArr[3].Length != 4 && i == 3) //Tjekker om tallet er på 8 cifre. Danske brugere only!
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Dit postnummer er for langt, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }


                }

                if (i == 1 || i == 4) // Navn og bynavn, de følger samme regler, placeret længere nede på listen for at undgå problemer når vi så skulle forbi min if (i == 3) statement
                {

                    if (Regex.IsMatch(inputArr[i], @"^[a-zA-Z]+$") == false)
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Din indtastning indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }

                }


                if (i == 5) //Email
                {
                    if (Regex.IsMatch(inputArr[5], @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false) //Regex der tjekker at emailen overholder en masse grundregler.
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Din email følger ikke");
                        Thread.Sleep(1000);
                        i--;
                    }
                }


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

        private static void Overview()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 10);
            Console.WriteLine("Indhold af databasen");


            string[] txtArr = File.ReadAllLines(@"DB.txt");


            int counter = 0;
            bool ShowMore = true;
            while (ShowMore == true)
            {

                Console.SetCursorPosition(0, 5);

                for (int i = 0; i < txtArr.Length; i++)
                {
                    if (txtArr.Length == counter)
                    {

                        Console.SetCursorPosition(txtArr[i].Length / 2 - 12, i + 6); //Et mesterværk af gypsy-code
                        Console.WriteLine("Der er ikke mere at vise");
                        Thread.Sleep(250);
                        Console.SetCursorPosition(46, 28);
                        Console.Write(new string(' ', 50));
                        return;

                    }

                    if (i > 14)
                    {
                        break;
                    }

                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Console.WriteLine(txtArr[i].Length + txtArr[counter]);
                        counter += 1;
                    }

                }

                Console.SetCursorPosition(Console.WindowWidth / 2 - 19, (Console.WindowHeight / 2) + 8);
                Console.WriteLine("Der er {0} linjer som ikke bliver vist", txtArr.Length - counter);



                Console.SetCursorPosition(46, 28);
                Console.Write("Se mere [p]");
                Console.SetCursorPosition(68, 28);
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
            return;

        }

        private static void Clear()
        {
            for (int i = 4; i < 26; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r"); // Overskriver linjer fra 1-26 med tomme linjer, i stedet for console.clear
            }
        }

        private static void Menu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 27, 1);
            Console.Write("Carlos Montana Information Systems - Gæste-registering");

            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Opret[a]");

            Console.SetCursorPosition(14, 28);
            Console.WriteLine("Søg[b]");

            Console.SetCursorPosition(26, 28);
            Console.WriteLine("Se Database[c]");

            Console.SetCursorPosition(63, 28);
            Console.WriteLine("Valg[ ]");

            Console.SetCursorPosition(68, 28);

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

            else
            {
                Menu();
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

