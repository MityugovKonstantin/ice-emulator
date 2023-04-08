using Engine.Enums;

namespace Engine.Models.Temp
{
    public class StartValue
    {
        public float Temperature { get; set; }
        public float Rotation { get; set; }
        public bool IsHandBrake { get; set; }
        public RockerPositions RockerPositions { get; set; }
        public MovementType MovementType { get; set; }
    }
}
