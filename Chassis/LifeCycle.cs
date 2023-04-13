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
        
        public bool IsActive() 
        { 
            return _isActivate; 
        }

        //ФИКСИТЬ ЦИКЛ И ДЕЛЕГАТЫ

        private void Life()
        { 
            while (_isActivate)
            {
                if (_contract.isTemperatureIncrease && !_contract.isTemperatureIncreasing)
                {
                    _contract.isTemperatureIncreasing = true;
                    Increase inc = _chassis.IncreaseTemperature;
                    Thread temperatureThread = new Thread(() => Action(_contract.temperatureCommand.Time, inc));
                    temperatureThread.Start();

                }
                Thread.Sleep(100);
            }
        }

        private void Action(int time, Increase inc)
        {
            int iterations = time * 1000 / 250;
            for (int i = 0; i < iterations; i++)
            {
                inc();
                Thread.Sleep(250);
            }

            _contract.isTemperatureIncreasing = false;
            _contract.isTemperatureIncrease = false;
        }
    }
}
