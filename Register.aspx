<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="website.Register" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Filters Sets</title>
    <link href="resources/basis.css" rel="stylesheet" />
    <link href="resources/register-style.css" rel="stylesheet" />
</head>

<body>

    <div class="container-fluid general-background register-wrapper">
        <div class="col-xs-offset-4 col-xs-4 general-register-box" style="top:0 !important;">
            <div class="col-xs-10" style="margin:20px !important;">
                <h2>Register</h2>
                  <form runat="server" >
                <div class="form-group">
                    <span> ID</span> 
                    <asp:TextBox ID="UserName" CssClass="form-control" type="text" runat="server" placeholder="User name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <span> First Name</span> 
                    <asp:TextBox ID="FirstName" CssClass="form-control" type="text" runat="server" placeholder="First name" ></asp:TextBox>
                </div>
                      
                <div class="form-group">
                    <span> Last Name</span> 
                    <asp:TextBox ID="LastName" CssClass="form-control" type="text" runat="server" placeholder="Last name"></asp:TextBox>
                </div>
             
                <div class="form-group">
                    <span> Password</span> 
                    <asp:TextBox ID="Password" CssClass="form-control" type="password" runat="server" placeholder="Password"></asp:TextBox>
                </div>
          
                <div class="form-group">
                    <span> Confirm Password</span>
                    <asp:TextBox ID="ConfirmPassword" CssClass="form-control" type="password" runat="server" placeholder="Confirm Password"></asp:TextBox>
                </div>   
          
                <div class="form-group">          
                    <span> Email</span>
                    <asp:TextBox ID="Email" CssClass="form-control" type="text" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator> 
                </div>   
                <div class="form-group">
                    <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Back" type="button" Onclick ="Back_Click"></asp:Button>
                    <asp:Button runat="server" CssClass="btn btn-primary btn-round btn-3-4-long" Text="Send" type="button" Onclick ="Send_Click"></asp:Button>      
                </div>
                         </form>
            </div>
         </div>
    </div>
</body>

</html>
