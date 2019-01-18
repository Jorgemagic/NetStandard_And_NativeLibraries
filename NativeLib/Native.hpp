#pragma once

#if _MSC_VER
	#define DLLEXPORT __declspec(dllexport)
#else
	#define DLLEXPORT
#endif

extern "C" DLLEXPORT void Sum(int number1, int number2, int& result);