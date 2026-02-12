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
            Console.Write("Enter driving distance in km: ");
            int drivingDistance = Convert.ToInt32(Console.ReadLine());
            

            Console.WriteLine();

            //Console.WriteLine("Car Brand: " + carBrand);
            //Console.WriteLine("Car Model: " + modelType);
            //Console.WriteLine("Car Year: " + year);
            //Console.WriteLine("Gear Type: " + gearType);

            Console.WriteLine($"Fuel type: {fuelType}");
            Console.WriteLine($"Km/l: {kmPerLiter}");
            Console.WriteLine($"Driving distance: {drivingDistance}");
            
          
            


        }
    }
}
