using MarsRover.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarsRover.RoverEnums;

namespace MarsRover.Tests
{
    [TestClass]
    public class CommandHandlerTests
    {        

        [TestMethod]
        public void Test_PlaceRover_RoverShouldBePlaced()
        {
            //Arrange
            IRover Rover = new Rover();
            CommandHandler handler = new CommandHandler(Rover);

            Position newPosition = new Position
            {
                XPosition = 1,
                YPosition = 2,
                FacingDirection = Direction.E
            };

            //Act
            handler.PlaceRover(newPosition);

            //Assert
            Assert.AreEqual(newPosition.XPosition, Rover.RoverPosition.XPosition);
            Assert.AreEqual(newPosition.YPosition, Rover.RoverPosition.YPosition);
            Assert.AreEqual(newPosition.FacingDirection, Rover.RoverPosition.FacingDirection);
        }

        [TestMethod]
        public void Test_MoveRover_ShouldMoveBasedOnCommand()
        {
            //Arrange
            IRover Rover = new Rover();
            CommandHandler handler = new CommandHandler(Rover);
            int[] plateauSize = { 5, 5 };
            Rover.RoverPosition = new Position
            {
                XPosition = 2,
                YPosition = 3,
                FacingDirection = Direction.E
            };

            Direction expectedDirection = Direction.N;

            //Act
            handler.MoveRover('L', plateauSize);

            //Assert
            Assert.AreEqual(expectedDirection, Rover.RoverPosition.FacingDirection);
        }

        [TestMethod]
        public void Test_IsValidPosition_ShouldBeValid()
        {
            //Arrange
            IRover Rover = new Rover();
            CommandHandler handler = new CommandHandler(Rover);
            int[] plateauSize = { 5, 5 };
            Position newPosition = new Position
            {
                XPosition = 1,
                YPosition = 2,
                FacingDirection = Direction.N
            };

            //Act
            bool IsValid = handler.IsValidPosition(newPosition, plateauSize);

            //Assert
            Assert.IsTrue(IsValid);
        }

        [TestMethod]
        public void Test_IsValidPosition_ShouldBeInvalid()
        {
            //Arrange
            IRover Rover = new Rover();
            CommandHandler handler = new CommandHandler(Rover);
            int[] plateauSize = { 5, 5 };
            Position newPosition = new Position
            {
                XPosition = 6,
                YPosition = 2,
                FacingDirection = Direction.N
            };

            //Act
            bool IsValid = handler.IsValidPosition(newPosition, plateauSize);

            //Assert
            Assert.IsFalse(IsValid);
        }
    }
}
