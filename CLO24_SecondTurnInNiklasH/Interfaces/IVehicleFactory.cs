using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    public interface IVehicleFactory
    {
        // This interface is used to define the CreateVehicle method that all vehicle factories must implement
        IVehicle CreateVehicle(string model, int year, double mileage);
    }
}
