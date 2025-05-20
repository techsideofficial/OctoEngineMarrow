# DOCUMENTATION

## Getting Started
Please see the example `octo_config.xml`, and set all the values that you need. This file is placed next to the DLL.
> [!WARNING]
> Do NOT change the `AppId` property in `octo_config.xml`!

## Methods
### Logging
This will log any message to the console, while logging it to a file at the same time.
Usage:
```csharp
OctoEngine.MarrowFramework.Internal.ModLog.LogMessage("YOUR MESSAGE");
OctoEngine.MarrowFramework.Internal.ModLog.LogWarn("YOUR WARNING");
OctoEngine.MarrowFramework.Internal.ModLog.LogError("YOUR ERROR");
```

### Temporary files
This allows you to write temporary files to store any string you want.
Usage:
```csharp
OctoEngine.TempStorage.WriteTempValue("<NAME>", "<VALUE>");
OctoEngine.TempStorage.ReadTempValue("<NAME>");
OctoEngine.TempStorage.ReadTempLines("<NAME>");
OctoEngine.TempStorage.DeleteTempValue("<NAME>");
```

## Scripts
All scripts are pretty self-explanatory:
https://github.com/techsideofficial/OctoEngineMarrow/tree/main/OctoEngine/MarrowFramework/MarrowFramework
