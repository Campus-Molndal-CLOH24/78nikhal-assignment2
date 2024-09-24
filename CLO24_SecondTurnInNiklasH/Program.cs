namespace CLO24_SecondTurnInNiklasH
{
    using Factories;
    using Interfaces;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a List of vehicles and display their details
            List<IVehicle> vehicles = CreateVehicleList();

            // Shuffle the vehicle list and then display the modified vehicles
            ShuffleList(vehicles);
            DisplayOriginalAndModifiedVehicles(vehicles);

            FactoryShutdown();
        }

        // Method to create a list of vehicles
        private static List<IVehicle> CreateVehicleList()
        {
            // Creating vehicle instances of the vehicle classes to supply our factory classes
            CarFactory carFactory = new CarFactory();
            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();
            TractorFactory tractorFactory = new TractorFactory();

            // Creating a list to hold all the vehicles
            List<IVehicle> vehicles = new List<IVehicle>();

            // Adding vehicles to the list
            vehicles.Add(CreateVehicle(carFactory, "Toyota", "Corolla", 2020, 15000, 4));
            vehicles.Add(CreateVehicle(motorcycleFactory, "Harley Davidson", "Sportster", 2019, 5000, "V-Twin"));
            vehicles.Add(CreateVehicle(tractorFactory, "John Deere", "X9", 2021, 500, "Harvester"));
            vehicles.Add(CreateVehicle(carFactory, "Ford", "Focus", 2018, 30000, 5));
            vehicles.Add(CreateVehicle(motorcycleFactory, "Yamaha", "MT-07", 2020, 8000, "Parallel Twin"));
            vehicles.Add(CreateVehicle(tractorFactory, "Massey Ferguson", "MF 5700", 2019, 800, "Plow"));
            vehicles.Add(CreateVehicle(carFactory, "Honda", "Civic", 2021, 10000, 4));
            vehicles.Add(CreateVehicle(motorcycleFactory, "Ducati", "Monster", 2022, 2000, "V-Twin"));
            vehicles.Add(CreateVehicle(tractorFactory, "Kubota", "M7", 2020, 600, "Forklift"));

            return vehicles;
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

        // Method to display original and modified vehicle details
        private static void DisplayOriginalAndModifiedVehicles(List<IVehicle> vehicles)
        {
            // Define lists of possible modifications
            List<int> carDoorModifications = new List<int> { 2, 3, 4, 5 }; // Possible door counts for cars
            List<string> motorcycleEngineModifications = new List<string> { "V-Twin", "Inline-4", "Parallel Twin", "Single Cylinder" }; // Possible engine types for motorcycles
            List<string> tractorUtilityModifications = new List<string> { "Plow", "Harvester", "Forklift", "Seeder" }; // Possible utility types for tractors

            // Create a single Random instance for the entire process
            Random tempRandom = new Random();

            // Display original and modified details
            foreach (var vehicle in vehicles)
            {
                // Display original details
                Console.WriteLine("Original Vehicle Details:");
                DisplayVehicleDetails(vehicle);

                // Apply modifications based on vehicle type
                if (vehicle is ICar car)
                {
                    // Apply a random door modification from the list
                    int newDoors = carDoorModifications[tempRandom.Next(carDoorModifications.Count)];
                    Console.WriteLine($"Modified Car Doors: {newDoors}"); // Display only the modified doors
                    car.Doors = newDoors; // Apply the modification
                }
                else if (vehicle is IMotorcycle motorcycle)
                {
                    // Apply a random engine modification from the list
                    string newEngineType = motorcycleEngineModifications[tempRandom.Next(motorcycleEngineModifications.Count)];
                    Console.WriteLine($"Modified Motorcycle Engine Type: {newEngineType}"); // Display only the modified engine type
                    motorcycle.EngineType = newEngineType; // Apply the modification
                }
                else if (vehicle is ITractor tractor)
                {
                    // Apply a random utility modification from the list
                    string newUtilityType = tractorUtilityModifications[tempRandom.Next(tractorUtilityModifications.Count)];
                    Console.WriteLine($"Modified Tractor Utility: {newUtilityType}"); // Display only the modified utility type
                    tractor.UtilityType = newUtilityType; // Apply the modification
                }

                Console.WriteLine(); // Add a line break between vehicles
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

        // Generic method to create a Tractor
        private static IVehicle CreateVehicle(TractorFactory factory, string brand, string model, int year, double mileage, string utilityType) // Note: utilityType
        {
            return factory.CreateTractor(brand, model, year, mileage, utilityType);
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
                Console.WriteLine($"Car doors: {car.Doors}"); // Display the modified number of doors
            }

            // Check for motorcycle-specific properties
            if (vehicle is IMotorcycle motorcycle)
            {
                Console.WriteLine($"Motorcycle engine type: {motorcycle.EngineType}"); // Display the modified engine type
            }

            // Check for tractor-specific properties
            if (vehicle is ITractor tractor)
            {
                Console.WriteLine($"Tractor utility type: {tractor.UtilityType}"); // Display the utility type
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
