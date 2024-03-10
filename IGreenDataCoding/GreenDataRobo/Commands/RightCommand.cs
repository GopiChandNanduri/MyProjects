using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Commands
{
    // Concrete command for rotating the robot to the right
    public class RightCommand : ICommand
    {
        private ToyRobot robot;

        public RightCommand(ToyRobot robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.Right();
        }
    }
}
