Public NotInheritable Class SplashScreen1
    Public WDSurvNums As New List(Of Route)
    Public SDSurvNums As New List(Of Route)

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        VersionLabel.Text = "Version: " & Application.ProductVersion

        If Not IsACreator() Then
            CreateButt.Enabled = False
            BatchButt.Enabled = False
            'CreateButt.Visible = False
            'BatchButt.Visible = False
        End If

        Dim Something As String = "."
        If My.Application.CommandLineArgs.Count > 0 Then
            Something = CStr(My.Application.CommandLineArgs.Item(0))
        End If
        MainForm.Status("Checking for software updates.", False)
        UpdateSettings(Something)
        If Not Comm.CheckConnection() Then
            MsgBox("There is a problem connecting to the NTD Surveys.  This program will exit.", vbOKOnly, "Connection Problem")
            End
        End If
        MainForm.Status("Checking File Associations", False)
        Associate()

        MainForm.Status("Updating routes and runs", False)
        ReadSurveyInfo(WDSurvNums, SDSurvNums)

    End Sub

    Private Sub CreateButt_Click(sender As Object, e As EventArgs) Handles CreateButt.Click
        Me.Hide()
        'Me.Close()
        MainForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub BatchButt_Click(sender As Object, e As EventArgs) Handles BatchButt.Click
        Me.Hide()
        'Me.Close()
        BatchForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub EnterButt_Click(sender As Object, e As EventArgs) Handles EnterButt.Click
        Me.Hide()
        SurveyEntry.ShowDialog()
        Me.Show()
    End Sub

    Private Sub CloseButt_Click(sender As Object, e As EventArgs) Handles CloseButt.Click
        Me.Close()
    End Sub
    Shared Function IsACreator() As Boolean
        Return ((System.Environment.UserDomainName = "RABA") And (My.User.IsInRole("NTD_Creator")))
    End Function
End Class
