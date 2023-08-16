#!/bin/bash

# shellcheck disable=SC2043
for file in src/consts.cs; do
  cat << EOF > $file
namespace retrans; 

public static class Global {
    public const string AzureClientId = "${AZURE_CLIENT_ID}";
    public const string AzureClientSecret = "${AZURE_CLIENT_SECRET}";
    public const string BuildNumber = "${BUILD_NUMBER}";
    public const string SpeechKey = "${SPEECH_KEY}";
}
EOF
done