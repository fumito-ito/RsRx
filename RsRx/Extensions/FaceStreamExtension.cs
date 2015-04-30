using RsRx.EventArgs;
using SharpSenses;
using System;
using System.Reactive.Linq;
using RsRx.Enums;

namespace RsRx.Extensions
{
    public static class FaceStreamExtension
    {
        public static IObservable<FaceEventArgs> AsObservable(this Face face)
        {
            return Observable.Merge(
                face.EyesDirectionAsObservable(),
                face.FaceRecognizedAsObservable(),
                face.FacialExpressionAsObservable(),
                face.MovedAsObservable(),
                face.VisibleAsObservable(),
                face.NotVisibleAsObservable(),
                face.YawnedAsObservable());
        }

        public static IObservable<bool> VisibilityAsObservable(this Face face)
        {
            return Observable.Merge(
                face.VisibleAsObservable(),
                face.NotVisibleAsObservable())
                .Select(args => args.EventType.Equals(FaceEventType.Visible));
        }

        public static IObservable<FaceEventArgs> EyesDirectionAsObservable(this Face face)
        {
            return Observable.FromEventPattern<DirectionEventArgs>(
                h => face.EyesDirectionChanged += h,
                h => face.EyesDirectionChanged -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.EyesDirectionChanged, args.EventArgs);
                });
        }

        public static IObservable<FaceEventArgs> FaceRecognizedAsObservable(this Face face)
        {
            return Observable.FromEventPattern<FaceRecognizedEventArgs>(
                h => face.FaceRecognized += h,
                h => face.FaceRecognized -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.FaceRecognized, args.EventArgs);
                });
        }

        public static IObservable<FaceEventArgs> FacialExpressionAsObservable(this Face face)
        {
            return Observable.FromEventPattern<FacialExpressionEventArgs>(
                h => face.FacialExpresssionChanged += h,
                h => face.FacialExpresssionChanged -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.FacialExpressionChanged, args.EventArgs);
                });
        }

        public static IObservable<FaceEventArgs> MovedAsObservable(this Face face)
        {
            return Observable.FromEventPattern<PositionEventArgs>(
                h => face.Moved += h,
                h => face.Moved -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.Moved, args.EventArgs);
                });
        }

        public static IObservable<FaceEventArgs> VisibleAsObservable(this Face face)
        {
            return Observable.FromEventPattern(
                h => face.Visible += h,
                h => face.Visible -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.Visible);
                });
        }

        public static IObservable<FaceEventArgs> NotVisibleAsObservable(this Face face)
        {
            return Observable.FromEventPattern(
                h => face.NotVisible += h,
                h => face.NotVisible -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.NotVisible);
                });
        }

        public static IObservable<FaceEventArgs> YawnedAsObservable(this Face face)
        {
            return Observable.FromEventPattern<System.EventArgs>(
                h => face.Yawned += h,
                h => face.Yawned -= h
                ).Select(args =>
                {
                    return new FaceEventArgs(FaceEventType.Yawned);
                });
        }
    }
}
