using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;

    public class TractorImplementation : VehicleFoundation, ITractor
    {
        // Internal property with restricted access, specific to Tractor
        protected double InternalWeight { get; private set; }

        // Explicit interface implementation to protect the property
        double ITractor.Weight
        {
            get => InternalWeight;
            set => InternalWeight = value;
        }

        // Internal property with restricted access, specific to Tractor
        protected string InternalUtilityTool { get; private set; }

        // Explicit interface implementation to protect the property
        string ITractor.UtilityTool
        {
            get => InternalUtilityTool;
            set => InternalUtilityTool = value;
        }

        // Override to provide a user-friendly type name, "Tractor" instead of "Vehicle"
        protected override string VehicleTypeName => "Tractor";

        // Constructor to initialize properties, calling the base class constructor
        public TractorImplementation(string brand, string model, int year, double mileage, string utilityTool, double weight)
            : base(brand, model, year, mileage)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(utilityTool))
                throw new ArgumentException("Utility tool cannot be empty or null.");

            if (weight <= 0)
                throw new ArgumentException("Weight must be a positive value.");

            InternalUtilityTool = utilityTool;
            InternalWeight = weight;
        }
    }
}
