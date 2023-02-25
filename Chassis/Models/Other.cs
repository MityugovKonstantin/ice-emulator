using Engine.Models.Other;

namespace Engine.Models
{
    public class OtherParam
    {
        public HandBrake HandBrake { get; set; }
        public Movement Movement { get; set; }
        public Rocker Rocker { get; set; }

        public OtherParam(HandBrake handBrake, Movement movement, Rocker rocker)
        {
            HandBrake = handBrake;
            Movement = movement;
            Rocker = rocker;
        }
    }
}
