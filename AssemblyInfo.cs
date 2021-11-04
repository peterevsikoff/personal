using Xamarin.Forms.Xaml;
using Xamarin.Forms;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("ofont.ru_Whitehall.ttf", Alias = "WhitehallCyr")]

// Needed for Picking photo/video
//[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

//// Needed for Taking photo/video
//[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
//[assembly: UsesPermission(Android.Manifest.Permission.Camera)]

//// Add these properties if you would like to filter out devices that do not have cameras, or set to false to make them optional
//[assembly: UsesFeature("android.hardware.camera", Required = true)]
//[assembly: UsesFeature("android.hardware.camera.autofocus", Required = true)]