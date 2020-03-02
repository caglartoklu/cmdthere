OPTION _EXPLICIT


$EXEICON:'.\CmdThere.ico'



Main
' TestMain


SUB Main
    _TITLE "CmdThere"
    ' _SCREENHIDE

    ' TODO: 6 if there is no parameter, open a default shell.

    DIM count AS INTEGER
    DIM i AS INTEGER
    DIM candidate AS STRING
    DIM found AS INTEGER

    count = _COMMANDCOUNT

    FOR i = 1 TO count
        ' PRINT COMMAND$(i) 'or process commands sent

        ' this can be a directory, or a file.
        candidate = COMMAND$(i)

        IF _FILEEXISTS(candidate) THEN
            ' this is a file.
            ' extract its directory name.
            candidate = ExtractDirectoryName$(candidate)
            found = found + 1
        END IF

        ' TODO: 6 if a directory is duplicated, do not open a shell for it.

        IF _DIREXISTS(candidate) THEN
            ' this is a directory.
            ' use it as it is.
            PRINT (candidate)
            CHDIR (candidate)
            SHELL _DONTWAIT BuildShellCommand$
            found = found + 1
        END IF
    NEXT

    IF found = 0 THEN
        CALL ProcessNoParameter
    END IF

    ' passes "press any key to continue"
    SYSTEM
END SUB


SUB TestMain
    ' just a function to redirect the main flow for testing.
END SUB


SUB ShowTitle (title AS STRING)
    DIM missingCount AS INTEGER
    DIM missing AS STRING

    missingCount = 79 - LEN(title)
    missing = STRING$(missingCount, " ")
    COLOR 15, 1
    PRINT " " + title + missing
END SUB


SUB ProcessNoParameter
    CALL ShowTitle("CmdThere")

    COLOR 7, 0
    PRINT
    PRINT "Usage:"
    PRINT "Drag and drop directories and files to CmdThere."
    PRINT "It will open cmd.exe instances."
    PRINT "If the items are files, cmd.exe instances will be opened to its containing directories."
    PRINT

    PRINT "Do you want to open a default shell? [y]/n"
    DIM result AS STRING
    result = YesOrNo$
    IF result = "yes" THEN
        SHELL _DONTWAIT BuildShellCommand$
    END IF
END SUB


FUNCTION ExtractDirectoryName$ (fileName AS STRING)
    ' Extracts the path before the path separator and returns it.
    DIM sep AS STRING
    sep = PathSeparator$

    DIM lastPosition AS INTEGER
    lastPosition = _INSTRREV(fileName, sep)

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


FUNCTION TRIM$ (needle$)
    TRIM$ = LTRIM$(RTRIM$(needle$))
END FUNCTION


SUB PressAnyKey
    ' Spin-waits until a key is pressed.
    DO
        ' wait for a second
        SLEEP 1
    LOOP UNTIL INKEY$ <> ""
END SUB


FUNCTION YesOrNo$
    ' Returns "yes" or "no"
    ' Spin-waits until a key is pressed.
    DIM key1 AS STRING
    DIM result AS STRING
    DO
        ' wait for a second
        SLEEP 1
        key1 = TRIM$(LCASE$(INKEY$))
    LOOP UNTIL key1 <> ""
    IF key1 = "y" THEN
        result = "yes"
    ELSEIF ASC(key1) = 13 THEN
        result = "yes"
    ELSE
        result = "no"
    END IF
    YesOrNo$ = result
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


FUNCTION BuildShellCommand$
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
        result = CHR$(34)
    END IF
    PathSeparator$ = result
END FUNCTION
