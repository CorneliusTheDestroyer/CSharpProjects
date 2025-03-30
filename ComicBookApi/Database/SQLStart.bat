@echo off
if not "%1"=="am_admin" (powershell start -verb runas '%0' am_admin & exit /b)

NET STOP  MSSQL$SQL2022 /y
NET START MSSQL$SQL2022
timeout 5
NET STOP  SQLAgent$SQL2022
NET START SQLAgent$SQL2022
timeout 5
NET STOP  SQLBrowser
NET START SQLBrowser