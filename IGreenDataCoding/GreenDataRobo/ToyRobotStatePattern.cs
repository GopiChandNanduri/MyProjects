using GreenDataRobo.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo
{
    /// <summary>
    /// Receiver class representing the toy robot implementing State pattern on Directions
    /// </summary>
    public class ToyRobotStatePattern
    {
        private Dictionary<string, Direction> directionMapping = new Dictionary<string, Direction>();

        public ToyRobotStatePattern()
        {
            directionMapping.Add("NORTH", new North());
            directionMapping.Add("EAST", new East());
            directionMapping.Add("WEST", new West());
            directionMapping.Add("SOUTH", new South());
        }

        private bool isPlaced = false;
        private int positionX;

        private int PositionX
        {
            get { return positionX; }
            set
            {
                if (positionX < 0 || positionX > 4)
                    return;
                else
                    positionX = value;
            }
        }

        private int positionY;

        private int PositionY
        {
            get { return positionY; }
            set
            {
                if (positionY < 0 || positionY > 4)
                    return;
                else
                    positionY = value;
            }
        }

        private DirectionDetails directionDetails = null;

        public void Place(int x, int y, string facing)
        {
            if (!isPlaced)
            {
                if (IsValid(x) && IsValid(y) &&
                    directionMapping.TryGetValue(facing, out Direction direction))
                {
                    isPlaced = true;
                    if (directionDetails == null)
                        directionDetails = new DirectionDetails(direction);

                    PositionY = y;
                    PositionX = x;
                }
            }
        }

        public void Move()
        {
            if (!isPlaced) return;

            string facingDirection = directionDetails.GetCurrentDirection();

            if (facingDirection == "NORTH")
            {
                PositionY++;
            }
            else if (facingDirection == "EAST" )
            {
                PositionX++;
            }
            else if (facingDirection == "SOUTH" )
            {
                PositionY--;
            }
            else if (facingDirection == "WEST" )
            {
                PositionX--;
            }
        }

        public void Left()
        {
            if (!isPlaced) return;
            // update direction
            directionDetails.LeftDirection();

            // update coordinates
            Move();
        }

        public void Right()
        {
            if (!isPlaced) return;

            // update direction
            directionDetails.RightDirection();

            // update coordinates
            Move();

        }

        public (int x, int y, string facing) Report()
        {
            if (!isPlaced) return new(-1, -1, "");
            return new(positionX, positionY, directionDetails.GetCurrentDirection());
        }

        private bool IsValid(int position)
        {
            if (position < 0 && position > 4)
                return false;
            else
                return true;
        }

    }
}
