Imports System.Globalization, System.IO
Public Class BatchForm
    Dim WeekdayBatch(12) As String
    Dim WeekendBatch(12) As String
    Public StatusSpacer As String = vbNewLine & "        "
    Public PathDelimiter As String = "\"
    Dim Result As MsgBoxResult ' This allows for a messagebox to be used anywhere in the form, just a quick placeholder basically
    Private Sub BatchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EndingDateRadioButton.Checked = True
        NoOfDaysRadioButton.Checked = False
        EndDatePicker.Enabled = True
        NumbOfDays.Enabled = False
        StartDatePicker.Value = FirstMonday(Now)
        EndDatePicker.Value = DateAdd(DateInterval.Day, 7, StartDatePicker.Value)
        SetupCalendar(MonthCalendar1, FirstDayofMonth(FirstMonday(Now)), 1)
        Status("Reading Weekday Batch File", False)
        'ReadBatchFile(My.Settings.BaseLocation & My.Settings.WeekdayBatchFileName, WeekdayBatch)
        ReadBatchFile(MainForm.GlobalSettings.BaseLocation & PathDelimiter & MainForm.GlobalSettings.WeekdayBatchFile, WeekdayBatch)
        Status("Reading Weekend Batch File", False)
        'ReadBatchFile(My.Settings.BaseLocation & My.Settings.WeekendBatchFileName, WeekendBatch)
        ReadBatchFile(MainForm.GlobalSettings.BaseLocation & PathDelimiter & MainForm.GlobalSettings.WeekendBatchFile, WeekendBatch)
        Status("Done Reading Files", False)
        Status(clear:=True)
    End Sub
    Private Function BoldDates(ByVal dt As Date, ed As Date) As Date()
        '  Returns an array of dates that are bolded on the calendar
        '  A bolded date is a date on which the system should not produce a survey,
        '  usually a day on which the transit system is closed
        Status(clear:=True)
        Dim loopDate As Date = dt
        'Dim testNum As Integer = 0
        Dim dtarray As New List(Of Date)
        dtarray.AddRange(Comm.HolidaysBetween(dt, ed, BatchStatus))

        While CDate(loopDate) <= CDate(ed)
            'testNum = loopDate.DayOfWeek + 1
            'If Mid(My.Settings.DayIndex, testNum, 1) = "F" Then
            If Not MainForm.GlobalSettings.OperatesOnThisDay(loopDate.DayOfWeek) Then
                dtarray.Add(CDate(loopDate.ToShortDateString))
            End If
            loopDate = loopDate.AddDays(1)
        End While

        Return dtarray.ToArray
    End Function
    Private Shared Function FirstDayofMonth(d As Date) As Date
        '  Quick and dirty way to calculate the first day of any given month.
        Return New Date(d.Year, d.Month, 1)
    End Function
    Private Shared Function LastDayofMonth(d As Date) As Date
        '  Quick and dirty way to calculate the last day of any given month.
        Dim nd As Date = d.AddMonths(1)
        Return New Date(nd.Year, nd.Month, 1).AddDays(-1)
    End Function

    Private Sub SetupCalendar(calName As MonthCalendar, sDate As Date, months As Integer)
        '  Handles displaying up to three monthly calendars, bolding any previously bolded dates
        '  which includes recurring weekly bolded days
        calName.Enabled = False
        If months < 1 Then
            months = 1
        ElseIf months > 3 Then
            months = 3
        End If
        Dim MaxDate As Date = LastDayofMonth(FirstDayofMonth(sDate.AddMonths(months - 1)))
        Dim MinDate As Date = CDate(FirstDayofMonth(sDate))

        If MaxDate <= MinDate Then MaxDate = LastDayofMonth(MinDate.AddMonths(months + 1))
        If MinDate >= MaxDate Then MinDate = FirstDayofMonth(MaxDate.AddDays(-1))

        calName.CalendarDimensions = New Size(months, 1)
        calName.MinDate = MinDate
        calName.MaxDate = MaxDate
        calName.BoldedDates = BoldDates(FirstDayofMonth(sDate), LastDayofMonth(sDate.AddMonths(months - 1)))
        calName.Visible = True
        calName.UpdateBoldedDates()
        calName.Enabled = True
    End Sub
    Private Sub StartDatePicker_ValueChanged(sender As Object, e As EventArgs) Handles StartDatePicker.ValueChanged
        'Keep from chosing a date earlier than today
        If CDate(StartDatePicker.Value) > CDate(Now) Then
            EndDatePicker.Value = DateAdd(DateInterval.Day, 7, StartDatePicker.Value)
            UpdateCalendars(StartDatePicker.Value, EndDatePicker.Value)
        End If
    End Sub
    Private Sub UpdateCalendars(SDate As Date, EDate As Date)
        '  Handles all of the updates to a calendar, including adding or removing
        '  displayed calendars
        'Dim cal As Calendar = CultureInfo.InvariantCulture.Calendar
        'Dim numWeeks As Integer = CInt(DateDiff(DateInterval.WeekOfYear, SDate, LastDayofMonth(SDate.AddMonths(2))) + 1)
        Dim NumMonths As Integer = CInt(DateDiff(DateInterval.Month, FirstDayofMonth(SDate), LastDayofMonth(EDate)) + 1)
        SetupCalendar(MonthCalendar1, SDate, NumMonths)
    End Sub
    Private Function FirstMonday(sDate As Date) As Date
        If sDate.DayOfWeek = DayOfWeek.Monday Then
            Return sDate
        Else
            Return CDate(sDate.AddDays(If(sDate.DayOfWeek = DayOfWeek.Monday, 7, (7 - sDate.DayOfWeek + 1) Mod 7)))
        End If
    End Function
    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        If MainForm.GlobalSettings.OperatesOnThisDay(e.Start.DayOfWeek) Then
            'If My.Settings.DayIndex(e.Start.DayOfWeek) <> "F" Then ' Checks to ensure it is a day we are running.
            Dim index = Array.IndexOf(MonthCalendar1.BoldedDates, e.Start.Date)
            If index = -1 Then
                MonthCalendar1.AddBoldedDate(e.Start.Date)
            Else
                MonthCalendar1.RemoveBoldedDate(e.Start.Date)
            End If
            MonthCalendar1.UpdateBoldedDates()
        End If
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumbOfDays.ValueChanged
        EndDatePicker.Value = DateAdd(DateInterval.Day, NumbOfDays.Value, StartDatePicker.Value)
        UpdateCalendars(StartDatePicker.Value, EndDatePicker.Value)
    End Sub
    Private Sub EndDatePicker_ValueChanged(sender As Object, e As EventArgs) Handles EndDatePicker.ValueChanged
        If CDate(EndDatePicker.Value) < CDate(StartDatePicker.Value) Then EndDatePicker.Value = StartDatePicker.Value
        NumbOfDays.Value = DateDiff(DateInterval.Day, StartDatePicker.Value, EndDatePicker.Value)
        'Dim ChosenDate As Date = FirstMonday(StartDatePicker.Value)
        UpdateCalendars(StartDatePicker.Value, EndDatePicker.Value)
    End Sub
    Private Sub EndingDateRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles EndingDateRadioButton.CheckedChanged
        NoOfDaysRadioButton.Checked = Not EndingDateRadioButton.Checked
        EndDatePicker.Enabled = EndingDateRadioButton.Checked
        NumbOfDays.Enabled = Not EndingDateRadioButton.Checked
    End Sub
    Private Sub NoOfDaysRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles NoOfDaysRadioButton.CheckedChanged
        EndingDateRadioButton.Checked = Not NoOfDaysRadioButton.Checked
        EndDatePicker.Enabled = Not NoOfDaysRadioButton.Checked
        NumbOfDays.Enabled = NoOfDaysRadioButton.Checked
        If NumbOfDays.Enabled Then
            NumbOfDays.Focus()
        End If
    End Sub
    Private Sub RunBatchButton_Click(sender As Object, e As EventArgs) Handles RunBatchButton.Click
        Cursor = Cursors.WaitCursor
        Dim StartDate As Date = CDate(StartDatePicker.Value.ToShortDateString)
        Dim EndDate As Date = CDate(EndDatePicker.Value.ToShortDateString)
        Dim RunPart As String = ""
        'Dim SurveySerial As String = ""
        Dim Surveys As New List(Of Survey)
        Dim CurrDate As Date = StartDate
        Status("Getting bolded dates from calendar", False)
        Dim Bolds As Date() = BoldDates(StartDate, EndDate)
        Status("Done getting bolded dates", False)
        Dim BatchFile As String() = {"Batch"}
        Dim CurrSurveys As New List(Of Route)
        Dim SingleSurvey As Route
        Dim SurveyTime As String = ""
        Dim RoutePart As String = ""

        While (CDate(CurrDate.ToShortDateString) <= CDate(EndDate.ToShortDateString))
            If Not Bolds.Contains(CurrDate.Date) Then
                Status(clear:=True)
                Status("Working on " & CurrDate.ToShortDateString, False)
                Status(after:=False)

                If CurrDate.DayOfWeek = DayOfWeek.Saturday Then
                    Dim Biggs As Integer = WeekendBatch.Length - 1
                    ReDim BatchFile(Biggs)
                    WeekendBatch.CopyTo(BatchFile, 0)
                    'BatchFile = WeekendBatch
                    CurrSurveys = SplashScreen1.SDSurvNums
                Else
                    Dim Biggs As Integer = WeekdayBatch.Length - 1
                    ReDim BatchFile(Biggs)
                    WeekdayBatch.CopyTo(BatchFile, 0)
                    'BatchFile = WeekdayBatch
                    CurrSurveys = SplashScreen1.WDSurvNums
                End If
                For Each batch As String In BatchFile
                    Dim SBatch As String() = batch.Split(","c)
                    For Each serial As String In SBatch
                        Status(serial, True)
                        RunPart = SerialPart("RUN", serial)
                        RoutePart = SerialPart("ROUTE", serial)
                        If ((RunPart = "#NA") OrElse (RoutePart = "#NA")) Then GoTo GoAheadAndJump
                        If Strings.Left(RoutePart, 2) = "SE" Then
                            If Strings.Right(RoutePart, 1) = "2" Then
                                Surveys.Add(New Survey(serial, CDate(CurrDate & " " & "15:20"), "SE2"))
                                GoTo GoAheadAndJump
                            Else
                                If Weekday(CurrDate) = vbMonday Then
                                    Surveys.Add(New Survey(serial, CDate(CurrDate & " " & "13:20"), "SE1"))
                                    GoTo GoAheadAndJump
                                Else
                                    Surveys.Add(New Survey(serial, CDate(CurrDate & " " & "15:20"), "SE1"))
                                    GoTo GoAheadAndJump
                                End If
                            End If
                        End If
                        SingleSurvey = FindRoute(CurrSurveys, RoutePart)
                        SurveyTime = FindTime(SingleSurvey, RunPart)
                        'Surveys.Add(New Survey(serial, CDate(CurrDate & " " & SurveyTime), SingleSurvey.SheetName))
                        Surveys.Add(New Survey(serial, CDate(CurrDate & " " & SingleSurvey.Times(CInt(RunPart) - 1)), SingleSurvey.SheetName))
