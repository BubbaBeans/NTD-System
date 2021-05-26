''Imports System.Printing, System.IO, System.Threading
''Friend Class Program
''<System.MTAThreadAttribute()>
''Shared Sub Main(ByVal args() As String) ' Added for clarity, but this line is redundant because MTA is the default.
' Create the secondary thread and pass the printing method for
' the constructor's ThreadStart delegate parameter. The BatchXPSPrinter
' class is defined below.
''Dim printingThread As New Thread(AddressOf BatchXPSPrinter.PrintXPS)
''
' Set the thread that will use PrintQueue.AddJob to single threading.
''printingThread.SetApartmentState(ApartmentState.STA)
''
' Start the printing thread. The method passed to the Thread
' constructor will execute.
''printingThread.Start()
''
''End Sub
''
''End Class
''
''Public Class BatchXPSPrinter
''Public Shared Sub PrintXPS(Optional StapleAndDuplex As Boolean = False)
' Create print server and print queue.
''Dim localPrintServer As New LocalPrintServer()
''Dim defaultPrintQueue As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()
''
' Prompt user to identify the directory, and then create the directory object.
''Dim directoryPath As String = "C:\temp"
''Dim dir As New DirectoryInfo(directoryPath)
''
' Batch process all XPS files in the directory.
''For Each f As FileInfo In dir.GetFiles("*.xps")
''MsgBox(dir.GetFiles("*.xps").Count.ToString, vbOKOnly)
''Dim nextFile As String = directoryPath & "\" & f.Name
''Dim pTicket As PrintTicket = defaultPrintQueue.DefaultPrintTicket
''If StapleAndDuplex Then
''
''
''Dim printCapabilites As PrintCapabilities = defaultPrintQueue.GetPrintCapabilities()
''
' Modify PrintTicket
''If printCapabilites.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge) Then
''pTicket.Duplexing = Duplexing.TwoSidedLongEdge
''End If
''
''If printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft) Then
''pTicket.Stapling = Stapling.StapleTopLeft
''End If
''End If
''Dim xpsPrintJob As PrintSystemJobInfo = defaultPrintQueue.AddJob(f.Name, nextFile, False, pTicket) 'defaultPrintQueue.AddJob(f.Name, nextFile, False)
''Next f ' end for each XPS file
''For Each filename As FileInfo In dir.GetFiles
''Try
''booo:
'System.IO.File.Delete(filename)
''filename.Delete()
''Catch ex As Exception
''GoTo booo
''End Try
''Next
''
''
''End Sub
''
''End Class