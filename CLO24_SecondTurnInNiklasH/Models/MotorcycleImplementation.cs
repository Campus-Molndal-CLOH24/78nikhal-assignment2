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
        public MotorcycleImplementation(string brand, string model, int year, double mileage, string engineType)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            EngineType = engineType;
        }
    }
}