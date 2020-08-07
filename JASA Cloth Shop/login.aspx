<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="JASA_Cloth_Shop.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Bootstrap/jquery-3.5.1.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Bootstrap/popper.min.js"></script>

    <link href="fontawesome-free-5.13.0-web/css/all.min.css" rel="stylesheet" />
    <script src="fontawesome-free-5.13.0-web/js/all.min.js"></script>
</head>
<link href="CSS/login.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server">
    <div>
    
         <br /> <br /> <br />
        <div class="login-wrap">
	<iv class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab"></label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
					<label for="user" class="label">Username
                    </label>
                    &nbsp;<asp:TextBox class="input" ID="txtUserName" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <%--					<input id="user" type="text" class="input">--%>
				</div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" ErrorMessage="UserName is Empty" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000"></asp:RequiredFieldValidator>
				<div class="group">
					<label for="pass" class="label">Password
                    </label>
                    &nbsp;<asp:TextBox class="input" ID="txtPassword" runat="server" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                    <%--					<input id="pass" type="password" class="input" data-type="password">--%>
				</div>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Empty" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000"></asp:RequiredFieldValidator>
				
				<br />
				
				<div class="group">
					<input id="check" type="checkbox" class="check" checked>
					<label for="check"><span class="icon"></span> Keep me Signed in</label>
				</div>
				<div class="group">
                    <asp:Button class="button" ID="LoginForm" runat="server" Text="Log In" />
                    <%--					<input type="submit" class="button" value="Sign In">--%>
				</div>
                <br /> <br /> 
                <div class="group text-xl-center">
                <asp:Label ID="lblMessage" runat="server" Font-Size="14pt" ></asp:Label>
                    </div>
                <br /> <br /> 
                <%--<div class="hr">
                    
				</div>--%>
				<div class="foot-lnk">
					<a href="#forgot">Forgot Password?</a>
				</div>
			</div>
			
            	
        
		
		</div>
		</iv>
	</div>
         <%--</div>--%>
            <script src="validApp.js"></script>
            <br /> <br /> 

    </div>
    </form>
</body>
</html>
