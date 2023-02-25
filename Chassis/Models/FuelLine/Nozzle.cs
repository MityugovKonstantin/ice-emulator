using Engine.Interfaces;
using System.CodeDom.Compiler;

namespace Engine.FuelLine
{
    public class Nozzle : IGlowPlugHeated
    {
        private float _temp { get; set; }

        public void warmUp()
        {
            // increase temp by formula
        }


    }
}
