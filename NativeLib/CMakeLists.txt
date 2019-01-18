cmake_minimum_required(VERSION 2.8.9)

project(NativeLib)

set(SOURCE_FILES
    Native.cpp
    Native.hpp
)

source_group("Source Files" FILES ${SOURCE_FILES})

set(DLL_NAME NativeLib)

add_library(${DLL_NAME} SHARED ${SOURCE_FILES})