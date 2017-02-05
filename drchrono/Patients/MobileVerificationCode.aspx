<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="MobileVerificationCode.aspx.cs" Inherits="drchrono.Patients.MobileVerificationCode" %>

<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    
    
    <div>
    

        <p > Enter the 4-digit number sent to your mobile inorder to proceed</p>

       
    </div>

        <asp:TextBox runat="server" ID="MobileCode"></asp:TextBox>
        <asp:Button ID="MobileCodeButton" OnClick="MobileCodeButton_Click" runat="server" Text="Confirm" />
  </asp:Content>
