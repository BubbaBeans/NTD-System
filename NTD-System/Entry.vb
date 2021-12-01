Imports System.IO, System.Data.OleDb
Module Entry
    Friend Function CSVtoDataSource(RouteFile As String, ByRef grid As DataGridView, ByRef SurveyThingy As EnteredSurvey) As Boolean
        Dim DidItWork As Boolean = True
        Dim Location As String = MainForm.GlobalSettings.SurveyMastersLocation & "\" & RouteFile
        Try

            Using SR As New StreamReader(Location)

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
        Catch ex As Exception
            MsgBox("Error importing the file into the data Grid" + vbNewLine + ex.Message + vbNewLine + "File: " + Location, vbExclamation)
            DidItWork = False
        End Try

        Return DidItWork
    End Function

End Module
