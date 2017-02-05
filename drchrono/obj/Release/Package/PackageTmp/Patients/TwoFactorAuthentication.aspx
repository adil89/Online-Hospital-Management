<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="TwoFactorAuthentication.aspx.cs" Inherits="drchrono.Patients.TwoFactorAuthentication" %>


 
   <asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <p>
            Every time you log in to goMDnow, you'll be asked to enter a verification code, sent to you by sms, along with your password. This verification code will
            be sent to you via SMS.
            
            To enable Two Factor Authentication for your account, enter your mobile number :

        </p>
            
        <p>
            
              Mobile Number : 
       
        </p> 
        
            
        <asp:TextBox runat="server" ID="mobileno"></asp:TextBox>

        <div class="pull-right">

            <asp:Label runat="server" ID="mobilecodelabel" Text="Code:"></asp:Label>
            <asp:TextBox runat="server" ID="mobilecodetextbox"></asp:TextBox>

        </div>

        
         <div>
      
    <table>
        
        <tr>
        
            <td>
            
                <asp:Button ID="save" OnClick="save_Click1" Text="Save" runat="server"  />
       
            </td>

            <td>
                
                 <asp:Button ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" />
    
            </td>    
       
        </tr>

            </table>

     </div>
    </div>
   </asp:Content>