@echo off
if not "%1"=="am_admin" (powershell start -verb runas '%0' am_admin & exit /b)

NET STOP  SQLAgent$SQL2022
timeout 5
NET STOP  SQLBrowser
timeout 5
NET STOP  MSSQL$SQL2022 /y
