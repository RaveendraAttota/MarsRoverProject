using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IRover
    {
        Position RoverPosition { get; set; }
        Position Move();
        void TurnLeft();
        void TurnRight();
    }
}
