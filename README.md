# StarboundTLOPatcher
### About
StarboundTLOPatcher is a program designed specifically for automating process of creating patches for [Tanz Lighting Overhaul](https://steamcommunity.com/sharedfiles/filedetails/?id=729467376) mod.

### How to use
Launch a compiled .exe file from command line and specify 2 parameters:
1. Full path to the target mod **object** folder
2. Full path to your mod folder

Example: StarboundTLOPatcher.exe "C:\ModName\objects" "C:\YourMod"

The program will create patches for files in the folder of your mod, including all the subfolders. It automatically checks if object emits light and does not have dynamic lighting yet, and if so, then it creates a patch for that object.
