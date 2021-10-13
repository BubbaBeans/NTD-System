Imports System.Globalization
'<Assembly: Resources.NeutralResourcesLanguage("en-us")>
Public Class MainForm
    Public GlobalSettings As New NtdSettings
    'Private NoSurveys() As Date
    Public StatusSpacer As String = vbNewLine & "        "
    Public r As New Random
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sNum.Value = GlobalSettings.SurveysPerWeek
        Dim SDate As Date = FirstMonday(Now)
        StartDatePicker.Value = SDate
        Status(clear:=True)
        Randomize()
        Me.Show()
    End Sub
    Private Function BoldDates(ByVal dt As Date, ed As Date) As Date()
        '  Returns an array of dates that are bolded on the calendar
        '  A bolded date is a date on which the system should not produce a survey,
        '  usually a day on which the transit system is closed
        Dim loopDate As Date = dt
        Dim dtarray As New List(Of Date)
        Status(clear:=True)
        dtarray.AddRange(Comm.HolidaysBetween(dt, ed, StatusText))

        While CDate(loopDate) <= CDate(ed)
            If Not GlobalSettings.OperatesOnThisDay(loopDate.DayOfWeek) Then 'Mid(My.Settings.DayIndex, testNum, 1) = "F" Then
                dtarray.Add(loopDate)
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
        If MaxDate < MinDate Then
            MaxDate = LastDayofMonth(MinDate.AddMonths(months - 1))
        End If
        If MinDate > MaxDate Then
            MinDate = FirstDayofMonth(MaxDate)
        End If

        calName.CalendarDimensions = New Size(months, 1)
        calName.MaxDate = MaxDate
        calName.MinDate = MinDate
        calName.BoldedDates = BoldDates(FirstDayofMonth(sDate), LastDayofMonth(sDate.AddMonths(months - 1)))
        calName.Visible = True
        calName.UpdateBoldedDates()
        calName.Enabled = True
    End Sub
    Private Sub StartDatePicker_ValueChanged(sender As Object, e As EventArgs) Handles StartDatePicker.ValueChanged
        'Keep from chosing a date earlier than today
        If CDate(StartDatePicker.Value) >= CDate(Now) Then
            'ChosenDate is set to the first Monday after the date picked
            Dim ChosenDate As Date = FirstMonday(StartDatePicker.Value)
            If StartDatePicker.Value <> ChosenDate Then StartDatePicker.Value = ChosenDate
            UpdateCalendars(CDate(ChosenDate), CInt(ctrlnWeeks.Value))
        End If
    End Sub
    Private Sub UpdateCalendars(SDate As Date, NWeeks As Integer)
        '  Handles all of the updates to a calendar, including adding or removing
        '  displayed calendars
        Dim cal As Calendar = CultureInfo.InvariantCulture.Calendar
        Dim EDate As Date = cal.AddWeeks(SDate, NWeeks)
        ThruDate.Text = "End Date: " & CStr(Format(EDate.AddDays(-2), "M/d/yy"))
        Dim numWeeks As Integer = CInt(DateDiff(DateInterval.WeekOfYear, SDate, LastDayofMonth(SDate.AddMonths(2))) + 1)
        ctrlnWeeks.Maximum = numWeeks
        Dim NumMonths As Integer = CInt(DateDiff(DateInterval.Month, FirstDayofMonth(SDate), LastDayofMonth(EDate)) + 1)
        SetupCalendar(MonthCalendar1, SDate, NumMonths)
    End Sub
    Private Sub CtrlnWeeks_ValueChanged(sender As Object, e As EventArgs) Handles ctrlnWeeks.ValueChanged
        Dim ChosenDate As Date = StartDatePicker.Value
        UpdateCalendars(CDate(ChosenDate), CInt(ctrlnWeeks.Value))
    End Sub
    Private Function FirstMonday(sDate As Date) As Date
        If sDate.DayOfWeek = DayOfWeek.Monday Then
            Return sDate
        Else
            Return CDate(sDate.AddDays(If(sDate.DayOfWeek = DayOfWeek.Monday, 7, (7 - sDate.DayOfWeek + 1) Mod 7)))
        End If
    End Function
    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        'If My.Settings.DayIndex(e.Start.DayOfWeek) = "F" Then Exit Sub
        If GlobalSettings.OperatesOnThisDay(e.Start.DayOfWeek) Then
            Dim index = Array.IndexOf(MonthCalendar1.BoldedDates, e.Start.Date)
            If index = -1 Then
                MonthCalendar1.AddBoldedDate(e.Start.Date)
            Else
                MonthCalendar1.RemoveBoldedDate(e.Start.Date)
            End If
            MonthCalendar1.UpdateBoldedDates()
        End If
    End Sub

    Private Sub DoneButt_Click(sender As Object, e As EventArgs) Handles DoneButt.Click
        '  Now for the hard work.  Once all dates are chosen, this subroutine handles
        '  the actual creation of the required number of surveys over the provided
        '  time period

        On Error GoTo Err

        Dim StartDate As Date = CDate(StartDatePicker.Value)
        Dim Weeks As Integer = CInt(ctrlnWeeks.Value)
        Dim SurveysPerWeek As Integer = CInt(sNum.Value)
        Dim CurrWeek As Date
        Dim ChosenDate As String = ""
        Dim Rout As Route
        Dim Run As String = ""
        Dim SurveySerial As String = ""
        Dim Surveys As New List(Of Survey)
        'Dim SCount As Integer = 0
        Dim IsRepeat As Boolean = False

        Status("Running " & CStr(SurveysPerWeek) & " surveys for " & CStr(Weeks) & " weeks", False)

        ' Starting a for loop to iterate over the required number of weeks
        For i As Integer = 1 To Weeks
            CurrWeek = StartDate.AddDays((i - 1) * 6)
            Status("", False)
            Status("Week " & CStr(i) & " starting " & Format(CurrWeek, "MM/dd/yyyy"))

            '  Starting a for loop to iterate over the required number of surveys per week
            For keepcount As Integer = 1 To SurveysPerWeek

                Do
                    ChosenDate = Format(UsableDate(CurrWeek), "MM/dd/yyyy")
                    Rout = UsableRoute(CDate(ChosenDate))
                    Run = CStr(Rand(r, 1, Rout.Runs - 1))
                    SurveySerial = Rout.Name & "-" & Run
                    IsRepeat = RepeatSurvey(Surveys, SurveySerial, CDate(ChosenDate))
                    If IsRepeat Then
                        Status("     SURVEY IS REPEATED.  CHOOSING ANOTHER.")
                    End If
                Loop Until Not IsRepeat

                Surveys.Add(New Survey(SurveySerial, CDate(ChosenDate & " " & Rout.Times(CInt(Run) - 1)), Rout.SheetName))
                Status("Survey " & CStr(keepcount) & " : " & CStr(ChosenDate) & " " & CStr(SurveySerial))

            Next
        Next
        Status("", False)
        Dim SortedSurveys As List(Of Survey)
        Status("Sorting surveys by date", True)
        SortedSurveys = Surveys.OrderBy(Function(x) x.DateOfSurvey).ToList()
        SaveSurveys(SortedSurveys)
        Dim m As String = PrintSheets(SortedSurveys, False, True)
        'm = ""
        If m <> "None" Then
            MsgBox(m, vbOKOnly)
        Else
            MsgBox("All surveys sent to the printer.", MsgBoxStyle.Information, "Finish Printing")
        End If
        GoTo DunDunDun

