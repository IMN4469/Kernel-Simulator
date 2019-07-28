﻿
'    Kernel Simulator  Copyright (C) 2018-2019  EoflaOE
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

Imports System.Text

Public Class Manual

    Public Property ManualTitle As String
    Public Property ManualRevision As String
    Public Property ManualLayoutVersion As String
    Public Property Body As New StringBuilder
    Public Property Colors As New Dictionary(Of String, ConsoleColor)
    Public Property Sections As New Dictionary(Of String, String)
    Public Property Todos As New List(Of String)

    Public Sub New(ByVal Title As String)
        If AvailablePages.Contains(Title) Then
            ManualTitle = Title
        End If
    End Sub

End Class