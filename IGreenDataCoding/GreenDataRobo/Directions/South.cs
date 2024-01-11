using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Directions
{
    public class South : Direction
    {
        public override string CurrentDirection { get; } = nameof(South);
        public override void LeftDirection()
        {
            this.context.ChangeDirection(new East());
        }

        public override void RightDirection()
        {
            this.context.ChangeDirection(new West());
        }
    }
}
