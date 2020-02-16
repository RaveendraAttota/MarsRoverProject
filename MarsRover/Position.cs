using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.RoverEnums;

namespace MarsRover
{
    public class Position
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Direction FacingDirection { get; set; }
    }
}
