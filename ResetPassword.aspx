<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="website.ResetPassword" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=1080, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Filters Sets</title>
    <link href="resources/basis.css" rel="stylesheet" />
    <link href="resources/password-reset-style.css" rel="stylesheet" />
</head>

<body>
    <div style="text-align: center">

        <br />
        <br />
        <br />
        <h1>Reset Password</h1>
         <form runat="server">
        <label>New Password</label>
        <asp:TextBox ID="NewPassword" type="text" runat="server" ></asp:TextBox>
        <br />
             <label>Confirm Password</label>
        <asp:TextBox ID="Confirm" type="text" runat="server" ></asp:TextBox>
        <br />
             <label>Retrun Token</label>
        <asp:TextBox ID="RetrunToken" type="text" runat="server" ></asp:TextBox>
        <br />
        <div>
            <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Back" OnClick="Back_Click" />
            <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Create" OnClick="Create_Click" />
             
        </div>
              
        
 </form>

    </div>
    
</body>

</html>
