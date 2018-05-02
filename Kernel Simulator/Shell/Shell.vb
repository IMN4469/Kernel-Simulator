﻿
'    Kernel Simulator  Copyright (C) 2018  EoflaOE
'
'    This file is part of Kernel Simulator
'
'    Kernel Simulator is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Kernel Simulator is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Module Shell

    'Available Commands (availableCommands())
    'Admin-Only commands (strictCmds())
    Public ueshversion As String = "0.0.3.1"                'Current shell version
    Public strcommand As String                             'Written Command
    Public CommandFlag As Boolean = False                   'A signal for command kernel argument
    Public availableCommands() As String = {"help", "logout", "version", "currentdir", "list", "changedir", "cdir", "ls", "chdir", "read", "echo", "choice", _
                                            "lsdrivers", "shutdown", "reboot", "disco", "future-eyes-destroyer", "beep", "annoying-sound", "adduser", "chmotd", _
                                            "chhostname", "showmotd", "fed", "hwprobe", "ping", "lsnet", "lsnettree", "showtd", "chpwd", "sysinfo", "arginj", _
                                            "panicsim", "setcolors", "rmuser", "cls", "addperm", "editperm", "chusrname"}
    Public strictCmds() As String = {"adduser", "addperm", "arginj", "chhostname", "chmotd", "chusrname", "editperm", "rmuser"}

    'For contributors: For each added command, you should also add a command in availableCommands array so there is no problems detecting your new command.
    '                  For each added admin command, you should also add a command in strictCmds array after performing above procedure so there is no problems 
    '                  checking if user has Admin permission to use your new admin command.

    Sub initializeShell()

        'Initialize Shell
        getLine(True)
        commandPromptWrite()
        System.Console.ForegroundColor = CType(inputColor, ConsoleColor)
        strcommand = System.Console.ReadLine()
        System.Console.ResetColor()
        getLine()

    End Sub

    Sub commandPromptWrite()

        'The "/" is added for preparation for the directory system that is coming in 0.0.4 or later, so the "/" might not be real.
        If adminList(signedinusrnm) = True Then
            System.Console.Write("[")
            System.Console.ForegroundColor = CType(userNameShellColor, ConsoleColor)
            System.Console.Write(signedinusrnm)
            System.Console.ResetColor()
            System.Console.Write("@")
            System.Console.ForegroundColor = CType(hostNameShellColor, ConsoleColor)
            System.Console.Write(My.Settings.HostName)
            System.Console.ResetColor()
            System.Console.Write("]/ # ")
        Else
            System.Console.Write("[")
            System.Console.ForegroundColor = CType(userNameShellColor, ConsoleColor)
            System.Console.Write(signedinusrnm)
            System.Console.ResetColor()
            System.Console.Write("@")
            System.Console.ForegroundColor = CType(hostNameShellColor, ConsoleColor)
            System.Console.Write(My.Settings.HostName)
            System.Console.ResetColor()
            System.Console.Write("]/ $ ")
        End If

    End Sub

    Sub getLine(Optional ByVal ArgsMode As Boolean = False)

        'Reads command written by user
        For i As Integer = 0 To availableCommands.Count - 1
            If ArgsMode = False Then
                If (adminList(signedinusrnm) = True And strictCmds.Contains(strcommand) = True) Then
                    GetCommand.ExecuteCommand(strcommand)
                    initializeShell()
                ElseIf (adminList(signedinusrnm) = False And strictCmds.Contains(strcommand) = True) Then
                    System.Console.WriteLine("You don't have permission to use {0}", strcommand)
                    initializeShell()
                ElseIf (availableCommands.Contains(strcommand)) Then
                    GetCommand.ExecuteCommand(strcommand)
                    initializeShell()
                ElseIf (strcommand = Nothing Or strcommand.StartsWith(" ") = True) Then
                    initializeShell()
                Else
                    System.Console.WriteLine("Shell message: The requested command {0} is not found. See 'help' for available commands.", strcommand)
                    initializeShell()
                End If
            ElseIf (ArgsMode = True And CommandFlag = True) Then
                CommandFlag = False
                Dim argcmds() As String = argcommands.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                For Each cmd In argcmds
                    If (availableCommands.Contains(cmd)) Then
                        If (adminList(signedinusrnm) = True And strictCmds.Contains(cmd) = True) Then
                            GetCommand.ExecuteCommand(strcommand)
                        ElseIf (adminList(signedinusrnm) = False And strictCmds.Contains(cmd) = True) Then
                            System.Console.WriteLine("You don't have permission to use {0}", cmd)
                        ElseIf (cmd = "logout" Or cmd = "shutdown" Or cmd = "reboot") Then
                            System.Console.WriteLine("Shell message: Command {0} is not allowed to run on log in.", cmd)
                        ElseIf (cmd = Nothing Or cmd.StartsWith(" ") = True) Then
                            initializeShell()
                        Else
                            GetCommand.ExecuteCommand(cmd)
                        End If
                    Else
                        System.Console.WriteLine("Shell message: The requested command {0} is not found.", cmd)
                    End If
                Next
            End If
        Next

    End Sub

End Module
