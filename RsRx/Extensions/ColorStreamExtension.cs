using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsRx.Extensions
{
    public static class ColorStreamExtension
    {
        private static float colorStreamFPS = 30;

        public static void InitializeColorStream(this PXCMSenseManager manager)
        {
            manager.InitializeColorStream(640, 380, 30);
        }

        public static void InitializeColorStream(this PXCMSenseManager manager, int width, int height, float fps)
        {
            colorStreamFPS = fps;
            manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, width, height, fps);
        }

        public static IObservable<Bitmap> AsObservable(this PXCMSenseManager manager)
        {
            // TODO: refer stream fps
            var interval = Math.Floor((double)(1000 / colorStreamFPS));
            return Observable.Interval(TimeSpan.FromMilliseconds(interval))
                .Where(_ => manager.AcquireFrame(true) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                .Select(_ =>
                {
                    PXCMCapture.Sample sample = manager.QuerySample();
                    PXCMImage image = sample.color;
                    PXCMImage.ImageData imageData;

                    image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_RGB32, out imageData);
                    Bitmap bitmapImage = imageData.ToBitmap(0, image.info.width, image.info.height);

                    image.ReleaseAccess(imageData);
                    manager.ReleaseFrame();

                    return bitmapImage;
                });
        }
    }
}
