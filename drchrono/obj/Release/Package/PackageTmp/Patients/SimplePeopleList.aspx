<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimplePeopleList.aspx.cs"
    Inherits="jTableWithAspNetWebForms.SimplePeopleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <link href="/Content/Site.css" rel="stylesheet" type="text/css" />
    
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />
      
    <!-- jTable style file -->
    
    <link href="../Scripts/jtable/themes/metro/blue/jtable.css" rel="stylesheet" />
    <script src="../Scripts/modernizr-2.6.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>

    <script src="../Scripts/jtablesite.js" type="text/javascript"></script>
    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="../Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="../Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="../Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="../Scripts/npm.js"></script>
    <style type="text/css">
td
{
    padding:0 15px 0 15px;
}
</style>
</head>
<body>
    <div>
   <form runat="server">
    
         <table >
        <tr>
            <td>
                <asp:Label ID="Height" runat="server" Text="Height"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="HeightTextbox" runat="server" Width="120px" BorderStyle="Inset" ></asp:TextBox>
            </td>
          
        <td>
                <asp:Label ID="Weight" runat="server" Text="Weight"></asp:Label>
        </td>

            <td class="auto-style1">
                <asp:TextBox ID="WeightTextbox" runat="server" Width="120px" BorderStyle="Inset"></asp:TextBox>
            </td>
              
                  <td>
                <asp:Label ID="BMI" runat="server" Text="BMI"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="BMITextBox" runat="server" Width="120px" BorderStyle="Inset" ></asp:TextBox>
            </td>



                  <td>
                <asp:Label ID="BloodGroupLabel" runat="server" Text="BloodGroup"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="BloodGroupTextBox" runat="server" Width="120px" BorderStyle="Inset" ></asp:TextBox>
            </td>

            </tr>
                          </table>
       </form>
        </div>
    <div id="PersonTableContainer">
    </div>
    <div id="MedicationTableContainer"></div>
    <div></div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#PersonTableContainer').jtable({
                title: 'Allergies',
                actions: {
                    listAction: 'SimplePeopleList.aspx/PersonList',
                    createAction: 'SimplePeopleList.aspx/CreatePerson',
                    updateAction: 'SimplePeopleList.aspx/UpdatePerson',
                    deleteAction: 'SimplePeopleList.aspx/DeletePerson'
                },
                fields: {
                    AllergyId: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    Allergies: {
                        title: 'My Allergies',
                        width: '20%',
                        options: 'SimplePeopleList.aspx/PopulateAllergy',
                        


                    },



                    Reaction: {
                        title: 'Reaction',
                        width: '20%',
                       
                       
                    },

                    Since_when: {
                        title: 'Since When',
                        width: '20%',
                        type: 'date'
                    },

                    Status: {
                        title: 'Status',
                        width: '20%'
                    }

                }
            });

            $('#PersonTableContainer').jtable('load');
        });
    </script>
     <script type="text/javascript">
         $(document).ready(function () {
             $('#MedicationTableContainer').jtable({
                 title: 'Medication',
                 actions: {
                     listAction: 'SimplePeopleList.aspx/PersonMedicationList',
                     createAction: 'SimplePeopleList.aspx/CreatePersonMedication',
                     updateAction: 'SimplePeopleList.aspx/UpdatePersonMedication',
                     deleteAction: 'SimplePeopleList.aspx/DeletePersonMedication'
                 },
                 fields: {
                     MedicationId: {
                         key: true,
                         create: false,
                         edit: false,
                         list: false
                     },
                     Medication: {
                         title: 'My Medicine',
                         width: '20%',
                         options: 'SimplePeopleList.aspx/PopulateMedication',



                     },



                     dose: {
                         title: 'Dose',
                         width: '20%',


                     },

                     frequency: {
                         title: 'Frequency',
                         width: '20%',
                         
                     },

                     Since: {
                         title: 'Taking Since',
                         width: '20%',
                         type:'date'
                     },
                    Prescribed: {
                         title: 'Prescribed by',
                         width: '20%'
                     }

                 }
             });

             $('#MedicationTableContainer').jtable('load');
         });
    </script>
</body>
</html>
