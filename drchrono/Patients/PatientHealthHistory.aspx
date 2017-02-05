<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientHealthHistory.aspx.cs" Inherits="drchrono.PatientHealthHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

         <table>
        <tr>
            <td>
                <asp:Label ID="Height" runat="server" Text="Height"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="HeightTextbox" runat="server" Width="120px" BorderStyle="Inset" ></asp:TextBox>
            </td>
        </tr>    
        <tr>
            <td>
                <asp:Label ID="Weight" runat="server" Text="Weight"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="WeightTextbox" runat="server" Width="120px" BorderStyle="Inset"></asp:TextBox>
            </td>
        </tr>
             <tr>
                  <td>
                <asp:Label ID="BMI" runat="server" Text="BMI"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="BMITextBox" runat="server" Width="120px" BorderStyle="Inset" ></asp:TextBox>
            </td>


             </tr>

              <tr>
                  <td>
                <asp:Label ID="BloodGroupLabel" runat="server" Text="BloodGroup"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="BloodGroupTextBox" runat="server" Width="120px" BorderStyle="Inset" ></asp:TextBox>
            </td>


             </tr>

               <tr>
                  <td>
                <asp:Label ID="HealthProblemLabel" runat="server" Text="Do you Have any Health Problems?"></asp:Label>
            </td>
            <td class="auto-style1">

                <>
                <asp:DropDownList ID="HealthProblemDropDownList" runat="server" Width="120px" BorderStyle="Inset" OnSelectedIndexChanged="HealthProblemDropDownList_SelectedIndexChanged" ></asp:DropDownList>
                
                 </td>


             </tr>

               <tr>
                  <td>
                <asp:Label ID="FamilyHistoryLabel" runat="server" Text="Do any Medical Problems run in your family?"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="FamilyHistoryDropDownList" runat="server" Width="120px" BorderStyle="Inset" OnSelectedIndexChanged="FamilyHistoryDropDownList_SelectedIndexChanged" ></asp:DropDownList>
            </td>



             </tr>

               <tr>
                  <td>
                <asp:Label ID="MedicationLabel" runat="server" Text="What Medicines are you taking?"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="MedicationDropDownList" runat="server" Width="120px" BorderStyle="Inset" OnSelectedIndexChanged="MedicationDropDownList_SelectedIndexChanged" ></asp:DropDownList>
            </td>


             </tr>
               <tr>
                  <td>
                <asp:Label ID="AllergiesLabel" runat="server" Text="Do you Have any Allergy?"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="AllergyDropDownList" runat="server" Width="120px" BorderStyle="Inset" OnSelectedIndexChanged="AllergyDropDownList_SelectedIndexChanged" ></asp:DropDownList>
            </td>


             </tr>

             </table>
    
    </div>
    </form>
</body>
</html>
