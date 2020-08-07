Imports System.Data.SqlClient
Public Class bill
    Inherits System.Web.UI.Page
    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet


    Sub clear()
        txtItem.Text = ""
        txtPrice.Text = ""
        txtQuantity.Text = ""
        txtTotal.Text = ""
    End Sub
    Sub fillData()
        cmd.Connection = cn
        cmd.CommandText = "select item_name,price,quantity from product"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView4.DataSource = dr
        GridView4.DataBind()
        cn.Close()


    End Sub

    'display sale items
    Sub Readtemporary()
        cmd.Connection = cn
        cmd.CommandText = "select item,price,quantity,total from temporary where id !=1"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView3.DataSource = dr
        GridView3.DataBind()
        cn.Close()
    End Sub
    'function insert
    Sub insertTemporary()
        Dim today As String = CStr(Date.Today)
        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "INSERT into sales values(@bill_date,@item,@price,@quantity,@total)"
        cmd.Parameters.AddWithValue("@bill_date", today)
        cmd.Parameters.AddWithValue("@item", txtItem.Text)
        cmd.Parameters.AddWithValue("@price", txtPrice.Text)
        cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text)
        cmd.Parameters.AddWithValue("@total", txtTotal.Text)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "INSERT into temporary values(@item,@price,@quantity,@total)"
        cmd.Parameters.AddWithValue("@item", txtItem.Text)
        cmd.Parameters.AddWithValue("@price", txtPrice.Text)
        cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text)
        cmd.Parameters.AddWithValue("@total", txtTotal.Text)


        Try

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Recore inserted Succesfully !", MsgBoxStyle.Information)
            'FillData()
            Readtemporary()
            cmd.Parameters.Clear()
            'readonlytotal()
            clear()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub insertInvoice()
        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "INSERT into invoice values(@cust_name,@total,@paid,@remainder)"
        cmd.Parameters.AddWithValue("@cust_name", DropDownList1.Text)
        cmd.Parameters.AddWithValue("@total", txtAllTotal.Text)
        cmd.Parameters.AddWithValue("@paid", txtPaid.Text)
        cmd.Parameters.AddWithValue("@remainder", txtRemainderBalance.Text)


        Try

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Recore inserted Succesfully !", MsgBoxStyle.Information)
            'FillData()
            Readtemporary()
            cmd.Parameters.Clear()
            'readonlytotal()
            clear()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub updateQuantity()
        Dim netQuantity As Integer = txtTotalQuantity.Text - txtSelectedQuantity.Text
        cmd.Parameters.Clear()

        cmd.Connection = cn
        cmd.CommandText = "UPDATE product set quantity=@quantity where item_name=@item_name"
        cmd.Parameters.AddWithValue("@item_name", txtProductName.Text)
        cmd.Parameters.AddWithValue("@quantity", netQuantity)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Parameters.Clear()
            fillData()
            clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'reset temporary gridview
    Sub resetAlltemporary()
        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "DELETE temporary where id != 1"
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Parameters.Clear()
            Readtemporary()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    'function view that stores totalsold
    Sub readonlytotalView()
        cmd.Connection = cn
        cmd.CommandText = "select sum(total) as totalsale from temporary"
        cn.Open()
        dr = cmd.ExecuteReader()
        While dr.Read = True
            Dim total As Double
            total = (dr("totalsale"))
            txtAllTotal.Text = total

        End While
        dr.Close()
        cn.Close()
    End Sub

    Sub readCustomer()
        cmd.Connection = cn
        cmd.CommandText = "select Cust_FullName,Cust_Id from Customer"
        cn.Open()
        dr = cmd.ExecuteReader()
        While dr.Read = True
            DropDownList1.Items.Add(dr("Cust_FullName"))
        End While
        dr.Close()
        cn.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillData()
        readCustomer()
    End Sub

   

    Protected Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        txtTotal.Text = txtPrice.Text * txtQuantity.Text
        txtSelectedQuantity.Text = txtQuantity.Text
    End Sub

    Protected Sub txtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtPaid.TextChanged
        txtRemainderBalance.Text = txtAllTotal.Text - txtPaid.Text
    End Sub


    Protected Sub addChart_Click(sender As Object, e As EventArgs) Handles addChart.Click
        Readtemporary()
        insertTemporary()
        readonlytotalView()
        updateQuantity()
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView3.SelectedIndexChanged
        readonlytotalView()
    End Sub

    Protected Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        resetAlltemporary()
        txtAllTotal.Text = ""
    End Sub

    Protected Sub GridView4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView4.SelectedIndexChanged
        Dim row As GridViewRow = GridView4.SelectedRow
        txtItem.Text = row.Cells(1).Text
        txtPrice.Text = row.Cells(2).Text

        txtTotalQuantity.Text = row.Cells(3).Text
        txtProductName.Text = row.Cells(1).Text

    End Sub

    Protected Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click
        insertInvoice()
    End Sub
End Class