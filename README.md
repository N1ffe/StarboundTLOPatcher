# StarboundTLOPatcher
### About
StarboundTLOPatcher is a program designed specifically for automating the process of creating patches for [Tanz Lighting Overhaul](https://steamcommunity.com/sharedfiles/filedetails/?id=729467376) mod.
**Anyone is free to use it to create and upload mods/patches.** Just don't forget to put a link to this program so more people can see it.

### How to use
#### If using the source code
Move or copy patch.json file to the binaries folder, and then you can compile the project by yourself.
#### If using the compiled program
Download .json, .dll, .exe, .runtimeconfig.json files (can be found in the Releases tab) and save them in the same folder.
Launch the .exe file from command line (command prompt) and specify 2 parameters:
1. Full path to the target mod **object** folder
2. Full path to your mod folder

Example: StarboundTLOPatcher.exe "C:\ModName\objects" "C:\YourMod"

The program will create patches for files in the folder of your mod, including all the subfolders. It automatically checks if object emits light and does not have dynamic lighting yet, and if so, then it creates a patch for that object.
