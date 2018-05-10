# BattleTech Real Hit Chance
This is a mod for BattleTech to display real hit chances in the UI.

## Motivation
In the release version of BattleTech, displayed attack hit chances are not accurate, because to-hit rolls are corrected before comparing to a hit chance.
The effect of that correction is that easy attacks are actually easier than shown, and difficult attacks are more difficult.

Many players prefer to see actual hit chances though.

## Scope
This mod only fixes the chance as displayed in the UI.

It does not (currently):
- change any to hit chances, or any other game logic
- fix AI estimation of hit chances to acount for correction
- provide options to use uncorrected rolls
- disable or display streak-breaking

## Security Notice & Disclaimer

Harmony mods like this one modify your game code at runtime. They inject arbitrary .NET code into Unity engine, that potentially could do harmful things to your computer.

By running mods of this kind you are trusting the authors of the mod, BTML and Harmony to the same extent as you are already trusting the authors of BattleTech game itself.

While every effort was made to keep this mod safe, author(s) cannot provide any warranty or accept any responsibility. It is provided "as is" and using it is at the user's own risk.

## Usage

This mod uses [Harmony](https://github.com/pardeike/Harmony) and [BTML](https://github.com/Mpstark/BattleTechModLoader).

1. Download and install [BTML](https://github.com/Mpstark/BattleTechModLoader#installingupdating)
2. Download the latest release of this mod from [nexus](https://www.nexusmods.com/battletech/mods/90) or [github](https://github.com/alexanderabramov/bt-real-hit-chance/releases)
3. Unpack AA.BT.RealHitChance.dll into BATTLETECH\Mods\
4. After launching the game, check that BATTLETECH\Mods\BTModLoader.log has a line "Found DLL: AA.BT.RealHitChance.dll" and no errors

## Reporting issues

If you run into any issues, please include BTModLoader.log, a screenshot, a save game, a clear description etc with your report to make it easy to reproduce the issue.

## Building

If you are would like to build from source or contribute an improvement, you can!

1. Clone this repository
2. Link game and Unity dlls, e.g. by running "mklink /D BattleTech "C:\Program Files (x86)\Steam\steamapps\common\BATTLETECH\BattleTech_Data\Managed"" from "lib" folder
3. Compile and run tests with Visual Studio
