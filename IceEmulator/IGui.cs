using Engine.Models;
using System;

namespace GUI
{
    public interface IGui
    {
        event EventHandler<Chassis> Start;
    }
}
