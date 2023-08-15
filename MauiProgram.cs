// MauiProgram.cs
// Copyright (C) 2023-2023 Sienna Lloyd
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License

#region

using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using retrans.Pages;
using retrans.Services;
using retrans.ViewModels;

#endregion

namespace retrans;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("materialdesignicons.ttf", "MaterialDesignIcons");
            });

#if DEBUG
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
#endif

        // builder.Services.AddAzureClients(x =>
        // {
        //     x.UseCredential(new DefaultAzureCredential());
        // });

        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<ITextService, TextBufferService>();
        builder.Services.AddSingleton<ISpeechService, SpeechService>();

        // builder.Services.AddTransientWithShellRoute<MainPage, MainViewModel>($"//{nameof(MainPage)}");
        builder.Services.AddTransientWithShellRoute<SpeakPage, SpeakViewModel>($"//{nameof(SpeakPage)}");

        return builder.Build();
    }
}
