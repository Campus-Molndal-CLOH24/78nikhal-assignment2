using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;

    public class MotorcycleImplementation : VehicleFoundation, IMotorcycle
    {
        // Internal property with restricted access, property specific to Motorcycle
        protected string InternalEngineType { get; private set; }

        // Explicit interface implementation to protect the property
        string IMotorcycle.EngineType
        {
            get => InternalEngineType;
            set => InternalEngineType = value;
        }

        // Override to provide a user-friendly type name, "Motorcycle" instead of "Vehicle"
        protected override string VehicleTypeName => "Motorcycle";

        // Constructor to initialize properties, calling the base class constructor
        public MotorcycleImplementation(string brand, string model, int year, double mileage, string engineType) : base(brand, model, year, mileage)
        {
            // Input validation, engine type cannot be empty or null
            if (string.IsNullOrWhiteSpace(engineType))
                throw new ArgumentException("Engine type cannot be empty or null.");

            InternalEngineType = engineType;
        }
    }
}