Imports Microsoft.Office.Interop.Excel
Imports System.Printing, System.Drawing.Printing
'Imports System.Globalization
Module ExcelFunctions
    Dim app As Application
    Const SerialCell As String = "B4"
    Const DateCell As String = "C4"
    Const TimeCell As String = "E4"
    Friend Function PrintSheets(svey As List(Of Survey), Optional StapleAndDuplex As Boolean = False, Optional PrintNow As Boolean = False) As String

        On Error GoTo Oops
        PrintSheets = "None"
        app = New Application With {
            .DisplayAlerts = False
        }

        Dim modifier As Integer = 0
        'Dim book As Workbook = app.Workbooks.Open(My.Settings.BaseLocation & My.Settings.SurveyFileName)
        Dim printbook As Workbook = app.Workbooks.Add()
        Dim FNames As New List(Of String)

        Dim DtCell, TmCell As Range
        Dim counter As Integer = 1
        MainForm.Status(clear:=True)
        For Each s As Survey In svey
            MainForm.Status("Printing Survey " & CStr(counter) & ": " & s.DateTime.ToShortDateString & "  " & s.Serial)
            Dim book As Workbook = app.Workbooks.Open(My.Settings.BaseLocation & My.Settings.SurveyFileName)

            Dim sheet As Worksheet = book.Sheets(s.SheetName)

            sheet.Name = counter.ToString & "--"
            sheet.Name = SheetName() ''SheetName(printbook, s.Serial, modifier)
            sheet.Copy(After:=printbook.Sheets(printbook.Sheets.Count))

            sheet = printbook.ActiveSheet
            book.Close(False)
            sheet.Name = SheetName() ''SheetName(printbook, s.Serial, modifier)
            sheet.Range(SerialCell).Value = s.Serial
            DtCell = sheet.Range(DateCell)
            TmCell = sheet.Range(TimeCell)
            DtCell.Value = CStr(Format(s.DateTime, "MM/dd/yy"))
            TmCell.Value = CStr(s.TimeofSurvey)
            If s.Serial.Contains("SE2") Then
                If s.DateTime.DayOfWeek = vbMonday Then
                    TmCell.Value = ("13:20")
                Else
                    TmCell.Value = ("15:20")
                End If
            End If
            If s.Serial.Contains("SE1") Then
                TmCell.Value = "7:30"
            End If
            counter += 1
        Next

        For Each sht As Worksheet In printbook.Worksheets
            If sht.Name.StartsWith("Sheet") Then sht.Delete()
        Next
        Dim printerName As String
        If StapleAndDuplex Then
            printerName = "Kyocera-Staple"
        Else
            Dim settings As New PrinterSettings()
            printerName = settings.PrinterName
        End If
        printbook.PrintOutEx(ActivePrinter:=printerName)
        'Dim pname As String = ToXPS(printbook)

        printbook.Close(False)
        'If PrintNow Then BatchXPSPrinter.PrintXPS(StapleAndDuplex)
        PrintSheets = "None"
        GoTo ouvre
Oops:
        MsgBox(Err.Description, vbOKOnly)
        PrintSheets = Err.ToString
        'End Try
ouvre:
        ''DeletePrinterFiles(FNames)
        'sheet = Nothing
        'book.Close(False)
        'printbook.Close(False)
        printbook = Nothing
        app.Quit()
        app = Nothing

    End Function
    ''  Private Function ToXPS(book As Workbook) As String
    '' Dim rightnow As String = Now.ToString("MM-dd-yyyy_hh-mm-ss")
    ''Dim dName As String = "C:\temp\" & rightnow & ".xps"
    ''  book.ExportAsFixedFormat(XlFixedFormatType.xlTypeXPS, dName, XlFixedFormatQuality.xlQualityStandard)
    ''
    ''ToXPS = dName ' + ".xps"
    ''End Function

    ''Private Function SheetName(book_to_check As Workbook, checkname As String, number As Integer) As String
    ' 'Dim Found = False
    ''For Each w As Worksheet In book_to_check.Worksheets
    '' If w.Name = checkname Then Found = True
    '' Next
    '' If Found Then number += 1
    '' Return checkname & number.ToString()
    Private Function SheetName() As String
        Return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
    End Function
End Module
