'Imports System.Linq
Imports System.ComponentModel
Imports unvell.ReoGrid
Imports System.Runtime.InteropServices

Public Class SurveyEntry
    ' =========================================================================================================================================
    ' This whole section is added in order to speed up DataGridView, which is notoriously slow when it isn't databound.
    ' It allows the redrawing of the view to be disabled before updating, then enable after it has been updating, keeping it from redrawing multiple times
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Boolean, ByVal lParam As IntPtr) As Integer
    End Function
    Private Const WM_SETREDRAW As Integer = 11
    Public Shared Sub SuspendDrawing(ByVal Target As Control)
        SendMessage(Target.Handle, WM_SETREDRAW, False, 0)
    End Sub

    Public Shared Sub ResumeDrawing(ByVal Target As Control)
        SendMessage(Target.Handle, WM_SETREDRAW, True, 0)
        Target.Invalidate()
    End Sub

    ' =========================================================================================================================================


    ' The following Const contain the column indexes so they can be referenced by name
    Const Odo As Integer = 2
    Const PBoard As Integer = 3
    Const PDBoard As Integer = 4
    Const POB As Integer = 5
    Const DBS As Integer = 6
    Const PM As Integer = 7

    'Dim PassedChecks As Boolean = True ' Indicates whether data in the grid has been verified and has no errors
    Dim CurrentlyUpdating As Boolean = False ' Tracks whether the data is updating on the DataGridView
    Dim LastRow As Integer = 0
    Dim WorkingCell As DataGridViewCell
    Dim WorkingSurvey As New EnteredSurvey
    Dim DOWeek As Integer
    Dim TOfDay As String
    Dim TotalCapacity As Integer
    Dim SeatedCapacity As Integer
    Dim VehicleInfo As List(Of String())
    Dim TotalWorkbook As New ReoGridControl
    Dim PreviouslySelectedRow As Integer = 0
    'Dim PrevValue As New DataGridViewRow
    Private Sub SurveyEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        VehicleInfo = ReadVehicleFile()
        Dim AutoCompleteCollection As New AutoCompleteStringCollection
        For Each Vehicle() As String In VehicleInfo
            VehComboBox.Items.Add(Vehicle(0))
            AutoCompleteCollection.Add(Vehicle(0))
        Next
        VehComboBox.AutoCompleteCustomSource = AutoCompleteCollection
        TotalWorkbook.Load(My.Settings.BaseLocation & "\" & My.Settings.TotalFile, IO.FileFormat.Excel2007)
    End Sub

    Private Sub SurveyEntry_Show(sender As Object, e As EventArgs) Handles Me.Shown
        ' The GUI doesn't allow the datagridview double-buffering to be enabled, so the next three lines enable it
        Dim dgvType As Type = SurveyView.GetType()
        Dim pi As Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        pi.SetValue(SurveyView, True, Nothing)
        ' And now there should be double-buffering, which will help speed the repainting of the control, especially when scrolling.
        DateTimePicker1.Value = Now()
        DateTimePicker1.MaxDate = Now()
        VehComboBox.SelectedIndex = CInt(VehicleInfo.Count / 2)
        SerialTextBox.Select()
    End Sub

    Public Sub StartEntry(RouteFile As String)
        RemoveAllHandlers()
        If CSVtoDataSource(RouteFile, SurveyView, WorkingSurvey) Then
            SurveyView.AutoResizeColumns()
            ResizeGrid(SurveyView)
            LastRow = SurveyView.Rows.Count - 1
            SurveyView.Rows(LastRow).ReadOnly = True
            SurveyView.CurrentCell = SurveyView.Rows(0).Cells(PBoard)
            SurveyView.FirstDisplayedScrollingRowIndex = 0
            'PreviouslySelectedRow = 0
            SurveyView.Rows(0).DefaultCellStyle.BackColor = Color.Aqua
        Else
            SurveyView.Rows.Clear()
            ImportButt.Enabled = True
        End If
        SurveyView.Tag = 0
        AddAllHandlers()

        'ResizeGrid(SurveyView)
    End Sub

    Private Sub ResizeGrid(ByRef dgrid As DataGridView)
        SuspendDrawing(dgrid)
        Dim fullWidth As Integer = 0
        For Each c As DataGridViewColumn In dgrid.Columns
            If c.Visible Then fullWidth += c.Width + c.DividerWidth * 2
        Next
        fullWidth += SystemInformation.VerticalScrollBarWidth + 15
        ' Do NOT move this line below the dgrid.Width statement.  Without the control redrawing when the width is set, the whole window gets ugly
        ResumeDrawing(dgrid)
        dgrid.Width = fullWidth
        SaveButton.Location = New Point((dgrid.Location.X + fullWidth) + 12, SaveButton.Location.Y)
        ClearButt.Location = New Point((dgrid.Location.X + fullWidth) + 12, ClearButt.Location.Y)
        Me.Width = SaveButton.Location.X + SaveButton.Width + 25
    End Sub

    Private Sub SurveyEntry_ResizeEnd(sender As Object, e As EventArgs) ' Handles Me.SizeChanged
        ResizeGrid(SurveyView)
    End Sub

    Protected Friend Sub SurveyView_CellValueChanged(Optional sender As Object = Nothing, Optional e As DataGridViewCellEventArgs = Nothing) ' Handles SurveyView.CellValueChanged
        Dim ItIs As Object = CellVal(SurveyView, e.ColumnIndex, e.RowIndex)
        If Not IsNumeric(ItIs) Then
            SurveyView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
        End If
        Dim currentvalue As Int64 = CellVal(SurveyView, e.ColumnIndex, e.RowIndex)
        'Dim cellCollection() As DataGridViewCell = New DataGridViewCell(2) {}
        With SurveyView

            If currentvalue < 0 Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                WorkingCell.Style.ForeColor = Color.Red
                .Rows(SurveyView.CurrentCell.RowIndex).Cells(SurveyView.CurrentCell.ColumnIndex).Style.ForeColor = Color.Red
                .CurrentCell.Style.ForeColor = Color.Red
                SurveyView.Tag += 1
            Else
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
                '.CurrentCell.Style.ForeColor = Color.Black
                .Rows(SurveyView.CurrentCell.RowIndex).Cells(SurveyView.CurrentCell.ColumnIndex).Style.ForeColor = Color.Black
                WorkingCell.Style.ForeColor = Color.Black
                SurveyView.Tag -= 1
            End If
        End With

        If Not CurrentlyUpdating Then
            CurrentlyUpdating = True
            If currentvalue = 0 Then SurveyView.CurrentCell.Value = DBNull.Value
            UpdateTotals(SurveyView)
            CurrentlyUpdating = False
        End If
        If SurveyView.Tag < 0 Then SurveyView.Tag = 0
        SaveButton.Enabled = (SurveyView.Tag = 0)
    End Sub

    Private Sub UpdateTotals(ByRef dgrid As DataGridView)
        SuspendDrawing(dgrid)
        Dim POnTotal As Integer = 0
        Dim POffTotal As Integer = 0
        Dim CurrentOn As Integer
        Dim CurrentOff As Integer
        'Dim Index As Integer = 0
        'While Index < LastRow
        For Index As Integer = 0 To LastRow - 1

            CurrentOn = CellVal(dgrid, PBoard, Index)
            CurrentOff = CellVal(dgrid, PDBoard, Index)
            POnTotal += CurrentOn
            POffTotal += CurrentOff
            If ((CurrentOn > 0) Or (CurrentOff > 0)) Then
                Update_POB(dgrid, Index)
                'Update_POB(dgrid, LastRow)
                Update_DBStops(dgrid, Index)
                'Update_DBStops(dgrid, LastRow)
                Update_PMiles(dgrid, Index)
                'Update_PMiles(dgrid, LastRow)
            Else
                ZeroColumns(dgrid, Index)
            End If
            Update_POB(dgrid, LastRow)
            Update_DBStops(dgrid, LastRow)
            Update_PMiles(dgrid, LastRow)
        Next
        'End While
        dgrid(PDBoard, LastRow).Value = POnTotal - POffTotal
        If POnTotal - POffTotal < 0 Then SurveyView.Tag += 1
        dgrid(POB, LastRow).Value = POnTotal
        ResumeDrawing(dgrid)
    End Sub

    Private Sub Update_POB(ByRef dgrid As DataGridView, ChangedRow As Integer)
        SuspendDrawing(dgrid)
        Dim POnBrd As Integer
        Dim Index As Integer = 0
        While Index < ChangedRow
            POnBrd += CellVal(dgrid, PBoard, Index) - CellVal(dgrid, PDBoard, Index)
            Index += 1
        End While
        If POnBrd <> 0 Then
            dgrid(POB, ChangedRow).Value = CInt(POnBrd)
        Else
            dgrid(POB, ChangedRow).Value = DBNull.Value
        End If
        ResumeDrawing(dgrid)
    End Sub

    Private Sub Update_DBStops(ByRef dgrid As DataGridView, ChangedRow As Integer)
        SuspendDrawing(dgrid)
        If ChangedRow <> 0 Then
            Dim PrevRow As Integer = FindPrevious(dgrid, ChangedRow)
            Dim DB As Double = Convert.ToDouble(CellVal(dgrid, Odo, ChangedRow) - CellVal(dgrid, Odo, PrevRow))
            If DB <> 0 Then
                dgrid.Rows(ChangedRow).Cells(DBS).Value = Format(DB, "##.##")
            Else
                dgrid.Rows(ChangedRow).Cells(DBS).Value = DBNull.Value
            End If
        End If
        ResumeDrawing(dgrid)
    End Sub

    Private Sub Update_PMiles(ByRef dgrid As DataGridView, ChangedRow As Integer)
        SuspendDrawing(dgrid)
        If ChangedRow <> 0 Then
            'Dim PrevRow As Integer = FindPrevious(dgrid, ChangedRow)
            Dim PMil As Double = Convert.ToDouble(CellVal(dgrid, DBS, ChangedRow) * CellVal(dgrid, POB, ChangedRow))
            If PMil <> 0 Then
                dgrid.Rows(ChangedRow).Cells(PM).Value = Format(PMil, "##.##")
            Else
                dgrid.Rows(ChangedRow).Cells(PM).Value = DBNull.Value
            End If
        End If
        ResumeDrawing(dgrid)
    End Sub

    Private Sub SurveyView_KeyDown(sender As Object, e As KeyEventArgs) Handles SurveyView.KeyDown
        Dim AllowedKeys() As Keys = {Keys.Back, Keys.Delete, Keys.Left, Keys.Right, Keys.Home, Keys.End,
                                     Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Tab, Keys.Enter,
                                     Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
                                     Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5,
                                     Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9}
        If Not AllowedKeys.Contains(e.KeyCode) Then
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Delete Then
            WorkingCell.Value = DBNull.Value
        End If
    End Sub

    Private Shared Function CellVal(dgrid As DataGridView, column As Integer, Row As Integer) As Object
        Dim value As Object
        Dim Rtn As Object
        value = dgrid.Rows(Row).Cells(column).Value
        If value IsNot DBNull.Value Then
            Rtn = value
        Else
            Rtn = 0
        End If
        Return Rtn
    End Function

    Shared Function FindPrevious(dgrid As DataGridView, CurrentRow As Integer) As Integer
        Dim Index As Integer = CurrentRow - 1
        Dim Rtn As Integer = 0
        While (Index >= 0)
            If CellVal(dgrid, PBoard, Index) <> 0 Or CellVal(dgrid, PDBoard, Index) <> 0 Then
                Rtn = Index
                Exit While
            End If
            Index -= 1
        End While
        Return Rtn
    End Function

    Private Shared Sub ZeroColumns(dgrid As DataGridView, ChangedRow As Integer)
        dgrid.Rows(ChangedRow).Cells(POB).Value = DBNull.Value
        dgrid.Rows(ChangedRow).Cells(DBS).Value = DBNull.Value
        dgrid.Rows(ChangedRow).Cells(PM).Value = DBNull.Value
    End Sub

    Private Sub SurveyView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SurveyView.CellEnter
        ''    PrevValue = SurveyView.CurrentRow
        WorkingCell = SurveyView.CurrentCell
    End Sub

    Protected Sub SurveyView_SelectionChanged(sender As Object, e As EventArgs) 'Handles SurveyView.SelectionChanged
        SuspendDrawing(SurveyView)
        With SurveyView
            If .CurrentCell.ColumnIndex < PBoard Then
                Dim WorkRow As Integer = .CurrentCell.RowIndex
                If WorkRow > 0 Then
                    WorkRow -= 1
                Else
                    WorkRow = LastRow - 1
                End If
                .CurrentCell = .Rows(WorkRow).Cells(PDBoard)
            ElseIf .CurrentCell.ColumnIndex > PDBoard Then
                Dim WorkRow As Integer = .CurrentCell.RowIndex
                If WorkRow < LastRow Then
                    WorkRow += 1
                Else
                    WorkRow = 0
                End If
                .CurrentCell = .Rows(WorkRow).Cells(PBoard)
            End If
            .Rows(PreviouslySelectedRow).DefaultCellStyle = Nothing
            PreviouslySelectedRow = .CurrentRow.Index
            .CurrentRow.DefaultCellStyle.BackColor = Color.Aqua
        End With
        ResumeDrawing(SurveyView)
    End Sub

    Private Sub StoreOnFile(SV As EnteredSurvey) ', Workbook As ReoGridControl)
        'Workbook.Load(My.Settings.BaseLocation & "\" & My.Settings.TotalFile, IO.FileFormat.Excel2007)
        Dim Sheet As Worksheet = TotalWorkbook.CurrentWorksheet
        With Sheet
            'Dim BottomLine As Integer = CInt(.Cells("X2").Data)
            Dim BottomLine As Integer = LastLine()
            Dim SerialSplit() As String = RouteRunSplit(SV.TripSerial)
            If SerialSplit(0) = "2E" Then SerialSplit(0) = "2East"
            Dim SerialFix = SerialSplit(0) + "-" + SerialSplit(1)
            .Cells("A" & BottomLine.ToString()).Data = SerialFix.ToString()
            .Cells("B" & BottomLine.ToString()).Data = SV.SurveyDate.ToString()
            .Cells("C" & BottomLine.ToString()).Data = SV.DayOfWeek.ToString()
            .Cells("D" & BottomLine.ToString()).Data = SV.TimePeriod.ToString()
            .Cells("E" & BottomLine.ToString()).Data = SV.Route.ToString()
            .Cells("F" & BottomLine.ToString()).Data = SV.TotalCapacity
            .Cells("G" & BottomLine.ToString()).Data = SV.SeatedCapacity
            .Cells("H" & BottomLine.ToString()).Data = Convert.ToDouble(SV.CapacityMiles)
            .Cells("I" & BottomLine.ToString()).Data = Convert.ToDouble(SV.SeatedMiles)
            .Cells("J" & BottomLine.ToString()).Data = SV.PassengersBoarded
            .Cells("K" & BottomLine.ToString()).Data = SV.PassengersOnBoard
            .Cells("L" & BottomLine.ToString()).Data = Convert.ToDouble(SV.DistanceBetStops)
            .Cells("M" & BottomLine.ToString()).Data = Convert.ToDouble(SV.PassengerMiles)
            .Cells("X2").Data = BottomLine + 1
        End With
        TotalWorkbook.Save(My.Settings.BaseLocation & "\" & My.Settings.TotalFile, IO.FileFormat.Excel2007)
        Sheet = Nothing
        'TotalWorkbook = Nothing
    End Sub

    Private Sub DateTimePicker1_Leave(sender As Object, e As EventArgs) Handles DateTimePicker1.Leave
        If DateTimePicker1.Value > Today() Then
            DateTimePicker1.Value = Today()
        End If
        If DateAndTime.Weekday(CDate(DateTimePicker1.Value)) = vbSunday Then
            MsgBox("Date cannot be a Sunday.", vbCritical)
            DateTimePicker1.Value = DateTimePicker1.Value.AddDays(1)
            DateTimePicker1.Select()
        End If
        If Not String.IsNullOrEmpty(SerialTextBox.Text) Then
            FillInTODAndDOW()
        End If

    End Sub


    Private Function TimeOfDay(Serial As String, DayOfWeek As Integer) As String()
        Dim RRun() As String = RouteRunSplit(Serial)
        Dim SurveysToCheck As List(Of Route)
        If ((DayOfWeek = 7) Or (Strings.Right(RRun(0), 1) = "S")) Then
            SurveysToCheck = SplashScreen1.SDSurvNums
        Else
            SurveysToCheck = SplashScreen1.WDSurvNums
        End If
        Dim TOD As String = ""
        Try
            TOD = RunTimes(RRun(0), SurveysToCheck)(CInt(RRun(1) - 1))
        Catch
            Return New String() {"Error", "Error"}
        End Try
        Dim TimePeriod As String = "Afternoon"
        If DateTime.Parse(TOD) >= DateTime.Parse(My.Settings.PMPeak) Then
            TimePeriod = "PM Peak"
        ElseIf DateTime.Parse(TOD) < DateTime.Parse(My.Settings.Afternoon) Then
            TimePeriod = "AM Peak"
        End If
        WorkingSurvey.TimePeriod = TimePeriod
        WorkingSurvey.TripSerial = Serial
        Return New String() {TimePeriod, TOD}
    End Function

    Private Shared Function RunTimes(RName As String, Surveys As List(Of Route)) As List(Of String)
        Dim ListOfRuns As New List(Of String)
        For Each Rout As Route In Surveys
            If Rout.Name = RName Then
                ListOfRuns = Rout.Times
                Exit For
            End If
        Next
        Return ListOfRuns
    End Function

    Private Shared Function RouteRunSplit(Serial As String) As String()
        RouteRunSplit = Trim(Serial).Split("-")
    End Function

    Private Sub FillInTODAndDOW()
        Dim SurveyDate As Date = DateTimePicker1.Value
        Dim SurveySerial As String = Trim(SerialTextBox.Text.ToUpper())
        'Dim IsSaturday As Boolean = False
        DOWeek = DateAndTime.Weekday(CDate(SurveyDate))
        DayOfWeekLabel.Text = "Day Of Week: " & DateAndTime.WeekdayName(DOWeek)
        Dim TOfDInfo() As String = TimeOfDay(SurveySerial, DOWeek)
        If TOfDInfo(0) = "Error" Then
            MsgBox("The Serial Number is invald.  Please correct.", vbCritical)
            SerialTextBox.Clear()
            SerialTextBox.Focus()
            ImportButt.BackColor = SystemColors.ControlDarkDark
            ImportButt.Enabled = False
            Exit Sub
        End If
        'MsgBox("Date: " + Trim(DateTimePicker1.Value.ToString()) + "   Time: " + Trim(SerialTextBox.Text), vbOKOnly)
        If PreviouslyEntered(Trim(SurveyDate.ToString("MM/dd/yyyy")), Trim(SurveySerial)) Then
            MsgBox("This survey has been entered already.", vbCritical)
            SerialTextBox.Clear()
            DateTimePicker1.Value = Today()
            Exit Sub
        End If
        TOfDay = TOfDInfo(0)
        TimeOfDayLabel.Text = "Time Of Day: " & TOfDInfo(1) & vbNewLine & "(" & TOfDInfo(0) & ")"
        WorkingSurvey.TimePeriod = TOfDay
        WorkingSurvey.SurveyDate = SurveyDate.ToShortDateString
        WorkingSurvey.SurveyTime = TOfDInfo(1)
        ImportButt.BackColor = SystemColors.ActiveCaption
        ImportButt.Enabled = True
    End Sub

    Private Sub SerialTextBox_Leave(sender As Object, e As EventArgs) Handles SerialTextBox.Leave
        'SerialTextBox.Text = SerialTextBox.Text.ToUpper()
        If Not String.IsNullOrEmpty(SerialTextBox.Text) Then
            WorkingSurvey.TripSerial = Trim(SerialTextBox.Text.ToUpper())
            'If Not String.IsNullOrEmpty(DateTimePicker1.Value.ToString()) Then
            FillInTODAndDOW()

        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveButton.Enabled = False
        WorkingSurvey.TripSerial = SerialTextBox.Text
        WorkingSurvey.TimePeriod = TOfDay
        TotalItAll(SurveyView)
        StoreOnFile(WorkingSurvey) ', TotalWorkbook)
        MsgBox("Saved", vbOKOnly)
        'ClearButt.PerformClick()
        RemoveAllHandlers()
        SurveyView.Rows.Clear()
        SerialTextBox.Clear()
        ImportButt.Enabled = True
        TimeOfDayLabel.Text = "Time Of Day:"
        SerialTextBox.Select()
    End Sub

    Private Sub ImportButt_Click(sender As Object, e As EventArgs) Handles ImportButt.Click
        RemoveAllHandlers()
        ImportButt.BackColor = SystemColors.ControlDarkDark
        ImportButt.Enabled = False
        SurveyView.Rows.Clear()
        WorkingSurvey.Clear()
        Dim FileName As String = RouteRunSplit(Trim(SerialTextBox.Text).ToUpper())(0)
        If Strings.Right(FileName, 1) = "S" Then
            FileName = FileName.Remove(FileName.Length - 1, 1)
            If DOWeek <> 7 Then
                MsgBox("The Serial Number indicates a Saturday route" & vbNewLine & "but the date is not a Saturday." & vbNewLine & vbNewLine & "Please fix the error.", vbCritical)
                SerialTextBox.Select()
                Exit Sub
            End If
        End If
        FileName = "R" + FileName + ".csv"
        StartEntry(FileName)
        AddAllHandlers()
    End Sub

    Private Sub VehComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles VehComboBox.SelectedIndexChanged
        SeatedCapacity = CInt(VehicleInfo(VehComboBox.SelectedIndex)(2))
        TotalCapacity = CInt(VehicleInfo(VehComboBox.SelectedIndex)(1))
        SeatedLabel.Text = ""
        TotalLabel.Text = ""
        SeatedLabel.Text = "Seated Cap: " & SeatedCapacity.ToString()
        TotalLabel.Text = "Total Cap: " & TotalCapacity.ToString()
        WorkingSurvey.SeatedCapacity = SeatedCapacity
        WorkingSurvey.TotalCapacity = TotalCapacity

    End Sub

    Private Sub TotalItAll(dgrid As DataGridView)
        Dim PassengersBoarded As Integer = 0
        Dim PassengersOnBoard As Integer = 0
        Dim DistanceBetweenStops As Double = 0D
        Dim PassengerMiles As Double = 0D
        For row As Integer = 0 To LastRow
            PassengersBoarded += CInt(CellVal(dgrid, PBoard, row))
            PassengersOnBoard += CInt(CellVal(dgrid, POB, row))
            DistanceBetweenStops += Convert.ToDouble(CellVal(dgrid, DBS, row))
            PassengerMiles += Convert.ToDouble(CellVal(dgrid, PM, row))
        Next
        With WorkingSurvey
            .PassengersBoarded = PassengersBoarded
            .PassengersOnBoard = PassengersOnBoard
            .DistanceBetStops = DistanceBetweenStops
            .PassengerMiles = PassengerMiles
            .TotalCapacity = TotalCapacity
            .SeatedCapacity = SeatedCapacity
            .SurveyDate = DateTimePicker1.Value.ToShortDateString
            .SurveyTime = TimeOfDay(SerialTextBox.Text, CInt(DateTimePicker1.Value.DayOfWeek))(1)
        End With
    End Sub

    Private Sub ClearButt_Click(sender As Object, e As EventArgs) Handles ClearButt.Click
        RemoveAllHandlers()
        SuspendDrawing(SurveyView)
        For Index As Integer = 0 To LastRow
            SurveyView.Rows(Index).Cells(PBoard).Value = DBNull.Value
            SurveyView.Rows(Index).Cells(PDBoard).Value = DBNull.Value
            ZeroColumns(SurveyView, Index)
        Next
        SurveyView.CurrentCell = SurveyView.Rows(0).Cells(PBoard)
        SurveyView.FirstDisplayedScrollingRowIndex = 0
        ResumeDrawing(SurveyView)
        AddAllHandlers()
    End Sub

    Private Sub RemoveAllHandlers()
        RemoveHandler SurveyView.CellValueChanged, AddressOf SurveyView_CellValueChanged
        RemoveHandler Me.SizeChanged, AddressOf SurveyEntry_ResizeEnd
        RemoveHandler SurveyView.SelectionChanged, AddressOf SurveyView_SelectionChanged
    End Sub
    Private Sub AddAllHandlers()
        AddHandler SurveyView.CellValueChanged, AddressOf SurveyView_CellValueChanged
        AddHandler Me.SizeChanged, AddressOf SurveyEntry_ResizeEnd
        AddHandler SurveyView.SelectionChanged, AddressOf SurveyView_SelectionChanged
    End Sub

    Private Sub SurveyEntry_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        TotalWorkbook = Nothing
    End Sub

    Private Function PreviouslyEntered(dayt As String, Serial As String) As Boolean
        Dim IsFound As Boolean = False
        'TotalWorkbook.Load(My.Settings.BaseLocation & "\" & My.Settings.TotalFile, IO.FileFormat.Excel2007)
        Dim Sheet As Worksheet = TotalWorkbook.CurrentWorksheet
        Dim BottomLine As Integer = LastLine() - 1
        While ((BottomLine > 2) And (Not IsFound))
            'If IsDBNull(Sheet.GetCell("A" + BottomLine.ToString())) Then Return False
            Dim Trip As String = Sheet.GetCellData("A" & BottomLine.ToString()).ToString()
            Dim SDate As String = Sheet.GetCellData("B" & BottomLine.ToString()).ToString()
            IsFound = ((dayt = SDate) And (Serial = Trip)) ' Checks whether this serial number has been entered for this date already, indicating a duplicate
            BottomLine -= 1
        End While
        Sheet = Nothing
        Return IsFound
    End Function

    Private Function LastLine() As Integer
        ' Although there is a built-in way to find the last entered line on a spreadsheet, this one is consistently correct.
        ' The built-in method finds the last line accessed, rather than the last line with any data.
        Dim Last As Integer = 1
        Dim Wsheet As Worksheet = TotalWorkbook.Worksheets("Sheet1")
        While Not IsDBNull(Wsheet.CreateAndGetCell("A" + Last.ToString())) And Wsheet.GetCellData("A" + Last.ToString()) <> ""
            Last += 1
        End While
        Return Last
    End Function

    Private Sub CapTimer_Tick(sender As Object, e As EventArgs) Handles CapTimer.Tick
        Dim r As Integer = SeatedLabel.ForeColor.R
        Dim g As Integer = SeatedLabel.ForeColor.G
        Dim b As Integer = SeatedLabel.ForeColor.B
        r -= 4
        If r >= 0 Then
            SeatedLabel.ForeColor = Color.FromArgb(r, g, b)
            TotalLabel.ForeColor = Color.FromArgb(r, g, b)
        Else
            CapTimer.Stop()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DayOfWeekLabel.Text = "Day Of Week: " & DateAndTime.WeekdayName(DateAndTime.Weekday(CDate(DateTimePicker1.Value)))
        DayOfWeekLabel.ForeColor = Color.FromArgb(255, 0, 0)
        DOWTimer.Start()
    End Sub

    Private Sub DOWTimer_Tick(sender As Object, e As EventArgs) Handles DOWTimer.Tick
        Dim r As Integer = DayOfWeekLabel.ForeColor.R
        Dim g As Integer = DayOfWeekLabel.ForeColor.G
        Dim b As Integer = DayOfWeekLabel.ForeColor.B
        r -= 4
        If r >= 0 Then
            DayOfWeekLabel.ForeColor = Color.FromArgb(r, g, b)
        Else
            DOWTimer.Stop()
        End If
    End Sub

    Private Sub TODTimer_Tick(sender As Object, e As EventArgs) Handles TODTimer.Tick
        Dim r As Integer = TimeOfDayLabel.ForeColor.R
        Dim g As Integer = TimeOfDayLabel.ForeColor.G
        Dim b As Integer = TimeOfDayLabel.ForeColor.B
        r -= 4
        If r >= 0 Then
            TimeOfDayLabel.ForeColor = Color.FromArgb(r, g, b)
        Else
            TODTimer.Stop()
        End If
    End Sub

    Private Sub DayOfWeekLabel_TextChanged(sender As Object, e As EventArgs) Handles DayOfWeekLabel.TextChanged
        DayOfWeekLabel.ForeColor = Color.FromArgb(255, 0, 0)
        DOWTimer.Start()
    End Sub

    Private Sub SeatedLabel_TextChanged(sender As Object, e As EventArgs) Handles SeatedLabel.TextChanged
        SeatedLabel.ForeColor = Color.FromArgb(255, 0, 0)
        TotalLabel.ForeColor = Color.FromArgb(255, 0, 0)
        CapTimer.Start()
    End Sub

    Private Sub TimeOfDayLabel_TextChanged(sender As Object, e As EventArgs) Handles TimeOfDayLabel.TextChanged
        TimeOfDayLabel.ForeColor = Color.FromArgb(255, 0, 0)
        TODTimer.Start()
    End Sub


End Class