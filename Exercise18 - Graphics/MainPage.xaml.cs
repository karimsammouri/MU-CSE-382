using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Diagnostics;

namespace Graphics
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        bool pageIsActive;
        Color color1 = Color.Red;
        Color color2 = Color.Blue;

        public MainPage()
        {
            InitializeComponent();
        }

        private static float PointsPerInch = Device.RuntimePlatform == "UWP" ? 96 : 160;
        private static float PPI = (float)DeviceDisplay.MainDisplayInfo.Density * PointsPerInch;
        private float PixelsToInches(float pixs)
        {
            return pixs / PPI;
        }

        private float InchesToPixels(float inches)
        {
            return inches * PPI;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            pageIsActive = true;
            await AnimationLoop();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pageIsActive = false;
        }

        async Task AnimationLoop()
        {
        }

        void OnCanvasViewPaintSurface1(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint1 = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = color1.ToSKColor(),
            };
            SKPaint paint2 = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = color2.ToSKColor(),
            };
            float r = InchesToPixels(2.0f);
            canvas.DrawRect(0, 0, 700, 1000, paint1);
            //canvas.DrawRect(100, 100, 10, 20, paint2);
        }

        void OnCanvasViewPaintSurface2(object sender, SKPaintSurfaceEventArgs args)
        {
            int height = Convert.ToInt32(entry2.Text);
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint1 = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = color1.ToSKColor(),
            };
            SKPaint paint2 = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = color2.ToSKColor(),
            };
            canvas.DrawRect(info.Width/2, 0, 350, height, paint1);
            //canvas.DrawRect(100, 100, 10, 20, paint2);
        }
    }
}
