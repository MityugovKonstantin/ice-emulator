namespace Engine.HeatingSystem
{
    public class Heater
    {
        private bool _isActive = false;

        public Heater(bool avctivity)
        {
            _isActive = avctivity;
        }

        public bool isActive()
        {
            return _isActive;
        }

        public void changeHeaterAvtivity()
        {
            if (_isActive) _isActive = false;
            else _isActive = true;
        }
    }
}
