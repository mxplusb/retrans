// MainPage.cs
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

using CommunityToolkit.Maui.Markup;
using retrans.ViewModels;

#endregion

namespace retrans.Pages;

public class MainPage : BaseContentPage<MainViewModel> {
    public MainPage(MainViewModel mainViewModel) : base(mainViewModel) {
        Title = "Demo Page";
        Content = new ScrollView {
            Content = new VerticalStackLayout {
                Spacing = 25,
                Padding = 30,
                Children = {
                    new Label()
                        .Text("Hello World")
                        .Font(size: 32)
                        .CenterHorizontal(),
                    new Label()
                        .Text("Welcome to .NET MAUI Markup Community Toolkit Sample")
                        .Font(size: 18)
                        .CenterHorizontal(),
                    new Label()
                        .Font(size: 18, bold: true)
                        .CenterHorizontal()
                        .Bind(Label.TextProperty,
                              static (MainViewModel vm) => vm.ClickCount,
                              convert: count => $"Current Count: {count}"),
                    new Button()
                        .Text("Click Me")
                        .Font(bold: true)
                        .CenterHorizontal()
                        .Bind(Button.CommandProperty,
                              static (MainViewModel vm) => vm.IncrementClickMeButtonCommand,
                              mode: BindingMode.OneTime),
                    new Image()
                        .Source("dotnet_bot")
                        .Size(250, 310)
                        .CenterHorizontal()
                }
            }
        };
    }
}
