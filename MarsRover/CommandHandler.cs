using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.RoverEnums;

namespace MarsRover
{
    public class CommandHandler : ICommandHandler
    {
        public IRover Rover { get; private set; }

        public CommandHandler(IRover rover)
        {
            Rover = rover;
        }

        public void PlaceRover(Position position)
        {
            Rover.RoverPosition = position;
        }
        public void MoveRover(char command, int[] plateauSize)
        {
            switch(command)
            {
                case 'M':
                    if(IsValidPosition(Rover.RoverPosition, plateauSize))
                        Rover.Move();
                    break;
                case 'L':
                    Rover.TurnLeft();
                    break;
                case 'R':
                    Rover.TurnRight();
                    break;
            }
        }

        public string GetPosition()
        {
            return string.Format("Output: {0},{1},{2}", Rover.RoverPosition.XPosition,
                Rover.RoverPosition.YPosition, Rover.RoverPosition.FacingDirection.ToString());
        }

        public bool IsValidPosition(Position position, int[] plateauSize)
        {
            return position.XPosition < plateauSize[0] && position.XPosition >= 0 &&
                   position.YPosition < plateauSize[1] && position.YPosition >= 0;
        }
    }
}
