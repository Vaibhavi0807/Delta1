<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deltaform.aspx.cs" Inherits="DeltaWare.deltaform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FETCHING DATA</title>
</head>
<body>
   <div class="col-sm-4">
        <div class="form-group">
            <asp:Textbox id="txtProductId" runat="server" CssClass="form-control login-input border-bottom">

            </asp:Textbox>
        </div>
            <div class="row">
                <div class="col-sm-12">
                    <center>
                        <asp:Button id="btnFetch" runat="server" onclick="btnFetch_Click" Text="FETCH" CssClass="btn btn-primary border-bottom">

                        </asp:Button>
                    </center>
                </div>
            </div>
        </div>
   
    <asp:GridView ID="gvDelta" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="150px" DataField="Product_Name" HeaderText="Product_Name"/>
            <asp:BoundField ItemStyle-Width="150px" DataField="Product_Description" HeaderText="Product_Description"/>
            </Columns>
        </asp:GridView>

</body>
</html>
