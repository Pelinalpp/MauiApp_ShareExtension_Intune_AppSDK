using MauiApplication.Helpers;
using MauiApplication.Services;
using Microsoft.Extensions.Logging;

#if IOS
using MauiApplication.Platforms.iOS.IntuneAuthentication;
#else
using MauiApplication.Platforms.Android.IntuneAuthentication;
#endif

namespace MauiApplication
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<IIntuneAuthenticationService, IntuneAuthenticationService>();

            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);

            return app;
        }
    }
}
