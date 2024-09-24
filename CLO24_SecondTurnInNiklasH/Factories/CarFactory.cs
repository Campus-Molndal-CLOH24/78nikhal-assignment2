using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Factories
{
    using Models;

    internal class CarFactory
    {
        internal CarImplementation CreateCar(string brand, string model, int year, double mileage, int doors)
        {
            return new CarImplementation(brand, model, year, mileage, doors);
        }
    }
}