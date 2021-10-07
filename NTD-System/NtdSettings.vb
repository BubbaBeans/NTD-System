Public Class NtdSettings
    ' Taking the place of the built-in settings so it is easier to update settings externally.
    Private _SetDat As DateTime = Convert.ToDateTime("01/04/1070 12:01:00AM")
    Private _DomName As String = "RABA" 'Domain Name
    Private _OperatingDays() As Boolean = {False, True, True, True, True, True, True} 'Indicates whether the system operates on that day
    Private _DifferentSurvey() As Boolean = {False, False, False, False, False, False, True} 'Indicates whether the day operates under a different schedule
    Private _Base As String = "N:\" 'Network or mapped drive location.  Base folder for the NTD storage
    Private _Comp As String = "\Completed" 'Location of storage of entered surveys, based on _Base
    Private _EntryMasterLoc As String = "\SurveyEntryMasters" 'Location of the csv master files for entering route surveys
    Private _DataLoc As String = "\Data"
    Private _SurveysPerWeek As Integer = 9 'Number of surveys to create per week
    Private _DefltSettings As String = "RABA,False,True,True,True,True,True,True,False,False,False,False,False,False,True,N:\,\Completed,\SurveyEntryMasters,\Data,9,Surveys.xlsm,settings.ntd,Route_Run.scv,WDSurveyBatch.csv,WESurveyBatch.csv,\Created,SurveyTotals.xlsx,5:00, 10:00,14:00,VehicleCapacity.csv,349,146,True"
    'Holds all of the default settings.  Seems strange, but if changes are made to the settings, and they are to become the default, this variable is updated.
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
    Private _FormSize As New Size(349, 146)
    Private _Audible As Boolean = True 'Switch to determine whether or not to include audible warnings

    Public Sub New()

    End Sub

    Public Function NewSettings(SettingsDate As String) As Boolean
        Return Convert.ToDateTime(SettingsDate + " 12:01:00AM") > _SetDat
    End Function
    Public Function OperatesOnThisDay(DayOfWeek As Integer) As Boolean
        Return _OperatingDays(DayOfWeek)
    End Function
    Public Function DifferentSurveyDay(DayOfWeek As Integer) As Boolean
        Return _DifferentSurvey(DayOfWeek)
    End Function

    Public Property SettingsDate As String
        Get
            Return _SetDat
        End Get
        Set(value As String)
            _SetDat = Trim(value)
        End Set
    End Property
    Public Property DomainName As String
        Get
            Return _DomName
        End Get
        Set(value As String)
            _DomName = Trim(value)
        End Set
    End Property
    Public Property BaseLocation As String
        Get
            Return _Base
        End Get
        Set(value As String)
            _Base = Trim(value)
        End Set
    End Property
    Public Property CompletedLocation As String
        Get
            Return _Base + _Comp
        End Get
        Set(value As String)
            _Comp = Trim(value)
        End Set
    End Property
    Public Property SurveyMastersLocation As String
        Get
            Return _EntryMasterLoc
        End Get
        Set(value As String)
            _EntryMasterLoc = Trim(value)
        End Set
    End Property
    Public Property DataFileLocation As String
        Get
            Return _DataLoc
        End Get
        Set(value As String)
            _DataLoc = Trim(value)
        End Set
    End Property
    Public Property SurveysPerWeek As Integer
        Get
            Return _SurveysPerWeek
        End Get
        Set(value As Integer)
            _SurveysPerWeek = Math.Abs(value)
        End Set
    End Property
    Public Property DefaultSettings As String
        Get
            Return _DefltSettings
        End Get
        Set(value As String)
            _DefltSettings = Trim(value)
        End Set
    End Property
    Public Property NameOfSurveyFile As String
        Get
            Return _SurveyFName
        End Get
        Set(value As String)
            _SurveyFName = Trim(value)
        End Set
    End Property
    Public Property NameOfSettingsFile As String
        Get
            Return _SettingsFName
        End Get
        Set(value As String)
            _SettingsFName = Trim(value)
        End Set
    End Property
    Public Property NameOfRouteRunFile As String
        Get
            Return _RRNam
        End Get
        Set(value As String)
            _RRNam = Trim(value)
        End Set
    End Property
    Public Property WeekdayBatchFile As String
        Get
            Return _WDBatch
        End Get
        Set(value As String)
            _WDBatch = Trim(value)
        End Set
    End Property
    Public Property WeekendBatchFile As String
        Get
            Return _WEBatch
        End Get
        Set(value As String)
            _WEBatch = Trim(value)
        End Set
    End Property
    Public Property CreatedSurveyLocation As String
        Get
            Return _Created
        End Get
        Set(value As String)
            _Created = Trim(value)
        End Set
    End Property
    Public Property CompletedSurveyLocation As String
        Get
            Return _Comp
        End Get
        Set(value As String)
            _Comp = Trim(value)
        End Set
    End Property
    Public Property SurveyTotalFile As String
        Get
            Return _TotFile
        End Get
        Set(value As String)
            _TotFile = Trim(value)
        End Set
    End Property
    Public Property AMPeak As String
        Get
            Return _AmPeak
        End Get
        Set(value As String)
            _AmPeak = Trim(value)
        End Set
    End Property
    Public Property Afternoon As String
        Get
            Return _After
        End Get
        Set(value As String)
            _After = Trim(value)
        End Set
    End Property
    Public Property PMPeak As String
        Get
            Return _PmPeak
        End Get
        Set(value As String)
            _PmPeak = Trim(value)
        End Set
    End Property
    Public Property VehicleCapacityFile As String
        Get
            Return _VehCap
        End Get
        Set(value As String)
            _VehCap = Trim(value)
        End Set
    End Property
    Public Property FormSize As Size
        Get
            Return _FormSize
        End Get
        Set(value As Size)
            _FormSize = value
        End Set
    End Property
    Public Property AudibleAlert As Boolean
        Get
            Return _Audible
        End Get
        Set(value As Boolean)
            _Audible = value
        End Set
    End Property
    Public Sub ToggleAudibleAlert()
        _Audible = -_Audible
    End Sub
End Class
