# WinUI 3 on .NET Platform

## Introduction

This is a template project for the development of a Windows desktop application:

* .NET Platform
* WinUI 3 GUI Framework (Windows only, via Windows App SDK)
* Minimum OS: Windows 10 version 1809 (build 17763)

It is the companion project of

* https://github.com/future2r/gelato
* https://github.com/future2r/macchiato
* https://github.com/future2r/potato
* https://github.com/future2r/tomato

## Prerequisites

Install VS Code:

    winget install --id Microsoft.VisualStudioCode

Install the C# Dev Kit extension:

    code --install-extension ms-dotnettools.csdevkit

Install the .NET platform:

    winget install --id Microsoft.DotNet.SDK.10

## Workspace

Open the workspace in VS Code:

    File > Open Workspace from File... > Cioccolato.code-workspace

This workspace contains editor settings (format-on-save, organize-imports-on-save) and extension recommendations.

Three debug launch configurations are available (F5):

* **Cioccolato** - Default locale
* **Cioccolato (English)** - English locale
* **Cioccolato (German)** - German locale

## Build, Test and Run

Build the project:

    dotnet build

Run the tests:

    dotnet test

Run the application:

    dotnet run --project Cioccolato.Gui/Cioccolato.Gui.csproj -r win-x64

Run the application with a specific language:

    dotnet run --project Cioccolato.Gui/Cioccolato.Gui.csproj -r win-x64 -- --lang=en-US
    dotnet run --project Cioccolato.Gui/Cioccolato.Gui.csproj -r win-x64 -- --lang=de-DE

Publish the application (including .NET):

    dotnet publish Cioccolato.Gui/Cioccolato.Gui.csproj -c Release -r win-x64 --self-contained true
    dotnet publish Cioccolato.Gui/Cioccolato.Gui.csproj -c Release -r win-arm64 --self-contained true

Find the deployable executable in:

    Cioccolato.Gui/bin/Release/net10.0-windows10.0.19041.0/win-x64/publish
    Cioccolato.Gui/bin/Release/net10.0-windows10.0.19041.0/win-arm64/publish

## Project Structure

The project is organized as a .NET solution with three projects:

* `Cioccolato.Core/` - Core library with domain model (`Variety`) and in-memory database (`Database`)
* `Cioccolato.Gui/` - GUI application with WinUI 3 views and MVVM view models
    * `Resources/Strings/` - Localization via `.resx` files (English, German)
    * `Resources/Images/` - Application icons
* `Cioccolato.Gui.Tests/` - Unit tests (xUnit, FluentAssertions)
* `Design/` - Design assets (ICO and PNG in various sizes)

The language can be overridden at startup with the `--lang=` argument (e.g. `--lang=en-US`, `--lang=de-DE`).

## Project Setup

These steps document how the project was created from scratch.

Create the solution:

    dotnet new sln -n Cioccolato --format slnx

Create the module projects:

    dotnet new classlib -n Cioccolato.Core -f net10.0
    dotnet new winui -n Cioccolato.Gui

Add module projects to the solution:

    dotnet sln Cioccolato.slnx add Cioccolato.Core/Cioccolato.Core.csproj
    dotnet sln Cioccolato.slnx add Cioccolato.Gui/Cioccolato.Gui.csproj

Add the reference to the Core to the Gui:

    dotnet add Cioccolato.Gui/Cioccolato.Gui.csproj reference Cioccolato.Core/Cioccolato.Core.csproj

### NuGet Packages

Add the required NuGet packages to the Gui project:

    dotnet add Cioccolato.Gui/Cioccolato.Gui.csproj package Microsoft.WindowsAppSDK
    dotnet add Cioccolato.Gui/Cioccolato.Gui.csproj package CommunityToolkit.Mvvm

### Test Project

Create the test project:

    dotnet new xunit -n Cioccolato.Gui.Tests -f net10.0

Add the test project to the solution:

    dotnet sln Cioccolato.slnx add Cioccolato.Gui.Tests/Cioccolato.Gui.Tests.csproj

Add project references to the test project:

    dotnet add Cioccolato.Gui.Tests/Cioccolato.Gui.Tests.csproj reference Cioccolato.Gui/Cioccolato.Gui.csproj
    dotnet add Cioccolato.Gui.Tests/Cioccolato.Gui.Tests.csproj reference Cioccolato.Core/Cioccolato.Core.csproj

Add the required NuGet packages to the test project:

    dotnet add Cioccolato.Gui.Tests/Cioccolato.Gui.Tests.csproj package FluentAssertions
