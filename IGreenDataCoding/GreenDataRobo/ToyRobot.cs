using GreenDataRobo.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo
{
    /// <summary>
    /// Receiver class representing the toy robot implementing Command pattern
    /// </summary>
    class ToyRobot
    {
        private bool isPlaced = false;
        private int x;
        private int y;
        private string facing;

        /// <summary>
        /// Placing the Robo
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="facing"></param>
        public void Place(int x, int y, string facing)
        {
            if (!isPlaced && IsValidPosition(x, y))
            {
                isPlaced = true;
                this.x = x;
                this.y = y;
                this.facing = facing;
            }
        }

        /// <summary>
        /// Implement move logic while ensuring the robot stays on the table
        /// </summary>
        public void Move()
        {
            if (!isPlaced)
            {
                return;
            }

            if (facing == "NORTH" && y < 4)
            {
                y++;
            }
            else if (facing == "EAST" && x < 4)
            {
                x++;
            }
            else if (facing == "SOUTH" && y > 0)
            {
                y--;
            }
            else if (facing == "WEST" && x > 0)
            {
                x--;
            }
        }

        /// <summary>
        /// Implement left rotation logic
        /// </summary>
        public void Left()
        {
            if (!isPlaced)
            {
                return;
            }
            if (facing != null)
            {
                var currentDirectionIndex = Array.IndexOf(ToyRobotConstants.DIRECTIONS, facing);
                if (currentDirectionIndex == -1)
                    return;
                var newDirectionIndex = (currentDirectionIndex + 3) % 4; // 3 represents a 90-degree left rotation
                facing = ToyRobotConstants.DIRECTIONS[newDirectionIndex];
                Move();
            }
        }

        /// <summary>
        /// Implement right rotation logic
        /// </summary>
        public void Right()
        {
            if (!isPlaced)
            {
                return;
            }
            if (facing != null)
            {
                var currentDirectionIndex = Array.IndexOf(ToyRobotConstants.DIRECTIONS, facing);
                if (currentDirectionIndex == -1)
                    return;
                var newDirectionIndex = (currentDirectionIndex + 1) % 4; // 1 represents a 90-degree right rotation
                facing = ToyRobotConstants.DIRECTIONS[newDirectionIndex];
                Move();
            }
        }

        /// <summary>
        /// Robot's position
        /// </summary>
        public void Report()
        {
            if (!isPlaced)
            {
                Console.WriteLine($"Output: ");
                return;
            }
            Console.WriteLine($"Output: {x},{y},{facing}");

        }

        /// <summary>
        /// Implement validation logic for the position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= 4 && y >= 0 && y <= 4;
        }
    }
}
