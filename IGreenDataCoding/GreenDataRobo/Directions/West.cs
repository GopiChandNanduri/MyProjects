using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Directions
{
    public class West : Direction
    {
        public override string CurrentDirection { get; } = nameof(West);
        public override void LeftDirection()
        {
            this.context.ChangeDirection(new South());
        }

        public override void RightDirection()
        {
            this.context.ChangeDirection(new North());
        }
    }
}
