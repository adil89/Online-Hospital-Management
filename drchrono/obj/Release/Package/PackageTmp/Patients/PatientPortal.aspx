<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="PatientPortal.aspx.cs" Inherits="drchrono.PatientPortal" %>


<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div>
    <asp:Button ID="requestConsultButton" runat="server" onclick="requestConsultButton_Click" Text="Request a Consult" />
        <asp:Button ID="myProfileButton" runat="server" onclick="myProfileButton_Click" Text="My Profile" />
        <asp:Button ID="myAppointmentsButton" runat="server" onclick="myAppointmentsButton_Click" Text="My Appointments" />
        <asp:Button ID="healthHstoryButton" runat="server" onclick="healthHstoryButton_Click" Text="Health History" />
        <asp:Button ID="accountHistoryButton" runat="server" onclick="accountHistoryButton_Click" Text="Account History" />
        <asp:Button ID="messagesButton" runat="server" onclick="messagesButton_Click" Text="Messages" /> 
        <asp:Button ID="myDocumentsButton" runat="server" onclick="myDocumentsButton_Click" Text="My Documents" />   
        <asp:Button ID="myBillingButton" runat="server" onclick="myBillingButton_Click" Text="My Billing" />   
        <asp:Button ID="dependantButton" runat="server" onclick="dependantButton_Click" Text="Dependant" />      
        <asp:Button ID="systemTestButton" runat="server" onclick="systemTestButton_Click" Text="System Test" />  
        <asp:Button ID="contactUsButton" runat="server" onclick="contactUsButton_Click" Text="Contact US" />
    </div>
    </asp:Content>