using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;

namespace StrategicRise
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("icons.ttf", "IconsTB");
					fonts.AddFont("Poppins-Regular.ttf", "PopR");
					fonts.AddFont("Poppins-Medium.ttf", "PopM");
					fonts.AddFont("Poppins-SemiBold.ttf", "PopS");
				})
				.ConfigureMauiHandlers(handlers =>
				{
#if ANDROID
					handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomeShell));
#endif
				})
				.UseMauiCommunityToolkitCore()
				.UseMauiCommunityToolkit();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
