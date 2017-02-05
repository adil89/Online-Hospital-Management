<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorLogin.aspx.cs" Inherits="drchrono.DoctorLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <asp:Button ID="patientsButton" runat="server" onclick="patientsButton_Click" Text="Patients" />
        <asp:Button ID="organizationsButton" runat="server" onclick="organizationsButton_Click" Text="Organizations" />
        <asp:Button ID="aboutUsButton" runat="server" onclick="aboutUsButton_Click" Text="About Us" />
        <asp:Button ID="howgomdnowWorksButton" runat="server" onclick="aboutUsButton_Click" Text="How GoMDnow Works" />
        <asp:Button ID="contactUsButton" runat="server" onclick="aboutUsButton_Click" Text="Contact Us" />
        <asp:Button ID="faqsButton" runat="server" onclick="aboutUsButton_Click" Text="FAQS" />
        <h2>Doctor Portal</h2>
        goMDnow provides 24/7 physician consultation via phone and video at the most reasonable rates. No need to go to the hospital or clinic now. Talk to our patients anytime at the comfort of your home. 
    </div>   
    <table>
        <tr>
            <td>
                <asp:Label ID="emailTextbox" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="userTextbox" runat="server" Width="167px"></asp:TextBox>
            </td>
        </tr>    
        <tr>
            <td>
                <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="passwordTextbox" runat="server" Width="167px"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td>
            Remember me:
            <asp:CheckBox ID="chkRememberMe" runat="server" /><br />
            </td>
            <td style="float: right;">
                <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />  
            </td>
        </tr> 
        <tr>
            <td colspan="2">
                <asp:HyperLink id="forgotPasswordHyperlink" NavigateUrl="~/Patients/ForgotPassword.aspx" Text="Forgot Password?" runat="server"/> 
            </td>
        </tr> 
        <tr>
            <td colspan="2">
                If you are a new doctor, please 
                <asp:HyperLink id="registerHyperlink" NavigateUrl="~/Doctor/DoctorRegister.aspx" Text="Register." runat="server"/> 
            </td>
        </tr> 
    </table>
    Get started in 3 easy steps
        1- Register Yourself            
        2- Complete your profile         
        3- Check your patients

    Need any help?  
    Call us at +111111111 or write to us at support@goMDnow.com
    </div>
    </form>
</body>
</html>
