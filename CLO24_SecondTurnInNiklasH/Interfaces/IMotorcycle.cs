using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    public interface IMotorcycle : IVehicle
    {
        string EngineType { get; set; } // Motorcycle-specific variable that defines the type of engine the motorcycle has
    }
}
