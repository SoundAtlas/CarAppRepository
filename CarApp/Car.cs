public class Car
{

    //attribues
    private string _carBrand;
    private string _carModel;
    private int _carYear;
    private string _fuelType;
    private string _gearType;
    private double _odometer;
    private bool _isEngineOn;
    private double _kmPerLiter;

    private const double dieselPrice = 11.00;
    private const double petrolPrice = 13.49;


    //properties

    public string CarBrand
    {
        get { return _carBrand; }
        set { _carBrand = value; }
    }

    public string CarModel { get => _carModel; set => _carModel = value; }

    public int CarYear { get => _carYear; set => _carYear = value; }

    public string FuelType { get => _fuelType; set => _fuelType = value; }

    public string GearType { get => _gearType; set => _gearType = value; }

    public double Odometer { get => _odometer; set => _odometer = value; }

    public bool IsEngineOn { get => _isEngineOn; set => _isEngineOn = value; }

    public double KmPerLiter { get => _kmPerLiter; set => _kmPerLiter = value; }


    //constructors

    public Car(string carBrand, string carModel, int carYear, string fuelType, string gearType, double odometer, bool isEngineOn, double kmPrLiter)
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



    //methods

    public void ReadCarDetails()
    {
        Console.Write("Brand: ");
        CarBrand = Console.ReadLine();
        Console.Write("Model: ");
        CarModel = Console.ReadLine();
        Console.Write("Year: ");
        CarYear = Convert.ToInt32(Console.ReadLine());
        Console.Write("Fuel Type: ");
        FuelType = Console.ReadLine();
        Console.Write("Km/l: ");
        KmPerLiter = Convert.ToDouble(Console.ReadLine());
        Console.Write("odometer: ");
        Odometer = Convert.ToInt32(Console.ReadLine());
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
        Console.WriteLine($"Original Milage: {Odometer} km");
    }


    // Metode til at simulere en køretur
    public void Drive(double distance)
    {
        if (IsEngineOn == false)
        {
            Console.WriteLine("You need to start the engine first!");
            return;
        }

        if (distance <= 0)
        {
            Console.WriteLine("Distance must be greater than 0!");
            return;
        }

        Odometer = Odometer + (int)distance;

        Console.WriteLine($"You drove {distance} km.");
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
        string ft = FuelType.ToLower();

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
        double litersUsed = distance / KmPerLiter;
        //double totalPrice = litersUsed * chosenLiterPrice;

        return litersUsed * chosenLiterPrice;
    }

    public void PrintAllTeamCars()
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


}