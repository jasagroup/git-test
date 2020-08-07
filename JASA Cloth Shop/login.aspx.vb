Imports System.Data.SqlClient
Public Class login
    Inherits System.Web.UI.Page
    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(Str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

  
    Protected Sub LoginForm_Click(sender As Object, e As EventArgs) Handles LoginForm.Click
        cmd.Connection = cn
        cmd.CommandText = "select UserName,UserPassword from LoginUser where UserName=@UserName and UserPassword=@UserPassword"
        cmd.Parameters.AddWithValue("UserName", txtUserName.Text)
        cmd.Parameters.AddWithValue("UserPassword", txtPassword.Text)
        cn.Open()
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            Response.Redirect("home.aspx")
        Else
            lblMessage.Text = "Invalid userName Or Password"
            lblMessage.ForeColor = Drawing.Color.Red
        End If
    End Sub
End Class