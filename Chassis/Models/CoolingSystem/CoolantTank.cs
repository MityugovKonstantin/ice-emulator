namespace Engine.CoolingSystem
{
    public class CoolantTank
    {
        public float _coolantVolume { get; set; }
        public float _coolantPressure { get; set; }

        public CoolantTank(float oilVolume, float pressureVolume)
        {
            _coolantVolume = oilVolume;
            _coolantPressure = pressureVolume;
        }
    }
}
