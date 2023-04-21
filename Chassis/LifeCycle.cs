using Engine.Interfaces;
using Engine.Models;
using System.Threading;
using NatsContracts;
using System;


namespace Engine
{
    public class LifeCycle: ILifeCycle
    {
        private delegate void Increase();

        private Thread? _lifeCycleThread;
        private Chassis? _chassis;
        private Contract _contract;
        private bool _isActive = false;

        /// <summary>
        /// Start lifecycle
        /// </summary>
        /// <param name="chassis"></param>
        /// <exception cref="Exception"></exception>
        public void StartLifeCycle(Chassis chassis)
        {
            _chassis = chassis;
            _lifeCycleThread = new Thread(Life);
            _isActive = true;
            try
            {
                _lifeCycleThread.Start();
            } catch
            {
                _isActive = false;
                throw new Exception("Thread start crashed!");
            }
        }

        /// <summary>
        /// Stop lifecycle
        /// </summary>
        public void StopLifeCycle() { _isActive = false; }

        /// <summary>
        /// Return condition of lifecycle
        /// </summary>
        /// <returns></returns>
        public bool IsActive() { return _isActive; }

        /// <summary>
        /// Infinity loop for lifecycle
        /// </summary>
        private void Life()
        { 
            //while (_isActive)
            //{
                //if (_contract.isTemperatureIncrease && !_contract.isTemperatureIncreasing)
                //{
                //    _contract.isTemperatureIncreasing = true;
                //    Increase inc = _chassis.IncreaseTemperature;
                //    Thread temperatureThread = new Thread(() => Action(_contract.temperatureCommand.Time, inc));
                //    temperatureThread.Start();
                //}
                Action(10, null);
                Thread.Sleep(100);
            //}
        }

        private void Action(int time, Increase inc)
        {
            int iterations = time * 1000 / 250;
            for (int i = 0; i < iterations; i++)
            {
                _chassis.IncreaseTemperature();
                Thread.Sleep(250);
            }

            //_contract.isTemperatureIncreasing = false;
            //_contract.isTemperatureIncrease = false;
        }
    }
}
