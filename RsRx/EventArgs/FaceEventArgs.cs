using RsRx.Enums;
using SharpSenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsRx.EventArgs
{
    public class FaceEventArgs : System.EventArgs
    {
        public FaceEventType EventType { get; private set; }

        public PositionEventArgs Position { get; private set; }

        public FacialExpressionEventArgs FacialExpression { get; private set; }

        public FaceRecognizedEventArgs FaceRecognized { get; private set; }

        public DirectionEventArgs Direction { get; private set; }

        private FaceEventArgs() { }

        public FaceEventArgs(FaceEventType type)
        {
            this.EventType = type;
        }

        public FaceEventArgs(FaceEventType type, PositionEventArgs position)
        {
            this.EventType = type;
            this.Position = position;
        }

        public FaceEventArgs(FaceEventType type, FacialExpressionEventArgs facialExpression)
        {
            this.EventType = type;
            this.FacialExpression = facialExpression;
        }

        public FaceEventArgs(FaceEventType type, FaceRecognizedEventArgs faceRecognized)
        {
            this.EventType = type;
            this.FaceRecognized = faceRecognized;
        }

        public FaceEventArgs(FaceEventType type, DirectionEventArgs direction)
        {
            this.EventType = type;
            this.Direction = direction;
        }
    }
}
