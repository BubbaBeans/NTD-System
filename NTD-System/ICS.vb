Imports Ical.Net
Module ICS
    Public Function CreateReminder(ReminderDate As String) As String
        Dim Clendr As New Ical.Net.Calendar()
        Dim CalEvent As New CalendarComponents.CalendarEvent
        Dim Start As DateTime = CDate(ReminderDate)
        CalEvent.Start = New Ical.Net.DataTypes.CalDateTime(Start)
        CalEvent.Duration = TimeSpan.FromHours(1)
        CalEvent.Summary = "Create new NTD Route Surveys starting Monday"
        Clendr.Events.Add(CalEvent)
        Dim ser As New Ical.Net.Serialization.CalendarSerializer
        Return ser.SerializeToString(Clendr)
    End Function
End Module
