Public Class main
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Botonera_Menus1.DataSource = New List(Of testClass) From {
            New testClass() With {.Name = "Button 1"},
            New testClass() With {.Name = "Button 2"},
            New testClass() With {.Name = "Button 3"},
            New testClass() With {.Name = "Button 4"},
            New testClass() With {.Name = "Button 5"},
            New testClass() With {.Name = "Button 6"},
            New testClass() With {.Name = "Button 7"},
            New testClass() With {.Name = "Button 8"},
            New testClass() With {.Name = "Button 9"},
            New testClass() With {.Name = "Button 10"},
            New testClass() With {.Name = "Button 11"},
            New testClass() With {.Name = "Button 12"},
            New testClass() With {.Name = "Button 13"},
            New testClass() With {.Name = "Button 14"},
            New testClass() With {.Name = "Button 15"},
            New testClass() With {.Name = "Button 16"}
        }

        Botonera_Menus2.DataSource = New List(Of testClass) From {
            New testClass() With {.Name = "Button 1"},
            New testClass() With {.Name = "Button 2"},
            New testClass() With {.Name = "Button 3"},
            New testClass() With {.Name = "Button 4"},
            New testClass() With {.Name = "Button 5"}
        }
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Botonera_Menus1.DataSource = Nothing
        Botonera_Menus2.DataSource = Nothing
    End Sub
End Class

Class testClass
    Public Property Name As String
    Public Property Callback As Action
End Class