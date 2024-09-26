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
        // Internal properties from the IVehicle interface
        protected string InternalBrand { get; private set; } = string.Empty; // Defaults to an empty string
        protected string InternalModel { get; private set; } = string.Empty;
        protected int InternalYear { get; private set; }
        protected double InternalMileage { get; private set; }

        // Property to provide a more user-friendly type name
        protected virtual string VehicleTypeName => "Vehicle";

        // Explicit interface implementation to encapsulate the internal properties
        string IVehicle.Brand
        {
            get => InternalBrand;
            set => InternalBrand = value;
        }
        string IVehicle.Model
        {
            get => InternalModel;
            set => InternalModel = value;
        }
        int IVehicle.Year
        {
            get => InternalYear;
            set => InternalYear = value;
        }
        double IVehicle.Mileage
        {
            get => InternalMileage;
            set => InternalMileage = value;
        }

        // Constructor to initialize internal properties
        protected VehicleFoundation(string brand, string model, int year, double mileage)
        {
            InternalBrand = brand;
            InternalModel = model;
            InternalYear = year;
            InternalMileage = mileage;
        }

        // Engine status property shared by all vehicles
        private bool engineOn = false;

        // IVehicle Methods below: Checking is Engine on?, Start and Stop engine
        public bool IsEngineOn()
        {
            return engineOn;
        }

        public void StartEngine()
        {
            if (!engineOn)
            {
                engineOn = true;
                Console.WriteLine($"{VehicleTypeName} engine started!");
            }
        }

        public void StopEngine()
        {
            if (engineOn)
            {
                engineOn = false;
                Console.WriteLine($"{VehicleTypeName} engine stopped.");
            }
        }

        // IDriveable Method to simulate driving
        public virtual string Drive()
        {
            if (engineOn)
            {
                return $"{VehicleTypeName} is driving...";
            }
            else
            {
                return "The engine is not on.";
            }
        }

        // Overriding ToString to display detailed vehicle information
        public override string ToString()
        {
            return $"Brand: {InternalBrand}, Model: {InternalModel}, Year: {InternalYear}, Mileage: {InternalMileage:N0} km";
            // the :NO formatting displays the value (mileage) with thousands separators, i.e. 15 000 instead of 15000
        }
    }
}
