// TextBufferService.cs
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

namespace retrans.Services;

public interface ITextService {
    Task FlushAsync();
    void Write(TextChangedEventArgs e);
}

/// <inheritdoc cref="System.IO.MemoryStream" />
public class TextBufferService : ITextService {
    private readonly object _lock = new();
    private readonly ISpeechService _speechService;
    private string _pendingSpeech;

    public TextBufferService(ISpeechService speechService) { _speechService = speechService; }

    /// <summary>
    ///     Update the buffer with current input. This will completely replace the buffer
    /// </summary>
    /// <param name="e"></param>
    public void Write(TextChangedEventArgs e) { _pendingSpeech = e.NewTextValue; }

    public async Task FlushAsync() {
        await _speechService.Speak(_pendingSpeech);
        _pendingSpeech = "";
    }
}
