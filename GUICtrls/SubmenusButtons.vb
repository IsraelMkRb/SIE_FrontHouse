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
    ''' <summary>
    ''' Objeto que acepta tipo list(Of ...) donde cada elemento contenga propiedad .Name = Texto del boton
    ''' y .Event = delegado de funciones sin parametros 
    ''' </summary>
    ''' <returns></returns>
    Public Property DataSource As Object
        Get
            Return PrivDataSource
        End Get
        Set(value As Object)
            CleanControl()

            If value Is Nothing Then Return

            PrivDataSource = value
            Groups = Math.Ceiling(value.Count / 6)
            CastDataSource(value, 0)
        End Set
    End Property
    Private Property PrivCurrentGroupDisplayed As Integer = 0
    Public Property CurrentGroupDisplayed As Integer
        Get
            Return PrivCurrentGroupDisplayed
        End Get
        Set(value As Integer)
            PrivCurrentGroupDisplayed = value
            CastDataSource(PrivDataSource, value)
        End Set
    End Property
    Private Property Groups As Integer
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
    Private Sub CastDataSource(value As Object, GroupNumber As Object)
        Dim i As Integer = 1
        Dim j As Integer = 0

        If PrivDataSource Is Nothing Then Exit Sub

        'Limpiamos los textos de todos los botones por si se ocupan menos de 6
        'No queden con el valor anterior
        For Each button As Button In Me.Controls
            button.Text = ""
        Next

        For Each item In PrivDataSource

            If j < GroupNumber * 6 Then
                j += 1
                Continue For
            End If

            For Each button As Button In Me.Controls
                If button.Name.Contains("Position_" & i) Then
                    button.Text = item.Name
                    i += 1
                    Exit For
                End If
            Next
        Next

        For Each button As Button In Me.Controls
            button.Visible = Not Equals(button.Text, "") Or button.Name.Contains("Go")
            button.Enabled = Not Equals(button.Text, "") Or button.Name.Contains("Go")
        Next

        If GroupNumber = Groups - 1 Then GoNext_Btn.Enabled = False
        If GroupNumber = 0 Then GoBack_btn.Enabled = False

    End Sub
    Private Sub CleanControl()
        Groups = 0
        CurrentGroupDisplayed = 0

        For Each button As Button In Me.Controls
            If button.Name.Contains("Go") Then
                button.Enabled = False
            Else
                button.Text = ""
                button.Visible = False
            End If
        Next

    End Sub
    Private Sub DoEventOfButton(ButtonPosition As Int16)
        If PrivDataSource(ButtonPosition + (CurrentGroupDisplayed * 6)).Callback IsNot Nothing Then
            PrivDataSource(ButtonPosition + (CurrentGroupDisplayed * 6)).Callback.Invoke
        End If
    End Sub
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

    Private Sub GoNext_Btn_Click(sender As Object, e As EventArgs) Handles GoNext_Btn.Click
        If DataSource Is Nothing Then Exit Sub
        CurrentGroupDisplayed += 1
        CastDataSource(PrivDataSource, CurrentGroupDisplayed)
        If Not GoBack_btn.Enabled Then GoBack_btn.Enabled = True
    End Sub

    Private Sub GoBack_btn_Click(sender As Object, e As EventArgs) Handles GoBack_btn.Click
        If DataSource Is Nothing Then Exit Sub
        CurrentGroupDisplayed -= 1
        CastDataSource(PrivDataSource, CurrentGroupDisplayed)
        If Not GoNext_Btn.Enabled Then GoNext_Btn.Enabled = True
    End Sub

    Private Sub Btn_Position_1_Click(sender As Object, e As EventArgs) Handles Btn_Position_1.Click
        DoEventOfButton(0)
    End Sub

    Private Sub Btn_Position_2_Click(sender As Object, e As EventArgs) Handles Btn_Position_2.Click
        DoEventOfButton(1)
    End Sub

    Private Sub Btn_Position_3_Click(sender As Object, e As EventArgs) Handles Btn_Position_3.Click
        DoEventOfButton(2)
    End Sub

    Private Sub Btn_Position_4_Click(sender As Object, e As EventArgs) Handles Btn_Position_4.Click
        DoEventOfButton(3)
    End Sub

    Private Sub Btn_Position_5_Click(sender As Object, e As EventArgs) Handles Btn_Position_5.Click
        DoEventOfButton(4)
    End Sub

    Private Sub Btn_Position_6_Click(sender As Object, e As EventArgs) Handles Btn_Position_6.Click
        DoEventOfButton(5)
    End Sub
#End Region

End Class
