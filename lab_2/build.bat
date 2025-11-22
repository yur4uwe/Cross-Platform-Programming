@echo off

REM === LIBRARY PATHS ===
set LIB=.\includes

REM === DEFAULTS ===
set COMPILE_RESOURCES=false
set CLEANUP=true

REM === ARGUMENT PARSING ===
set FOUND_SOURCE=false
set OUTPUT_PATH=
set SOURCE_FILE=
set SOURCE_DIR=

for %%A in (%*) do (
    if /I "%%A"=="/noclean" (
        set CLEANUP=false
    ) else if /I "%%A"=="/rc" (
        set COMPILE_RESOURCES=true
    ) else if not "%%A:~0,1"=="/" (
        if not "%FOUND_SOURCE%"=="true" (
            set SOURCE_FILE=%%A
            set SOURCE_DIR=%%~dpA
            set FOUND_SOURCE=true
        ) else (
            set OUTPUT_PATH=%%A
        )
    )
)

if "%SOURCE_FILE%"=="" (
    echo Error: No source file provided.
    echo Usage: build32.bat [source_file] [output_directory] [/rc] [/noclean]
    exit /b 1
)

if "%OUTPUT_PATH%"=="" (
    set OUTPUT_PATH=%SOURCE_DIR%
)

if not exist "%OUTPUT_PATH%" mkdir "%OUTPUT_PATH%"

REM === Extract file name without extension ===
for %%F in (%SOURCE_FILE%) do set FILE_NAME=%%~nF

set KERNEL32_LIB=%LIB%\kernel32.lib
set USER32_LIB=%LIB%\user32.lib
set COMDLG32_LIB=%LIB%\comdlg32.lib

REM === Assemble ===
echo Assembling %SOURCE_FILE%...
ml /c /coff /Cp /I %LIB% /Fo"%OUTPUT_PATH%%FILE_NAME%.obj" %SOURCE_FILE%
if not "%ERRORLEVEL%"=="0" (
    echo Error: Assembly failed with exit code %ERRORLEVEL%.
    goto cleanup
)

REM === Resource Compilation ===
set RESOURCE_FLAG=%OUTPUT_PATH%%FILE_NAME%.obj
if exist "%SOURCE_DIR%%FILE_NAME%.rc" (
    if "%COMPILE_RESOURCES%"=="true" (
        echo Compiling resources...
        rc /fo "%OUTPUT_PATH%%FILE_NAME%.res" "%SOURCE_DIR%%FILE_NAME%.rc"
        if not "%ERRORLEVEL%"=="0" (
            echo Error: Resource compilation failed with exit code %ERRORLEVEL%.
            goto cleanup
        )
        set RESOURCE_FLAG=%RESOURCE_FLAG% "%OUTPUT_PATH%%FILE_NAME%.res"
    ) else (
        echo Resource file found, but no /rc flag set. Skipping resource compilation.
    )
)

REM === Linking ===
echo Linking...
link %RESOURCE_FLAG% "%KERNEL32_LIB%" "%USER32_LIB%" "%COMDLG32_LIB%" /subsystem:windows /out:"%OUTPUT_PATH%%FILE_NAME%.exe"
if not "%ERRORLEVEL%"=="0" (
    echo Error: Linking failed with exit code %ERRORLEVEL%.
    goto cleanup
)

echo Build complete. Executable is located at %OUTPUT_PATH%\%FILE_NAME%.exe

:cleanup
if "%CLEANUP%"=="true" (
    echo Cleaning up intermediate files...
    if exist "%OUTPUT_PATH%\%FILE_NAME%.obj" del "%OUTPUT_PATH%\%FILE_NAME%.obj"
    if exist "%OUTPUT_PATH%\%FILE_NAME%.res" del "%OUTPUT_PATH%\%FILE_NAME%.res"
)
exit /b %ERRORLEVEL%