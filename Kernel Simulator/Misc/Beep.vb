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

Public Module Beep

    Public Sub Beep(ByVal freq As Integer, ByVal s As Double)

        If (freq <= 36 Or freq >= 32768) Then
            Wln("Invalid value for beep frequency.", "neutralText")
        ElseIf (freq > 2048) Then
            Wln("ERROR: Beep may be loud, depending on speaker. Setting values higher than 2048 might cause your ears to damage, " + _
                "and more importantly, your motherboard speaker might deafen, or malfunction." + vbNewLine + vbNewLine + _
                "Please read documentation for more info why high frequency shouldn't be used.", "neutralText")
        Else
            Wln("Beeping in {0} seconds in {1} Hz...", "neutralText", s, freq)
            System.Console.Beep(freq, CInt(s * 1000))
        End If

    End Sub

End Module
