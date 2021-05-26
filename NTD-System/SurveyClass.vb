Imports NTD_System, System.Xml.Serialization
'  Yet another class created simply because this program was quickly cobbled together.
'  This forces everything to be kept in check
<Serializable()>
Public Class Survey
    Implements IComparable
    Implements IEquatable(Of Survey)
    Private _sNum As String ' Serial number of the survey
    Private _sDat As DateTime ' Date and Time of the survey
    Private _shtNam As String ' Name of the Excel worksheet for that particular route
    Public Sub New()

    End Sub
    Public Sub New(Optional sn As String = "", Optional sd As Date = #01/04/1970 01:02:30AM#, Optional stn As String = "")
        _sNum = Trim(CStr(sn))
        _sDat = CType(sd, DateTime)
        _shtNam = Trim(CStr(stn))
    End Sub
    Public Property Serial As String
        Get
            Return CStr(_sNum)
        End Get
        Set(value As String)
            _sNum = CStr(value)
        End Set
    End Property
    Public Property DateOfSurvey As Date
        Get
            Return CDate(_sDat)
        End Get
        Set(value As Date)

        End Set
    End Property
    Public Property TimeofSurvey As String
        Get
            Return CStr(Format(_sDat, "HH:mm"))
        End Get
        Set(value As String)

        End Set
    End Property
    Public Property DateTime As DateTime
        Get
            Return _sDat
        End Get
        Set(value As DateTime)
            _sDat = CType(value, DateTime)
        End Set
    End Property
    Public Property SheetName As String
        Get
            Return _shtNam
        End Get
        Set(value As String)
            _shtNam = Trim(CStr(value))
        End Set
    End Property
    Public Function CompareTo(other As Object) As Integer Implements IComparable.CompareTo
        '  Obviously handles the CompareTo function.  Uses dates and times of two surveys.

        Dim Result As Integer ' = 0
        Dim Ser1, Ser2 As Date
        Ser1 = DateTime
        Ser2 = CType(other, Survey).DateTime
        Result = CInt(DateDiff(DateInterval.Day, Ser1, Ser2))

        CompareTo = Result
    End Function

    Public Overloads Function Equals(other As Survey) As Boolean Implements IEquatable(Of Survey).Equals
        '  Used to determine whether two surveys are the same by comparing date/time and serial

        If other Is Nothing Then
            Return False
        End If
        'Dim Route, Route1 As String
        'Route = Me.DateOfSurvey.ToString & " " & Me.Serial
        'Route1 = other.DateOfSurvey.ToString & " " & other.Serial
        'Return (Route = Route1)
        Return (DateOfSurvey = other.DateOfSurvey) And (Serial = other.Serial)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If ReferenceEquals(Me, obj) Then
            Return True
        Else Return False
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return 0
    End Function

    Public Shared Operator =(left As Survey, right As Survey) As Boolean
        If left Is Nothing Then
            Return right Is Nothing
        End If

        Return left.Equals(right)
    End Operator

    Public Shared Operator <>(left As Survey, right As Survey) As Boolean
        Return Not left = right
    End Operator

    Public Shared Operator <(left As Survey, right As Survey) As Boolean
        Return If(left Is Nothing, right IsNot Nothing, left.CompareTo(right) < 0)
    End Operator

    Public Shared Operator <=(left As Survey, right As Survey) As Boolean
        Return left Is Nothing OrElse left.CompareTo(right) <= 0
    End Operator

    Public Shared Operator >(left As Survey, right As Survey) As Boolean
        Return left IsNot Nothing AndAlso left.CompareTo(right) > 0
    End Operator

    Public Shared Operator >=(left As Survey, right As Survey) As Boolean
        Return If(left Is Nothing, right Is Nothing, left.CompareTo(right) >= 0)
    End Operator
End Class