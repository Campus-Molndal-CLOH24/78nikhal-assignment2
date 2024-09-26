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
        // Factory method to create a TractorImplementation object
        internal TractorImplementation CreateTractor(string brand, string model, int year, double mileage, string utilityTool, double weight)
        {
            return new TractorImplementation(brand, model, year, mileage, utilityTool, weight);
        }
    }
}
