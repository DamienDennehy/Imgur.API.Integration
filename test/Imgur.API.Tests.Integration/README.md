# Running Integration Tests

## config.json settings
Integration Tests require several settings to be set in the config.json file.

These variables contain the Imgur and Mashape authentication settings.

**ClientId**: The Imgur App ClientId.

**ClientSecret**: The Imgur App ClientSecret.

**MashapeKey**: The Mashape Key for commercial applications.

**AccessToken**: An OAuth2 access token for testing Imgur API methods that require user authentication.

**RefreshToken**: An OAuth2 refresh token for testing Imgur API methods that require user authentication.

## Preventing config.json commits
The config.json file shouldn't be committed using your ClientId and Secret. After checking out this repository from GitHub open a Git Shell and run the following command:

git update-index --assume-unchanged .\test\Imgur.API.Tests.Integration\config.json

This will prevent changes to the file being commited as long as the repository exists on your machine.