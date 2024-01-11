using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Directions
{
    public class DirectionDetails
    {
        private Direction direction = null;

        public DirectionDetails(Direction direction)
        {
            this.direction = direction;
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        public string GetCurrentDirection() => direction.CurrentDirection;

        public void LeftDirection()
        {
            this.direction.LeftDirection();
        }

        public void RightDirection()
        {
            this.direction.RightDirection();
        }

    }
}
