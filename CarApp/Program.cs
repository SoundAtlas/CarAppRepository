namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /* Console.Write("Enter car brand: ");
             string? carBrand = Console.ReadLine();
             Console.Write("Enter car model: ");
             string? modelType = Console.ReadLine();
             Console.Write("Enter car year: ");
             int year = Convert.ToInt32(Console.ReadLine());
             Console.Write("Enter gear type: ");
             char gearType = Console.ReadLine()[0];

             Console.WriteLine();*/


            Console.Write("Enter fuel type: ");
            string? fuelType = Console.ReadLine();
            Console.Write("Enter km/l: ");
            double kmPerLiter = Convert.ToDouble(Console.ReadLine());
            Console.Write("Kilometers driven: ");
            double milage = Convert.ToDouble(Console.ReadLine());

            double drivingDistance = 43.5;

            double dieselPrice = 12.29;
            double petrolPrice = 13.49;

            double fuelNeeded = drivingDistance / kmPerLiter;


            double tripCostDiesel = fuelNeeded * dieselPrice;
            double tripCostPetrol = fuelNeeded * petrolPrice;

            Console.WriteLine($"Fuel type: {fuelType}");
            Console.WriteLine($"Km/l: {kmPerLiter}");
            Console.WriteLine($"Kilometers driven: {milage}");
            Console.WriteLine($"Trip cost using petrol {tripCostPetrol}");
            Console.WriteLine($"Trip cost using petrol {tripCostDiesel}");
            
          
            


        }
    }
}
