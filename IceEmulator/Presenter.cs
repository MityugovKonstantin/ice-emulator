using Engine;
using Engine.Interfaces;

namespace GUI
{
    public class Presenter
    {
        private readonly IGui _gui;
        private readonly IChassis _chassis;
        private readonly LifeCycle _lifeCycle;

        public Presenter(IGui gui, IChassis chassis, LifeCycle lifeCycle)
        {
            _gui = gui;
            _chassis = chassis;
            _lifeCycle = lifeCycle;
        }
    }
}