GoAheadAndJump:
                    Next
                    Status("Printing " & FormatDateTime(CurrDate, DateFormat.ShortDate), False)
                    If PrintSheets(Surveys, True, False) <> "None" Then
                        If MsgBox("Should surveys continue to print?", vbYesNo) = vbNo Then GoTo OuttaHere
                    End If
                    Surveys.Clear()
                Next
            End If
            CurrDate = CurrDate.AddDays(1)
        End While
        Cursor = Cursors.Default
        Status("Done with all surveys!", False)
        ''BatchXPSPrinter.PrintXPS(True)
        MsgBox("All surveys sent to the printer.", MsgBoxStyle.Information, "Finish Printing")

        ' This next bit is kinda weird, but is included because of how NOT pausing for two seconds is quite jarring to the user
        Dim dtefutureDate As Date = Date.Now().AddSeconds(2)
        Do Until Date.Now() > dtefutureDate
            Windows.Forms.Application.DoEvents()
        Loop
        ' If there is no pause, the window suddenly just disappears, which is surprising.  By pausing for two seconds it appears
        ' that the app is actually DOING something, and the user isn't surprised.

OuttaHere:
        Status(clear:=True)
        Me.Close()
    End Sub
    Friend Function SerialPart(Part As String, serial As String) As String
        Dim hyphen As Integer = serial.IndexOf("-")
        If hyphen = -1 Then Return "#NA"
        Select Case UCase(Part)
            Case "ROUTE"
                Return Trim(serial.Substring(0, hyphen))
            Case "RUN"
                Return Trim(serial.Substring(hyphen + 1))
        End Select
        Return "#NA"

    End Function
    Friend Function FindRoute(routes As List(Of Route), Rt As String) As Route
        For Each item As Route In routes
            If item.Name = Rt Then
                Return item
            End If
        Next
        MsgBox("Not Found: " & Rt.ToString, vbOKOnly)
        Return Nothing
    End Function
    Friend Function FindTime(route As Route, run As String) As String
        Return route.Times(CInt(run) - 1)
    End Function
    Friend Sub Status(Optional msg As String = "", Optional after As Boolean = True, Optional clear As Boolean = False)
        ' This sub simply handles the status line (more like box) with a couple options for adding
        ' text before or after the existing contents of the box, and clearing the box entirely
        If after Then
            msg &= StatusSpacer
        Else msg &= vbNewLine
        End If

        BatchStatus.AppendText(msg)
        BatchStatus.SelectionStart = Len(BatchStatus.Text)
        BatchStatus.ScrollToCaret()
        If clear Then
            BatchStatus.Clear()
            BatchStatus.Text = ""
        End If
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles BatchCancel.Click
        Status(clear:=True)
        Me.Close()
    End Sub
    Private Sub ReadBatchFile(file As String, ByRef target As String())
        Dim indx As Integer = 0
        Using sr As New StreamReader(file)
            While Not sr.EndOfStream
                ReDim Preserve target(indx)
                target(indx) = sr.ReadLine()
                Status(target(indx), False)
                indx += 1
            End While
        End Using
    End Sub
    Private Sub Mess(M As String)
        Result = MsgBox(M, vbOKOnly)
    End Sub
End Class