<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="drchrono.Patients.ChangePassword" %>

<asp:Content runat="server" ID="changepasswordcontent" ContentPlaceHolderID="ContentPlaceHolder1">
      
     <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
         </style>
    <div>
    
        <table>

            <tr>
                <td>
                <asp:Label runat="server" Text="Current Password:"></asp:Label>
                    </td>
                <td class="auto-style1">

                    <asp:TextBox runat="server" ID="currpassTextBox"></asp:TextBox>

                </td>
            </tr>
       
                 <tr>   
                
                
             <td>

            
                <asp:Label runat="server" Text="New Password:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox runat="server"  ID="newpassTextBox"></asp:TextBox>

            </td>
                     <td>

                       <!--          <img src="../Images/rules.JPG" /> -->

                     </td>
                         </tr>

                <tr>

                    <td>

                        <asp:Label runat="server" Text="Repeat New Password:"></asp:Label>

                    </td>

                    <td class="auto-style1">

                        <asp:TextBox runat="server" ID="repeatnewpassTextBox"></asp:TextBox>

                    </td>

            </tr>

            <tr>


            </tr>

            <tr>

                
                <td>

                    <p>Note: You will be logged out and will need to log in again to continue.</p>
                </td>
                     
                      </tr>

            <tr>


                <td>


                    <asp:Button  runat="server" ID="reset" Text="Reset" OnClick="reset_Click"/>
                    <asp:Button  runat="server" Text="cancel" ID="cancel" OnClick="cancel_Click"/>

                </td>

            </tr>
        </table>
    </div>
    </asp:Content>