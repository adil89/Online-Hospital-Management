<%@ Page MasterPageFile="~/Patients/Layout.Master" Language="C#" AutoEventWireup="true" CodeBehind="RecoveryEmailSent.aspx.cs" Inherits="drchrono.RecoveryEmailSent" %>
<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div>
     <div>
        If you have provided the correct email and date of birth, we have sent you an email with instructions on how to recover password.
        Please follow the instructions and <asp:HyperLink id="loginHyperlink" NavigateUrl="Default.aspx" Text="login" runat="server"/> here.
    </div>
    </div>
    </asp:Content>