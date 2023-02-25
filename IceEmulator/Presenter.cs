using Engine.Interfaces;

namespace GUI
{
    public class Presenter
    {
        private readonly IGui _gui;
        private readonly IChassis _chassis;

        public Presenter(IGui gui, IChassis chassis)
        {
            _gui = gui;
            _chassis = chassis;
        }
    }
}
