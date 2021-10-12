Imports System.IO, System.Xml.Serialization
Imports System.Deployment.Application
Imports Nager.Date
Module Comm
    Friend Function CheckConnection() As Boolean
        CheckConnection = File.Exists(My.Settings.BaseLocation & My.Settings.SurveyFileName)
    End Function
    ' Friend Sub UpdateSettings(Optional fyle As String = ".")
    ' '  Settings can be updated by placing a settings file on the server
    ' '  It's a simple CSV file, with the first value of the second line indicating the type
    ' '  of settings file.  0xC000 indicates a valid file including changes for everything
    ' '  Further codes can be implemented here for various reasons.
    ' If fyle <> "." Then
    '         File.Delete(My.Settings.BaseLocation & My.Settings.SettingsFileName)
    '         File.Copy(fyle, My.Settings.BaseLocation & My.Settings.SettingsFileName)
    ' End If
    '     fyle = My.Settings.SettingsFileName
    '
    '    If File.Exists(My.Settings.BaseLocation & fyle) Then
    '    Dim StngsFile As New StreamReader(My.Settings.BaseLocation & fyle)
    '    Dim Line, stings() As String
    '            Line = StngsFile.ReadLine() 'First line is the date of the settings.  This allows for
    '    '  for an updates settings file to be created ahead of time, placed on the server, and
    '    '  the changes won't take effect until the date on the first line of the file.
    '    If CDate(Line) >= CDate(My.Settings.SetDat) Then
    '    Do While StngsFile.Peek() >= 0
    '                    Line = StngsFile.ReadLine
    '                    stings = Line.Split(CChar(","))
    '    If stings(0) = "0xC000" Then
    '    '  0xC000 indicates that all of the settings are to be changed.
    '    '  On one line, following the code, are the settings in plain text
    '    '  in this order:
    '    '
    '    '  1. T or F, indicating whether or not to update the default settings
    '    '  2. Base location for the NTD files on the server
    '    '  3. A series of T and F indicating whether the service runs on each
    '    '       individual day of the week
    '    '  4. A series of T and F indicating whether an individual day requires
    '    '       a different type of survey
    '    '  5. The location in which to store completed surveys
    '    '  6. The number of surveys per week
    '    '  7. The name of the settings file
    '    '  8. The name of the main survey file
    '    '  9. The name of the Route/Run file
    '    ' The next two settings are the names of the file that holds the batch runs,
    '    '       which contains the paired route/runs in order to print full surveys
    '    '       in batches
    '    ' 10. The name of the batch file for weekday surveys
    '    ' 11. The name of the batch file for weekend surveys
    '    ' 12.  The location in which to store the created survey logs
    '    ' 13. The name of the file used to store the survey totals
    '    ' 14. AM Peak Start Time
    '    ' 15. Afternoon Start Time
    '    ' 16. PM Peak Start Time
    '    ' 17. Vehicle Capacity File Name
    '    ' 18. All of the updated default settings, in the order given in this list,
    '    '       but NOT comma separated. Instead, use the vertical separator |
    '    With My.Settings
    '    .BaseLocation = Trim(stings(2))
    '    .DayIndex = Trim(stings(3))
    '    .DiffDay = Trim(stings(4))
    '    .CompletedLocation = Trim(stings(5))
    '    .NumSurveys = CInt(Trim(stings(6)))
    '    .SettingsFileName = Trim(stings(7))
    '    .SurveyFileName = Trim(stings(8))
    '    .RouteRunFileName = Trim(stings(9))
    '    .WeekdayBatchFileName = Trim(stings(10))
    '    .WeekendBatchFileName = Trim(stings(11))
    '    .CreatedLocation = Trim(stings(12))
    '    .TotalFile = Trim(stings(13))
    '    .AMPeak = Trim(stings(14))
    '    .Afternoon = Trim(stings(15))
    '    .PMPeak = Trim(stings(16))
    '    .VehCapFile = Trim(stings(17))
    '    If Trim(stings(1)) = "T" Then
    '    .Defaults = FormSettings.SwitchComma(stings(18))
    '    End If
    '    .SetDat = Now
    '    End With
    '    End If
    '    Loop
    '                StngsFile.Close()
    '    End If
    '    End If
    '
    '       InstallUpdateSyncWithInfo()
    '  End Sub
    ' Friend Sub StoreNewSettings(base As String, dayin As String, diffday As String, complet As String, survnum As Integer)
    ' '  If changes are made, this sub allows the changes to be written to a CSV
    ' With My.Settings
    ' If File.Exists(.BaseLocation & .SettingsFileName) Then
    '             File.Delete(.BaseLocation & .SettingsFileName)
    ' Dim SFile As New StreamWriter(.BaseLocation & .SettingsFileName)
    ' Dim c As String = ","
    '             SFile.WriteLine(CStr(Now))
    ' Dim line As String = "0xC000,F," & c & Trim(base) & c & Trim(dayin) & c & Trim(diffday) & c & Trim(complet) & c & Trim(CStr(survnum)) & c & Trim(.SettingsFileName) & c
    '             line &= Trim(.SurveyFileName) & c & Trim(.RouteRunFileName) & c & Trim(.WeekdayBatchFileName) & c & Trim(.WeekendBatchFileName) & c & Trim(.TotalFile)
    '             line &= Trim(.AMPeak) & c & Trim(.Afternoon) & c & Trim(.PMPeak) & c & Trim(.VehCapFile)
    '             SFile.WriteLine(line)
    '             SFile.Flush()
    '             SFile.Close()
    ' End If
    ' End With
    ' End Sub
    Private Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo '= Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " &
                        "version to version " & info.MinimumRequiredVersion.ToString() &
                        ". The application will now install the update and restart.",
                        "Update Available", MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("The application has been upgraded, and will now restart.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
                        Return
                    End Try
                End If
            End If
        End If
    End Sub
    Friend Sub ReadSurveyInfo(ByRef Wday As List(Of Route), ByRef Sday As List(Of Route))
        'Using sr As New StreamReader(My.Settings.BaseLocation & My.Settings.RouteRunFileName)
        Using sr As New StreamReader(MainForm.GlobalSettings.BaseLocation & "\" & MainForm.GlobalSettings.NameOfRouteRunFile)
            MainForm.Status("", False)
            Do Until sr.EndOfStream
                Dim line() As String = sr.ReadLine().Split(","c)
                ' a letter "S" at the end of the Serial number denotes a Saturday route.
                ' However, the letter "S" could be used elsewhere in the SN.  Therefore Saturday surveys
                ' use double-tilde "~~" in the Route_Run.csv to denote Saturday surveys.
                ' If the serial number has "~~" it is replaced with "S" and that SN is placed in a list
                ' of Saturday surveys.
                If (line(0).Contains("~~")) Then
                    line(0) = line(0).Replace("~~", "S")
                    Sday.Add(New Route(line(0), line(1), line(2)))
                    MainForm.Status("Saturday: " & CStr(line(0)) & " " & CStr(line(1)) & " Sheet " & line(2))
                Else
                    Wday.Add(New Route(line(0), line(1), line(2)))
                    MainForm.Status(CStr(line(0)) & " Sheet " & CStr(line(1)) & line(2), False)
                End If
            Loop
            'sr.Close()
        End Using
    End Sub
    Friend Sub SaveSurveys(ByVal Srvys As List(Of Survey))
        Dim serializer As New XmlSerializer(GetType(List(Of Survey)))
        'Dim FyleName As String = My.Settings.CreatedLocation & "\" & Format(Now, "mmddyyyy") & ".srv"
        Dim FyleName As String = MainForm.GlobalSettings.CreatedSurveyLocation & "\" & Format(Now, "mmddyyyy") & ".srv"
        If Not System.IO.File.Exists(FyleName) Then
            System.IO.File.Create(FyleName).Dispose()
        End If
        Dim SR As New StreamWriter(FyleName)
        serializer.Serialize(SR, Srvys)
        SR.Close()
        SR = Nothing
        serializer = Nothing
    End Sub
    Friend Sub Associate()
        '  Simply associates .ntd extensions to this app.
        'Dim Key As Microsoft.Win32.RegistryKey
        'Key = My.Computer.Registry.ClassesRoot.OpenSubKey("NTD")

        'If Key Is Nothing Then
        ' My.Computer.Registry.ClassesRoot.CreateSubKey(".ntd").SetValue("", "NTD", Microsoft.Win32.RegistryValueKind.String)
        ' My.Computer.Registry.ClassesRoot.CreateSubKey("NTD\shell\open\command").SetValue("", Application.ExecutablePath & " ""%1"" ", Microsoft.Win32.RegistryValueKind.String)
        ' End If

    End Sub
    Friend Sub SaveSettings(settings As String)
        Using sw As New SaveFileDialog
            sw.Filter = "Comma Separated Value|*.csv"
            sw.Title = "Save Settings File As"
            'sw.FileName = My.Settings.SettingsFileName
            sw.FileName = MainForm.GlobalSettings.NameOfSettingsFile
            If sw.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(sw.FileName) Then
                    My.Computer.FileSystem.WriteAllText(sw.FileName, settings, False)
                End If
            End If
        End Using
    End Sub
    Public Function ReadVehicleFile() As List(Of String())
        Dim Info As New List(Of String())
        'Using sr As New StreamReader(My.Settings.BaseLocation & "\" & My.Settings.VehCapFile)
        Using sr As New StreamReader(MainForm.GlobalSettings.BaseLocation & "\" & MainForm.GlobalSettings.VehicleCapacityFile)
            Do Until sr.EndOfStream
                Dim Line() As String = sr.ReadLine().Split(","c)
                Info.Add(Line)
            Loop
        End Using
        Return Info
    End Function
    Public Function HolidaysBetween(StartDate As Date, StopDate As Date, ByRef InfoBox As RichTextBox) As List(Of Date)
        Dim Holidates As New List(Of Date)
        Dim CurrentHolidays = DateSystem.GetPublicHoliday(StartDate, StopDate, CountryCode.US)
        Dim NonRunningHolidays() As String = {"New Year's Day", "Memorial Day", "Independence Day", "Labour Day", "Veterans Day", "Thanksgiving Day", "Christmas Day"}
        For Each h In CurrentHolidays
            If Array.IndexOf(NonRunningHolidays, h.Name) >= 0 Then
                If Not Holidates.Contains(h.Date) Then
                    Holidates.Add(h.Date)
                    InfoBox.Text += h.LocalName + " is on " + h.Date.ToLongDateString + vbCrLf
                End If
            End If
        Next
        Return Holidates
    End Function
End Module