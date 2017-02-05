<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="PatientProfile.aspx.cs" Inherits="drchrono.PatientProfile" %>


<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="firstNameLabel" runat="server" Text="Firstname"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="firstNameLabelValue" Width="120px" BorderStyle="Inset"></asp:Label>
 
            </td>
        </tr>    

         <tr>
            <td>
                <asp:Label ID="middleNameLabel" runat="server" Text="Middlename"></asp:Label>
            </td>
            <td>
                <asp:Label ID="middleNamealue" runat="server" Width="120px" BorderStyle="Inset"></asp:Label>
            </td>
        </tr>    

        <tr>
            <td>
                <asp:Label ID="lastNameLabel" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lastNameValue" runat="server" Width="120px" BorderStyle="Inset"></asp:Label>
            </td>
        </tr>
      
        <tr>
            <td>
                <asp:Label ID="dateOfBirthLabel" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td colspan="1">
                <asp:Label ID="dateOfBirthLabelValue" runat="server" Width="120px"  BorderStyle="Inset" ></asp:Label>
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="genderLabel" runat="server" Text="Gender"></asp:Label>
            </td>
            <td >
                <asp:Label ID="genderLabelValue" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="cellNumberLabel" runat="server" Text="Cell Number"></asp:Label>
            </td>
            <td colspan="2"> 
                <asp:Label ID="cellNumberLabelValue" runat="server" Width="120px"  BorderStyle="Inset"></asp:Label>                
            </td>
        </tr> 

        <tr>
            <td>
                <asp:Label ID="homePhoneLabel" runat="server" Text="Home(Phone)"></asp:Label>
            </td>
            <td colspan="2"> 
                <asp:Label ID="homePhoneLabelValue" runat="server" Width="120px" BorderStyle="Inset" ></asp:Label>                
            </td>
        </tr> 

        <tr>
            <td>
                <asp:Label ID="addressLabel" runat="server" Text="Address"></asp:Label>
            </td>
            <td colspan="3"> 
                <asp:Label ID="addressLabelValue" runat="server"  BorderStyle="Inset" ></asp:Label>                
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="ctyLabel" runat="server" Text="City"></asp:Label>
            </td>
            <td colspan="3"> 
                <asp:Label ID="cityLabelValue" runat="server" BorderStyle="Inset" ></asp:Label>                
            </td>
        </tr> 
        
        <tr>
            <td>
                <asp:Label ID="zipLabel" runat="server" Text="Zip"></asp:Label>
            </td>
            <td > 
               <asp:Label ID="zipLabelValue" runat="server" ></asp:Label>
            </td>
        </tr> 
        
         
        <tr>
            <td>
                <asp:Label ID="stateLabel" runat="server" Text="State"></asp:Label>
            </td>
            <td colspan="3"> 
                <asp:Label ID="stateLabelValue" runat="server"  BorderStyle="Inset"></asp:Label>                
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="countryLabel" runat="server" Text="Country"></asp:Label>
            </td>
            <td>
                US 
            </td>
        </tr> 

         <tr>
            <td>
            <a  type="button"  id="editprofile"  href="/Patients/editprofile.aspx" class="btn btn-success">Edit Profile</a>
            </td>
            
        </tr> 
    </table>
	      <br/>
        <br/>
        <br/>
        <a type="button" href="/Patients/Billing.aspx" class="btn btn-success">Billing</a>
  
    </div>
    </asp:Content>