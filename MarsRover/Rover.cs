using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.RoverEnums;

namespace MarsRover
{
    public class Rover : IRover
    {
        public Position RoverPosition { get; set; }

        public Position Move()
        {
            switch (RoverPosition.FacingDirection)
            {
                case Direction.N:
                    RoverPosition.YPosition = RoverPosition.YPosition + 1;
                    break;
                case Direction.E:
                    RoverPosition.XPosition = RoverPosition.XPosition + 1;
                    break;
                case Direction.S:
                    RoverPosition.YPosition = RoverPosition.YPosition - 1;
                    break;
                case Direction.W:
                    RoverPosition.XPosition = RoverPosition.XPosition - 1;
                    break;
            }

            return new Position()
            {
                XPosition = RoverPosition.XPosition,
                YPosition = RoverPosition.YPosition,
                FacingDirection = RoverPosition.FacingDirection
            };
        }

        public void TurnLeft()
        {
            switch (RoverPosition.FacingDirection)
            {
                case Direction.N:
                    RoverPosition.FacingDirection = Direction.W;
                    break;
                case Direction.E:
                    RoverPosition.FacingDirection = Direction.N;
                    break;
                case Direction.S:
                    RoverPosition.FacingDirection = Direction.E;
                    break;
                case Direction.W:
                    RoverPosition.FacingDirection = Direction.S;
                    break;
                default:
                    break;

            }
        }
        public void TurnRight()
        {
            switch (RoverPosition.FacingDirection)
            {
                case Direction.N:
                    RoverPosition.FacingDirection = Direction.E;
                    break;
                case Direction.E:
                    RoverPosition.FacingDirection = Direction.S;
                    break;
                case Direction.S:
                    RoverPosition.FacingDirection = Direction.W;
                    break;
                case Direction.W:
                    RoverPosition.FacingDirection = Direction.N;
                    break;
                default:
                    break;

            }
        }
    }
}
