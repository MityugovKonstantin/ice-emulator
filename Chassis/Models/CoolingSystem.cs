using Engine.CoolingSystem;

namespace Engine.Models
{
    public class CoolingSystem
    {
        public CoolantTank CoolantTank { get; set; }

        public CoolingSystem(CoolantTank coolantTank)
        {
            CoolantTank = coolantTank;
        }
    }
}
