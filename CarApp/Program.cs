namespace CarApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Car car1 = new Car("", "", 0, "", "", 0, false, 0);

            Car carAndreas = new Car("Mazda", "3", 2019, "Diesel", "A", 64000, false, 19);
            Car carFiozi = new Car("Toyota", "BZ4x", 2026, "EL", "A", 200000, false, 15);


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
                Console.Write("\nSelect an option:\n> ");

                // Læser brugerinput og konverterer det til et heltal
                string? userInput = Console.ReadLine();
                int choice = Convert.ToInt32(userInput);

                // Tager brugerens valg og udfører den tilsvarende handling
                switch (choice)
                {
                    case 1:
                        car1.ReadCarDetails();
                        ReturnToMenu();
                        break;
                    case 2:
                        car1.TurnEngineOn();
                        ReturnToMenu();
                        break;
                    case 3:
                        Console.WriteLine("How many km do you want to drive? ");
                        double distance = Convert.ToDouble(Console.ReadLine());
                        car1.Drive(distance);
                        ReturnToMenu();
                        break;
                    case 4:
                        Console.WriteLine("Trip distance in km?: ");
                        double tripDistance = Convert.ToDouble(Console.ReadLine());

                        double price = car1.CalculateTripPrice(tripDistance);

                        Console.WriteLine($"Trip price: {price:F2} DKK");
                        ReturnToMenu();
                        break;
                    case 5:
                        car1.PrintCarDetails();
                        ReturnToMenu();
                        break;
                    case 6:
                        bool result = IsPalindrome(car1.Odometer);
                        if (result)
                            Console.WriteLine($"Your cars milage ({car1.Odometer}) is a palindrome");
                        else
                            Console.WriteLine($"Your cars milage ({car1.Odometer}) is NOT a palindrome");
                        ReturnToMenu();
                        break;
                    case 7:
                        Console.WriteLine("\n=== TEAM CARS ===");
                        Console.WriteLine("\nANDREAS");
                        carAndreas.PrintAllTeamCars();
                        Console.WriteLine("\nFIOZI");
                        carFiozi.PrintAllTeamCars();
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


        static bool IsPalindrome(double km)
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

        // Metode til at vente på brugerinput
        static void ReturnToMenu()
        {
            Console.Write("\nPress any key to return to menu...");
            Console.ReadKey();
        }



    }


}
