using Engine.Interfaces;
using Engine.Models;

namespace Engine
{
    public class Chassis : IChassis
    {
        public Models.CoolingSystem CoolingSystem { get; set; }
        public OtherParam OtherParam { get; set; }
        public Models.OilLine OilLine {get; set;}
        public Models.HeatingSystem HeatingSystem { get; set; }
        public Ice Ice { get; set; }

        public Chassis(
            Models.CoolingSystem coolingSystem, 
            OtherParam otherParam, 
            Models.OilLine oilLine, 
            Models.HeatingSystem heatingSystem, 
            Ice ice)
        {
            CoolingSystem = coolingSystem;
            OtherParam = otherParam;
            OilLine = oilLine;
            HeatingSystem = heatingSystem;
            Ice = ice;
        }
    }
}
