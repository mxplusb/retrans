// SpeechService.cs
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
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

#endregion

namespace retrans.Services;

public interface ISpeechService {
    Task Speak(string s);
}

public class SpeechService : ISpeechService {
    private readonly AudioConfig _audioConfig;
    private readonly SpeechConfig _speechConfig;
    private readonly SpeechSynthesizer _speechSynthesizer;

    public SpeechService() {
        _speechConfig = SpeechConfig.FromSubscription(Global.SpeechKey, "westcentralus");

        // _audioConfig = AudioConfig.FromDefaultSpeakerOutput();

        _speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";
        _speechSynthesizer = new SpeechSynthesizer(_speechConfig);
    }

    public async Task Speak(string s) {
#if DEBUG
        Trace.WriteLine($"sending: {s}");
#endif

        var result = await _speechSynthesizer.SpeakTextAsync(s);
        Result(result);
    }

    public static void Result(SpeechSynthesisResult result) {
        switch (result.Reason) {
            case ResultReason.SynthesizingAudioCompleted:
#if DEBUG
                Trace.WriteLine("Speech Synthesized");
#endif
                break;
            case ResultReason.Canceled:
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error) {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                    Console.WriteLine("CANCELED: Did you set the speech resource key and region values?");
                }

                break;
        }
    }
}
