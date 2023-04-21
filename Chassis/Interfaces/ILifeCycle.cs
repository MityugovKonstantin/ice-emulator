using Engine.Models;

namespace Engine.Interfaces
{
    public interface ILifeCycle
    {
        /// <summary>
        /// Start lifecycle
        /// </summary>
        /// <param name="chassis"></param>
        /// <exception cref="Exception"></exception>
        void StartLifeCycle(Chassis chassis);

        /// <summary>
        /// Stop lifecycle
        /// </summary>
        void StopLifeCycle();
    }
}
