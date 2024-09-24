using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    public interface ITractor
    {
        double Weight { get; set; } // Weight in tons
        string UtilityTool { get; set; } // Defines the type of utility tool or attachment the tractor uses.
    }
}