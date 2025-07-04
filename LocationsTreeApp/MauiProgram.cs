﻿using LocationsTreeApp.Services;
using LocationsTreeApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace LocationsTreeApp
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

            builder.Services
            .AddSingleton<ILocationService, LocationService>()
            .AddSingleton<MainViewModel>()
            .AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
