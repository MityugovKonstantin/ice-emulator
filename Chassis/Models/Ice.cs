using System;

namespace Engine.Models
{
    public class Ice
    {
        public float _revilutionsPerMinute { get; set; }
        private bool _isTractionRelayActive = false;
        private bool _isStarterActive = false;
        private bool _isIceActive = false;

        public void activateStarter()
        {
            if (_isStarterActive)
                throw new ArgumentException("Starter active yet");
            else
                _isStarterActive = true;
        }

        public void activateTractionRelay()
        {
            if (_isTractionRelayActive)
                throw new ArgumentException("Traction relay active yet");
            else
                _isTractionRelayActive = true;
        }

        public void disableStarter()
        {
            if (!_isStarterActive)
                throw new ArgumentException("Starter disable yet");
            else
                _isStarterActive = false;
        }

        public void disableTractionRelay()
        {
            if (!_isTractionRelayActive)
                throw new ArgumentException("Traction relay disable yet");
            else
                _isTractionRelayActive = false;
        }

        public void startEngineBySparkPlug()
        {
            if (_isIceActive)
                throw new ArgumentException("Engine active yet");
            else
                _isIceActive = true;
        }

        public void startEngineByAirValve()
        {
            if (_isIceActive)
                throw new ArgumentException("Engine active yet");
            else
                _isIceActive = true;
        }

        public void increaseRpm()
        {
            // condition to increace
            // increase rpm by the formula
        }
    }
}
