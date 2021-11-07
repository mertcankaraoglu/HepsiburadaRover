using HepsiburadaRover.BusinessLogicLayer;
using HepsiburadaRover.EntityLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HepsiburadaRover.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void RoverActionTest()
        {
            Rover r1 = new Rover { x = 2, y = 2, direction = EntityLayer.Enum.Directions.N };
            char[] moves = { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };
            Matrix m = new Matrix { x = 10, y = 10 };
            RoverControls.RoverAction(r1, moves, m);

            Rover r2 = new Rover();
            r2.x = 2;r2.y = 3;r2.direction = EntityLayer.Enum.Directions.N;
            Assert.ReferenceEquals(r1, r2);
        }

        [TestMethod]
        public void RoverTurnTest()
        {
            Rover r1 = new Rover { x = 2, y = 2, direction = EntityLayer.Enum.Directions.N };
            RoverControls.RoverTurn(r1,EntityLayer.Enum.Moves.L);
            Rover r2 = new Rover();
            r2.x = 2; r2.y = 2; r2.direction = EntityLayer.Enum.Directions.W;
            Assert.ReferenceEquals(r1, r2);
        }

    }
}
