# RsRx

Reactive extensions for Intel Realsense SDK (C#) for Windows

**This repository just only README!! please wait my contribution.**

## Description

There was only painfull way to use Intel RealSense SDK (C#) for Windows.  
This module provides easier way to use RealSense SDK by the [SharpSenses](https://github.com/SharpSenses) infrastructure and [Rx](https://rx.codeplex.com/) syntax.

It supports hand tracking, gesture, custom poses, face expressions and much more.

## Demo

T.B.D.

## Requirement

- RealSense SDK
- Intel 3D Camera Driver
- .NET Framework 4.5

## Dependency

- [SharpSenses.RealSense](https://github.com/SharpSenses/SharpSenses)
    - Great works by [Andre Carlucci](https://github.com/andrecarlucci) for easier way to use RealSense SDK.
- [Rx.NET](https://github.com/Reactive-Extensions/Rx.NET)
    - Reactive Extensions for .NETFramwork (a.k.a. `Rx`). This module depends on [Rx-Core](https://www.nuget.org/packages/Rx-Core/) module.

## Usage

```cs
ICamera cam = Camera.Create();

// hand event as observable
cam.RightHand.MoveAsObservable().Subscribe( (s,a) =>
{
    Console.WriteLine("-> x:{0} y:{1}", a.Position.Image.X, a.Position.Image.Y);
});

// gesture as observable
cam.Gestures.SlideLeftAsObservable().Subscribe( (s, a) => Console.WriteLine("Swipe Left"));

// poses as observable
cam.Poses.PeaceAsObservable().Subscribe(
    hand => Console.WriteLine("Make love, not war"),
    ex => Console.WriteLine(""),
    () => Console.WriteLine("Bye!"));

// facial expression as observable
cam.Face.FacialExpressionAsObservable().Subscribe( (s,e) =>
{
    Console.WriteLine("FacialExpression: " + e.NewFacialExpression);
});

// face recognition
cam.Face.PersonRecognizedAsObservable().Subscribe( (s,a) =>
{
    Console.WriteLine("Hello " + a.UserId);
});

// speech recognition
cam.Speech.SpeechRecognizeAsObservable().Subscribe( (s,a) =>
{
    Console.WriteLine("-> " + a.Sentence);
});


// start sampling
cam.Start();
```

## Install

Install from [Nuget Gallery](https://www.nuget.org/packages/RsRx/)

```
PM> Install-Package RsRx
```

## LICENSE

[The MIT License](https://github.com/fumitoito/RsRx/blob/master/LICENSE)

## Author

[fumitoito](https://github.com/fumitoito)
