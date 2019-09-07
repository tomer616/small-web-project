<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="website.ForgotPassword" %>
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
        <h1>Forgot Password</h1>
         <form runat="server">
        <label>Email</label>
        <asp:TextBox ID="UserName" type="text" runat="server" Width="387px" ></asp:TextBox>
        <br />
        <div>
            <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Back" OnClick="Back_Click" />
            <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back"  Text="Get Reset Link" OnClick="Get_Click" />
        </div>
 </form>

    </div>
    
</body>

</html>
