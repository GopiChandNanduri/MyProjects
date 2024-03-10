using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Commands
{
    // Concrete command for moving the robot
    public class MoveCommand : ICommand
    {
        private ToyRobot robot;

        public MoveCommand(ToyRobot robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.Move();
        }
    }
}
