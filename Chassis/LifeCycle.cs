using Engine.Interfaces;
using Engine.Models;
using System.Threading;
using System;

namespace Engine
{
    public class LifeCycle: ILifeCycle
    {

        private Thread? _lifeCycleThread;
        private Chassis? _chassis;
        private bool _isActivate = false;

        public void StartLifeCycle(Chassis chassis)
        {
            _chassis = chassis;
            _lifeCycleThread = new Thread(Life);
            _isActivate = true;
            try
            {
                _lifeCycleThread.Start();
            } catch
            {
                _isActivate = false;
                throw new Exception("Thread start crashed!");
            }
        }

        public void StopLifeCycle()
        {
            _isActivate = false;
        }

        private void Life()
        { 
            while (_isActivate)
            {
                // do something
            }
        }
    }
}
