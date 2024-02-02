<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Crud_app_with_image.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 450PX;
            border:3px solid black;
           
            margin:auto;
        }
        .auto-style2 {
            width: 21px;
        }
        .auto-style3 {
            width: 21px;
            height: 39px;
        }
        .auto-style4 {
            height: 39px;
            width: 526px;
        }
        .auto-style5 {
            width: 526px;
        }
        h2{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table cellpadding="4" cellspacing="4" class="auto-style1">
                <tr>
                    <td colspan="2"><h2>EMPLOYEE CRUD APPLICATION</h2></td>
                </tr>
                <tr>
                    <td class="auto-style2">ID</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="IdTextBox" runat="server" Height="24px" Width="287px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" Display="Dynamic" ErrorMessage="PLEASE ENTER ID" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">NAME</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="NameTextBox" runat="server" Height="21px" Width="286px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NameTextBox" Display="Dynamic" ErrorMessage="PLEASE ENTER NAME" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">AGE</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="AgeTextBox" runat="server" Height="20px" Width="284px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AgeTextBox" Display="Dynamic" ErrorMessage="PLEASE ENTER AGE" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">GENDER</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="Genderddl" runat="server" Height="20px" Width="293px">
                            <asp:ListItem>SELECT GENDER</asp:ListItem>
                            <asp:ListItem>MALE</asp:ListItem>
                            <asp:ListItem>FEMALE</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Genderddl" Display="Dynamic" ErrorMessage="PLEASE SELECT GENDER" ForeColor="Red" InitialValue="SELECT GENDER" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">DESIGNATION</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="Desigddl" runat="server" Height="19px" Width="293px">
                            <asp:ListItem>SELECT DESIGNATION</asp:ListItem>
                            <asp:ListItem>MANAGER</asp:ListItem>
                            <asp:ListItem>TEAM LEADER</asp:ListItem>
                            <asp:ListItem>DEVELOPER</asp:ListItem>
                            <asp:ListItem>HR</asp:ListItem>
                            <asp:ListItem>NETWORK ENGINEER</asp:ListItem>
                            <asp:ListItem>FRONTEND DEVELOPER</asp:ListItem>
                            <asp:ListItem>DESIGNER</asp:ListItem>
                            <asp:ListItem>TESTER</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Desigddl" Display="Dynamic" ErrorMessage="PLEASE SELECT DESIGNATION" ForeColor="Red" InitialValue="SELECT DESIGNATION" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">SALARY</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="SalaryTextBox" runat="server" Height="18px" Width="286px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="SalaryTextBox" Display="Dynamic" ErrorMessage="PLEASE ENTER SALARY" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">IMAGE</td>
                    <td class="auto-style5">
                        <asp:Image ID="Getimg" Height="70" Width="70" Visible="false" runat="server" />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="INSERTBTN" runat="server" Height="33px" Text="INSERT" Width="104px" OnClick="INSERTBTN_Click" />
                        <asp:Button ID="DeletrButton" runat="server" Height="33px" Text="DELETE" Width="104px" OnClick="DeletrButton_Click" />
                        <asp:Button ID="UpdateButton" runat="server" Height="33px" Text="UPDATE" Width="104px" OnClick="UpdateButton_Click" />
                        <asp:Button ID="ResetButton" runat="server" Height="33px" Text="RESET" Width="104px" OnClick="ResetButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Silver" Font-Size="Large" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="Labelid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NAME">
                         <ItemTemplate>
                            <asp:Label ID="Labelname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGE">
                         <ItemTemplate>
                            <asp:Label ID="Labelage" runat="server" Text='<%#Eval("age") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GENDER">
                         <ItemTemplate>
                            <asp:Label ID="Labelgender" runat="server" Text='<%#Eval("gender") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DESIGNATION">
                         <ItemTemplate>
                          <asp:Label ID="Labeldesig" runat="server" Text='<%#Eval("designation") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SALARY">
                         <ItemTemplate>
                           <asp:Label ID="Labelsalary" runat="server" Text='<%#Eval("salar") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IMAGE">
                         <ItemTemplate>
                             <asp:Image ID="Image1" ImageUrl='<%# Eval("img_path") %>' Width="100" Height="100" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
