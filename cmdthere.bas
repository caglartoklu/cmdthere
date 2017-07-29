OPTION _EXPLICIT

Main
' TestMain


SUB Main
    _TITLE "CmdThere"
    _SCREENHIDE

    ' TODO: 6 if there is no parameter, open a default shell.

    DIM count AS INTEGER
    DIM i AS INTEGER
    DIM candidate AS STRING
    DIM itsDirectory AS STRING

    count = _COMMANDCOUNT

    FOR i = 1 TO count
        ' PRINT COMMAND$(i) 'or process commands sent

        ' this can be a directory, or a file.
        candidate = COMMAND$(i)

        IF _FILEEXISTS(candidate) THEN
            ' this is a file.
            ' extract its directory name.
            candidate = ExtractDirectoryName$(candidate)
        END IF

        ' TODO: 6 if a directory is duplicated, do not open a shell for it.

        IF _DIREXISTS(candidate) THEN
            PRINT (candidate)
            CHDIR (candidate)
            SHELL _DONTWAIT BuildShellCommand$(candidate)
        END IF
    NEXT

    ' passes "press any key to continue"
    SYSTEM
END SUB


SUB TestMain
    ' just a function to redirect the main flow for testing.
END SUB


FUNCTION ExtractDirectoryName$ (fileName AS STRING)
    ' Extracts the path before the path separator and returns it.
    DIM sep AS STRING
    sep = PathSeparator$

    DIM lastPosition AS INTEGER
    lastPosition = InStrLast(fileName, sep)

    DIM dirName AS STRING
    dirName = LEFT$(fileName, lastPosition)

    ExtractDirectoryName$ = dirName
END FUNCTION


FUNCTION StrUntil$ (haystack AS STRING, needle AS STRING)
    ' Returns the part of the haystack until needle.

    ' Examples:
    'PRINT (StrUntil$("deneme", "m")) ' "dene"
    'PRINT (StrUntil$("deneme", "d")) ' ""
    'PRINT (StrUntil$("deneme", "e")) ' "d"
    'PRINT (StrUntil$("deneme", "neme")) ' "de"
    'PRINT (StrUntil$("deneme", "x")) ' ""

    DIM result AS STRING
    DIM firstPosition AS INTEGER
    firstPosition = INSTR(haystack, needle)
    result = MID$(haystack, 1, firstPosition - 1)
    StrUntil$ = result
END FUNCTION


FUNCTION InStrLast% (haystack AS STRING, needle AS STRING)
    ' InStr function, but returns the last index instead of the first one.
    ' if the string is not found, -1 is returned.

    ' Examples:
    'PRINT PathSeparator$
    'PRINT (InStrLast%("abcxa", "x")) ' 4
    'PRINT (InStrLast%("xabcxa", "x")) '5
    'PRINT (InStrLast%("xabca", "x")) '1
    'PRINT (InStrLast%("xaxxbcaxx", "xx")) '8
    'PRINT (InStrLast%("xaxxbcaxxaa", "xx")) '8
    'PRINT (InStrLast%("---", "x")) '-1

    DIM startPosition AS INTEGER
    DIM i AS INTEGER
    DIM temp AS STRING
    DIM lastPosition AS INTEGER
    lastPosition = -1
    FOR i = 1 TO LEN(haystack)
        temp = MID$(haystack, i, LEN(needle))
        IF temp = needle THEN
            lastPosition = i
        END IF
    NEXT
    InStrLast% = lastPosition
END FUNCTION


FUNCTION DetectOs$ ()
    ' Detects the operating system and returns a string accordingly.
    ' For Windows : "windows"
    ' Note that the strings in BuildShellCommand$ and DetectOs$()
    ' must be compatible.
    ' If one of them is modified, the other must be modified too.

    ' TODO: 5 Linux and Mac Support
    DIM result AS STRING
    IF ENVIRON$("windir") <> "" THEN
        result = "windows"
    END IF
    DetectOs$ = result
END FUNCTION


FUNCTION BuildShellCommand$ (directoryName AS STRING)
    ' Returns the shell command to use.
    ' Note that the strings in BuildShellCommand$ and DetectOs$()
    ' must be compatible.
    ' If one of them is modified, the other must be modified too.

    DIM result AS STRING
    DIM os AS STRING
    os = DetectOs$
    IF os = "windows" THEN
        result = "cmd.exe /k"
    ELSEIF os = "debian" THEN
        ' TODO: 5 build shell command for debian
    ELSEIF os = "osx" THEN
        ' TODO: 5 build shell command for osx
    END IF
    BuildShellCommand$ = result
END FUNCTION


FUNCTION PathSeparator$ ()
    ' Returns the path separator.
    ' Requires : DetectOs$()
    DIM result AS STRING
    result = "/" ' this is the default.
    IF DetectOs$ = "windows" THEN
        result = "\"
    END IF
    PathSeparator$ = result
END FUNCTION
