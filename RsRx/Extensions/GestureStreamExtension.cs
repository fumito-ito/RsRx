using SharpSenses.Gestures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsRx.Extensions
{
    public static class GestureStreamExtension
    {

        public static IObservable<GestureEventArgs> AsObservable(this IGestureSensor gesture)
        {
            return Observable.Merge(
                gesture.MoveForwardAsObservable(),
                gesture.SlideDownAsObservable(),
                gesture.SlideUpAsObservable(),
                gesture.SlideLeftAsObservable(),
                gesture.SlideRightAsObservable(),
                gesture.WaveAsObservable());
        }

        public static IObservable<GestureEventArgs> MoveForwardAsObservable(this IGestureSensor gesture)
        {
            return Observable.FromEventPattern<GestureEventArgs>(
                h => gesture.MoveForward += h,
                h => gesture.MoveForward -= h)
                .Select(args =>
                {
                    return args.EventArgs;
                });
        }

        public static IObservable<GestureEventArgs> SlideDownAsObservable(this IGestureSensor gesture)
        {
            return Observable.FromEventPattern<GestureEventArgs>(
                h => gesture.SlideDown += h,
                h => gesture.SlideDown -= h)
                .Select(args =>
                {
                    return args.EventArgs;
                });
        }

        public static IObservable<GestureEventArgs> SlideUpAsObservable(this IGestureSensor gesture)
        {
            return Observable.FromEventPattern<GestureEventArgs>(
                h => gesture.SlideUp += h,
                h => gesture.SlideUp -= h)
                .Select(args =>
                {
                    return args.EventArgs;
                });
        }

        public static IObservable<GestureEventArgs> SlideLeftAsObservable(this IGestureSensor gesture)
        {
            return Observable.FromEventPattern<GestureEventArgs>(
                h => gesture.SlideLeft += h,
                h => gesture.SlideLeft -= h)
                .Select(args =>
                {
                    return args.EventArgs;
                });
        }

        public static IObservable<GestureEventArgs> SlideRightAsObservable(this IGestureSensor gesture)
        {
            return Observable.FromEventPattern<GestureEventArgs>(
                h => gesture.SlideRight += h,
                h => gesture.SlideRight -= h)
                .Select(args =>
                {
                    return args.EventArgs;
                });
        }

        public static IObservable<GestureEventArgs> WaveAsObservable(this IGestureSensor gesture)
        {
            return Observable.FromEventPattern<GestureEventArgs>(
                h => gesture.Wave += h,
                h => gesture.Wave -= h)
                .Select(args =>
                {
                    return args.EventArgs;
                });
        }
    }
}
