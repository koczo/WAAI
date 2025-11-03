@echo off
powershell -ExecutionPolicy Bypass -File commit.ps1 -Message "%*"
