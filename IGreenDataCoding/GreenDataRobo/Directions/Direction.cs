using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDataRobo.Directions
{
    public abstract class Direction
    {
        protected DirectionDetails context;
        public void SetContext(DirectionDetails context)
        {
            this.context = context;
        }

        public abstract string CurrentDirection { get; }
        public abstract void LeftDirection();
        public abstract void RightDirection();

    }
}
