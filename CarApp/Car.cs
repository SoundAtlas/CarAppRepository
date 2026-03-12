using System.Text.RegularExpressions;

namespace CarApp
{


    public class Car
    {

        //attribues
        private string _carBrand;
        private string _carModel;
        private int _carYear;
        private FuelType _fuelType;
        private string _gearType;
        private double _odometer;
        private bool _isEngineOn;
        private double _kmPerLiter;

        private const double _dieselPrice = 11.00;
        private const double _petrolPrice = 13.49;


        //Properties
        public string CarBrand
        {
            get { return _carBrand; }
            set { _carBrand = value; }
        }

        public string CarModel { get => _carModel; set => _carModel = value; }

        public int CarYear { get => _carYear; set => _carYear = value; }

        public FuelType FuelType { get; private set; }  // property der giver adgang til bilens brændstoftype

        public string GearType { get => _gearType; set => _gearType = value; }

        public double Odometer { get => _odometer; set => _odometer = value; }

        public bool IsEngineOn { get => _isEngineOn; set => _isEngineOn = value; }

        public double KmPerLiter { get => _kmPerLiter; set => _kmPerLiter = value; }


        //constructors

        public Car(string carBrand, string carModel, int carYear, FuelType fuelType, string gearType, double odometer, bool isEngineOn, double kmPrLiter)
        {
            CarBrand = carBrand;
            CarModel = carModel;
            CarYear = carYear;
            FuelType = fuelType;
            GearType = gearType;
            Odometer = odometer;
            IsEngineOn = isEngineOn;
            KmPerLiter = kmPrLiter;
        }

        //Trips

        private List<Trip> _trips = new List<Trip>();
        

        public List<Trip> GetTrips()
        {
            return _trips; 
        }

        //methods

        public void ReadCarDetails()
        {
            Console.Write("Brand: "); 
            CarBrand = Console.ReadLine();
            Console.Write("Model: ");
            CarModel = Console.ReadLine();
            CarYear = ReadIntWithinRange("Year: ", 1930, 2026);

            //string fuelinput = Console.ReadLine().ToLower(); // Brugers iput valg bliver stored i fuelinput variablen
            //FuelType selctedFuelType = (FuelType)Enum.Parse(typeof(FuelType), fuelinput); // Her konventere vi string input til Enum
            while (true)
            {

                Console.Write("Fuel Type: ");
                if (Enum.TryParse(Console.ReadLine(), out FuelType selectedFuel))
                {
                    FuelType = selectedFuel;
                    break;
                }

                Console.WriteLine("Invalid fuel type.");
            }


            KmPerLiter = ReadDoubleNonNegative("Km/l: ");
            Odometer = ReadDoubleNonNegative("Odometer: ");
        }


        // Metode til at udskrive bilens detaljer
        public void PrintCarDetails()
        {
            Console.WriteLine("\n=== CAR INFO ===");
            Console.WriteLine($"Brand: {CarBrand}");
            Console.WriteLine($"Model: {CarModel}");
            Console.WriteLine($"Year: {CarYear}");
            Console.WriteLine($"Fuel Type: {FuelType}");
            Console.WriteLine($"Km/l: {KmPerLiter}");
            Console.WriteLine($"Odometer: {Odometer} km");
        }


        // Metode til at simulere en køretur
        public void Drive(Trip newTrip)
        {
            if (IsEngineOn == false)
            {
                Console.WriteLine("You need to start the engine first!");
                return;
            }

            if (newTrip.Distance <= 0)
            {
                Console.WriteLine("Distance must be greater than 0!");
                return;
            }

            Odometer += newTrip.Distance;
            _trips.Add(newTrip);

            Console.WriteLine($"You drove {newTrip.Distance} km.");
            Console.WriteLine($"Total milage is now {Odometer}");

        }

        public double CalculateTripPrice(double distance)
        {
            if (KmPerLiter == 0)
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
            string ft = FuelType.ToString().ToLower();

            double chosenLiterPrice;

            if (ft == "diesel")
                chosenLiterPrice = _dieselPrice;
            else if (ft == "petrol" || ft == "benzin")
                chosenLiterPrice = _petrolPrice;

            else
            {
                Console.WriteLine("Fejl: Fuel type must be 'petrol' or 'diesel' (or 'benzin').");
                return -1;
            }

            // 4) Beregn liter og pris
            double litersUsed = distance / KmPerLiter;
            //double totalPrice = litersUsed * chosenLiterPrice;

            return litersUsed * chosenLiterPrice;
        }

        public void PrintAllTeamCars()
        {
            Console.WriteLine($"Brand & Model: {CarBrand} {CarModel}\nYEAR: {CarYear}\nFUEL TYPE: {FuelType}");
        }

        public void ToggleEngine()
        {
            if (IsEngineOn)
            {
                IsEngineOn = false;
                Console.WriteLine("\nEngine is now off.");
            }
            else
            {
                IsEngineOn = true;
                Console.WriteLine("\nEngine is now ON.");
            }
        }


        //helper method to read user choice and validate it as an integer
        public int ReadIntWithinRange(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice >= min &&
                    choice <= max)
                    return choice;

                Console.WriteLine($"Invalid choice. Please enter a whole number between {min} and {max}");
            }
        }

        //helper method to read user choice and validate it as a non-negative double
        public double ReadDoubleNonNegative(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double choice) &&
                    choice >= 0)
                    return choice;

                Console.WriteLine("Invalid choice. Please enter a positive number");
            }
        }
        //Filters _trips by date
        public List<Trip> GetTripsByDate(DateTime TripDate)
        {
            foreach (Trip trip in _trips)
            {
                if (trip.TripDate.Date == TripDate)
                {
                    _trips.Add(trip);
                }
            }
            return _trips;
        }
    }
}