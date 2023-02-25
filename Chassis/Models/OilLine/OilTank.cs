namespace Engine.OilLine
{
    public class OilTank
    {
        private float _oilVolume = 0f;
        private float _oilPressure = 0f;

        public OilTank(float oilVolume, float pressureVolume)
        {
            _oilVolume = oilVolume;
            _oilPressure = pressureVolume;
        }

        public void setOilVolume(float oilVolume)
        {
            _oilVolume = oilVolume;
        }

        public float getOilVolume()
        {
            return _oilVolume;
        }

        public void setOilPressure(float oilPressure)
        {
            _oilPressure = oilPressure;
        }

        public float getOilPressure()
        {
            return _oilPressure;
        }
    }
}
