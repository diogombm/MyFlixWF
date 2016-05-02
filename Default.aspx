<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%">
            <tr>
                <td align="center" valign="top">
                    <table width="700">
                        <tr>
                            <td align="left">
                                <strong>
                                    Adicionar Filme</strong><br />
                                    <asp:TextBox ID="txtimdb_id" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                    <asp:Button ID="btnDispRemote" runat="server" Text="Criar" OnClick="btnDispRemote_Click" ValidationGroup="B" /></td>
                            <td align="left">
                                <strong>
                                    Pesquisar Filme<br />
                                <asp:TextBox ID="txtPesqFilme" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                </strong>
                                <asp:Button ID="btnPesqFilme" runat="server" OnClick="btnPesqFilme_Click1" Text="Pesquisar" />
                                <br />
                                    <br />
                                    </td>
                             <td align="left">
                                <strong>
                                    Remover Filme<br />
                                 </strong>
                                 <asp:TextBox ID="txtRemFilme" runat="server"></asp:TextBox>
                                 <br />
                                    <br />
                                    <asp:Button ID="BtnRemFilme" runat="server" OnClick="BtnRemFilme_Click" Text="Eliminar" />
                                 <br />
                                 <asp:Label ID="lblRemFilme" runat="server"></asp:Label>
                                    </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="grdList" runat="server" BackColor="White" BorderColor="#336666"
                        BorderStyle="Double" BorderWidth="3px" CellPadding="4" EnableViewState="False"
                        Width="100%" EnableModelValidation="True" GridLines="Horizontal" EmptyDataText="Filme não existe">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <RowStyle ForeColor="#333333" BackColor="White" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
