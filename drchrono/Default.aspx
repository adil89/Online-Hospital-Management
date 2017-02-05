<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="drchrono._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
      
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  
  <script type="text/javascript">

      function getIP(json)
      {
             $.ajax({
                type: "POST",
                url: "Default.aspx/GetIPAddress",
                data: JSON.stringify({ ip: json.ip }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                async: "true",
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                },
                success: function (result) {

                }
            });

      }

    </script>
 <script type="text/javascript" src="https://api.ipify.org?format=jsonp&callback=getIP"></script>
    
   

            
            
       
   <div>
       
        <asp:Button ID="healthCareProvidersButton" runat="server" onclick="healthCareProvidersButton_Click" Text="Health Care Providers" />
        <asp:Button ID="organizationsButton" runat="server" onclick="organizationsButton_Click" Text="Organizations" />
        <asp:Button ID="aboutUsButton" runat="server" onclick="aboutUsButton_Click" Text="About Us" />
        <asp:Button ID="howgomdnowWorksButton" runat="server" onclick="howgomdnowWorksButton_Click" Text="How GoMDnow Works" />
        <asp:Button ID="contactUsButton" runat="server" onclick="contactUsButton_Click" Text="Contact Us" />
        <asp:Button ID="faqsButton" runat="server" onclick="faqsButton_Click" Text="FAQS" />
       <div>

         goMDnow provides 24/7 physician consultation via phone and video at the most reasonable rates. No need to go to the hospital now. Talk to our board certified doctors anytime at the comfort of your home. 

    </div>

        <h2>Patient Portal</h2>
    </div>   
    
    <table>
        <tr>
            <td>
                <asp:Label ID="emailTextbox" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="userTextbox" runat="server" Width="167px" TextMode="Email"></asp:TextBox>
            </td>
        </tr>    
        <tr>
            <td>
                <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="passwordTextbox" runat="server" Width="167px" TextMode="Password"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td>
            Remember me:
            <asp:CheckBox ID="chkRememberMe" OnCheckedChanged="chkRememberMe_CheckedChanged" runat="server" /><br />
            </td>
            <td style="float: right;">
                <asp:Button ID="loginButton" runat="server"  onClick="loginButton_Click" Text="Login" />  
              
            
            </td>
        </tr> 
        
        <tr>
            <td colspan="2">
                <asp:HyperLink id="forgotPasswordHyperlink" NavigateUrl="~/Patients/forgetpassword.aspx" Text="Forgot Password?" runat="server"/> 
            </td>
           
        </tr> 
        <tr>
            <td colspan="2">
                If you are a new patient, please 
                <asp:HyperLink id="registerHyperlink" NavigateUrl="~/Patients/RegisterPatient.aspx" Text="Register." runat="server"/> 
            </td>
        </tr> 
    </table>
    Get started in 3 easy steps
        1- Register Yourself            
        2- Complete your medical history         
        3- Request a Virtual Visit
    Need any help?  
    Call us at +111111111 or write to us at support@goMDnow.com
   

    </asp:Content>
 