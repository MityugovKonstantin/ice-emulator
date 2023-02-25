using Engine.OilLine;

namespace Engine.Models
{
    public class OilLine
    {
        public OilTank OilTank { get; set; }

        public OilLine(OilTank oilTank)
        {
            OilTank = oilTank;
        }
    }
}