Err:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
DunDunDun:
        If MsgBox("Would you like a reminder to print the next set?", vbYesNo) = MsgBoxResult.Yes Then
            Dim Stuff(1) As String
            Stuff(0) = CDate(StartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) & " 9:00:00 AM").AddDays(Weeks * 7 - 5).ToString()
            Stuff(1) = CDate(Stuff(0)).AddHours(1).ToString
            If WriteCalendar(LoadInfo(Stuff)) Then
                MsgBox("Reminder file is on your desktop." & vbCrLf & "Double-click the file to add it to your calendar", vbOKOnly)
            Else
                MsgBox("There was a problem creating the reminder.", vbOKOnly)
            End If
        End If
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        Me.Close()
    End Sub
    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        formSettings.Show()
    End Sub
    Private Function UsableDate(StartDate As Date) As Date
        Dim Works As Date

        Do
            Works = StartDate.AddDays(Rand(r, 0, 6))
        Loop Until Not MonthCalendar1.BoldedDates.Contains(Works.Date)

        Return Works
    End Function
    Private Function UsableRoute(Dayt As Date) As Route
        Dim isSaturday As Boolean = (Dayt.DayOfWeek = DayOfWeek.Saturday)
        'Private Function UsableSerial(Dayt As Date) As String
        'Dim Serial As String = ""
        Dim RandomSerial As Route
        'Dim Done = False
        '
        If isSaturday Then
            RandomSerial = ChooseASerial(SplashScreen1.SDSurvNums)
        Else
            RandomSerial = ChooseASerial(SplashScreen1.WDSurvNums)
        End If
        '   Serial = RandomSerial.Name & "-" & CStr(Rand(r, 1, RandomSerial.Runs))
        '  UsableSerial = Serial
        Return RandomSerial
        'End Function
    End Function

    Shared Function Bolded(cal As MonthCalendar) As String()
        Dim c As Integer = 0
        Dim d As String() = Array.Empty(Of String)()
        For Each b As Date In cal.BoldedDates
            d(c) = b.ToShortDateString
            c += 1
        Next
        Return d
    End Function
    Shared Function Rand(random As Random, Optional lowest As Integer = 0, Optional highest As Integer = 100) As Integer
        Dim randomNumber As Integer = random.Next(lowest, highest + 1)
        Return randomNumber
    End Function

    Shared Function RepeatSurvey(SV As List(Of Survey), Ser As String, SDat As Date) As Boolean
        Dim s As New Survey(Ser, SDat)
        Return SV.Contains(s)
    End Function
    Function ChooseASerial(SurvNums As List(Of Route)) As Route
        ' This short function returns a random route
        Dim rn As Integer
        Dim srl As Route
