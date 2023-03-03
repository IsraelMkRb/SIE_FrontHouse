Public Class Botonera_Menus
#Region "Properies"
    Private Property PrivBtnColors As Color
    ''' <summary>
    ''' Obtiene o establece el color de fondo de la lista de botones
    ''' </summary>
    ''' <returns></returns>
    Public Property ButtonsBackColors As Color
        Get
            Return PrivBtnColors
        End Get
        Set(value As Color)
            PrivBtnColors = value
            SetPropertyValueButtonList(value, "BackColor")
        End Set
    End Property
    Private Property PrivBtnForeColor As Color
    ''' <summary>
    ''' Obtiene o establece el color de texto de la lista de botones
    ''' </summary>
    ''' <returns></returns>
    Public Property ButtonsForeColor As Color
        Get
            Return PrivBtnForeColor
        End Get
        Set(value As Color)
            PrivBtnForeColor = value
            SetPropertyValueButtonList(value, "ForeColor")
        End Set
    End Property
    Private Property PrivDataSource As Object
    Public Property DataSource As Object
        Get
            Return PrivDataSource
        End Get
        Set(value As Object)
            CastDataSource(value, 0)
        End Set
    End Property
    Private Property CurrentGroupDisplayed As Integer = 0
#End Region
#Region "Events"
    Private Sub Botonera_Menus_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim lastButton As Button = Nothing

        For Each _button As Button In Me.Controls
            _button.Location = New Point(3, 3) 'esto arregla un bug al recorrer controles y poner un punto aleatorio
            _button.Height = Me.Height - 3
            _button.Width = Me.Width * 0.11734


            If lastButton IsNot Nothing Then
                _button.Location = New Point(lastButton.Location.X + lastButton.Width + (Me.Width * 0.0078226), _button.Location.Y)
            End If

            lastButton = _button
        Next
    End Sub
#End Region
#Region "Methods"
    Private Sub SetPropertyValueButtonList(ByRef value As Object, ByRef propertyName As String)

        Dim TypeofButton As Type = GoNext_Btn.GetType
        Dim PropertiesList As Reflection.PropertyInfo() = TypeofButton.GetProperties

        For Each btn As Button In Me.Controls
            For Each [property] As Reflection.PropertyInfo In PropertiesList
                If [property].Name <> propertyName Then Continue For

                Try
                    [property].SetValue(btn, value)
                Catch ex As Exception
                    'Just let it go, we tried...
                End Try
            Next
        Next
    End Sub
    Private Sub CastDataSource(value As Object, NumberGroup As Integer)
        PrivDataSource = value

        If PrivDataSource Is Nothing Then Exit Sub
        Dim GroupCalc As Integer = NumberGroup * 6
        Dim i As Integer = 2 + GroupCalc

        For Each item In PrivDataSource
            If i = 7 + GroupCalc Then Exit For

            Dim _i As Integer = 1
            For Each button As Button In Me.Controls
                If _i + GroupCalc = i And _i < 7 And button.Name <> "GoBack_btn" And button.Name <> "GoNext_Btn" Then
                    button.Text = item.name
                End If
                _i += 1
            Next

            i += 1
        Next
    End Sub
#End Region
End Class
