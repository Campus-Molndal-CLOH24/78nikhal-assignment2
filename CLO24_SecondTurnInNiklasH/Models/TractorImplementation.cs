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
        protected string InternalUtilityType { get; private set; }

        // Explicit implementation of the interface to protect the property
        string ITractor.UtilityType
        {
            get => InternalUtilityType;
            set => InternalUtilityType = value;
        }

        // Constructor to initialize properties, calling the base class constructor
        public TractorImplementation(string brand, string model, int year, double mileage, string utilityType)
            : base(brand, model, year, mileage)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(utilityType))
                throw new ArgumentException("Utility type cannot be empty or null.");

            InternalUtilityType = utilityType;
        }
    }
}
