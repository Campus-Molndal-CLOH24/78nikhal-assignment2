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

        // Explicit implementation of the interface to protect the property
        string IMotorcycle.EngineType
        {
            get => InternalEngineType;
            set => InternalEngineType = value;
        }

        // Override the VehicleTypeName property to return a user-friendly type name
        protected override string VehicleTypeName => "Motorcycle";

        // Setting up the constructor to initialize the properties
        public MotorcycleImplementation(string brand, string model, int year, double mileage, string engineType) : base(brand, model, year, mileage)
        // Input validation
        {
            if (string.IsNullOrWhiteSpace(engineType))
                throw new ArgumentException("Engine type cannot be empty or null.");

            InternalEngineType = engineType;
        }
    }
}