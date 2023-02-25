using Engine.Interfaces;
using Engine.Models;

namespace Engine
{
    public class Chassis : IChassis
    {
        public Models.CoolingSystem? CoolingSystem { get; set; }
        public OtherParam? OtherParam { get; set; }
        public Models.OilLine? OilLine {get; set;}
        public Models.HeatingSystem? HeatingSystem { get; set; }
        public Ice? Ice { get; set; }
    }
}
