using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;

    public class CarImplementation : VehicleFoundation, ICar
    {
        // Internal property with restricted access, specific to Car
        protected int InternalDoors { get; private set; }

        // Explicit implementation of the interface to protect the property
        int ICar.Doors
        {
            get => InternalDoors;
            set => InternalDoors = value;
        }

        // Override to provide a user-friendly type name, "Car" instead of "Vehicle"
        protected override string VehicleTypeName => "Car";

        // Constructor to initialize properties, calling the base class constructor
        public CarImplementation(string brand, string model, int year, double mileage, int doors)
            : base(brand, model, year, mileage)
        {
            // Input validation, doors must be a positive integer
            if (doors <= 0)
                throw new ArgumentException("Doors must be a positive integer.");

            InternalDoors = doors;
        }
    }
}
