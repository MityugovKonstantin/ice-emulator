using Engine.Interfaces;
using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.Interfaces;

namespace View
{
    public class ChassisInfromation: IChassisInformation
    {
        Chassis _chassis;
        Thread _chassisInformationThread = null;
        private bool _isActive = false;

        public event EventHandler<Chassis> Update;

        /// <summary>
        /// Start chassis information
        /// </summary>
        /// <param name="chassis"></param>
        /// <exception cref="Exception"></exception>
        public void StartChassisInformation(Chassis chassis)
        {
            _chassis = chassis;
            _chassisInformationThread = new Thread(ChassisInformationCycle);
            _isActive = true;
            try
            {
                _chassisInformationThread.Start();
            }
            catch
            {
                _isActive = false;
                throw new Exception("Thread start crashed!");
            }
        }

        /// <summary>
        /// Stop chassis information
        /// </summary>
        public void StopChassisInformation() { _isActive = false; }

        /// <summary>
        /// Return condition of chassis information
        /// </summary>
        /// <returns></returns>
        public bool IsActive() { return _isActive; }

        /// <summary>
        /// Infinity loop for chassis information
        /// </summary>
        private void ChassisInformationCycle()
        {
            while (_isActive)
            {
                Update.Invoke(this, _chassis);
                Thread.Sleep(250);
            }
        }
    }
}
