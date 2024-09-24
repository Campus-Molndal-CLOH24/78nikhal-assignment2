using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;
    public abstract class VehicleFoundation : IVehicle, IDriveable
    {
        // Properties from IVehicle
        public string Brand { get; set; } = string.Empty; // Defaults to an empty string
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public double Mileage { get; set; }

        // Constructor to initialize properties
        public VehicleFoundation(string brand, string model, int year, double mileage)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
        }

        // Engine status property shared by all vehicles
        private bool engineOn = false;

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
                Console.WriteLine($"{GetType().Name} engine started!");
            }
        }

        public void StopEngine()
        {
            if (engineOn)
            {
                engineOn = false;
                Console.WriteLine($"{GetType().Name} engine stopped.");
            }
        }

        // IDriveable Method
        public virtual string Drive()
        {
            if (engineOn)
            {
                return $"{GetType().Name} is driving...";
            }
            else
            {
                return "The engine is not on.";
            }
        }

        // Overriding ToString to display vehicle details
        public override string ToString()
        {
            return $"{Brand} {Model} {Year}";
        }
    }
}