redo:
        rn = Rand(r, 0, SurvNums.Count - 1)
        Try
            srl = SurvNums(rn)
        Catch ex As Exception
            GoTo redo
        End Try
        Return srl
    End Function
    Friend Sub Status(Optional msg As String = "", Optional after As Boolean = True, Optional clear As Boolean = False)
        ' This sub simply handles the status line (more like box) with a couple options for adding
        ' text before or after the existing contents of the box, and clearing the box entirely
        If after Then
            msg &= StatusSpacer
        Else msg &= vbNewLine
        End If

        StatusText.AppendText(msg)
        StatusText.SelectionStart = Len(StatusText.Text)
        StatusText.ScrollToCaret()
        If clear Then StatusText.Clear()
    End Sub

    Private Sub BatchBut_Click(sender As Object, e As EventArgs) Handles batchBut.Click
        BatchForm.Show()
    End Sub

    Private Sub Oops_Click(sender As Object, e As EventArgs) Handles Oops.Click
        SplashScreen1.WDSurvNums = Nothing
        SplashScreen1.SDSurvNums = Nothing
        StatusSpacer = Nothing
        r = Nothing
        Me.Close()
    End Sub

    Private Sub AboutButt_Click(sender As Object, e As EventArgs) Handles AboutButt.Click
        AboutForm.Show()
    End Sub
    Private Function LoadInfo(Info() As String) As String
        Dim LongInfo As String
        Dim N As Char = vbCrLf
        LongInfo = "BEGIN:VCALENDAR" & N & "VERSION:2.0" & N & "BEGIN:VEVENT" & N
        LongInfo += "DTSTART:" & CDate(Info(0)).ToUniversalTime & N & "DTEND:" & CDate(Info(1)).ToUniversalTime & N
        LongInfo += "SUMMARY:Print Surveys starting Monday" & N & "UID:" & System.Guid.NewGuid.ToString() & N
        LongInfo += "CLASS:PUBLIC" & N & "END:VEVENT" & N & "END:VCALENDAR"
        Return LongInfo
    End Function
    Private Function WriteCalendar(Info As String) As Boolean
        Dim Outcome As Boolean = True
        Try
            Dim di = New System.IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
            Dim fn = System.IO.Path.Combine(di.FullName, "Survey Reminder.ics")
            System.IO.File.WriteAllText(fn, Info)
        Catch ex As Exception
            Outcome = False
        End Try
        Return Outcome
    End Function
End Class