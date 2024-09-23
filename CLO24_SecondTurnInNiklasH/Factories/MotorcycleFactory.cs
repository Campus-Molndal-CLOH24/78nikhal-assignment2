using CLO24_SecondTurnInNiklasH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Factories
{
    internal class MotorcycleFactory
    {
        public MotorcycleImplementation CreateMotorcycle(string brand, string model, int year, double mileage, string engineType)
        {
            return new MotorcycleImplementation(brand, model, year, mileage, engineType);
        }
    }
}
