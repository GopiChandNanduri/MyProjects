using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Directions
{
    public class East : Direction
    {
        public override string CurrentDirection { get; } = nameof(East);
        public override void LeftDirection()
        {
            this.context.ChangeDirection(new North());
        }

        public override void RightDirection()
        {
            this.context.ChangeDirection(new South());
        }
    }
}
