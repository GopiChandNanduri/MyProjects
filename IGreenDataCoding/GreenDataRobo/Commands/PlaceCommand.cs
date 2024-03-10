using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Commands
{
    // Concrete command for placing the robot
    public class PlaceCommand : ICommand
    {
        private ToyRobot robot;
        private int x, y;
        private string facing;

        public PlaceCommand(ToyRobot robot, int x, int y, string facing)
        {
            this.robot = robot;
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public void Execute()
        {
            robot.Place(x, y, facing);
        }
    }
}
