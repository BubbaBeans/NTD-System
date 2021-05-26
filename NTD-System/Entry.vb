Imports System.IO, System.Data.OleDb
Module Entry
    Friend Function CSVtoDataSource(RouteFile As String, ByRef grid As DataGridView, ByRef SurveyThingy As EnteredSurvey) As Boolean
        Dim DidItWork As Boolean = True
        Try
            Using SR As StreamReader = New StreamReader(My.Settings.BaseLocation & "\SurveyEntryMasters\" & RouteFile)

                Dim line As String
                Do Until SR.EndOfStream
                    line = SR.ReadLine
                    If Not String.IsNullOrEmpty(line) Then
                        Dim splitLine() As String
                        splitLine = line.Split(","c)
                        grid.Rows.Add(splitLine)
                        SurveyThingy.AddStop(splitLine(1), CInt(splitLine(2)))
                    Else
                        Exit Do
                    End If
                Loop
            End Using
        Catch
            MsgBox("Error importing the file into the data Grid", vbExclamation)
            DidItWork = False
        End Try

        Return DidItWork
    End Function

End Module
