namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            Console.Write("Enter car brand: ");
            string? carBrand = Console.ReadLine();
            Console.Write("Enter car model: ");
            string? modelType = Console.ReadLine();
            Console.Write("Enter car year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter gear type: ");
            char gearType = Console.ReadLine()[0];

            Console.WriteLine();

            //Console.WriteLine("Car Brand: " + carBrand);
            //Console.WriteLine("Car Model: " + modelType);
            //Console.WriteLine("Car Year: " + year);
            //Console.WriteLine("Gear Type: " + gearType);

            Console.WriteLine("Your car is a " + carBrand + modelType + " from " + year + " with gear type: " +  gearType);
            


        }
    }
}
