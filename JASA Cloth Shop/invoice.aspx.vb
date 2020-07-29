Imports System.Data.SqlClient
Public Class invoice
    Inherits System.Web.UI.Page
    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Sub fillData()
        cmd.Connection = cn
        cmd.CommandText = "select *from invoice"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillData()
    End Sub

   
   
    Sub clear()
        txtInvoiceID.Text = ""
        txtCustName.Text = ""
        txtPaid.Text = ""
        txtAmount.Text = ""
        txtRemainder.Text = ""


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        txtInvoiceID.Text = row.Cells(1).Text
        txtCustName.Text = row.Cells(2).Text
        txtAmount.Text = row.Cells(3).Text
        txtPaid.Text = row.Cells(5).Text
        txtRemainder.Text = row.Cells(5).Text


        txtOldAmount.Text = row.Cells(3).Text
        txtOldPaid.Text = row.Cells(4).Text
        txtOldRemainder.Text = row.Cells(5).Text

    End Sub

  
    Protected Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        cmd.Parameters.Clear()

        'Dim amount As Integer = txtOldAmount.Text + txtAmount.Text
        Dim paid As Integer = Val(txtOldPaid.Text) + Val(txtPaid.Text)
        Dim remainder As Integer = txtOldRemainder.Text - txtPaid.Text

        cmd.Connection = cn
        cmd.CommandText = "UPDATE invoice set customer_fName=@customer_fName,total=@total,paid=@paid,remainder=@remainder where inv_id=@inv_id"
        cmd.Parameters.AddWithValue("@inv_id", txtInvoiceID.Text)
        cmd.Parameters.AddWithValue("@customer_fName", txtCustName.Text)
        cmd.Parameters.AddWithValue("@total", txtAmount.Text)
        cmd.Parameters.AddWithValue("@paid", paid)
        cmd.Parameters.AddWithValue("@remainder", remainder)


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

    


    Protected Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click

        Dim amount As Integer = Val(txtOldAmount.Text) + Val(txtAmount.Text)
        'Dim paid As Integer = Val(txtOldPaid.Text) + Val(txtPaid.Text)
        Dim remainder As Integer = Val(txtOldRemainder.Text) + Val(txtAmount.Text)

        cmd.Connection = cn
        cmd.CommandText = "UPDATE invoice set customer_fName=@customer_fName,total=@total,paid=@paid,remainder=@remainder where inv_id=@inv_id"
        cmd.Parameters.AddWithValue("@inv_id", txtInvoiceID.Text)
        cmd.Parameters.AddWithValue("@customer_fName", txtCustName.Text)
        cmd.Parameters.AddWithValue("@total", amount)
        cmd.Parameters.AddWithValue("@paid", txtPaid.Text)
        cmd.Parameters.AddWithValue("@remainder", remainder)


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
End Class