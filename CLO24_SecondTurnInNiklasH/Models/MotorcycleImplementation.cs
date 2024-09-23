using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;

    public class MotorcycleImplementation : IMotorcycle, IVehicle, IDriveable
    {
        // We start by implementing the properties from IVehicle
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }

        // Then we implement the property from IMotorcycle
        public string EngineType { get; set; }

        // We want a variable value to be used in the IsEngineOn method
        private bool engineOn = false;

        // Setting up the constructor to initialize the properties
        public MotorcycleImplementation(string brand, string model, int year, double mileage, string engineType)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            EngineType = engineType;
        }

        // IVehicle Methods
        public bool IsEngineOn()
        {
            return engineOn;
        }

        public void StartEngine() // TO DO: Why have we created these Methods twice? FIX!
        {
            if (!engineOn)
            {
                engineOn = true;
                Console.WriteLine("Motorcycle engine started!");
            }
        }

        public void StopEngine()
        {
            if (engineOn)
            {
                engineOn = false;
                Console.WriteLine("Motorcycle engine stopped.");
            }
        }

        // IDriveable Methods
        public string Drive()
        {
            if (engineOn) // We're checking if the engine is on, to make a bit more sense and a bit more fun application
            {
                return "The motorcycle is driving...";
            }
            else
            {
                return "The engine is not on.";
            }
        }

        // Overriding the ToString method to return the motorcycle properties
        public override string ToString()
        {
            return $"{Brand} {Model} {Year}";
        }
    }
}
