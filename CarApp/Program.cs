namespace CarApp
{
    internal class Program
    {
        static string carBrand = "";
        static string carModel = "";
        static int carYear = 0;
        static string fuelType = "";
        static double kmPerLiter = 0;
        static int kilometerStand = 0;
        static bool isEngineOn = false;
        static double dieselPrice = 11.00;
        static double petrolPrice = 13.49;
        static double distance = 0;
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
                Console.WriteLine("7. Exit");
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
                        isEngineOn = true;
                        Console.WriteLine("\nEngine is now ON.");
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
                    case 7:
                        running = false;
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }
            /* Console.Write("Enter car brand: ");
             string? carBrand = Console.ReadLine();
             Console.Write("Enter car model: ");
             string? modelType = Console.ReadLine();
             Console.Write("Enter car year: ");
             int year = Convert.ToInt32(Console.ReadLine());
             Console.Write("Enter gear type: ");
             char gearType = Console.ReadLine()[0];

             Console.WriteLine();


             Console.Write("Enter fuel type: ");
             string? fuelType = Console.ReadLine();
             Console.Write("Enter km/l: ");
             double kmPerLiter = Convert.ToDouble(Console.ReadLine());
             Console.Write("Total milage in km: ");
             double originalMilage = Convert.ToDouble(Console.ReadLine());
             Console.Write("Trip distance in kilometers: ");
             double drivingDistance = Convert.ToDouble(Console.ReadLine());

             double dieselPrice = 11.00;
             double petrolPrice = 13.49;

             double fuelNeeded = drivingDistance / kmPerLiter;


             double tripCostDiesel = fuelNeeded * dieselPrice;
             double tripCostPetrol = fuelNeeded * petrolPrice;

             int newMilage = Convert.ToInt32(originalMilage + drivingDistance);


             Console.WriteLine($"Fuel type: {fuelType}");
             Console.WriteLine($"Km/l: {kmPerLiter}");
             Console.WriteLine($"Original milage: {originalMilage}");
             Console.WriteLine($"New milage after trip: {newMilage}");
             Console.WriteLine($"Trip cost with petrol: {tripCostPetrol}");
             Console.WriteLine($"Trip cost with diesel: {tripCostDiesel}");

             string outputSentence = String.Format("Fuel expenses for {0} km er {1} kr with petrol and {2} kr for diesel", drivingDistance, tripCostPetrol, tripCostDiesel);


             Console.WriteLine(outputSentence);*/



            /* string tableBrand = carBrand.PadRight(15);
             string tableModel = modelType.PadRight(15);


             string headerBrand = ("Car Brand");
             string headerModel = ("Car Model");


             string tableHeaderBrand = headerBrand.PadRight(15);
             string tableHeaderModel = headerModel.PadRight(15);


             Console.WriteLine($"{tableHeaderBrand} | {tableHeaderModel} | Original Milage");
             Console.WriteLine("\n ------------------------------------- \n");
             Console.WriteLine(tableBrand + "|" + tableModel + "|" + originalMilage + " km");*/




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
            Console.Write("Kilometerstand: ");
            kilometerStand = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine($"Original Milage: {kilometerStand} km");
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

            kilometerStand = kilometerStand + (int)distance;

            Console.WriteLine($"You drove {distance} km.");
            Console.WriteLine($"Total milage is now {kilometerStand}");

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

    }
    

}
