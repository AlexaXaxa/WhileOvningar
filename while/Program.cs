using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace @while
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        static void Ovning1o31()                                                          //skriver ut talen mellan 1 och 100
        {
            int tal = 1;
            while (tal <= 100)
            {
                Console.WriteLine(tal);
                tal++;
            }  
        }               
        static void Ovning2()                                                             //Mata in ett rätt lösenord
        {
            /*Skapa ett program som ber dig skriva in ett lösenord
             * Om du matar in fel så ska det meddelas och man får försöka på nytt.
             * Programmet avslutas först då rätt lösenord matats in.
             * Du kan sen utöka programmet med att tala om hur många gånger du har försökt att logga in.
             */

            int length = 10;                                                //längden av lösenorden
            string correctPassword = GenerateRandomPassword(length);        // Rätt lösenord 
            Console.WriteLine(correctPassword);

            string userInput;
            int attempts = 0;                                // Räknare för alla antal försök
            int iter_attempts = 0;                          //räknare för antal försök för varje 5 försök. Varje gång value kommer upp till 5 blir value 0 igen.


            do
            {
                Console.Write("Ange lösenord: ");
                userInput = Console.ReadLine(); 

                attempts++;                                         // Öka räknaren för varje försök
                iter_attempts++;                                    // samma

                if (iter_attempts >= 5)                             
                {
                    Console.WriteLine("Du har provat 5 gånger. Vänta 5 sekunder");
                    
                    Thread inputThread = new Thread(IgnoreInput);               // Thread är olika händelser som kan händra under samma tid som main code.
                    inputThread.Start();                            //här använder jag thread för att i main code jag har timer på 5 sekunder. I det nya thread har jag metoden som ignorerar allting man skriver på tangenbordet

                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000); // väntar 1 sek
                        Console.Write("."); 
                    }

                                        // här slutar det nya threaden och input arbertar igen som vanligt
                    inputThread.Abort();
                    iter_attempts = 0;      //väntetid är över och det betyder att vi ger user en chans till att mata in lösenordet 5 gånger
                    Console.WriteLine("\nTimer är över. Du kan mata in text nu.");

                }
                else if (userInput != correctPassword)
                {
                    Console.WriteLine("Fel lösenord, försök igen.\n");
                }

            } while ((userInput != correctPassword));

            Console.WriteLine($"Du har matat in rätt lösenord! Du har försökt {attempts} antal gånger.");

        }       
        static void Ovning32()                                                            //Skriver ut alla talen från 10 till 1
        {
            int tal = 10;
            while (tal>=1)
            {
                Console.WriteLine(tal);
                tal--;
            }
        } 
        static void Ovning33()                                                            //Oändlig "hi"
        {
            while(true)
            { Console.WriteLine("hi"); }
        }
        static void Ovning34()                                                            //Spelet "Gissa talet" 
        {
            Console.WriteLine(@"
                             Spelet ""Gissa talet""
                                Talet är tänkt
                                Du måste gissa
                        Mata in ett tal mellan 1 och 100");

            bool spelaIgen = true;
            while (spelaIgen)
            {
                Random rnd = new Random();
                int tal = rnd.Next(1, 100);
                //Console.WriteLine(tal);

                int amount = 1;


                int gissning = 0;

                while (!(gissning == tal))
                {
                    string input = Console.ReadLine();
                    while (!int.TryParse(input, out gissning))
                    {
                        Console.WriteLine("Mata in ett heltal mellan 1 och 100!");
                        input = Console.ReadLine();
                    }

                    if (gissning > tal)
                    {
                        Console.WriteLine("För högt!");
                        amount++;
                    }
                    else if (gissning < tal)
                    {
                        Console.WriteLine("För lågt!");
                        amount++;
                    }
                }
                if (amount == 1)
                {
                    Console.WriteLine($"Grattis! Det tog dig {amount} gissning!");
                }
                else
                {
                    Console.WriteLine($"Grattis! Det tog dig {amount} gissningar!");
                }
                


                string answer = "";

                bool question = true;
                while (question)
                {
                    if (answer.ToUpper() == "YES" || answer.ToUpper() == "Y")
                    {
                        spelaIgen = true;
                        question = false;
                    }
                    else if (answer.ToUpper() == "NO" || answer.ToUpper()== "N")
                    {
                        spelaIgen = false;
                        question = false;
                    }
                    else
                    {
                        Console.Write("\nVill du spela igen? (yes/no): ");
                        answer = Console.ReadLine();
                    }
                }
            }
            
        }
        static void Ovning35()                                                            //listar alla tal i Fibbonacci serien och stannar vid en miljon
        {

            int miljon = 1000_000;
            int first = 0;          //first fibonaccital
            int second = 1;         //second fibonaccital
            int next = 1;

            while (next < miljon)
            {
                next = first + second;            //take the next fibonacci
                first = second;
                second = next;
                Console.WriteLine(FormatWithUnderscore(next));
            }
        }
        static void Ovning36()                                                            //Räkna ut år till slutmålet
        {
            /*Skriv ett program där man får mata in 3 saker; saldo, ränta samt slutmål.
             * Programmet ska sedan tala om hur många år det tar innan man når eller passerar slutmålet.
             * Ange räntan i procentenheter.*/

            double saldo;
            double ranta;
            double slutmal;
            
            Console.Write("Mata in slado på konto (kr): ");
            saldo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Mata in ränta (%): ");
            ranta = (Convert.ToInt32(Console.ReadLine()));
            ranta = ranta / 100+1;

            Console.Write("Mata in slutmål (kr): ");
            slutmal = Convert.ToInt32(Console.ReadLine());

            double ar = 0;

            while (saldo < slutmal)
            {
                saldo = saldo*ranta;
                ar++;
            }
            Console.WriteLine(ar);
            
        }
        static void Ovning37()                                                            //Alla skottår från 2024 till 2050
        {

            int yearNow = DateTime.Now.Year; 

            while (yearNow <= 2050)                 
            {
                if (DateTime.IsLeapYear(yearNow))
                {
                    Console.WriteLine(yearNow);
                }
                yearNow++;
                
            }
            Console.WriteLine();
            yearNow = DateTime.Now.Year;

            while (yearNow <= 2050) 
            {
                if (isSkottar(yearNow))             //här använder jag min method isSKottar
                {
                    Console.WriteLine(yearNow);
                }
                yearNow++;
            }    
        } 
        static void Ovning38()                                                            //Ett program som listar alla måndagar från början av året till dagens datum.
        {
            Console.WriteLine("Ett program som listar alla måndagar från början av året till dagens datum.\n");
        

            int borjanAvAret;
            int dagensDatum;

            int currentYear = DateTime.Now.Year;                    //year

            DateTime startDate = new DateTime(currentYear, 1, 1);   //2024, januari, 1 dagen + tid
            DateTime endDate = DateTime.Now;                        //2024, novemer, dag idag + tid
        

            Console.WriteLine($"Måndagar från {startDate.ToShortDateString()} till {endDate.ToShortDateString()}: "); //toshort utan tid

            Console.WriteLine("(Använder for loop)");
            TimeSpan oneWeek = TimeSpan.FromDays(7);
            DateTime date = startDate;
            for (date = startDate; date <= endDate; date = date.Add(oneWeek))      
            {
                // Om dagen är en måndag
                if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    Console.WriteLine(date.ToShortDateString());
                }
            }

            Console.WriteLine("\n(Använder while loop)") ;
            date = startDate;
            while (date <= endDate)
            {
                Console.WriteLine(date.ToShortDateString());
                date = date.AddDays(7);
            }
            


        }
        static bool isSkottar(int year)                                                   //Checkar om year är ett skottår
        {
            if ((year % 100 == 0) && (year % 400 == 0))
            {
                return true;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            else { return false; }

        }
        static string FormatWithUnderscore(int number)                                    //konverterar nummer till sträng
        {
            return number.ToString("N0", CultureInfo.InvariantCulture).Replace(",", "_"); 
            /*
             När man använder bara N:

                Resultatet kan variera beroende på användarens språk- och regionala inställningar.
                Exempel:
                Om en användare har engelska inställningar kan det bli 1,000.00.
                Om användaren har svenska inställningar kan det bli 1 000,00 eller till och med 1.000,00.

             När man använder N med CultureInfo.InvariantCulture:

             Resultatet blir alltid detsamma, oavsett användarens inställningar.
             Det kommer alltid att vara i formatet 1,000.00 (dvs. kommatecken som tusentalsavgränsare och punkt som decimalavgränsare).
                                                                           
             */
            //0 (i N0) betyder att man tar bort decimaler
        }
        static string GenerateRandomPassword(int length)                                  //Skapar en random lösenord med hjälp av StringBuilder
        {
            const string validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=-";          //characters att välja mellan
            StringBuilder password = new StringBuilder();                                                                           //password(StringBuilder) är en samling av symboler som list eller array, men den är gjort för att lagra typen string istället för alla typer (som lisor eller array gör). Man kunde ändra strängen med +, men det skappar hela tiden nya strängar och därför tar mer minne än StringBuilder.
            Random random = new Random();

            for (int i = 1; i <= length; i++)                                                                   //Upprepa koden length gånger för att lägga till length siffror till srängen
            {
                int index = random.Next(validCharacters.Length);                                // Väljer en slumpmässig index ur alla characters. Det kan väljas (index av) A eller m eller ( eller !. 
                password.Append(validCharacters[index]);                                  // Lägga till det slumpmässigt valda tecknet till password(av typen StringBuilder)
            }

            return password.ToString();                              //Här omvadlar vi password till typen string
        }
        static string GenerateRandomPassword2(int length)                                 //Skapar en random lösenord med hjälp av concatenation
        {
            const string validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=-";         
            string password = "";                                                                           
            Random random = new Random();

            for (int i = 1; i <= length; i++)                                                                   
            {
                int index = random.Next(validCharacters.Length);
                password = password + validCharacters[index];
                                                      
            }

            return password;                              
        }
        static void Ovning36WithLogatitm()                                                //Ränta, saldo, slutmål med användning av algebra istället för loop
        {
            double saldo;
            double ranta;
            double slutmal;

            Console.Write("Mata in slado på konto (kr): ");
            saldo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Mata in ränta (%): ");
            ranta = (Convert.ToInt32(Console.ReadLine()));
            ranta = ranta / 100 + 1;

            Console.Write("Mata in slutmål (kr): ");
            slutmal = Convert.ToInt32(Console.ReadLine());

            double ar = ((Math.Log(slutmal / saldo)) / (Math.Log(ranta)));
            Console.WriteLine(Math.Ceiling(ar));
        }
        static void IgnoreInput()                                                         //Blokerar input från tangentbordet
        {
                                                
            while (true)
            {
                                       // Input av en tangent tas emot, men true gör input osynlig
                Console.ReadKey(true); 
            }
        }                   

    }
}
