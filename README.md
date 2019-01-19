# C# NetStandard library template that required a C++ Native Library
This is a template that how to create a cross-platform C# NetStandard Library that required a C++ native library that another C# library can use as library reference or nuget reference with the same behavior.

## Prerequisites

* [Visual Studio 2017](https://www.visualstudio.com/downloads). C# IDE on Windows.
* [Visual Studio for Mac](https://visualstudio.microsoft.com/es/vs/mac/) C# IDE on MacOS.
* [Monodevelop](https://www.monodevelop.com/) C# IDE on Linux.
* [CMake](https://www.cmake.org/download/). C++ cross-compile tool.

## Goal

Create a C# NetStandard library that required a C++ Native Library and its must be copy the correct native library file by platform *(Windows, Linux and Mac)* and architecture *(x86 or x64)* when it is reference by another C# library/exe. Furthermore the C# NetStandard library must be prepared to provide a nuget package. So we can to use it as reference library *(development)* or a nuget library *(release)* and the behavior must be the same.

## Projects

* [NativeLib](NativeLib/) folder is a simple C++ library that export a SUM method.
* [NativeLibWrapper](NativeLibWrapper/) folder with a C# netstandard wrapper *(pinvoke)*.
* [ConsoleApp_x86](ConsoleApp_x86) x86 test that reference as library the NativeLibWrapper.
* [ConsoleApp_x64](ConsoleApp_x64) x64 test that use NativeLibWrapper as library reference.
* [Nuget_x86](Nuget_x86) x86 test that use NativeLibWrapper as nuget reference.
* [Nuget_x64](Nuget_X64) x64 test that use NativeLibWrapper as nuget reference.

## C++ NativeLib

Simple C++ library that export a **Sum** function that receive two numbers and return the sum of theses numbers.

### CMake 
*(in NativeLib folder)*
```
mkdir Build_x86
mkdir Build_x64

cd Build_86
cmake ../
cmake --build .

cd ..
cd Build_64
cmake -A x64 ../
cmake --build .
```

## Challenges

* Select correct native library platform *(Windows, Linux or Mac)* and architecture *(x86 or x64)*.
* Copy native library file to final proyect.
* Provide a valid nuget package.

## NativeLibWrapper anatomy

* **binaries folder**: Content the native library compiles to all platforms
* **NativeLibWrapper.targets**: Target to copy correct native libraries to final proyect by platform. *(Based on solution name)*.
* **DllRegister.cs**: Class that select the correct native library architecture *(x86 or x64)* in runtime *(only on Windows)*.
* **NativeLibWrapper.dll.config**: DLLMap file that indicates to pinvoke how to select the correct platform and architecture on mono platform *(only on Linux and Mac)*.
* **NativeLibWrapper.cs**: Class with pinvoke method to native library

## Roadmap

To add Android, iOS and UWP platforms.
