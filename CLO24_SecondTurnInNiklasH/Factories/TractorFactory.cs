using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Factories
{
    using Models;
    internal class TractorFactory
    {
        internal TractorImplementation CreateTractor(string brand, string model, int year, double mileage, string utilityType)
        {
            return new TractorImplementation(brand, model, year, mileage, utilityType);
        }
    }
}
