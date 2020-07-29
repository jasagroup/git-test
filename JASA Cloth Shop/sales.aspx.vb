Imports System.Data.SqlClient
Public Class sales
    Inherits System.Web.UI.Page
    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Sub fillData()
        cmd.Connection = cn
        cmd.CommandText = "select *from sales"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView3.DataSource = dr
        GridView3.DataBind()
        cn.Close()


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillData()
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView3.SelectedIndexChanged
        
    End Sub
End Class