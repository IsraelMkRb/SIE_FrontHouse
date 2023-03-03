Public Class main
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Botonera_Menus1.DataSource = New List(Of testClass) From {
            New testClass() With {.name = "button1"},
            New testClass() With {.name = "button2"},
            New testClass() With {.name = "button3"},
            New testClass() With {.name = "button4"},
            New testClass() With {.name = "button5"},
            New testClass() With {.name = "button6"},
            New testClass() With {.name = "button7"},
            New testClass() With {.name = "button8"},
            New testClass() With {.name = "button9"}
        }
    End Sub

    Private Sub GoToPayments_btn_Click(sender As Object, e As EventArgs) Handles GoToPayments_btn.Click

    End Sub
End Class

Class testClass
    Public Property name As String
End Class