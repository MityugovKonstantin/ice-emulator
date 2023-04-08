using Engine.Models;

namespace Engine.Interfaces
{
    public interface ILifeCycle
    {
        void StartLifeCycle(Chassis chassis);

        void StopLifeCycle();
    }
}
