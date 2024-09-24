namespace CLO24_SecondTurnInNiklasH
{
    using Factories;
    using Interfaces;
    using Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of the CarFactory and MotorcycleFactory classes
            CarFactory carFactory = new CarFactory();
            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            // Using CarFactory to create an object of the CarImplementation class
            IVehicle car = carFactory.CreateCar("Toyota", "Corolla", 2020, 15000, 4);
            // For car-specific properties, cast to ICar
            ICar specificCar = (ICar)car;
            Console.WriteLine(car.ToString()); // This prints the car's properties to the car variable
            car.StartEngine(); // Starting the car's engine
            Console.WriteLine("Car engine status: " + (car.IsEngineOn() ? "On" : "Off")); // Checking if the engine is On or Off
            Console.WriteLine(car.Drive()); // Prints the string returned from the Drive method, through IVehicle!
            car.StopEngine(); // Turns off the engine
            Console.WriteLine("Car engine status: " + (car.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine("Car doors: " + specificCar.Doors); // Prints the number of doors
            specificCar.Doors = 5; // Changes the number of doors and then prints it out
            Console.WriteLine("Car doors: " + specificCar.Doors);

            // Below we're doing the same as above, but with a motorcycle
            IVehicle motorcycle = motorcycleFactory.CreateMotorcycle("Harley Davidson", "Sportster", 2019, 5000, "V-Twin");
            // For motorcycle-specific properties, cast to IMotorcycle
            IMotorcycle specificMotorcycle = (IMotorcycle)motorcycle;
            Console.WriteLine(motorcycle.ToString());
            motorcycle.StartEngine();
            Console.WriteLine("Motorcycle engine status: " + (motorcycle.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine(motorcycle.Drive());
            motorcycle.StopEngine();
            Console.WriteLine("Motorcycle engine status: " + (motorcycle.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine("Motorcycle engine type: " + specificMotorcycle.EngineType);
            specificMotorcycle.EngineType = "Inline-4";
            Console.WriteLine("Motorcycle engine type: " + specificMotorcycle.EngineType);
        }
    }
}
