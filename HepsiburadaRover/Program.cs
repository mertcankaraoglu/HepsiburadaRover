using HepsiburadaRover.BusinessLogicLayer;
using HepsiburadaRover.EntityLayer;
using HepsiburadaRover.EntityLayer.Enum;
using System;

namespace HepsiburadaRover
{
    class Program
    {

        static void Main(string[] args)
        {
            Matrix m = new Matrix { x = 0, y = 0 };
            string input;
            string[] inputArray;
            char[] inputCharArray;

            int x = 0, y = 0;
            Directions rd;
            Rover r1 = new Rover();
            Rover r2 = new Rover();

            //First input
            Console.WriteLine("Size: ");
            input = Console.ReadLine().ToUpper();
            inputArray = input.Split(' ');
            if (inputArray.Length != 2 || !int.TryParse(inputArray[0], out x) || !int.TryParse(inputArray[1], out y))
            {
                Console.WriteLine("First input not correct format, please check again. e.g. 5 5");
                return;
            }
            else
            {
                m.x = x;
                m.y = y;
                if (m.x <= 0 || m.y <= 0)
                {
                    Console.WriteLine("Plateau area size can not be less than zero");
                    return;
                }
            }

            //Second input
            Console.WriteLine("Rover-1 Location and Direction: ");
            input = Console.ReadLine().ToUpper();
            inputArray = input.Split(' ');
            if (inputArray.Length != 3 || !int.TryParse(inputArray[0], out x) || !int.TryParse(inputArray[1], out y) || !Enum.TryParse(inputArray[2], true, out rd))
            {
                Console.WriteLine("Second input not correct format, please check again.");
                return;
            }
            else
            {
                r1.x = x;
                r1.y = y;
                r1.direction = rd;
                if (r1.x <= 0 || r1.y <= 0)
                {
                    Console.WriteLine("Rover location size can not be less than zero");
                    return;
                }
            }

            //Third input
            Console.WriteLine("Rover-1 Moves: ");
            input = Console.ReadLine().ToUpper();
            inputCharArray = input.ToCharArray();
            RoverControls.RoverAction(r1, inputCharArray, m);

            //Fourth input
            Console.WriteLine("Rover-2 Location and Direction: ");
            input = Console.ReadLine().ToUpper();
            inputArray = input.Split(' ');
            if (inputArray.Length != 3 || !int.TryParse(inputArray[0], out x) || !int.TryParse(inputArray[1], out y) || !Enum.TryParse(inputArray[2], true, out rd))
            {
                Console.WriteLine("Fourth input not correct format, please check again.");
                return;
            }
            else
            {
                r2.x = x;
                r2.y = y;
                r2.direction = rd;
                if (r2.x <= 0 || r2.y <= 0)
                {
                    Console.WriteLine("Rover location size can not be less than zero");
                    return;
                }
            }

            //Fifty input
            Console.WriteLine("Rover-2 Moves: ");
            input = Console.ReadLine().ToUpper();
            inputCharArray = input.ToCharArray();
            RoverControls.RoverAction(r2, inputCharArray, m);

            Console.WriteLine(r1.x.ToString() + ' ' + r1.y.ToString() + ' ' + r1.direction);
            Console.WriteLine(r2.x.ToString() + ' ' + r2.y.ToString() + ' ' + r2.direction);

            Console.Read();
        }
    }
}