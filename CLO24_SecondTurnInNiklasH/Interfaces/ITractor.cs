using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLO24_SecondTurnInNiklasH.Interfaces
{
    public interface ITractor
    {
        double Weight { get; set; } // Tractor-specific variable that defines the weight of the tractor
        string UtilityTool { get; set; } // Tractor-specific variable that defines the utility tool the tractor has
    }
}