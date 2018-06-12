<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NYshariaCooperative.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html lang="en">
<head>
 <meta charset="utf-8">
 <meta name="viewport" content="width=device-width">
 <meta http-equiv="content-type" content="text/html; charset=UTF-8">
 <!-- For Google -->
 <link rel="author" href="https://plus.google.com/+Scoopthemes">
 <link rel="publisher" href="https://plus.google.com/+Scoopthemes">
 <!-- Canonical -->
 <link rel="canonical" href="">
 <title>NY Sharia Cooperative</title>
 <!-- Bootstrap CSS -->
 <link rel="stylesheet"
href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css">
 <!-- font Awesome CSS -->
 <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/fontawesome/4.2.0/css/font-awesome.min.css">
 <!-- Main Styles CSS -->
 <link href="assets/css/main.css" rel="stylesheet">
 <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
 <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
 <!--[if lt IE 9]>
 <meta http-equiv="X-UA-Compatible" content="IE=edge">
 <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
 <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
 <![endif]-->
<style>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #8af3ac;
}

li {
    float: right;
}

li a {
    display: block;
    color: #2a8fbd;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover:not(.active) {
    background-color: #8af3ac;
}

.active {
    background-color: #29773f;
}
    .auto-style1 {
        height: 74px;
    }
    </style>
</head>
<body>
    <form id="form2" method="post" runat="server">
<ul class="auto-style1">
  <li><a href="LoginAdmin.aspx" style="font-family: ABeeZee"><strong>Admin</strong></a></li>
  <li style="font-family: ABeeZee"><a class="active"  href="Login.aspx"><strong>Member</strong></a><strong></li>
  <li><a href="Simulasi.aspx" style="font-family: ABeeZee"><strong>Simulasi</strong></a></li>
  <li><a href="DaftarMember.aspx" style="font-family: ABeeZee"><strong>Daftar Member</strong></a></li>
  <li><a href="aboutus.aspx" style="font-family: ABeeZee"><strong>About Us</strong></a></li> 
  <li><a href="Home.aspx" style="font-family: ABeeZee"><strong>Home</strong></a></li>
  <img src ="obj/logo_cooperative.png" style="margin: 10px 10px 5px 20px; width: 54px; height: 52px;"/><strong> NY Koperasi Syariah
</strong></ul>


<asp:Panel ID="Panel1" runat="server" BackColor="#fdffaa" BorderColor="#2A8FBD" BorderStyle="Dotted" Height="694px" BackImageUrl="~/obj/register5.png">
            <h2 class="text-center" style="font-family: ABeeZee"><strong style="color: #ffc9c9">LOGIN</strong></h2>
    <%--<hr />--%><div class="form-group">
                    <label for="Username" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Username:</label>
                    <asp:TextBox ID="Username" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label for="Password" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Password:</label>
                    <asp:TextBox ID="pass" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btn_save" CssClass="btn btn-md btn-primary" runat="server" Text="Login" OnClick="save" BackColor="#0A9FB2" Font-Bold="True" Font-Names="ABeeZee"  /> <br />
                    <br /> <asp:Label ID="lbl_error" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Andalus" ForeColor="Red"></asp:Label>
                </div></asp:Panel>
            </form>

</body>
</html>
