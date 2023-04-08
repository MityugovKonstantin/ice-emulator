using Engine;
using Engine.Interfaces;
using Engine.Models;
using System;

namespace GUI
{
    public class Presenter
    {
        private readonly IGui _gui;
        private readonly LifeCycle _lifeCycle;

        public Presenter(IGui gui, LifeCycle lifeCycle)
        {
            _gui = gui;
            _lifeCycle = lifeCycle;

            _gui.Start += Start;
        }

        private void Start(object? sender, Chassis chassis) {
            _lifeCycle.StartLifeCycle(chassis);
        }
    }
}
