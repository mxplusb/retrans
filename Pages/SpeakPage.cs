// SpeakPage.cs
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

using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Layouts;
using retrans.Utils;
using retrans.ViewModels;

#endregion

namespace retrans.Pages;

[SuppressMessage("ReSharper", "RedundantLambdaParameterType")]
public class SpeakPage : BaseContentPage<SpeakViewModel> {
    public SpeakPage(SpeakViewModel viewModel) : base(viewModel) {
        var tooltipIcon = new Label {
            Text = MaterialDesignIcons.InformationSymbol, FontSize = 20, FontFamily = "MaterialDesignIcons"
        };
        ToolTipProperties.SetText(tooltipIcon,
                                  "When the box is checked, individual words "
                                  + "automatically sent for speech generation. When you hit the space key, it will send that word, and then "
                                  + "remove it from the text box. It's highly recommended to test this before using it with others!");

        var speakBox = new Entry {
            Placeholder = "What do you want to say?", IsSpellCheckEnabled = true, IsTextPredictionEnabled = true
        }.Bind(Entry.TextProperty,
               static (SpeakViewModel vm) => vm.PendingText,
               static (SpeakViewModel vm, string msg) => vm.PendingText = msg);
        speakBox.TextChanged += viewModel.OnEntryTextChanged;
        speakBox.Completed += viewModel.OnEntryCompleted;

        Content = new VerticalStackLayout {
            Spacing = 5,
            Padding = 15,
            Children = {
                speakBox,
                new FlexLayout {
                    Wrap = FlexWrap.NoWrap,
                    JustifyContent = FlexJustify.Center,

                    // AlignItems = FlexAlignItems.Center,
                    Padding = 2,
                    Children = {
                        new CheckBox().Bind(CheckBox.IsCheckedProperty,
                                            static (SpeakViewModel vm) => vm.IsLive,
                                            static (SpeakViewModel vm, bool isSet) => vm.IsLive = isSet),
                        new Label { Text = "Enable live speaking", FontSize = 14 }.Padding(2),
                        tooltipIcon
                    }
                },
                new Button { Text = "Speak" }.BindCommand(static (SpeakViewModel vm) => vm.Speak)
            }
        };
    }
}
