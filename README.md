# C# NetStandard library template that requires a C++ Native Library
C# NetStandard Library template that requires a C++ native library. Other C# libraries can use it as library reference or nuget reference with the same behavior.

## Prerequisites

* [Visual Studio 2017](https://www.visualstudio.com/downloads). C# IDE on Windows.
* [Visual Studio for Mac](https://visualstudio.microsoft.com/es/vs/mac/) C# IDE on MacOS.
* [Monodevelop](https://www.monodevelop.com/) C# IDE on Linux.
* [CMake](https://www.cmake.org/download/). C++ cross-compile tool.

## Goal

Create a C# NetStandard library that requires a C++ Native Library. It must copy the correct native library file by platform *(Windows, Linux and Mac)* and architecture *(x86 or x64)*  when it is referenced by another C# library/exe. Furthermore, the C# NetStandard library must be prepared to provide a nuget package. So you can use it as reference library *(development)* or nuget library *(release)* and the behavior must be the same.

## Projects

* [NativeLib](NativeLib/) folder is a simple C++ library that export a *Sum* method.
* [NativeLibWrapper](NativeLibWrapper/) folder with a C# netstandard wrapper *(pinvoke)*.
* [ConsoleApp_x86](ConsoleApp_x86) x86 test that references NativeLibWrapper library.
* [ConsoleApp_x64](ConsoleApp_x64) x64 test that references NativeLibWrapper library.
* [Nuget_x86](Nuget_x86) x86 test that references NativeLibWrapper nuget.
* [Nuget_x64](Nuget_X64) x64 test that references NativeLibWrapper nuget.

## C++ NativeLib

Simple C++ library that export a **Sum** function. This function receives two numbers and returns the sum of these numbers.

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
* Copy native library file to final project.
* Provide a valid nuget package.

## NativeLibWrapper anatomy

* **binaries folder**: Contains the native library compiled files to all platforms.
* **NativeLibWrapper.targets**: Target to copy correct native libraries to final project by platform. *(Based on solution name)*.
* **DllRegister.cs**: Class that select the correct native library architecture *(x86 or x64)* in runtime *(only on Windows)*.
* **NativeLibWrapper.dll.config**: DLLMap file that indicates to pinvoke methods how to select the correct native library file on mono platforms *(only on Linux and Mac)*.
* **NativeLibWrapper.cs**: Class with pinvoke method to native library.

## Nuget

- Open **UsingNativeLib_Nuget.sln** solution
- Right click the project **NativeLibWrapper** and select the **Pack** command to generate nupkg file *(Visual Studio 2017)* 
- Add nupkg folder as a new local repository in **Tool -> Options -> Nuget Package Manager -> Package Sources**.

## Roadmap

To add Android, iOS and UWP platforms.

## Special Thanks
- [jacano](https://github.com/jacano)
- [danielcaceresm](https://github.com/danielcaceresm)