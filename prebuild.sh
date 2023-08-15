#!/bin/bash

cat << EOF > consts.cs
namespace retrans; 

public static class Global {
    public const string SpeechKey = "${SPEECH_KEY}";
}
EOF