Imports System.Deployment.Application
Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Version As String
        If ApplicationDeployment.IsNetworkDeployed Then
            Version = My.Application.Deployment.CurrentVersion.ToString
        Else
            Version = Application.ProductVersion
        End If
        With My.Application.Info
            TextBox1.Text = "Name: " & .ProductName & vbNewLine
            TextBox1.Text &= "Version: " & Version & vbNewLine
            TextBox1.Text &= .Copyright & vbNewLine
            TextBox1.Text &= "Company: " & .CompanyName & vbNewLine & vbNewLine
            TextBox1.Text &= .Description
        End With
    End Sub

    Private Sub OkButt_Click(sender As Object, e As EventArgs) Handles OkButt.Click
        Me.Close()
    End Sub
End Class