Imports System.Data.SqlClient
Public Class product
    Inherits System.Web.UI.Page
    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Sub fillData()
        cmd.Connection = cn
        cmd.CommandText = "select *from product"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()

    End Sub

    Sub clear()
        txtItemName.Text = ""
        txtPrice.Text = ""
        txtProductID.Text = ""
        txtQuantity.Text = ""

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillData()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        txtProductID.Text = row.Cells(1).Text
        txtItemName.Text = row.Cells(2).Text
        txtPrice.Text = row.Cells(3).Text
        txtQuantity.Text = row.Cells(4).Text
    End Sub

    Protected Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        cmd.Parameters.Clear()

        cmd.Connection = cn
        cmd.CommandText = "INSERT into product values (@item_name,@price,@quantity)"
        cmd.Parameters.AddWithValue("@item_name", txtItemName.Text)
        cmd.Parameters.AddWithValue("@price", txtPrice.Text)
        cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Recore inserted Succesfully !", MsgBoxStyle.Information)
            cmd.Parameters.Clear()
            fillData()
            clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "DELETE product WHERE pro_id=@pro_id"
        cmd.Parameters.AddWithValue("@pro_id", txtProductID.Text)
        Try
            Dim answer = MsgBox("Are you sure to delet this record", MsgBoxStyle.OkCancel)
            If answer = MsgBoxResult.Cancel Then
                Return
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Record has been Deleted!", MsgBoxStyle.Exclamation)
            cmd.Parameters.Clear()
            fillData()
            clear()


        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        cmd.Parameters.Clear()

        cmd.Connection = cn
        cmd.CommandText = "UPDATE product set item_name=@item_name,price=@price,quantity=@quantity where pro_id=@pro_id"
        cmd.Parameters.AddWithValue("@pro_id", txtProductID.Text)
        cmd.Parameters.AddWithValue("@item_name", txtItemName.Text)
        cmd.Parameters.AddWithValue("@price", txtPrice.Text)
        cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Recore inserted Succesfully !", MsgBoxStyle.Information)
            cmd.Parameters.Clear()
            fillData()
            clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()

    End Sub
End Class