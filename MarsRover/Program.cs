using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static MarsRover.RoverEnums;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IRover Rover = new Rover();
            
            var Handler = new CommandHandler(Rover);

            bool PlateauSizeDefined = false;
            bool RoverPlaced = false;

            bool StopApplication = false;

            int[] PlateauSize = new int[2];
            string[] RoverPlacementPosition = new string[3];
            List<char> moves = new List<char>();

            List<string> Positions = new List<string>();

            Console.WriteLine("Enter commands to control rovers\r\n" +
                "==============================================\r\n" +
                "Enter Plateau sizes in the format eg: 5 5\r\n" +
                "Enter Rover placement position in the format eg: 1 2 N\r\n" +
                "Enter Rover movement command as eg: MMLMM\r\n" +
                "Enter placement and movement commands again to start another rover\r\n" +
                "Enter REPORT to see final positions of all rovers entered\r\n" +
                "==========================================================\r\n");

            do
            {
                string userInput = Console.ReadLine();

                if (userInput.Equals("REPORT"))
                {
                    foreach(var finalPosition in Positions)
                    {
                        Console.WriteLine(finalPosition);
                        Positions = null;
                    }
                }

                if (userInput.Equals("EXIT"))
                        StopApplication = true;


                if(!PlateauSizeDefined)
                {
                    try
                    {
                        PlateauSize = Array.ConvertAll(userInput.Split(' '), s => int.Parse(s));
                        PlateauSizeDefined = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input entered for Plateau size");
                    }
                }
                else if (!RoverPlaced)
                {
                    RoverPlacementPosition = userInput.Split(' ');

                    Position position = new Position();

                    try
                    {
                        if (RoverPlacementPosition.Length == 3)
                        {
                            position.XPosition = Convert.ToInt32(RoverPlacementPosition[0]);
                            position.YPosition = Convert.ToInt32(RoverPlacementPosition[1]);
                            position.FacingDirection = (Direction)Enum.Parse(typeof(Direction), RoverPlacementPosition[2]);
                        }

                        Handler.PlaceRover(position);

                        RoverPlaced = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input entered for rover placement");
                    }
                }
                else if(PlateauSizeDefined && RoverPlaced)
                {
                    moves = userInput.ToUpper().ToCharArray().ToList();

                    foreach(var command in moves)
                    {
                        try
                        {
                            Handler.MoveRover(command, PlateauSize);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input entered for robot movement");
                        }
                    }
                    Positions.Add(Handler.GetPosition());
                    RoverPlaced = false;
                }
            } while (!StopApplication);


        }
    }
}
