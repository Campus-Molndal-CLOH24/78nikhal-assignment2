using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLO24_SecondTurnInNiklasH.Models;

namespace CLO24_SecondTurnInNiklasH.Factories
{
    internal class CarFactory
    {
        public CarImplementation CreateCar(string brand, string model, int year, double mileage, int doors)
        {
            return new CarImplementation(brand, model, year, mileage, doors);
        }
    }
}