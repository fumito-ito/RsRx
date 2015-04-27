using RsRx.Enums;
using SharpSenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsRx.EventArgs
{
    public class HandEventArgs
    {
        public HandEventType EventType { get; private set; }

        public PositionEventArgs PositionEventArgs { get; private set; }

        private HandEventArgs()
        {
        }

        public HandEventArgs(HandEventType type)
        {
            this.EventType = type;
        }

        public HandEventArgs(HandEventType type, PositionEventArgs e)
        {
            this.EventType = type;
            this.PositionEventArgs = e;
        }
    }
}
