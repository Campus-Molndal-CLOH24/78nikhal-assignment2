using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    public interface ICar : IVehicle, IDriveable
    {
        int Doors { get; set; } // Car-specific variable that defines the number of doors the car has
    }
}
