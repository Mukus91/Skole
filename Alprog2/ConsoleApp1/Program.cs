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
            string db = R1.ReadToEnd(); //Læser alle karakterer fra vores DB.txt fil, så vi kan tjekke om telefonnummeret findes i DB.
            R1.Close();
            string[] inputArr = new string[6];


            for (int i = 0; i < inputArr.Length; i++) // Loop der tager input fra brugeren
            {
                Console.SetCursorPosition(16, i + 4); //Dynamisk linjeskift alt efter hvor langt vi er i loopet, benytter ca det samme flere gange længere nede. 
                Console.Write(new string(' ', 50)); //Rydder linjen for den eventuelle fejlbesked som loopet nedenunder kan producere, inden vi tager input igen.
                Console.SetCursorPosition(16, i + 4);
                inputArr[i] = Console.ReadLine();


                if (i == 0) // Telefonnummer
                {

                    if (Regex.IsMatch(inputArr[0], @"^[0-9]+$") && i == 0) //Regex der kun tillader tal.
                    {

                        if (inputArr[0].Length != 8 && i == 0) //Tjekker om tallet er på 8 cifre. Danske brugere only!
                        {
                            Console.SetCursorPosition(16, i + 4);
                            Console.WriteLine("Dit telefonnummer er for langt, prøv igen");
                            Thread.Sleep(1000);
                            i--; //Fratrækker et "point" ved forkerte indtastninger så vi ikke skal ind i andre loops, men ryger tilbage til hvor vi kom fra
                        }

                        if (db.Contains(inputArr[0]) && i == 0) // Tjekker om telefonnummeret allerede findes i databasen. 
                        {
                            Console.SetCursorPosition(16, i + 4);
                            Console.WriteLine("Findes allerede i databasen, prøv igen");
                            Thread.Sleep(1000);
                            i--;
                        }
                    }

                    else //Hvis input ikke er et tal.
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Din indtastning indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }
                }

                if (i == 2) // Adresse
                {
                    if (Regex.IsMatch(inputArr[2], @"^[a-zA-Z0-9' ']+$") == false) //Regex der kun tillader bogstaver og tal
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Din indtastning indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }
                }

                if (i == 3) // Postnr
                {
                    if (Regex.IsMatch(inputArr[3], @"^[a-zA-Z0-9]+$") == false && i == 3) //Regex der kun tillader tal
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Dit postnr indeholdte forbudte tegn, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }

                    if (inputArr[3].Length != 4 && i == 3) //Tjekker om postnr er på 4 cifre.
                    {
                        Console.SetCursorPosition(16, i + 4);
                        Console.WriteLine("Dit postnr er for langt, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }
                }

                if (i == 1 || i == 4) // Navn og bynavn, de følger samme regler, placeret længere nede på listen for at undgå problemer når vi så skulle forbi min if (i == 3) statement
                {

                    if (Regex.IsMatch(inputArr[i], @"^[a-zA-Z]+$") == false) //Regex der kun tillader bogstaver.
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
                        Console.WriteLine("Din email er indtastet forkert, prøv igen");
                        Thread.Sleep(1000);
                        i--;
                    }
                }
            }

            string input = "";

            for (int i = 0; i < inputArr.Length; i++) // Loop der laver vores array om til en komma-sepereret string
            {
                input = input + "," + inputArr[i].ToLower(); //Gør det hele lower case. Ser bedre ud i databasen, ingen logisk grund til at gøre det ellers.
            }

            input = input.TrimStart(' ', ','); //Fjerner eventuelle mellemrum og kommaer fra starten og slutningen af vores string. 


            StreamWriter W1 = new StreamWriter((@"DB.txt"), true); // Gemmer vores string i txt

            {
                W1.WriteLine(input);
                W1.Close();
            }

            W1.Close(); // Lukker vores streamwriter session så vi kan tilgå filen igen senere
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Gemmer oplysninger...");
            Thread.Sleep(2500);

            Console.Clear();
            Menu();
        }

        private static void Overview()
        {
            Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.WindowHeight / 10);
            Console.WriteLine("Indhold af databasen");

            string[] txtArr = File.ReadAllLines(@"DB.txt"); //Opretter et array med vores linjer i.
            int counter = 0;
            bool ShowMore = true;

            while (ShowMore == true)
            {

                Console.SetCursorPosition(0, 5);

                for (int i = 0; i < txtArr.Length; i++) //For loop der kører igennem alle linjerne i vores array.
                {
                    if (txtArr.Length == counter)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 24) / 2, i + 6); //Centrerer teksten på skærmen.
                        Console.WriteLine("Der er ikke mere at vise");
                        Thread.Sleep(1000);
                        break;
                    }

                    if (i > 14)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 38) / 2, (Console.WindowHeight / 2) + 8);
                        Console.WriteLine("Der er {0} linjer som ikke bliver vist", txtArr.Length - counter); //Skriver hvor mange linjer der er tilbage i DB, efter visning af de første 15 linjer.
                        break;
                    }

                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Console.WriteLine(txtArr[i].Length + txtArr[counter]);
                        counter += 1;
                    }
                }


                Console.SetCursorPosition(46, 28);
                Console.Write("Se mere [p]");
                Console.SetCursorPosition(68, 28);
                ConsoleKeyInfo valg = Console.ReadKey();

                if (valg.Key != ConsoleKey.P) //Hvis brugeren ikke trykker P for at se mere, vil showmore blive sat til false, og vores while loop holder derfor op med at køre.
                {

                    ShowMore = false;

                }
                else
                {

                    Clear(); //Hvis brugeren trykker P sletter vi linjerne fra skærmen, og viser de resterende
                }

            }
            Menu();

        }

        private static void Clear()
        {
            for (int i = 4; i < 26; i++) // Overskriver linjer fra 4-26 med tomme linjer, i stedet for console.clear, så vores menu og overskrift forbliver på skærmen.
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                Console.SetCursorPosition(68, 28);
                Console.Write(new string(' ', 1));
            }
        }

        private static void Menu()
        {
            Console.SetCursorPosition((Console.WindowWidth - 54) / 2, 1);
            Console.Write("Carlos Montana Information Systems - Gæste-registering");

            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Opret[a]");

            Console.SetCursorPosition(14, 28);
            Console.WriteLine("Søg[b]");                               //Viser vores menu i bunden af skærmen

            Console.SetCursorPosition(26, 28);
            Console.WriteLine("Se Database[c]");

            Console.SetCursorPosition(63, 28);
            Console.WriteLine("Valg[ ]");

            Console.SetCursorPosition(68, 28);

            ConsoleKeyInfo valg = Console.ReadKey();

            if (valg.Key == ConsoleKey.A)
            {
                Clear();
                Add();
            }

            if (valg.Key == ConsoleKey.B)
            {
                Clear();
                Search();
            }

            if (valg.Key == ConsoleKey.C)                //Tager imod input fra brugeren og sender en videre til den metode de vælger.
            {
                Clear();
                Overview();
            }

            else
            {
                Clear();              //Hvis man trykker noget andet ryger man bare ud til menuen igen. 
                Menu();
            }

        }

        private static void Search()
        {
            Clear();

            Console.SetCursorPosition(24, 3);
            Console.Write("Søg efter:");

            string Input = Console.ReadLine().ToLower(); //Gør alt personen søger efter til lower case for at undgå fejl pga det. 
            Clear();
            Console.SetCursorPosition(24, 3);
            Console.Write("Resultat for {0}", Input); //Skriver brugerens søgning på skærmen. 
            Console.SetCursorPosition(0, 6);

            StreamReader R1 = new StreamReader(@"DB.txt");
            string line;


            while ((line = R1.ReadLine()) != null)
            {
                if (line.Contains(Input)) //Hvis linjen indeholder det personen søgte efter bliver det printet i vinduet. 
                {
                    Console.WriteLine(line);
                }
            }

            R1.Close(); // Lukker filen når vi er færdige med at søge, så vi kan åbne den andetsteds. 
            Menu();


        }

    }
}

