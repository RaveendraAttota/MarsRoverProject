using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface ICommandHandler
    {
        void PlaceRover(Position position);
        void MoveRover(char command, int[] plateauSize);
        bool IsValidPosition(Position position, int[] plateauSize);
    }
}
