namespace CLO24_SecondTurnInNiklasH
{
    using Factories;
    using Interfaces;

    internal class Program
    {
        static void Main(string[] args)
        {
            CreateAndDisplayVehicles();

            Console.WriteLine("Press play on tape (press any key)");
            Console.ReadKey();
            Environment.Exit(0); // Exit the program

        }

        internal static void CreateAndDisplayVehicles()
        {
            // Creating vehicle factories, instances for car, motorcycle, potential future installments, and then it print the vehicle details
            CarFactory carFactory = new CarFactory();
            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            // Create and display a car
            IVehicle car = CreateVehicle(carFactory, "Toyota", "Corolla", 2020, 15000, 4);
            DisplayVehicleDetails(car);

            // Create and display a motorcycle
            IVehicle motorcycle = CreateVehicle(motorcycleFactory, "Harley Davidson", "Sportster", 2019, 5000, "V-Twin");
            DisplayVehicleDetails(motorcycle);
        }

        // Generic method to create a vehicle
        private static IVehicle CreateVehicle(CarFactory factory, string brand, string model, int year, double mileage, int doors)
        {
            return factory.CreateCar(brand, model, year, mileage, doors);
        }

        private static IVehicle CreateVehicle(MotorcycleFactory factory, string brand, string model, int year, double mileage, string engineType)
        {
            return factory.CreateMotorcycle(brand, model, year, mileage, engineType);
        }

        // Method to display vehicle details
        private static void DisplayVehicleDetails(IVehicle vehicle)
        {
            Console.WriteLine(vehicle.ToString()); // Display basic vehicle details
            vehicle.StartEngine();
            Console.WriteLine("Vehicle engine status: " + (vehicle.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine(vehicle.Drive());
            vehicle.StopEngine();
            Console.WriteLine("Vehicle engine status: " + (vehicle.IsEngineOn() ? "On" : "Off"));

            // Check for car-specific properties
            if (vehicle is ICar car)
            {
                Console.WriteLine("Car doors: " + car.Doors);
                car.Doors = 5; // Modify the number of doors
                Console.WriteLine($"Car doors (modified): {car.Doors}\n");
            }

            // Check for motorcycle-specific properties
            if (vehicle is IMotorcycle motorcycle)
            {
                Console.WriteLine("Motorcycle engine type: " + motorcycle.EngineType);
                motorcycle.EngineType = "Inline-4"; // Modify the engine type
                Console.WriteLine($"Motorcycle engine type (modified): {motorcycle.EngineType}\n");
            }
        }
    }
}
