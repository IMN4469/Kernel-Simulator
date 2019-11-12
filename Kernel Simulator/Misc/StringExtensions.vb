﻿'
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


Module StringExtensions

    ' Credit: Mehang Rai | https://stackoverflow.com/questions/45831829/how-do-you-replace-the-last-occurance-of-a-with-the-word-and
    Public Function ReplaceLastOccurrence(ByVal source As String, ByVal searchText As String, ByVal replace As String) As String
        Dim position = source.LastIndexOf(searchText)
        If (position = -1) Then Return source
        Dim result = source.Remove(position, searchText.Length).Insert(position, replace)
        Return result
    End Function

    ' Credit: Matti Virkkunen | https://stackoverflow.com/questions/2641326/finding-all-positions-of-substring-in-a-larger-string-in-c-sharp
    <Runtime.CompilerServices.Extension>
    Public Iterator Function AllIndexesOf(ByVal str As String, ByVal value As String) As IEnumerable(Of Integer)
        If String.IsNullOrEmpty(value) Then
            Throw New ArgumentException("the string to find may not be empty", "value")
        End If
        Dim index As Integer = 0
        Do
            index = str.IndexOf(value, index)
            If index = -1 Then
                Exit Do
            End If
            Yield index
            index += value.Length
        Loop
    End Function

End Module