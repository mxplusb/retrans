// SpeakViewModel.cs
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

using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using retrans.Services;

#endregion

namespace retrans.ViewModels;

public partial class SpeakViewModel : BaseViewModel {
    private readonly ITextService _textService;

    [ObservableProperty]
    private bool _isLive;

    [ObservableProperty]
    private string _pendingText;

    public SpeakViewModel(ITextService textService) {
        _textService = textService;
        Speak = new Command(() => {
                                Task.Run(async () => await _textService.FlushAsync());
                                PendingText = "";
                            },
                            () => !IsLive); // todo (sienna): figure this out
    }

    public ICommand Speak { get; private set; }

    public void OnEntryTextChanged(object sender, TextChangedEventArgs e) { _textService.Write(e); }

    public void OnEntryCompleted(object sender, EventArgs e) {
        var text = ((Entry)sender).Text;

        Trace.WriteLine($"sent text: {text}");
        Task.Run(async () => await _textService.FlushAsync());

        PendingText = "";
    }
}
