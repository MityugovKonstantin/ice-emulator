using Engine.Enums;
using System;

namespace Engine.Models.Other
{
    public class Rocker
    {
        private RockerPositions _rockerPositions;

        public Rocker(RockerPositions rockerPositions)
        {
            _rockerPositions = rockerPositions;
        }

        public void setRockerPosition(RockerPositions rockerPositions)
        {
            if (rockerPositions == _rockerPositions)
                throw new ArgumentException("This rocker position is already set");
            _rockerPositions = rockerPositions;
        }

        public RockerPositions getRockerPositions()
        {
            return _rockerPositions;
        }
    }
}
