using Engine.HeatingSystem;

namespace Engine.Models
{
    public class HeatingSystem
    {
        public Heater Heater { get; set; }

        public HeatingSystem(Heater heater)
        {
            Heater = heater;
        }
    }
}
