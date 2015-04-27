using RsRx.EventArgs;
using SharpSenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using RsRx.Enums;

namespace RsRx.Extensions
{
    public static class HandEventStreamExtension
    {
        public static IObservable<HandEventArgs> AsObservable(this Hand hand)
        {
            return Observable.Merge(
                hand.VisibleAsObservable(),
                hand.NotVisibleAsObservable(),
                hand.OpenedAsObservable(),
                hand.ClosedAsObservable(),
                hand.MoveAsObservable(),
                hand.FingerOpenedAsObservable(),
                hand.FingerClosedAsObservable()
                );
        }

        public static IObservable<HandEventArgs> VisibleAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern(
                h => hand.Visible += h,
                h => hand.Visible -= h)
                .Select(args => 
                {
                    return new HandEventArgs(HandEventType.Visible);
                });
        }
        public static IObservable<HandEventArgs> NotVisibleAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern(
                h => hand.NotVisible += h,
                h => hand.NotVisible -= h)
                .Select(args =>
                {
                    return new HandEventArgs(HandEventType.NotVisible);
                });
        }
        public static IObservable<HandEventArgs> OpenedAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern(
                h => hand.Opened += h,
                h => hand.Opened -= h)
                .Select(args =>
                {
                    return new HandEventArgs(HandEventType.Opened);
                });
        }
        public static IObservable<HandEventArgs> ClosedAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern(
                h => hand.Closed += h,
                h => hand.Closed -= h)
                .Select(args =>
                {
                    return new HandEventArgs(HandEventType.Closed);
                });
        }
        public static IObservable<HandEventArgs> MoveAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern<PositionEventArgs>(
                h => hand.Moved += h,
                h => hand.Moved -= h)
                .Select(args =>
                {
                    return new HandEventArgs(HandEventType.Move, args.EventArgs);
                });
        }
        public static IObservable<HandEventArgs> FingerOpenedAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern(
                h => hand.FingerOpened += h,
                h => hand.FingerOpened -= h)
                .Select(args =>
                {
                    return new HandEventArgs(HandEventType.FingerOpened);
                });
        }
        public static IObservable<HandEventArgs> FingerClosedAsObservable(this Hand hand)
        {
            return Observable.FromEventPattern(
                h => hand.FingerClosed += h,
                h => hand.FingerClosed -= h)
                .Select(args =>
                {
                    return new HandEventArgs(HandEventType.FingerClosed);
                });
        }
    }
}
