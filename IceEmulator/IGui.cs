using Engine.Models;
using System;

// НУ УБЕДИТЬСЯ
namespace GUI
{
    public interface IGui
    {
        event EventHandler<Chassis> Start;
    }
}
