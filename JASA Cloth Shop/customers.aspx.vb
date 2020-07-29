Imports System.Data.SqlClient
Public Class customers
    Inherits System.Web.UI.Page

    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Sub fillData()
        cmd.Connection = cn
        cmd.CommandText = "select *from Customer"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()


    End Sub
    Sub clear()
        txtCustAddress.Text = ""
        txtCustEmail.Text = ""
        txtCustFullName.Text = ""
        txtContactNo.Text = ""
        txtCustId.Text = ""
        'DropDownList1.SelectedItem.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillData()

    End Sub


 
    Protected Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        cmd.Parameters.Clear()

        cmd.Connection = cn
        cmd.CommandText = "INSERT into Customer values(@Cust_FullName,@Cust_Gender,@Cust_Address,@Cust_ContactNo,@email)"
        cmd.Parameters.AddWithValue("@Cust_FullName", txtCustFullName.Text)
        cmd.Parameters.AddWithValue("@Cust_Gender", DropDownList1.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Cust_Address", txtCustAddress.Text)
        cmd.Parameters.AddWithValue("@Cust_ContactNo", txtContactNo.Text)
        cmd.Parameters.AddWithValue("@email", txtCustEmail.Text)
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

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        txtCustId.Text = row.Cells(1).Text
        txtCustFullName.Text = row.Cells(2).Text
        DropDownList1.SelectedItem.Text = row.Cells(3).Text
        txtCustAddress.Text = row.Cells(4).Text
        txtContactNo.Text = row.Cells(5).Text
        txtCustEmail.Text = row.Cells(6).Text
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "DELETE Customer WHERE Cust_Id=@Cust_Id"
        cmd.Parameters.AddWithValue("@Cust_Id", txtCustId.Text)
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
        cmd.CommandText = "UPDATE Customer set Cust_FullName=@Cust_FullName,Cust_Gender=@Cust_Gender,Cust_address=@Cust_address,Cust_contactNo=@Cust_contactNo,email=@email where Cust_Id=@Cust_Id"
        cmd.Parameters.AddWithValue("@Cust_Id", txtCustId.Text)
        cmd.Parameters.AddWithValue("@Cust_FullName", txtCustFullName.Text)
        cmd.Parameters.AddWithValue("Cust_Gender", DropDownList1.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Cust_address", txtCustAddress.Text)
        cmd.Parameters.AddWithValue("@Cust_contactNo", txtContactNo.Text)
        cmd.Parameters.AddWithValue("@email", txtCustEmail.Text)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Records updated successfully !", MsgBoxStyle.Information)
            cmd.Parameters.Clear()
            fillData()
            clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class