using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    // This is the IVehicle interface. It is used to define the properties and methods that all vehicles must implement
    public interface IVehicle
    {
        string Brand { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        double Mileage { get; set; }

        bool IsEngineOn();
        void StartEngine();
        void StopEngine();
    }
}
