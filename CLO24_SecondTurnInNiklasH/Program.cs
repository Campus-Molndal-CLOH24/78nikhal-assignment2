using CLO24_SecondTurnInNiklasH.Factories;
using CLO24_SecondTurnInNiklasH.Models;

namespace CLO24_SecondTurnInNiklasH

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of the CarFactory and MotorcycleFactory classes
            CarFactory carFactory = new CarFactory();
            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            // Using CarFactory to create an object of the CarImplementation class
            CarImplementation car = carFactory.CreateCar("Toyota", "Corolla", 2020, 15000, 4);
            Console.WriteLine(car.ToString()); // This prints the car's properties to the car variable
            car.StartEngine(); // Starting the car's engine
            Console.WriteLine("Car engine status: " + (car.IsEngineOn() ? "On" : "Off")); // Checking if the engine is On or Off
            Console.WriteLine(car.Drive()); // Prints the string returned from the Drive method
            car.StopEngine(); // Turns off the engine
            Console.WriteLine("Car engine status: " + (car.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine("Car doors: " + car.Doors); // Prints the number of doors
            car.Doors = 5; // Changes the number of doors and then prints it out
            Console.WriteLine("Car doors: " + car.Doors);

            // Below we're doing the same as above, but with a motorcycle
            MotorcycleImplementation motorcycle = motorcycleFactory.CreateMotorcycle("Harley Davidson", "Sportster", 2019, 5000, "V-Twin");
            Console.WriteLine(motorcycle.ToString());
            motorcycle.StartEngine();
            Console.WriteLine("Motorcycle engine status: " + (motorcycle.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine(motorcycle.Drive());
            motorcycle.StopEngine();
            Console.WriteLine("Motorcycle engine status: " + (motorcycle.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine("Motorcycle engine type: " + motorcycle.EngineType);
            motorcycle.EngineType = "Inline-4";
            Console.WriteLine("Motorcycle engine type: " + motorcycle.EngineType);
        }
    }
}
