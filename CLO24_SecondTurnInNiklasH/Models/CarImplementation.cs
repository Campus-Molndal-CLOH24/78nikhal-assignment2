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
        // We implement the properties from ICar, they are specific to a car
        public int Doors { get; set; }

        // Setting up the constructor to initialize the properties
        public CarImplementation(string brand, string model, int year, double mileage, int doors)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Doors = doors;
        }
    }
}
