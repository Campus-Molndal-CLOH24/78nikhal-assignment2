namespace CLO24_SecondTurnInNiklasH
{
    using Factories;
    using Interfaces;

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a List of vehicles, and then we display their details
            List<IVehicle> vehicles = CreateVehicleList();

            // Apply randomized modifications to vehicles
            ApplyVehicleModifications(vehicles);

            // Shuffle the vehicle list and then display it
            ShuffleList(vehicles); 
            DisplayAllVehicles(vehicles);

            FactoryShutdown();
        }

        // Method to create a list of vehicles
        private static List<IVehicle> CreateVehicleList()
        {
            // Creating vehicle instances of the vehicle classes to supply our factory classes
            CarFactory carFactory = new CarFactory();
            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            // Creating a list to hold all the vehicles
            List<IVehicle> vehicles = new List<IVehicle>();

            // Adding vehicles to the list
            vehicles.Add(CreateVehicle(carFactory, "Toyota", "Corolla", 2020, 15000, 4));
            vehicles.Add(CreateVehicle(motorcycleFactory, "Harley Davidson", "Sportster", 2019, 5000, "V-Twin"));
            vehicles.Add(CreateVehicle(carFactory, "Ford", "Focus", 2018, 30000, 5));
            vehicles.Add(CreateVehicle(motorcycleFactory, "Yamaha", "MT-07", 2020, 8000, "Parallel Twin"));
            vehicles.Add(CreateVehicle(carFactory, "Honda", "Civic", 2021, 10000, 4));
            vehicles.Add(CreateVehicle(motorcycleFactory, "Ducati", "Monster", 2022, 2000, "V-Twin"));

            return vehicles;
        }

        // Method to apply randomized modifications to each vehicle in the list
        private static void ApplyVehicleModifications(List<IVehicle> vehicles)
        {
            // Define lists of possible modifications
            List<int> carDoorModifications = new List<int> { 2, 3, 4, 5 }; // Possible door counts for cars
            List<string> motorcycleEngineModifications = new List<string> { "V-Twin", "Inline-4", "Parallel Twin", "Single Cylinder" }; // Possible engine types for motorcycles

            // Shuffle modification lists
            ShuffleList(carDoorModifications);
            ShuffleList(motorcycleEngineModifications);

            // Apply modifications to vehicles
            foreach (var vehicle in vehicles)
            {
                if (vehicle is ICar car)
                {
                    // Apply a random door modification from the shuffled list
                    car.Doors = carDoorModifications[new Random().Next(carDoorModifications.Count)];
                }
                else if (vehicle is IMotorcycle motorcycle)
                {
                    // Apply a random engine modification from the shuffled list
                    motorcycle.EngineType = motorcycleEngineModifications[new Random().Next(motorcycleEngineModifications.Count)];
                }
            }
        }

        // Method to shuffle the list of vehicles, Fisher-Yates shuffle algorithm
        private static void ShuffleList<T>(List<T> list)
        {
            Random shuffleList = new Random();      // Initializes a new random number
            int n = list.Count;                     // Get the total number of items in the list
            while (n > 1)                           // Continue until all items are shuffled
            {
                n--;                                // Decrease n (the range of unshuffled items) by 1
                int k = shuffleList.Next(n + 1);    // Generate a random index between 0 and n
                T value = list[k];                  // Store the value at the random index
                list[k] = list[n];                  // Swap the value at the random index with the last unshuffled item
                list[n] = value;                    // Place the stored value in the last unshuffled position
            }
        }

            // Method to iterate over all vehicles and display their details
            private static void DisplayAllVehicles(List<IVehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                DisplayVehicleDetails(vehicle);
            }
        }

        // This below section is the "Factory". We are utilizing the factory pattern to create vehicles, this can be expanded to include more vehicle types

        // Generic method to create a Car
        private static IVehicle CreateVehicle(CarFactory factory, string brand, string model, int year, double mileage, int doors) // Note: doors
        {
            return factory.CreateCar(brand, model, year, mileage, doors);
        }

        // Generic method to create a Motorcycle
        private static IVehicle CreateVehicle(MotorcycleFactory factory, string brand, string model, int year, double mileage, string engineType) // Note: engineType
        {
            return factory.CreateMotorcycle(brand, model, year, mileage, engineType);
        }

        // Method to display vehicle details - here we also check for car and motorcycle specific properties
        private static void DisplayVehicleDetails(IVehicle vehicle)
        {
            Console.WriteLine(vehicle.ToString());
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

        private static void FactoryShutdown()
        {
            // Take a key input to exit the program, it is a bit more user friendly than just closing the console window
            Console.WriteLine("Press play on tape (press any key)");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
