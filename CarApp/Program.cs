namespace CarApp
{
    internal class Program
    {
        static string carBrand = "";
        static string carModel = "";
        static int carYear = 0;
        static string fuelType = "";
        static double kmPerLiter = 0;
        static int odometer = 0;
        static bool isEngineOn = false;
        static double dieselPrice = 11.00;
        static double petrolPrice = 13.49;




        static string andreasBrand = "Mazda";
        static string andreasModel = "3";
        static int andreasYear = 2019;
        static string andreasFt = "Diesel";

        static string fioziBrand = "Toyota";
        static string fioziModel = "BZ4x";
        static int fioziYear = 2026;
        static string fioziFt = "Electric";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                //Main menu
                Console.Clear();
                Console.WriteLine("=== CAR APP ===");
                Console.WriteLine("1. Read Car Details");
                Console.WriteLine("2. Turn on engine");
                Console.WriteLine("3. Simulate Trip");
                Console.WriteLine("4. Calculate Trip Price");
                Console.WriteLine("5. Print Car Details");
                Console.WriteLine("6. IsPalindrome?");
                Console.WriteLine("7. Print All Team Cars");
                Console.WriteLine("8. Exit");
                Console.WriteLine("\nSelect an option:");
                Console.Write("> ");

                // Læser brugerinput og konverterer det til et heltal
                string? userInput = Console.ReadLine();
                int choice = Convert.ToInt32(userInput);

                // Tager brugerens valg og udfører den tilsvarende handling
                switch (choice)
                {
                    case 1:
                        ReadCarDetails();
                        ReturnToMenu();
                        break;
                    case 2:
                        TurnEngineOn();
                        ReturnToMenu();
                        break;
                    case 3:
                        Console.WriteLine("How many km do you want to drive? ");
                        double distance = Convert.ToDouble(Console.ReadLine());
                        Drive(distance);
                        ReturnToMenu();
                        break;
                    case 4:
                        Console.WriteLine("Trip distance in km?: ");
                        double tripDistance = Convert.ToDouble(Console.ReadLine());

                        double price = CalculateTripPrice(tripDistance);

                        Console.WriteLine($"Trip price: {price:F2} DKK");
                        ReturnToMenu();
                        break;
                    case 5:
                        PrintCarDetails();
                        ReturnToMenu();
                        break;
                    case 6:
                        bool result = IsPalindrome(odometer);
                        if (result)
                            Console.WriteLine($"Your cars milage ({odometer}) is a palindrome");
                        else
                            Console.WriteLine($"Your cars milage ({odometer}) is NOT a palindrome");
                        ReturnToMenu();
                        break;
                    case 7:
                        PrintAllTeamCars();
                        ReturnToMenu();
                        break;
                    case 8:
                        running = false;
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }


        }

        // Metode til at læse bilens detaljer fra brugeren
        static void ReadCarDetails()
        {
            Console.Write("Brand: ");
            carBrand = Console.ReadLine();
            Console.Write("Model: ");
            carModel = Console.ReadLine();
            Console.Write("Year: ");
            carYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Fuel Type: ");
            fuelType = Console.ReadLine();
            Console.Write("Km/l: ");
            kmPerLiter = Convert.ToDouble(Console.ReadLine());
            Console.Write("odometer: ");
            odometer = Convert.ToInt32(Console.ReadLine());
        }


        // Metode til at udskrive bilens detaljer
        static void PrintCarDetails()
        {
            Console.WriteLine("\n=== CAR INFO ===");
            Console.WriteLine($"Brand: {carBrand}");
            Console.WriteLine($"Model: {carModel}");
            Console.WriteLine($"Year: {carYear}");
            Console.WriteLine($"Fuel Type: {fuelType}");
            Console.WriteLine($"Km/l: {kmPerLiter}");
            Console.WriteLine($"Original Milage: {odometer} km");
        }

        // Metode til at vente på brugerinput
        static void ReturnToMenu()
        {
            Console.Write("\nPress any key to return to menu...");
            Console.ReadKey();
        }


        // Metode til at simulere en køretur
        static void Drive(double distance)
        {
            if (isEngineOn == false)
            {
                Console.WriteLine("You need to start the engine first!");
                return;
            }

            if (distance <= 0)
            {
                Console.WriteLine("Distance must be greater than 0!");
                return;
            }

            odometer = odometer + (int)distance;

            Console.WriteLine($"You drove {distance} km.");
            Console.WriteLine($"Total milage is now {odometer}");

        }



        static double CalculateTripPrice(double distance)
        {

            if (kmPerLiter == 0)
            {
                Console.WriteLine("Error: type car details first (menu 1).");
                return -1;
            }

            // 2) Tjek distance
            if (distance <= 0)
            {
                Console.WriteLine("Error: distance must be greater than 0.");
                return -1;
            }

            // 3) Find literpris ud fra fuelType (ignorerer literPrice input)
            string ft = fuelType.ToLower();

            double chosenLiterPrice;

            if (ft == "diesel")
                chosenLiterPrice = dieselPrice;
            else if (ft == "petrol" || ft == "benzin")
                chosenLiterPrice = petrolPrice;

            else
            {
                Console.WriteLine("Fejl: Fuel type must be 'petrol' or 'diesel' (or 'benzin').");
                return -1;
            }

            // 4) Beregn liter og pris
            double litersUsed = distance / kmPerLiter;
            //double totalPrice = litersUsed * chosenLiterPrice;

            return litersUsed * chosenLiterPrice;
        }

        static void PrintAllTeamCars()
        {
            Console.WriteLine("\n=== TEAM CARS ===");

            for (int i = 1; i <= 2; i++)
            {
                if (i == 1)
                    Console.WriteLine($"\nANDREAS\nBrand & Model: {andreasBrand} {andreasModel}\nYEAR: {andreasYear}\nFUEL TYPE: {andreasFt}");

                else if (i == 2)
                    Console.WriteLine($"\nFIOZI\nBrand & Model: {fioziBrand} {fioziModel}\nYEAR: {fioziYear}\nFUEL TYPE: {fioziFt}");
            }
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

        static void TurnEngineOn()
        {
            isEngineOn = true;
            Console.WriteLine("\nEngine is now ON.");
        }

    }


}
