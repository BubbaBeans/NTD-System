Imports System.IO

Module BatchSurvey
    'Private ReadOnly WeekdayPacks() As String
    'Private ReadOnly WeekendPacks() As String
    Friend Sub ReadPacks(ByRef packs() As String, BatchFile As String)
        'If Not File.Exists(My.Settings.BaseLocation & BatchFile) Then GoTo DunDunDun
        If File.Exists(MainForm.GlobalSettings.BaseLocation & BatchFile) Then
            Dim index As Integer = 0
            'Using sr As New StreamReader(My.Settings.BaseLocation & BatchFile)
            Using sr As New StreamReader(MainForm.GlobalSettings.BaseLocation & BatchFile)
                Do Until sr.EndOfStream
                    packs(index) = sr.ReadLine()
                    index += 1
                Loop
            End Using
        End If
        'DunDunDun:
    End Sub

End Module
