using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.TextInputLayout;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MyCollageCardsMobileApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfRatingRenderer.Init();
            SfListViewRenderer.Init();
            SfComboBoxRenderer.Init();
            SfTextInputLayoutRenderer.Init();
            SfSegmentedControlRenderer.Init();
            SfRadioButtonRenderer.Init();
            SfAvatarViewRenderer.Init();
            SfBorderRenderer.Init();
            SfButtonRenderer.Init();
            SfGradientViewRenderer.Init();

            LoadApplication(new App());

            //LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
            //  new UXDivers.Gorilla.Config("Good Gorilla")
            //      // Register Grial Shared assembly
            //      //.RegisterAssemblyFromType<UXDivers.Artina.Shared.CircleImage>()
            //      // Register UXDivers Effects assembly
            //      .RegisterAssembly(typeof(UXDivers.Effects.Effects).Assembly)
            //      // FFImageLoading.Transformations
            //      .RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
            //      // FFImageLoading.Forms
            //      .RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()
            //));

            return base.FinishedLaunching(app, options);
        }
    }
}
