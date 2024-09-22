using CLO24_SecondTurnInNiklasH.Factories;
using CLO24_SecondTurnInNiklasH.Models;

namespace CLO24_SecondTurnInNiklasH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instansiera fabriker för att skapa specifika fordon
            CarFactory carFactory = new CarFactory();
            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            // Skapa en bil med hjälp av CarFactory
            CarImpl car = carFactory.CreateCar("Toyota", "Corolla", 2020, 15000, 4);
            Console.WriteLine(car.ToString()); // Skriver ut bilens egenskaper
            car.StartEngine(); // Startar bilens motor
            Console.WriteLine("Car engine status: " + (car.IsEngineOn() ? "On" : "Off")); // Kollar om motorn är på
            car.StopEngine(); // Stänger av bilens motor
            Console.WriteLine("Car engine status: " + (car.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine("Car doors: " + car.Doors); // Skriver ut antalet dörrar
            car.Doors = 5; // Ändrar antal dörrar
            Console.WriteLine("Car doors: " + car.Doors);

            // Skapa en motorcykel med hjälp av MotorcycleFactory
            MotorcycleImpl motorcycle = motorcycleFactory.CreateMotorcycle("Harley Davidson", "Sportster", 2019, 5000, "V-Twin");
            Console.WriteLine(motorcycle.ToString()); // Skriver ut motorcykelns egenskaper
            motorcycle.StartEngine(); // Startar motorcykelns motor
            Console.WriteLine("Motorcycle engine status: " + (motorcycle.IsEngineOn() ? "On" : "Off")); // Kollar om motorn är på
            motorcycle.StopEngine(); // Stänger av motorcykelns motor
            Console.WriteLine("Motorcycle engine status: " + (motorcycle.IsEngineOn() ? "On" : "Off"));
            Console.WriteLine("Motorcycle engine type: " + motorcycle.EngineType); // Skriver ut motortypen
            motorcycle.EngineType = "Inline-4"; // Ändrar motortypen
            Console.WriteLine("Motorcycle engine type: " + motorcycle.EngineType);
        }

        // Expected output:
        //        Toyota Corolla 2020
        // Car engine started
        // Car engine status: On
        // Car engine stopped
        // Car engine status: Off
        // Car doors: 4
        // Car doors: 5
        // Harley Davidson Sportster 2019
        // Motorcycle engine started
        // Motorcycle engine status: On
        // Motorcycle engine stopped
        // Motorcycle engine status: Off
        // Motorcycle engine type: V-Twin
        // Motorcycle engine type: Inline-4
    }
}
