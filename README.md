<a href="https://github.com/zpar-ky/RoundSplitter/releases/latest/download/RoundSplitter.dll">
    <img align="left" alt="Icon" height="90" src="Icon.png">
    <img align="right" alt="Download" height="75" src="https://raw.githubusercontent.com/gurrenm3/BTD-Mod-Helper/master/BloonsTD6%20Mod%20Helper/Resources/DownloadBtn.png">
</a>

# BTD6 Autosplitter  
---
## Features  
---
* Customizable automatic splits for [LiveSplit](https://livesplit.org/)
* Automatic starting and restarting the timer

Based on hemisemidemipresent's [AutoSplitter](https://github.com/hemisemidemipresent/AutoSplitter-btd6) mod.

## Install:  
---
* Move your livesplit directory into `Mods/` and name it `LiveSplit`
* Copy `RoundSplitter.dll` into your `Mods/` directory
* Copy `splits.asl` into your `Mods/` directory

The expected structure is:
```
BloonsTD6
  - Mods
    - LiveSplit
      - LiveSplit.exe
      - ...
    - RoundSplitter.dll
    - splits.asl
    - ...
```

## Usage
--- 
* Have your splits correct for your mode. **IMPORTANT!** You *need* a victory split at the end! 
  * e.g. Medium: r20, r40, r60, **Victory**
* Add the autosplitting to LiveSplit:
  * Right click the timer > Edit Layout... > and add `Control/Scriptable Auto Splitter` and select `splits.asl` for the Script Path.
* The time between hitting play and starting fast-forward is **not** taken into account. Be fast! ;)

## Custom splits
---
If you want custom splits different from every 20 rounds, see the notes in `splits.asl` and `RoundSplitter.cs`.  
Modifying `splits.asl` does **NOT** require rebuilding the dll - the mod by default updates every 5 rounds (that is, every round divisible by 5) - so you can have splits every 5, 10, 15, 20, etc rounds without needing to rebuild the dll.  
If you do need to rebuild, it shouldn't be too terrible since the whole project is uploaded. See the [BTD-Mod-Helper wiki](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Prerequisites) to get started with building.

---
## Disclaimer
---
This mod is provided 'as-is' and I cannot guarentee your btd6 account's safety using this mod. I also cannot guarentee the mods speed and accuracy in controlling LiveSplit - doing a lot of file IO to control things sounds terrible but unless I dive deeper into btd6 modding it'll probably stay as it is.  
If you run into issues, open an issue!

[![Requires BTD6 Mod Helper](https://raw.githubusercontent.com/gurrenm3/BTD-Mod-Helper/master/banner.png)](https://github.com/gurrenm3/BTD-Mod-Helper#readme)
