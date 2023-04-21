using Engine;
using Engine.Interfaces;
using Engine.Models;
using System;
using View;
using View.Interfaces;

namespace GUI
{
    public class Presenter
    {
        private readonly IGui _gui;
        private readonly LifeCycle _lifeCycle;
        private readonly ChassisInfromation _chassisInfromation;
        public Presenter(IGui gui, LifeCycle lifeCycle, ChassisInfromation chassisInfromation)
        {
            _gui = gui;
            _lifeCycle = lifeCycle;
            _chassisInfromation = chassisInfromation;

            _gui.Start += Start;
            _gui.Stop += Stop;
            _chassisInfromation.Update += Update;
        }

        /// <summary>
        /// Start lifecycle and chassis information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="chassis"></param>
        private void Start(object? sender, Chassis chassis)
        {
            _lifeCycle.StartLifeCycle(chassis);
            _chassisInfromation.StartChassisInformation(chassis);
        }
        /// <summary>
        /// Stop lifecycle and chassis information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="_"></param>
        private void Stop(object? sender, EventArgs _)
        {
            _lifeCycle.StopLifeCycle();
            _chassisInfromation.StopChassisInformation();
        }
        /// <summary>
        /// Call method which update information in GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="chassis"></param>
        private void Update(object? sender, Chassis chassis) 
        {
            _gui.Update(chassis);
        }
    }
}
