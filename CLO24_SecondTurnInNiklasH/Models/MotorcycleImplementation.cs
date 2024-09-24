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
        // We implement the property from IMotorcycle since it is specific for a motorcycle
        public string EngineType { get; set; }

        // Setting up the constructor to initialize the properties
        public MotorcycleImplementation(string brand, string model, int year, double mileage, string engineType) : base(brand, model, year, mileage)
        { // Below section is a simple validation of the input parameters, if they are not they set a default value
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("Brand cannot be empty or null.");
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be empty or null.");
            if (year <= 0)
                throw new ArgumentException("Year must be a positive integer.");
            if (mileage < 0)
                throw new ArgumentException("Mileage cannot be negative.");
            if (string.IsNullOrWhiteSpace(engineType))
                throw new ArgumentException("How can you drive without en engine!");

            EngineType = engineType;
        }
    }
}