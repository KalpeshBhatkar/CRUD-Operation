<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerMaster.aspx.cs" Inherits="CustomerMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>CRUD Opration in asp.net using Gridview</h2>
            <asp:Label ID="lblmsg" runat="server" />
            <asp:GridView ID="gvCustomer" runat="server" DataKeyNames="CustomerID" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                            <asp:HiddenField ID="hdfCustomerIDit" runat="server" Value='<%#Eval("CustomerID") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:HiddenField ID="hdfCustomerIDft" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtName" runat="server" placeholder="Name" />
                            <asp:RequiredFieldValidator ID="reqtxtName" runat="server" ErrorMessage="Required!!!" Display="Dynamic" ControlToValidate="txtName" ForeColor="Red" ValidationGroup="Customer" />
                            <asp:RegularExpressionValidator ID="regtxtName" runat="server" ControlToValidate="txtName" ValidationExpression="[a-zA-Z]*$" ErrorMessage="Invalid Name!!!" Display="Dynamic" ForeColor="Red" ValidationGroup="Customer" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MobileNo">
                        <ItemTemplate>
                            <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMobileNo" runat="server" placeholder="Mobile No" />
                            <asp:RequiredFieldValidator ID="reqtxtMobileNo" runat="server" ErrorMessage="Required!!!" Display="Dynamic" ControlToValidate="txtMobileNo" ForeColor="Red" ValidationGroup="Customer" />
                            <asp:RegularExpressionValidator ID="regtxtMobileNo" runat="server" ControlToValidate="txtMobileNo" ValidationExpression="^[0-9]{10}$" ErrorMessage="Invalid Mobile No.!!!" Display="Dynamic" ForeColor="Red" ValidationGroup="Customer" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EmailID">
                        <ItemTemplate>
                            <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EmailID") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailID" runat="server" placeholder="Email ID" />
                            <asp:RequiredFieldValidator ID="reqtxtEmailID" runat="server" ErrorMessage="Required!!!" Display="Dynamic" ControlToValidate="txtEmailID" ForeColor="Red" ValidationGroup="Customer" />
                            <asp:RegularExpressionValidator ID="regtxtEmailID" runat="server" ControlToValidate="txtEmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ErrorMessage="Invalid EmailID!!!" Display="Dynamic" ForeColor="Red" ValidationGroup="Customer" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:RadioButtonList ID="rdbGender" runat="server">
                                <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Visible='<%#Eval("CustomerID").ToString() == "0" ? false : true %>' />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible='<%#Eval("CustomerID").ToString() == "0" ? false : true %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnSave" runat="server" Text="Insert" OnClick="btnSave_Click" ValidationGroup="Customer" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
