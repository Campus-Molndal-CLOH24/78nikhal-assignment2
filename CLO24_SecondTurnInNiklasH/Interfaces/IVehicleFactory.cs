using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string model, int year, double mileage);
    }
}
