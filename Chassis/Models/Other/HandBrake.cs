using System;

namespace Engine.Models.Other
{
    public class HandBrake
    {
        private bool _isHandBrakeTightened;

        public HandBrake(bool isHandBrakeTightened)
        {
            _isHandBrakeTightened = isHandBrakeTightened;
        }

        public void tighten()
        {
            if (_isHandBrakeTightened)
                throw new ArgumentException("Handbrake still on");
            _isHandBrakeTightened = true;
        }

        public void weaken()
        {
            if (!_isHandBrakeTightened)
                throw new ArgumentException("Handbrake still off");
            _isHandBrakeTightened = false;
        }

        public bool isHandBrakeTightened()
        {
            return _isHandBrakeTightened;
        }
    }
}
