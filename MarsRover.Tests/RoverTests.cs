using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarsRover.RoverEnums;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void Test_Move_RoverShouldMoveOneStep()
        {
            //Arrange
            Rover rover = new Rover();
            rover.RoverPosition = new Position
            {
                XPosition = 1,
                YPosition = 2,
                FacingDirection = Direction.S
            };

            Position expectedPosition = new Position
            {
                XPosition = 1,
                YPosition = 1,
                FacingDirection = Direction.S

            };

            //Act
            Position actualPosition = rover.Move();

            //Assert
            Assert.AreEqual(expectedPosition.YPosition, actualPosition.YPosition);
            Assert.AreEqual(expectedPosition.XPosition, actualPosition.XPosition);
            Assert.AreEqual(expectedPosition.FacingDirection, actualPosition.FacingDirection);

        }

        [TestMethod]
        public void Test_TurnLeft_ShouldChangeDirectionToLeft()
        {
            //Arrange
            Rover rover = new Rover();
            rover.RoverPosition = new Position
            {
                XPosition = 1,
                YPosition = 2,
                FacingDirection = Direction.S
            };

            Direction expectedDirection = Direction.E;

            //Act
            rover.TurnLeft();
            Direction actualDirection = rover.RoverPosition.FacingDirection;

            //Assert
            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void Test_TurnRight_ShouldChangeDirectionToRight()
        {
            //Arrange
            Rover rover = new Rover();
            rover.RoverPosition = new Position
            {
                XPosition = 1,
                YPosition = 2,
                FacingDirection = Direction.S
            };

            Direction expectedDirection = Direction.W;

            //Act
            rover.TurnRight();
            Direction actualDirection = rover.RoverPosition.FacingDirection;

            //Assert
            Assert.AreEqual(expectedDirection, actualDirection);
        }
    }
}
