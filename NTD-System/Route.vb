Public Class Route
    '  Normally a class shouldn't be created unless you're going to use it as a template, then add
    '  to it.  This is simply created to make things easier, and to enforce one way of doing things.
    '  This is what happens when a program is quickly thrown together... do weird stuff to keep other
    '  weird stuff from happening.

    Private _rName As String ' Simply the name of the route
    Private _rHours As List(Of String) '  List of hours that this route runs each day
    Private _sht As String '  The name of the worksheet associated with this route

    Public Sub New(Optional Name As String = "", Optional Sht As String = "", Optional Hrs As String = "")
        _rName = CStr(Name)
        _rHours = Hrs.Split("|"c).ToList
        _sht = Trim(CStr(Sht))
    End Sub
    Public Sub New()
        _rName = ""
        _rHours = New List(Of String)
        _sht = ""
    End Sub
    Public Property Name As String
        Get
            Return Trim(CStr(_rName))
        End Get
        Set(value As String)
            _rName = Trim(CStr(value))
        End Set
    End Property
    Public Property Runs As Integer
        Get
            Return CInt(_rHours.Count)
        End Get
        Set(value As Integer)

        End Set
    End Property
    Public Property SheetName As String
        Get
            Return Trim(CStr(_sht))
        End Get
        Set(value As String)
            _sht = Trim(CStr(value))
        End Set
    End Property
    Public Property Times As List(Of String)
        Get
            Return _rHours
        End Get
        Set(value As List(Of String))
            _rHours = value
        End Set
    End Property
    Public Property Time As String
        Get
            Return _rHours.ToString
        End Get
        Set(value As String)
            _rHours = value.Split("|"c).ToList
        End Set
    End Property
    Public Function RunTime(Optional run As Integer = 1) As String
        Return Trim(CStr(_rHours(run - 1)))
    End Function
    'Public Function Splits(lst As String) As List(Of String)
    'Return lst.Split("|"c).ToList
    'End Function
End Class
