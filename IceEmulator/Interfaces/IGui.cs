using Engine.Models;
using System;

// НУ УБЕДИТЬСЯ
namespace View.Interfaces
{
    public interface IGui
    {
        event EventHandler<Chassis> Start;
        event EventHandler Stop;

        /// <summary>
        /// Calling method which update information on GUI
        /// </summary>
        /// <param name="chassis"></param>
        public void Update(Chassis chassis);
    }
}
