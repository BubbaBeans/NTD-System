Public Class NtdSettings
    ' Taking the place of the built-in settings so it is easier to update settings externally.
    Private _SetDat As DateTime = Convert.ToDateTime("01/04/1070 12:01:00AM")
    Private _DayIndex As UShort = 0 'First 7 bits indicate whether the system operates on that day, next 7 bits indicate whether the day operates under a different schedule
    Private _Base As String = "N:\" 'Network or mapped drive location.  Base folder for the NTD storage
    Private _Comp As String = "\Completed" 'Location of storage of entered surveys, based on _Base
    Private _SurveysPerWeek As Integer = 9 'Number of surveys to create per week
    Private _DefaultSettings As String = "" 'Holds all of the default settings.  Seems strange, but if changes are made to the settings, and they are to become the default,
    'this variable is updated.
    Private _SurveyFName As String = "Surveys.xlsm" 'Name of the template file for the surveys
    Private _SettingsFName As String = "settings.ntd" 'Name of the settings file.
    Private _RRNam As String = "Route_Run.csv" 'Name of csv file  containing route and run information
    Private _WDBatch As String = "WDSurveyBatch.csv" 'Name of csv file containing what route/runs are to be printed together to do a full survey on a weekday
    Private _WEBatch As String = "WESurveyBatch.csv" 'Name of csv file containing what route/runs are to be printed together to do a full survey on a weekend
    Private _Created As String = "\Created" 'Location for storage of the list of created surveys - FUTURE EXPANSION
    Private _TotFile As String = "SurveyTotals.xlsx" 'Name of file for holding totals from completed surveys
    Private _AmPeak As String = "5:00" 'Time of the start of AM Peak period
    Private _After As String = "10:00" 'Time of the start of Afternoon period
    Private _PmPeak As String = "14:00" 'Time of the start of PM Peak period
    Private _VehCap As String = "VehicleCapacity.csv" 'Name of the csv file containing vehicle capacity information
    Private _FormSize As System.Drawing.Size = New Size(349, 146)
    Private _Audible As Boolean = True 'Switch to determine whether or not to include audible warnings

    Public Function NewSettings(SettingsDate As String) As Boolean
        Return Convert.ToDateTime(SettingsDate + " 12:01:00AM") > _SetDat
    End Function
    Public Function OperatesOnThisDay(DayOfWeek As Integer) As Boolean
        Return ((1 << _DayIndex) And DayOfWeek + 1)
    End Function
    Public Function DifferentSurveyDay(DayOfWeek As Integer) As Boolean
        Return ((1 << _DayIndex) And DayOfWeek + 8)
    End Function
    Public Property BaseLocation As String
        Get
            Return _Base
        End Get
        Set(value As String)
            _Base = Trim(value)
        End Set
    End Property
End Class
