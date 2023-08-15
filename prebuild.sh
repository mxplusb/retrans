#!/bin/bash

cat << EOF > consts.cs
namespace retrans; 

public static class Global {
    public const string SpeechKey = "${SPEECH_KEY}";
    public const string AzureClientId = "${AZURE_CLIENT_ID}";
    public const string AzureClientSecret = "${AZURE_CLIENT_SECRET}";
}
EOF