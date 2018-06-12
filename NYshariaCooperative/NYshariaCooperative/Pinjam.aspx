<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pinjam.aspx.cs" Inherits="NYshariaCooperative.Pinjam" %>

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
 <link rel="stylesheet"href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css">
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
        margin-bottom: 15px;
        height: 52px;
        margin-top: 28px;
    }
    </style>
</head>
<body>
    <form id="form1" method="post" runat="server" >
<ul class="auto-style1">
  <li><a href="Home.aspx" style="font-family: ABeeZee"><strong>Keluar</strong></a></li>
  <li><a class="active" href="Pinjam.aspx" style="font-family: ABeeZee"><strong>Ajukan Pinjamam</strong></a></li>
  <li><a href="HomeMember.aspx" style="font-family: ABeeZee"><strong>Profil Member</strong></a></li>
  <img src ="obj/logo_cooperative.png" style="margin: 10px 10px 5px 20px; width: 54px; height: 52px;"/></strong> <strong>NY Koperasi Syariah
</strong></ul>

        <asp:Panel ID="Panel1" runat="server" BackColor="#fdffaa" BorderColor="#2A8FBD" BorderStyle="Dotted" Height="763px" BackImageUrl="~/obj/register5.png">
            <h2 class="text-center" style="font-family: ABeeZee"><strong style="color: #ffc9c9">&quot;Isi Form Peminjaman&quot;</strong></h2>
    <%--<hr />--%>
                <div class="form-group">
                    <label for="ID Pinjam" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">ID Pinjam:</label>
                    <asp:TextBox ID="pinjamID" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
            <div class="form-group">
                    <label for="IDMember" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">ID Anggota:</label>
                    <asp:DropDownList ID="IDanggota" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px" Font-Bold="True" Font-Italic="True" OnSelectedIndexChanged="IDanggota_SelectedIndexChanged" AutoPostBack="True">

                    </asp:DropDownList>
             </div>
                <div class="form-group">
                    <label for="Member Name" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Nama Anggota:</label>
                    <asp:TextBox ID="memberN" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Gajji" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Gaji (Perbulan):</label>
                    <asp:TextBox ID="Gaji" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Jumlah Pinjam" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Jumlah Pinjaman:</label>
                    <asp:TextBox ID="jumlahP" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px" OnTextChanged="jumlahP_TextChanged"></asp:TextBox>
                </div>
            <div class="form-group">
                    <label for="Jangka Pinjam" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Jangka Pinjam (Bulan):
                    </label>
                    &nbsp;<asp:DropDownList ID="Jp" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px" Font-Bold="True" Font-Italic="True" OnSelectedIndexChanged="Jp_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
             </div>
                <div class="form-group">
                    <label for="Angsuran" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Angsuran:</label>
                    <asp:TextBox ID="Angsuran" CssClass="form-control" runat="server"  style="margin-left: 24px" Width="500px" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Status" style="margin-left: 26px; font-family: ABeeZee; color: #0A9FB2;">Status:</label>
                    <asp:TextBox ID="status" CssClass="form-control" runat="server" style="margin-left: 24px" Width="500px" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000">Pinjaman Anda akan segera di Proses</asp:TextBox>
                </div>
                <div class="auto-style2">
                    <asp:Button ID="btn_save" runat="server" BackColor="#0A9FB2" CssClass="btn btn-md btn-primary" Font-Bold="True" Font-Names="ABeeZee" Height="42px" OnClick="save" style="margin-left: 54; margin-top: 0" Text="Ajukan Pinjaman" Width="159px" />
                </div></asp:Panel>
            <p>
                &nbsp;</p>
            </form>

</body>
</html>
