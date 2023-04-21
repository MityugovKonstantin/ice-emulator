using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Interfaces
{
    public interface IChassisInformation
    {
        /// <summary>
        /// Start chassis information
        /// </summary>
        /// <param name="chassis"></param>
        /// <exception cref="Exception"></exception>
        public void StartChassisInformation(Chassis chassis);
        /// <summary>
        /// Stop chassis information
        /// </summary>
        public void StopChassisInformation();

        event EventHandler<Chassis> Update;

    }
}
