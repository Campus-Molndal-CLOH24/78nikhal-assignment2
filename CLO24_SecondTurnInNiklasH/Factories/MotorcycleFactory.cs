using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Factories
{
    using Models;

    internal class MotorcycleFactory
    {
        internal MotorcycleImplementation CreateMotorcycle(string brand, string model, int year, double mileage, string engineType)
        {
            return new MotorcycleImplementation(brand, model, year, mileage, engineType);
        }
    }
}
