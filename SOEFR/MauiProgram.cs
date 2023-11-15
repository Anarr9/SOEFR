using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using SOEFR.Views;
using Shiny;

namespace SOEFR;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            //.UseShiny()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("GemunuLibre-Bold.ttf", "Bold");
                fonts.AddFont("GemunuLibre-ExtraBold.ttf", "ExtraBold");
                fonts.AddFont("GemunuLibre-ExtraLight.ttf", "ExtraLight");
                fonts.AddFont("GemunuLibre-Light.ttf", "Light");
                fonts.AddFont("GemunuLibre-Medium.ttf", "Medium");
                fonts.AddFont("GemunuLibre-Regular.ttf", "Regular");
                fonts.AddFont("GemunuLibre-SemiBold.ttf", "SemiBold");
                fonts.AddFont("fontello.ttf", "Icons");

                fonts.AddFont("playsolid.svg", "FontAwesomeSolid");

            });
		builder.Services.AddSingleton(AudioManager.Current);
		builder.Services.AddTransient<HomePage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

