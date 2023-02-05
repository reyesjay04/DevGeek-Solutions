@echo off
REM ----------------------------------------------------------------
REM Create a directory to save mysql backup files if not already exists REM ----------------------------------------------------------------



REM ----------------------------------------------------------------
REM append date and time to mysqldump files
REM ----------------------------------------------------------------

SET dt=%date:~-4%-%date:~3,2%-%date:~0,2%-%time:~0,2%-%time:~3,2%-%time:~6,2%
SET dtfolder=%date:~-4%-%date:~3,2%-%date:~0,2%
SET dtyear=%date:~-4%

IF NOT EXIST "D:\DGPOS_BACKUP\%dtyear%" mkdir D:\DGPOS_BACKUP\%dtyear%
IF NOT EXIST "D:\DGPOS_BACKUP\%dtyear%\%dtfolder%" mkdir D:\DGPOS_BACKUP\%dtyear%\%dtfolder%

set bkupfilename=%dt%.sql

REM ----------------------------------------------------------------
REM Display some message on the screen about the backup
REM ----------------------------------------------------------------


ECHO Starting Backup of MySQL Database
ECHO Backup is going to save in C:\MYSQLBACKUPS\ folder.
ECHO Please wait ...

REM ----------------------------------------------------------------
REM mysqldump backup command. append date and time in filename
REM ----------------------------------------------------------------

"C:\xampp\mysql\bin\mysqldump.exe"  --routines -uposuser -pposuser pos > D:\DGPOS_BACKUP\%dtyear%\%dtfolder%\"DGPOS_%bkupfilename%"

REM ----------------------------------------------------------------
REM delete mysqldump backups older than 60 days
REM ----------------------------------------------------------------

ECHO.
ECHO Trying to find and delete backups older than 90 days if found.
ECHO And the result is:
forfiles /p C:\MYSQLBACKUPS /s /m *.* /d -3 /c "cmd /c del @file : date >= 60days"

ECHO.
ECHO Backup completed!
ECHO Backup saved in C:\MYSQLBACKUPS\
ECHO Thank You for backing up!
ECHO - Regards, Admin!
ECHO.