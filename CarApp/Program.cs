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
            Console.Write("Total milage in km: ");
            double originalMilage = Convert.ToDouble(Console.ReadLine());
            Console.Write("Trip distance in kilometers: ");
            double drivingDistance = Convert.ToDouble(Console.ReadLine());
                    
            double dieselPrice = 12.29;
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
            

            Console.WriteLine(outputSentence);
           
                  
        }
    }
}
