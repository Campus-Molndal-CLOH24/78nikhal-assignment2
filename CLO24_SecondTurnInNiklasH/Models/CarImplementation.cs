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
        // Property specific to Car
        public int Doors { get; set; }

        // Constructor to initialize properties, calling the base class constructor
        public CarImplementation(string brand, string model, int year, double mileage, int doors)
            : base(brand, model, year, mileage)
        { // Below section is a simple validation of the input parameters, if they are not they set a default value
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("Brand cannot be empty or null.");
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be empty or null.");
            if (year <= 0)
                throw new ArgumentException("Year must be a positive integer.");
            if (mileage < 0)
                throw new ArgumentException("Mileage cannot be negative.");
            if (doors <= 0)
                throw new ArgumentException("Doors must be a positive integer.");

            Doors = doors;
        }

        // Additional car-specific methods can be added here if needed
    }
}
