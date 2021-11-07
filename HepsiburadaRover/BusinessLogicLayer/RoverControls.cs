using HepsiburadaRover.EntityLayer;
using HepsiburadaRover.EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiburadaRover.BusinessLogicLayer
{
    public static class RoverControls
    {
        public static Rover RoverAction(Rover rover, char[] inputCharArray, Matrix m)
        {
            Moves mvs;
            foreach (char i in inputCharArray)
            {
                if (Enum.TryParse(i.ToString(), true, out mvs))
                {
                    switch (mvs)
                    {
                        case Moves.L:
                            RoverTurn(rover, Moves.L);
                            break;
                        case Moves.R:
                            RoverTurn(rover, Moves.R);
                            break;
                        case Moves.M:
                            RoverMove(rover,m);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("First Rover inputs wrong!");
                    rover.x = 0;
                    rover.y = 0;
                    rover.direction = Directions.N;
                    return rover;
                }
            }
            return rover;
        }

        public static void RoverTurn(Rover rover, Moves mvs)
        {
            switch (rover.direction)
            {//^N >E |S <W
                case Directions.N:
                    if (mvs == Moves.L)
                        rover.direction = Directions.W;
                    else if (mvs == Moves.R)
                        rover.direction = Directions.E;
                    break;
                case Directions.E:
                    if (mvs == Moves.L)
                        rover.direction = Directions.N;
                    else if (mvs == Moves.R)
                        rover.direction = Directions.S;
                    break;
                case Directions.W:
                    if (mvs == Moves.L)
                        rover.direction = Directions.S;
                    else if (mvs == Moves.R)
                        rover.direction = Directions.N;
                    break;
                case Directions.S:
                    if (mvs == Moves.L)
                        rover.direction = Directions.E;
                    else if (mvs == Moves.R)
                        rover.direction = Directions.W;
                    break;
            }
        }
        public static void RoverMove(Rover rover,Matrix m)
        {
            switch (rover.direction)
            {
                case Directions.N:
                    rover.y++;
                    if(rover.y > m.y || rover.y < m.y)
                        Console.WriteLine("Rover out of area!!!");
                    break;
                case Directions.E:
                    rover.x++;
                    if (rover.x > m.x || rover.x < m.x)
                        Console.WriteLine("Rover out of area!!!");
                    break;
                case Directions.W:
                    rover.x--;
                    if (rover.x > m.x || rover.x < m.x)
                        Console.WriteLine("Rover out of area!!!");
                    break;
                case Directions.S:
                    rover.y--;
                    if (rover.y > m.y || rover.y < m.y)
                        Console.WriteLine("Rover out of area!!!");
                    break;
            }
        }
    }
}
