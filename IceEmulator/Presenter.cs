using Engine;
using Engine.Interfaces;
using Engine.Models;
using System;

namespace GUI
{
    //ÏÎÄÊËŞ×ÈÒÜ ÂÛÂÎÄ ÍÀ ÃÓÈ
    public class Presenter
    {
        private readonly IGui _gui;
        private readonly LifeCycle _lifeCycle;

        public Presenter(IGui gui, LifeCycle lifeCycle)
        {
            _gui = gui;
            _lifeCycle = lifeCycle;

            _gui.Start += Start;
            _gui.Stop += Stop;
        }

        private void Start(object? sender, Chassis chassis)
        {
            _lifeCycle.StartLifeCycle(chassis);
        }
        private void Stop(object? sender, EventArgs _)
        {
            _lifeCycle.StopLifeCycle();
        }
    }
}
