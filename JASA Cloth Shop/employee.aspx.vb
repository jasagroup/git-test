Imports System.Data.SqlClient
Public Class employee
    Inherits System.Web.UI.Page
    Dim str As String = ("server=Samawade; database=JASA; integrated security=true;")
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Sub fillData()
        cmd.Connection = cn
        cmd.CommandText = "select *from Employee"
        cn.Open()
        dr = cmd.ExecuteReader
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()


    End Sub

    Sub Clear()
        txtContactNo.Text = ""
        txtEmpId.Text = ""
        txtEmpFullName.Text = ""
        txtEmpAddress.Text = ""
        txtEmpEmail.Text = ""
        txtEmpSalary.Text = ""


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillData()


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        txtEmpId.Text = row.Cells(1).Text
        txtEmpFullName.Text = row.Cells(2).Text
        DropDownList1.SelectedItem.Text = row.Cells(3).Text
        txtDateJoin.Text = row.Cells(4).Text
        txtEmpAddress.Text = row.Cells(5).Text
        txtContactNo.Text = row.Cells(6).Text
        txtEmpEmail.Text = row.Cells(7).Text
        txtEmpSalary.Text = row.Cells(8).Text
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        cmd.Parameters.Clear()

        cmd.Connection = cn
        cmd.CommandText = "UPDATE Employee set Emp_FullName=@Emp_FullName,Emp_Gender=@Emp_Gender,Emp_DateJoin=@Emp_DateJoin,Emp_Address=@Emp_Address,Emp_ContatNo=@Emp_ContatNo,Emp_Email=@Emp_Email,Emp_Salary=@Emp_Salary where Emp_Id=@Emp_Id"
        cmd.Parameters.AddWithValue("@Emp_Id", txtEmpId.Text)
        cmd.Parameters.AddWithValue("@Emp_FullName", txtEmpFullName.Text)
        cmd.Parameters.AddWithValue("@Emp_Gender", DropDownList1.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Emp_DateJoin", txtDateJoin.Text)
        cmd.Parameters.AddWithValue("@Emp_Address", txtEmpAddress.Text)
        cmd.Parameters.AddWithValue("@Emp_ContatNo", txtContactNo.Text)
        cmd.Parameters.AddWithValue("@Emp_Email", txtEmpEmail.Text)
        cmd.Parameters.AddWithValue("@Emp_Salary", txtEmpSalary.Text)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Recore inserted Succesfully !", MsgBoxStyle.Information)
            cmd.Parameters.Clear()
            fillData()
            cmd.Parameters.Clear()
            Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        cmd.Parameters.Clear()

        cmd.Connection = cn
        cmd.CommandText = "INSERT into Employee values (@Emp_FullName,@Emp_Gender,@Emp_DateJoin,@Emp_Address,@Emp_ContatNo,@Emp_Email,@Emp_Salary)"
        cmd.Parameters.AddWithValue("@Emp_FullName", txtEmpFullName.Text)
        cmd.Parameters.AddWithValue("@Emp_Gender", DropDownList1.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Emp_DateJoin", txtDateJoin.Text)
        cmd.Parameters.AddWithValue("@Emp_Address", txtEmpAddress.Text)
        cmd.Parameters.AddWithValue("@Emp_ContatNo", txtContactNo.Text)
        cmd.Parameters.AddWithValue("@Emp_Email", txtEmpEmail.Text)
        cmd.Parameters.AddWithValue("@Emp_Salary", txtEmpSalary.Text)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Recore inserted Succesfully !", MsgBoxStyle.Information)
            cmd.Parameters.Clear()
            fillData()

            Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        cmd.Parameters.Clear()
        cmd.Connection = cn
        cmd.CommandText = "DELETE Employee WHERE Emp_Id=@Emp_Id"
        cmd.Parameters.AddWithValue("Emp_Id", txtEmpId.Text)
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
            Clear()

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub
End Class