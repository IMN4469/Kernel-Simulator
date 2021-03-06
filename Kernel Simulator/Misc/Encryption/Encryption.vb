﻿
'    Kernel Simulator  Copyright (C) 2018-2020  EoflaOE
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

Module Encryption
    Public Function GetArrayEnc(ByVal encrypted As Byte()) As String
        Dim hash As String = ""
        For i As Integer = 0 To encrypted.Length - 1
            Wdbg("I", "Appending {0} to hash", encrypted(i))
            hash += $"{encrypted(i):X2}"
        Next
        Wdbg("I", "Final hash: {0}", hash)
        Return hash
    End Function
End Module
