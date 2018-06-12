<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdSimpan.aspx.cs" Inherits="NYshariaCooperative.UpdSimpan" %>

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
    .auto-style2 {
        height: 46px;
    }
</style>
</head>
<body>
    <form id="form1" method="post" runat="server">
<ul class="auto-style1">
  <li><a href="Home.aspx">Keluar</a></li>
  <li><a href="ViewMember.aspx">Data Anggota</a></li>
  <li><a href="ViewPinjam.aspx">Data Pinjam</a></li>
  <li><a  class="active" href="UpdSimpan.aspx">Data Simpan</a></li>
  <li class="auto-style2"><a  href="Simpan.aspx">Simpan</a></li>
  <img src ="obj/logo_cooperative.png" style="margin: 10px 10px 5px 20px; width: 54px; height: 52px;"/> NY Sharia Cooperative
</ul>

        <asp:Panel ID="Panel1" runat="server" BackColor="#8AF3AC" BorderColor="#2A8FBD" BorderStyle="Dotted" Height="806px" BackImageUrl="~/obj/registerbener.png">
            <div class="form-group">
                    <label for="ID Simpan">ID Simpan:</label>
                    <asp:TextBox ID="simpanID" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Member ID">Member ID:</label>
                    <asp:TextBox ID="memberId" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Member Name">Member Name:</label>
                    <asp:TextBox ID="memberN" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Pembayaran Perbulan">Pembayaran Perbulan:</label>
                    <asp:TextBox ID="bayar" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btn_save" CssClass="btn btn-md btn-primary" runat="server" Text="Update Simpan" OnClick="updateSimpan" BackColor="#29773F" Width="178px"  />
                </div></asp:Panel>
    </form>

</body>
</html>