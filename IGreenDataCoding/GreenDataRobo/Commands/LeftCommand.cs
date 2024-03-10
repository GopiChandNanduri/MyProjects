using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Commands
{
    // Concrete command for rotating the robot to the left
    public class LeftCommand : ICommand
    {
        private ToyRobot robot;

        public LeftCommand(ToyRobot robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.Left();
        }
    }
}
