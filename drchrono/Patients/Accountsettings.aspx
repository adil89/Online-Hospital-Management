<%@ Page Language="C#" MasterPageFile="~/Patients/Layout.Master" AutoEventWireup="true" CodeBehind="Accountsettings.aspx.cs" Inherits="drchrono.Patients.Accountsettings" %>



     <asp:Content  ContentPlaceHolderID="ContentPlaceHolder1"   runat="server" >
        
        
   
    <div >
        <table>

            <tr>
        
                <td>
               
                     <asp:Label runat="server" Text="Username"></asp:Label>
            
                </td>
                
                <td>

                    <asp:TextBox runat="server" ID="username" ReadOnly="true"></asp:TextBox>
                
                </td>    
            
            </tr>
            
            <tr>
                <td>

        
                    <asp:Label runat="server" Text="Password"></asp:Label>

               
                         </td>
                <td>
                  
                    <asp:TextBox runat="server" ID="password"  ReadOnly="true"></asp:TextBox>

                </td>
                <td>
                    
                    
                   <button id ="changepassword" ><img src="../Images/passwordchange.JPG" /></button>

                </td>
                
            </tr>
            
            <tr>

       
                <td>

                 <asp:Label runat="server" Text="Linked Email Address:" ></asp:Label>
                
           
                </td>

                <td>

                    <asp:TextBox runat="server" ID="linkedEmailAddress" ReadOnly="true"></asp:TextBox>

                </td>

            </tr>

            <tr>

        
                
                <td>

                
                    <asp:Label runat="server" Text="Linked Phone No:"></asp:Label>
               
                </td>

                <td>


                    <asp:TextBox runat="server" ID="linkedPhoneNo"></asp:TextBox>

                </td>
            </tr>
            
            <tr>

        
                <td>
                
                    <asp:Label runat="server" Text="Two Factor Authentication is disabled for your account"></asp:Label>
        
                </td>
                
                
                <td>

                    <a href="TwoFactorAuthentication.aspx" >Enable Two Factor Authentication</a>


                </td>
            </tr>
                
            
            <tr>

                <td>

               
                     <asp:Label runat="server" Text="Auto Lock Time:"></asp:Label>
                    
                </td>

                <td>


                   <asp:DropDownList ID="autolockdropdownlist" runat="server" OnSelectedIndexChanged="autolockdropdownlist_SelectedIndexChanged">
               
                <asp:ListItem Text="Select Time" Value="-1"></asp:ListItem>
                <asp:ListItem Text="5 minutes" Value="5"></asp:ListItem>
                <asp:ListItem Text="10 minutes" Value="10"></asp:ListItem>
                <asp:ListItem Text="15 minutes" Value="15"></asp:ListItem>
                <asp:ListItem Text="20 minutes" Value="20"></asp:ListItem>
                <asp:ListItem Text="25 minutes" Value="25"></asp:ListItem>
                <asp:ListItem Text="30 minutes" Value="30"></asp:ListItem>
                <asp:ListItem Text="35 minutes" Value="35"></asp:ListItem>
                <asp:ListItem Text="40 minutes" Value="40"></asp:ListItem>
                <asp:ListItem Text="45 minutes" Value="45"></asp:ListItem>
                <asp:ListItem Text="50 minutes" Value="50"></asp:ListItem>
                <asp:ListItem Text="55 minutes" Value="55"></asp:ListItem>
                <asp:ListItem Text="60 minutes" Value="60"></asp:ListItem>
                    
                             </asp:DropDownList>
                </td>

           </tr>

            
            <tr>

             
                   <td>
                
                         <asp:Label runat="server" Text="Enable Access outside US:"></asp:Label>
        
                   </td>

                <td>

                    <asp:label runat="server" Text="Deny"></asp:label>

                </td>

                <td>

                   <asp:Label runat="server" Text="Duration"></asp:Label>

                </td>

                <td>

                    <asp:DropDownList ID="durationdropdownlist" runat="server"></asp:DropDownList>

                </td>
           </tr>

            <tr>

                <td>


                    <asp:label runat="server" Text="Authorizations:"></asp:label>
                </td>
                
                <td>

                <asp:Button ID="authorize" OnClick="authorize_Click" Text="Authorize this Machine" runat="server"/>
                </td>
                
                <td>

                    <asp:Button ID="deauthorize" runat="server" OnClick="deauthorize_Click" Text="Deauthorize this Machine"/>

                </td>

            </tr>

            <tr>

               <td>

                   <asp:Label runat="server" Text="Best way to send you a reminder prior to the consultation?"></asp:Label>
               </td>

                <td>
                    
                    <asp:RadioButton runat="server" GroupName="Reminder" ID="email" Text="Email" OnCheckedChanged="email_CheckedChanged"/>
                    

                </td>

                <td>


                    <asp:RadioButton runat="server" GroupName="Reminder" ID="TextMessage" Text="TextMessage" OnCheckedChanged="TextMessage_CheckedChanged" />
                </td>

                <td>

                    <asp:RadioButton ID="both" runat="server" GroupName="Reminder" Text="Both" OnCheckedChanged="both_CheckedChanged" />

                </td>

                
            </tr>

            <tr>

                <asp:Label ID="lastlogin" runat="server"></asp:Label>

            </tr>

            <tr>
                <td>
                <p  >Click <a href="AccountActivity.aspx"> here</a> to view login history</p>
                <asp:Label runat="server" ID="login"></asp:Label>
                    </td>
            </tr>

            </table>

        <asp:Button ID="saveaccountsettings" OnClick="saveaccountsettings_Click" runat="server" Text="Save" />
    
    </div>
     <script type="text/javascript">

         $(document).ready(function () {

             $("#changepassword").click(function () {

                 
                 $(location).attr('href', 'ChangePassword.aspx');
                 return false;

             });

         });

          </script>


</asp:Content>