using RsRx.Enums;
using SharpSenses.Poses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsRx.EventArgs
{
    public class PoseEventArgs : Pose.PoseEventArgs
    {
        public PoseEventArgs(string poseName, PoseEventType type) : base(poseName)
        {
            this.EventType = type;
        }

        public PoseEventType EventType {get; private set;}
    }
}
