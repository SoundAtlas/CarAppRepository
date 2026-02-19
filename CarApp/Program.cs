using System.Security.Cryptography;

namespace CarApp
{
    internal class Program
    {
        static string make, model;
        static int year, odometer;
        static double fuelEffeciency;
        static bool isEngineOn;


        static void Main(string[] args)
        {
                      
            bool running = true;
                        
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== CAR APP ===");
                Console.WriteLine("1. Indlæs biloplysninger");
                Console.WriteLine("2. Kør bilen");
                Console.WriteLine("3. Beregn turpris");
                Console.WriteLine("4. Er km-stand et palindrom?");
                Console.WriteLine("5. Udskriv biloplsyninger");
                Console.WriteLine("6. Udskriv alle teambiler");
                Console.Write("7. Afslut\n> ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //læs bil oplysninger
                        ReadCarDetails();
                        Console.WriteLine("Biloplysninger gemt!");
                        Pause();
                        break;
                    case 2:
                        //Køre
                        if (string.IsNullOrWhiteSpace(make))
                        {
                            Console.WriteLine("Du skal indlæse biloplysninger først (valg 1).");
                            break;
                        }

                        if (!isEngineOn)
                        {
                            Console.WriteLine("Motoren er slukket. Vil du tænde den?\n1. Ja\n2. Nej");
                            int engineAnswer = int.Parse(Console.ReadLine());

                            if (engineAnswer == 1)
                            {
                                isEngineOn = true;
                                Console.WriteLine("Motoren er nu tændt!");
                            }
                            else
                            {
                                Console.WriteLine("Moteren blev ikke startet");
                                break;
                            }
                        }

                        Console.WriteLine("Hvor mange km skal du køre?: ");
                        double turLængde = double.Parse(Console.ReadLine());
                        
                        Drive(turLængde);
                        Pause();
                        break;
                    case 3:
                        //turpris
                        if (string.IsNullOrWhiteSpace(make))
                        {
                            Console.WriteLine("Du skal indlæse biloplysninger først (valg 1).");
                            break;
                        }

                        Console.WriteLine("Hvor mange km skal du køre?: ");
                        double distance = double.Parse(Console.ReadLine());
                        Console.WriteLine("Hvad koster en lister (kr)?: ");
                        double literPrice = double.Parse(Console.ReadLine());
                       
                        double price = CalculateTripPrice(distance, literPrice);
                        Console.WriteLine($"Turen koster: {price:F2} kr.");
                        Pause();
                        break;
                    case 4:
                        //palindrom
                        if (string.IsNullOrWhiteSpace(make))
                        {
                            Console.WriteLine("Du skal indlæse biloplysninger først (valg 1).");
                            break;
                        }

                        bool palindrome = IsPalindrome(odometer);

                        if (palindrome)
                            Console.WriteLine($"Ja {odometer} er et palindrom.");
                        else
                            Console.WriteLine($"Nej {odometer} er IKKE et palindrom.");

                        break;
                    case 5:
                        //udskriv
                        if (string.IsNullOrWhiteSpace(make))
                        {
                            Console.WriteLine("Du skal indlæse biloplysninger først (valg 1).");
                            break;
                        }
                        PrintCarDetails();
                        Pause();
                        break;
                    case 6:
                        //udskriv team
                        PrintAllTeamCars();
                        Pause();
                        break;
                    case 7:
                        //afslut
                        running = false;
                        Console.WriteLine("God dag!");
                        break;
                }

            }
                                
        }
        static void ReadCarDetails()
        {
            Console.WriteLine("Make of your car: ");
            make = Console.ReadLine();
            Console.WriteLine("Model of your car: ");
            model = Console.ReadLine();
            Console.WriteLine("Year of your car: ");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("How many km does your odometer display?: ");
            odometer = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your cars fuel effeciency in km/l?: ");
            fuelEffeciency = double.Parse(Console.ReadLine());
            isEngineOn = false;

        }

        static void Drive(double distance)
        {

            if (!isEngineOn)
            {
                Console.WriteLine("Motoren er slukket!");
                return;
            }
            if (distance <= 0)
            {
                Console.WriteLine("Distancen skal være større end 0");
                return;
            }
           
                odometer += (int)distance;
                Console.WriteLine($"Du kørte {distance} km");
                Console.WriteLine($"Ny odometer: {odometer}");
            
        }

        static double CalculateTripPrice(double distance, double literPrice)
        {
            if (fuelEffeciency == 0)
            {
                Console.WriteLine($"Fejl: fuelEffeciency er 0!");
                return 0;
            }
                      
            double liter = distance / fuelEffeciency;
            return liter * literPrice;
             
        }

        static bool IsPalindrome(int km)
        {
            string text = km.ToString();

            int left = 0;
            int right = text.Length - 1;

            while (left < right)
            {
                if (text[left] != text[right])
                    return false;

                left++;
                right--;

            }

            return true;
        }

        static void PrintCarDetails()
        {
            Console.WriteLine("--- CAR DETAILS ---");
            Console.WriteLine($"MAKE & MODEL: {make} {model}");
            Console.WriteLine($"YEAR: {year}");
            Console.WriteLine($"ODOMETER: {odometer} KM");
            Console.WriteLine($"FUEL EFFICIENCY: {fuelEffeciency} KM/L");
            Console.WriteLine($"IS ENGINE ON: {isEngineOn}");
        }


        static void PrintAllTeamCars()
        {
            Console.WriteLine("--- TEAM BILER ---");
            int teamSize = 6;

            for (int i = 0; i < teamSize; i++)
            {
                Console.WriteLine($"\n--- Bil nr. {i + 1} ---");
                ReadCarDetails();
                PrintCarDetails();
            }
        }


        static void Pause()
        {
            Console.WriteLine("Tryk på en tast for at returnere...");
            Console.ReadKey();
        }
    }


}
