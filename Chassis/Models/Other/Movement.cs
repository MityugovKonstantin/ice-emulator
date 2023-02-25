using Engine.Enums;
using System;

namespace Engine.Models.Other
{
    public class Movement
    {
        private MovementType _movementType;

        public Movement(MovementType movementType)
        {
            _movementType = movementType;
        }

        public void setMovementType(MovementType movementType)
        {
            if (_movementType == movementType)
                throw new ArgumentException("This movement type is already set");
            _movementType = movementType;
        }

        public MovementType getMovementType()
        {
            return _movementType;
        }
    }
}
