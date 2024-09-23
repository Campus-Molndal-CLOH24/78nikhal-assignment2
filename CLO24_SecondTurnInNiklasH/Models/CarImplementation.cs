using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;

    public class CarImplementation : ICar, IVehicle, IDriveable
    {
        // We start by implementing the properties from IVehicle
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }

        // Then we implement the properties from ICar
        public int Doors { get; set; }

        // We want a variable value to be used in the IsEngineOn method
        private bool engineOn = false;

        // Setting up the constructor to initialize the properties
        public CarImplementation(string brand, string model, int year, double mileage, int doors)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Doors = doors;
        }

        // IVehicle Methods
        public bool IsEngineOn()
        {
            return engineOn;
        }

        public void StartEngine()
        {
            if (!engineOn)
            {
                engineOn = true;
            Console.WriteLine("The cars engine started!");
            }
        }

        public void StopEngine()
        {
            if (engineOn)
            {
                engineOn = false;
                Console.WriteLine("The cars engine stopped.");
            }
        }

        // IDriveable Methods
        public string Drive()
        {
            if (engineOn) // We're checking if the engine is on, to make a bit more sense and a bit more fun application
            {
                return "The car is driving...";
            }
            else
            {
                return "The engine is not on.";
            }
        }

        // Overriding the ToString method to return the car's properties
        public override string ToString()
        {
            return $"{Brand} {Model} {Year}";
        }
    }
}
