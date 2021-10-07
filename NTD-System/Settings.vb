Imports System.Globalization
Public Class FormSettings
    ReadOnly DayArray(7) As CheckBox
    ReadOnly DifferentSurvey(7) As CheckBox
    Shared Function SwitchComma(inpt As String, Optional makecomma As Boolean = False) As String
        Dim out As String = ""
        For Each c As String In inpt
            If c <> "," And Not makecomma Then
                out &= c
            ElseIf c = "|" And makecomma Then
                out &= ","
            End If
        Next
        SwitchComma = out
    End Function

    Private Sub BaseChange_Click(sender As Object, e As EventArgs) Handles BaseChange.Click
        BaseBox.Text = DirectoryOrFile(BaseBox.Text, False)
    End Sub

    Private Function BoolToString(arr As Array) As String
        Dim Answer As String = ""
        Dim s As String
        For Each a As Boolean In arr
            If a Then
                s = "T"
            Else
                s = "F"
            End If
            Answer += s
        Next
        Return Trim(Answer)
    End Function

    Private Sub CanButt_Click(sender As Object, e As EventArgs) Handles CanButt.Click
        Hide()
        Close()
    End Sub

    Private Sub CompletedChange_Click(sender As Object, e As EventArgs) Handles CompletedChange.Click
        CompBox.Text = DirectoryOrFile(CompBox.Text, False)
    End Sub

    Private Sub CreButt_Click(sender As Object, e As EventArgs) Handles CreButt.Click
        Dim Look As New FolderBrowserDialog
        If Look.ShowDialog() = DialogResult.OK Then
            CreatedSurveys.Text = Look.SelectedPath
        End If
    End Sub

    Private Function DirectoryOrFile(Def As String, Optional ReturnFile As Boolean = True) As String
        DirectoryOrFile = Def
        If Not ReturnFile Then
            Dim Look As New FolderBrowserDialog
            If Look.ShowDialog() = DialogResult.OK Then
                DirectoryOrFile = Look.SelectedPath
            End If
        Else
            Dim Look As New OpenFileDialog()
            If Look.ShowDialog() = DialogResult.OK Then
                DirectoryOrFile = System.IO.Path.GetFileName(Look.FileName)
            End If
        End If
    End Function

    Private Sub DunButt_Click(sender As Object, e As EventArgs) Handles DunButt.Click
        'With My.Settings
        '.BaseLocation = Trim(CStr(BaseBox.Text))
        '.CompletedLocation = Trim(CStr(CompBox.Text))
        '.DayIndex = BoolToString(DayArray)
        '.DiffDay = BoolToString(DifferentSurvey)
        '.NumSurveys = CInt(nSurv.Value)
        '.SurveyFileName = Trim(CStr(SurveyFName.Text))
        '.SettingsFileName = Trim(CStr(SettingsFName.Text))
        '.RouteRunFileName = Trim(CStr(RRFN.Text))
        '.WeekdayBatchFileName = Trim(CStr(WDBatchName.Text))
        '.WeekendBatchFileName = Trim(CStr(WEBatchName.Text))
        '.CreatedLocation = Trim(CStr(CreatedSurveys.Text))
        '.TotalFile = Trim(CStr(TotalFileName.Text))
        '.AMPeak = Trim(CStr(AMPeakPicker.Value))
        '.Afternoon = Trim(CStr(AfternoonPicker.Value))
        '.PMPeak = Trim(CStr(PMPicker.Value))
        '.VehCapFile = Trim(CStr(VCapName.Text))
        '.Save()
        'End With
        With SplashScreen1.Settings
            .BaseLocation = Trim(CStr(BaseBox.Text))
            .CompletedLocation = Trim(CStr(CompBox.Text))
            '.DayIndex = BoolToString(DayArray)
            '.DiffDay = BoolToString(DifferentSurvey)
            .SurveysPerWeek = CInt(nSurv.Value)
            .NameOfSurveyFile = Trim(CStr(SurveyFName.Text))
            .NameOfSettingsFile = Trim(CStr(SettingsFName.Text))
            .NameOfRouteRunFile = Trim(CStr(RRFN.Text))
            .WeekdayBatchFile = Trim(CStr(WDBatchName.Text))
            .WeekendBatchFile = Trim(CStr(WEBatchName.Text))
            .CreatedSurveyLocation = Trim(CStr(CreatedSurveys.Text))
            .SurveyTotalFile = Trim(CStr(TotalFileName.Text))
            .AMPeak = Trim(CStr(AMPeakPicker.Value))
            .Afternoon = Trim(CStr(AfternoonPicker.Value))
            .PMPeak = Trim(CStr(PMPicker.Value))
            .VehicleCapacityFile = Trim(CStr(VCapName.Text))
        End With
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub F9_Key(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode <> 120 Then Exit Sub
        Const c As String = ","
        Const v As String = "|"
        Dim mess As String
        Dim Sett As String
        Dim Active As String = InputBox("On what date would you like the settings to become active?", "Active Date", Str(CDate(Now)))
        Dim UpdateDefault As Boolean = (MsgBox("Make these settings the new default?", vbYesNo, "Default Settings") = vbYes)
        mess = Active + c + vbNewLine + "0xC000,"
        If UpdateDefault Then
            mess += "T,"
        Else mess += "F,"
        End If
        Sett = Trim(BaseBox.Text) + c + BoolToString(DayArray) + c + BoolToString(DifferentSurvey) + c
        Sett += Trim(CompBox.Text) + c + Trim(CStr(nSurv.Value)) + c + Trim(SettingsFName.Text) + c
        Sett += Trim(SurveyFName.Text) + c + Trim(RRFN.Text) + c + Trim(WDBatchName.Text) + c
        Sett += Trim(WEBatchName.Text) + c + Trim(CreatedSurveys.Text) + c + Trim(TotalFileName.Text)
        Sett += Trim(AMPeakPicker.Value.ToString) + c + Trim(AfternoonPicker.Value.ToString) + c + Trim(PMPicker.Value.ToString) + c + Trim(VCapName.Text)
        If UpdateDefault Then
            Dim NewMess As String
            NewMess = Sett.Replace(c, v)
            Sett += c + NewMess
        End If
        Sett = mess + Sett
        SaveSettings(Sett)
    End Sub

    Private Sub LoadFromSettings()
        'Dim DayArray(7) As CheckBox
        'Dim DA As CheckBox
        DayArray(1) = CheckSun
        DayArray(2) = CheckMon
        DayArray(3) = CheckTue
        DayArray(4) = CheckWed
        DayArray(5) = CheckTh
        DayArray(6) = CheckFri
        DayArray(7) = CheckSat
        DifferentSurvey(1) = DiffSun
        DifferentSurvey(2) = DiffMon
        DifferentSurvey(3) = DiffTue
        DifferentSurvey(4) = DiffWed
        DifferentSurvey(5) = DiffThu
        DifferentSurvey(6) = DiffFri
        DifferentSurvey(7) = DiffSat

        For b As Integer = 1 To 7
            If UCase(Mid(My.Settings.DayIndex, b, 1)) = "T" Then
                DayArray(b).Checked = True
            Else DayArray(b).Checked = False
            End If
            If UCase(Mid(My.Settings.DiffDay, b, 1)) = "T" Then
                DifferentSurvey(b).Checked = True
            Else DifferentSurvey(b).Checked = False
            End If
            '      DA = DayArray(b)
            '       AddHandler DA.CheckStateChanged, AddressOf CheckBox_CheckedChanged
        Next
        With My.Settings
            nSurv.Value = CInt(.NumSurveys)
            BaseBox.Text = CStr(.BaseLocation)
            CompBox.Text = CStr(.CompletedLocation)
            SurveyFName.Text = CStr(.SurveyFileName)
            SettingsFName.Text = CStr(.SettingsFileName)
            RRFN.Text = CStr(.RouteRunFileName)
            WDBatchName.Text = CStr(.WeekdayBatchFileName)
            WEBatchName.Text = CStr(.WeekendBatchFileName)
            CreatedSurveys.Text = CStr(.CreatedLocation)
            TotalFileName.Text = CStr(.TotalFile)
            Dim Provider As New CultureInfo("en-US")
            AMPeakPicker.Value = Convert.ToDateTime(.AMPeak)
            AfternoonPicker.Value = Convert.ToDateTime(.Afternoon)
            PMPicker.Value = Convert.ToDateTime(.PMPeak)
            VCapName.Text = CStr(.VehCapFile)
        End With
    End Sub

    Private Sub RevertButt_Click(sender As Object, e As EventArgs) Handles RevertButt.Click
        SplitAndSet(My.Settings.Defaults)
        My.Settings.Save()
        LoadFromSettings()
    End Sub

    Private Sub RRFNButt_Click(sender As Object, e As EventArgs) Handles RRFNButt.Click
        RRFN.Text = DirectoryOrFile(RRFN.Text, True)
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AMPeakPicker.Format = DateTimePickerFormat.Custom
        AMPeakPicker.CustomFormat = "hh:mm"
        AfternoonPicker.Format = DateTimePickerFormat.Custom
        AfternoonPicker.CustomFormat = "hh:mm"
        PMPicker.Format = DateTimePickerFormat.Custom
        PMPicker.CustomFormat = "hh:mm"
        LoadFromSettings()
    End Sub
    Private Sub SettingsChange_Click(sender As Object, e As EventArgs) Handles SettingsChange.Click
        SettingsFName.Text = DirectoryOrFile(SettingsFName.Text, True)
    End Sub

    Private Sub SplitAndSet(sent As String, Optional dflt As Boolean = False)
        Dim Stngs() As String = Split(sent, ",")
        With My.Settings
            .DayIndex = Stngs(0)
            .DiffDay = Stngs(1)
            .BaseLocation = Stngs(2)
            .CompletedLocation = Stngs(3)
            .NumSurveys = CInt(Stngs(4))
            .SettingsFileName = Stngs(5)
            .SurveyFileName = Stngs(6)
            .RouteRunFileName = Stngs(7)
            .CreatedLocation = Stngs(8)
            .TotalFile = Stngs(9)
            .AMPeak = Stngs(10)
            .Afternoon = Stngs(11)
            .PMPeak = Stngs(12)
            .VehCapFile = Stngs(13)
            If dflt Then
                .Defaults = SwitchComma(Stngs(14))
            End If
        End With
    End Sub

    Private Sub SurveyChange_Click(sender As Object, e As EventArgs) Handles SurveyChange.Click
        SurveyFName.Text = DirectoryOrFile(SurveyFName.Text, True)
    End Sub

    Private Sub UndoBut_Click(sender As Object, e As EventArgs) Handles UndoBut.Click
        LoadFromSettings()
    End Sub
    'Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
    '    MsgBox(DirectCast(sender, CheckBox).Name, vbOKOnly)
    'End Sub
    Private Sub WeekdayBatch_Click(sender As Object, e As EventArgs) Handles WDButt.Click
        WDBatchName.Text = DirectoryOrFile(WDBatchName.Text, True)
    End Sub
    Private Sub WeekendBatch_Click(sender As Object, e As EventArgs) Handles WEButt.Click
        WEBatchName.Text = DirectoryOrFile(WEBatchName.Text, True)
    End Sub

    Private Sub TotalFileButt_Click(sender As Object, e As EventArgs) Handles TotalFileButt.Click
        TotalFileName.Text = DirectoryOrFile(TotalFileName.Text, True)
    End Sub

    Private Sub VehCapBut_Click(sender As Object, e As EventArgs) Handles VehCapBut.Click
        VCapName.Text = DirectoryOrFile(VCapName.Text, True)
    End Sub
End Class