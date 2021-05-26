Public Class EnteredSurvey
    Private SSerial As String
    Private Dayt As String
    Private Tyyme As String
    Private TPeriod As String
    Private Veh As Int32
    Private TotCap As Int32
    Private SeatCap As Int32
    Private PBoard As Int32
    Private PassOnBoard As Int32
    Private DistBetStop As Double
    Private PassMiles As Double
    Private StopList As List(Of StopLocation)
    Public Sub New()
        ' Me.SSerial = ""
        'Me.Dayt = ""
        'Me.Tyyme = ""
        'Me.TPeriod = ""
        'Me.Veh = 0
        'Me.TotCap = 0
        'Me.SeatCap = 0
        'Me.PBoard = 0
        'Me.PassOnBoard = 0
        'Me.DistBetStop = 0D
        'Me.PassMiles = 0D
        'Me.StopList = New List(Of StopLocation)
    End Sub
    Public ReadOnly Property Route As String
        Get
            Return Convert.ToString(Me.SSerial.Split("-"c)(0)).ToUpper()
        End Get
    End Property

    Public Property TripSerial
        Get
            Return Trim(Me.SSerial.ToString())
        End Get
        Set(value)
            Me.SSerial = Trim(value.ToString())
        End Set
    End Property
    Public ReadOnly Property Run As Int32
        Get
            Return Convert.ToInt32(Right(Me.SSerial, Me.SSerial.IndexOf("-")))
        End Get
    End Property
    '    Public Property SurveyDateAndTime(Dait As String, Thyme As String) As String()
    '    Get
    '    Return {Me.Dayt, Me.Tyyme}
    '    End Get
    '    Set(value As String())
    '    Me.Dayt = Trim(Dait)
    '    Me.Tyyme = Trim(Thyme)
    '    End Set
    '    End Property
    Public Property SurveyDate
        Get
            Return Me.Dayt
        End Get
        Set(value)
            Me.Dayt = Trim(value)
        End Set
    End Property
    Public Property SurveyTime
        Get
            Return Me.Tyyme
        End Get
        Set(value)
            Me.Tyyme = Trim(value)
        End Set
    End Property
    Public Property TimePeriod As String
        Get
            Return Trim(Me.TPeriod.ToString())
        End Get
        Set(value As String)
            Me.TPeriod = Trim(value.ToString())
        End Set
    End Property
    Public Property VehicleNumber As Int32
        Get
            Return Convert.ToInt32(Me.Veh)
        End Get
        Set(value As Int32)
            Me.Veh = Convert.ToInt32(value)
        End Set
    End Property
    Public Property TotalCapacity As Int32
        Get
            Return Convert.ToInt32(Me.TotCap)
        End Get
        Set(value As Int32)
            Me.TotCap = Convert.ToInt32(value)
        End Set
    End Property
    Public Property SeatedCapacity As Int32
        Get
            Return Convert.ToInt32(Me.SeatCap)
        End Get
        Set(value As Int32)
            Me.SeatCap = Convert.ToInt32(value)
        End Set
    End Property
    Public Property PassengersBoarded As Int32
        Get
            Return Convert.ToInt32(Me.PBoard)
        End Get
        Set(value As Int32)
            Me.PBoard = Convert.ToInt32(value)
        End Set
    End Property
    Public Property PassengersOnBoard As Int32
        Get
            Return Convert.ToInt32(Me.PassOnBoard)
        End Get
        Set(value As Int32)
            Me.PassOnBoard = Convert.ToInt32(value)
        End Set
    End Property
    Public Property DistanceBetStops As Double
        Get
            Return Convert.ToInt32(Me.DistBetStop)
        End Get
        Set(value As Double)
            Me.DistBetStop = Convert.ToInt32(value)
        End Set
    End Property
    Public Property PassengerMiles As Double
        Get
            Return Convert.ToDouble(Me.PassMiles)
        End Get
        Set(value As Double)
            Me.PassMiles = Convert.ToDouble(value)
        End Set
    End Property

    Overloads Sub AddStop(WhereStop As StopLocation)
        Me.StopList.Add(WhereStop)
    End Sub

    Overloads Sub AddStop(StopName As String, StopDist As Int32)
        Dim shtop As New StopLocation(StopName, StopDist)
        Me.StopList.Add(shtop)

    End Sub

    Public Iterator Function Stops() As IEnumerable(Of StopLocation)
        For Each IndStop As StopLocation In Me.StopList
            Yield IndStop
        Next
    End Function
    Public ReadOnly Property DayOfWeek As String
        Get
            Return CDate(Me.Dayt).DayOfWeek.ToString
        End Get
    End Property
    Public ReadOnly Property CapacityMiles As Double
        Get
            Return (Me.StopList(Me.StopList.Count - 1).Odometer - Me.StopList(0).Odometer) * Me.TotCap
        End Get
    End Property
    Public ReadOnly Property SeatedMiles As Double
        Get
            Return (Me.StopList(Me.StopList.Count - 1).Odometer - Me.StopList(0).Odometer) * Me.SeatCap
        End Get
    End Property
    Public Sub Clear()
        Me.SSerial = ""
        Me.Dayt = ""
        Me.Tyyme = ""
        Me.TPeriod = ""
        Me.Veh = 0
        Me.TotCap = 0
        Me.SeatCap = 0
        Me.PBoard = 0
        Me.PassOnBoard = 0
        Me.DistBetStop = 0D
        Me.PassMiles = 0D
        Me.StopList = New List(Of StopLocation)
    End Sub
End Class

Public Class StopLocation
    Private SName As String
    Private SMileage As Double
    Private PBoard As Integer
    Private PDBoard As Integer
    Public Sub New()
        Me.SName = ""
        Me.SMileage = 0D
    End Sub
    Public Sub New(Name As String, Mile As Int32)
        Me.SName = Trim(Name.ToString())
        Me.SMileage = Convert.ToInt32(Mile)
    End Sub
    Public Property StopName As String
        Set(value As String)
            Me.SName = (Trim(value.ToString()))
        End Set
        Get
            Return Trim(Me.SName.ToString())
        End Get
    End Property
    Public Property Odometer As Double
        Set(value As Double)
            Me.SMileage = CDbl(value)
        End Set
        Get
            Return CDbl(Me.SMileage)
        End Get
    End Property
    Public Property PassengersBoarded As Integer
        Get
            Return Me.PBoard
        End Get
        Set(value As Integer)
            Me.PBoard = CInt(value)
        End Set
    End Property
    Public Property PassengerDeboarded As Integer
        Get
            Return Me.PDBoard
        End Get
        Set(value As Integer)
            Me.PDBoard = CInt(value)
        End Set
    End Property



End Class

