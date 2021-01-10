![Release](https://github.com/Mutagen-Modding/Mutagen/workflows/Release/badge.svg) ![Dev](https://github.com/Mutagen-Modding/Mutagen/workflows/Dev/badge.svg) [![NuGet Stats](https://img.shields.io/nuget/v/Mutagen.Bethesda.svg)](https://www.nuget.org/packages/Mutagen.Bethesda)

[![Discord](https://discordapp.com/api/guilds/759302581448474626/widget.png)](https://discord.gg/53KMEsW)

# Mutagen
Mutagen is a C# library for analyzing, modifying, and creating Bethesda mods. One of its main features is offering interfaces and classes for the records that exist at compile time and are first class citizens in C#. With actual members for each field they get the benefits of type safety, simple live debugging, Intellisense features such as autocomplete. The interfaces offer clean API to the user and abstract away much of the binary record specifics and oddities of how they are stored on disk, while the actual implementation remains very closely tied to the data offering as much speed as it can by leveraging some of the latest C# features. Most of the public facing API is created by code generation, with small manual snippets of code for the one-off special cases. This means the library is able to provide consistent API with very little manual work when adding new record definitions or features.

## Goals
What is Mutagen trying to provide?
- Ability to analyze, create, or manipulate esp/esm mod files for Bethesda games in C#.
- Strongly typed objects and fields for all records, which naturally offer Intellisense and type safety.
- User abstraction from complex binary record structures/patterns, when appropriate and beneficial.
- Frameworks for accomplishing common tasks, such as Patchers
- Performance via intelligent short circuiting of work and minimal internal layers underneath the API.
- Heavy use of generated code to provide the above goals without requiring verbose manual development or maintenance.
- Powerful but gritty low level tools for those that want to forgo the autogenerated classes for special tasks.
- Other tooling related to Bethesda modding in C#

## Sample API
```csharp
using var mod = OblivionMod.CreateFromBinaryOverlay(pathToMod);
foreach (var editorId in mod.Potions.Records
    .Select(potion => potion.EditorID)
    .Distinct()
    .Where(s => !string.IsNullOrWhiteSpace(s)))
{
    System.Console.WriteLine(editorId);
}
```
This example snippet would print a mod's unique Potion EditorIDs to the console.

Check out the [Wiki](https://github.com/Mutagen-Modding/Mutagen/wiki) for more detailed explainations of Mutagen's API, and more typical use cases and examples.

## Seeing Mutagen in Action
### Synthesis
[Synthesis](https://github.com/Mutagen-Modding/Synthesis) is a patcher pipeline built on top of Mutagen, and it already has a [large library](https://github.com/Mutagen-Modding/Synthesis/network/dependents?package_id=UGFja2FnZS0xMzg1MjY1MjYz) of example patchers to study and get inspiration from.

### Example Project
Another option is the [Mutagen Bootcamp](https://github.com/Mutagen-Modding/MutagenBootcamp) project.  It contains a good number of example tasks which you can run after pointing it to your copy of Skyrim.  It should be a good starter to help you understand the basics and actually see some of the processing in action.

## Installing Mutagen
Mutagen can be added to your C# project via NuGet, under the package name `Mutagen.Bethesda`.  Search for it in Visual Studio, or find it [here](https://www.nuget.org/packages/Mutagen.Bethesda/).

If you're unfamiliar with setting up C# projects in general, a good place to start might be creating a simple [Synthesis patcher](https://github.com/Mutagen-Modding/Synthesis/wiki/Create-a-Patcher), and be sure to ask questions on our [Discord](https://discord.gg/53KMEsW).
