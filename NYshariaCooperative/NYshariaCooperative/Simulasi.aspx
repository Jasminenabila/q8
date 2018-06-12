<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulasi.aspx.cs" Inherits="NYshariaCooperative.Simulasi" %>

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
    <form id="form1" method="post" runat="server">
<ul class="auto-style1">
  <li><a href="LoginAdmin.aspx" style="font-family: ABeeZee"><strong>Admin</strong></a></li>
  <li><a href="Login.aspx" style="font-family: ABeeZee"><strong>Member</strong></a></li>
  <li style="font-family: ABeeZee"><a class="active"  href="Simulasi.aspx"><strong>Simulasi</strong></a><strong></li>
  <li><a href="DaftarMember.aspx" style="font-family: ABeeZee"><strong>Daftar Member</strong></a></li>
  <li><a href="aboutus.aspx" style="font-family: ABeeZee"><strong>About Us</strong></a></li> 
  <li><a href="Home.aspx" style="font-family: ABeeZee"><strong>Home</strong></a></li>
  <img src ="obj/logo_cooperative.png" style="margin: 10px 10px 5px 20px; width: 54px; height: 52px;"/> <strong>NY Koperasi Syariah
</strong></ul>

        <asp:Panel ID="Panel1" runat="server" BackColor="#7ad3d2" BorderColor="#2A8FBD" BorderStyle="Dotted" Height="563px" BackImageUrl="~/obj/inputsimpan.png">
            <h2 style="font-family: ABeeZee; color: #3f5659" class="text-left"><strong>Simulasi</strong></h2><br />
    <%--<hr />--%>
                <div class="form-group">
                    <label for="Gaji" style="margin-left: 26px; font-family: ABeeZee; color: #fdffaa;">Gaji (Perbulan):</label>
                    <asp:TextBox ID="gaji" CssClass="form-control" runat="server" style="margin-left: 24px" Width="700px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Jumpi" style="margin-left: 26px; font-family: ABeeZee; color: #fdffaa;">Jumlah Pinjaman:</label>
                    <asp:TextBox ID="jumlahP" CssClass="form-control" runat="server" style="margin-left: 24px" Width="700px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="JangkaP" style="margin-left: 26px; font-family: ABeeZee; color: #fdffaa;">Jangka Pinjaman (Bulan):</label>
                    &nbsp;<asp:DropDownList ID="JangkaP" CssClass="form-control" runat="server" style="margin-left: 24px" Width="700px" Font-Bold="True" Font-Italic="True" AutoPostBack="True" OnSelectedIndexChanged="JangkaP_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="form-group">
                    <label for="Angsuran" style="margin-left: 26px; font-family: ABeeZee; color: #fdffaa;">Angsuran:</label>
                    <asp:TextBox ID="Angsuran" CssClass="form-control" runat="server" style="margin-left: 24px" Width="700px" Font-Names="ABeeZee" AutoPostBack="True" Enabled="False"></asp:TextBox>
                </div>
                <div class="form-group">
                </div></asp:Panel>
            </form>

</body>
</html>