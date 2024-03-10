using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Commands
{
    // Concrete command for reporting the robot's position
    public class ReportCommand : ICommand
    {
        private ToyRobot robot;

        public ReportCommand(ToyRobot robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.Report();
        }
    }
}
