using SharpSenses.Poses;
using System;
using System.Reactive.Linq;
using RsRx.EventArgs;
using RsRx.Enums;

namespace RsRx.Extensions
{
    public static class PoseStreamExtensions
    {
        public static IObservable<HandPoseEventArgs> PeaceAsObservable(this IPoseSensor poses)
        {
            var start = Observable.FromEventPattern<HandPoseEventArgs>(h => poses.PeaceBegin += h, h => poses.PeaceBegin -= h);
            var end = Observable.FromEventPattern<HandPoseEventArgs>(h => poses.PeaceEnd += h, h => poses.PeaceEnd -= h);

            return Observable.Merge(start, end).Select(pattern => pattern.EventArgs);
        }
        public static IObservable<PoseEventArgs> AsObservable(this Pose pose)
        {
            var start = Observable.FromEventPattern<Pose.PoseEventArgs>(h => pose.Begin += h, h => pose.Begin -= h).Select(args => new PoseEventArgs(pose.Name, PoseEventType.StartEvent));
            var end = Observable.FromEventPattern<Pose.PoseEventArgs>(h => pose.End += h, h => pose.End -= h).Select(args => new PoseEventArgs(pose.Name, PoseEventType.EndEvent));

            return Observable.Merge(start, end);
        }
    }
}
