<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="AccountActivity.aspx.cs" Inherits="drchrono.Patients.AccountActivity" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <div>
    
    </div>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="lastlogindateLabel" runat="server" Text='<%# Eval("lastlogindate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lastlogintimeLabel" runat="server" Text='<%# Eval("lastlogintime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="browserLabel" runat="server" Text='<%# Eval("browser") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ipaddressLabel" runat="server" Text='<%# Eval("ipaddress") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="lastlogindateTextBox" runat="server" Text='<%# Bind("lastlogindate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="lastlogintimeTextBox" runat="server" Text='<%# Bind("lastlogintime") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="browserTextBox" runat="server" Text='<%# Bind("browser") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ipaddressTextBox" runat="server" Text='<%# Bind("ipaddress") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="lastlogindateTextBox" runat="server" Text='<%# Bind("lastlogindate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="lastlogintimeTextBox" runat="server" Text='<%# Bind("lastlogintime") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="browserTextBox" runat="server" Text='<%# Bind("browser") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ipaddressTextBox" runat="server" Text='<%# Bind("ipaddress") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="lastlogindateLabel" runat="server" Text='<%# Eval("lastlogindate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lastlogintimeLabel" runat="server" Text='<%# Eval("lastlogintime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="browserLabel" runat="server" Text='<%# Eval("browser") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ipaddressLabel" runat="server" Text='<%# Eval("ipaddress") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">lastlogindate</th>
                                    <th runat="server">lastlogintime</th>
                                    <th runat="server">browser</th>
                                    <th runat="server">ipaddress</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Label ID="lastlogindateLabel" runat="server" Text='<%# Eval("lastlogindate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lastlogintimeLabel" runat="server" Text='<%# Eval("lastlogintime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="browserLabel" runat="server" Text='<%# Eval("browser") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ipaddressLabel" runat="server" Text='<%# Eval("ipaddress") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connectionstring %>" SelectCommand="SELECT [lastlogindate], [lastlogintime], [browser], [ipaddress] FROM [accounthistory] WHERE ([patientID] = @patientID)">
            <SelectParameters>
                <asp:SessionParameter Name="patientID" SessionField="patientid" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
   </asp:Content>