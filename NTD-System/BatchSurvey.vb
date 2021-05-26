Imports System.IO

Module BatchSurvey
    Private ReadOnly WeekdayPacks() As String
    Private ReadOnly WeekendPacks() As String
    Friend Sub ReadPacks(ByRef packs() As String, BatchFile As String)
        If Not File.Exists(My.Settings.BaseLocation & BatchFile) Then GoTo DunDunDun
        Dim index As Integer = 0
        Using sr As New StreamReader(My.Settings.BaseLocation & BatchFile)
            Do Until sr.EndOfStream
                packs(index) = sr.ReadLine()
                index += 1
            Loop
        End Using
DunDunDun:
    End Sub

End Module
