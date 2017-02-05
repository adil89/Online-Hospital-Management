<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorPortal.aspx.cs" MasterPageFile="~/Patients/Layout.Master" Inherits="drchrono.DoctorPortal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    
    <link href="../Scripts/jtable/themes/metro/blue/jtable.css" rel="stylesheet" />
    <%--<script src="../Scripts/modernizr-2.6.2.js" type="text/javascript"></script>--%>
   <%-- <script src="../Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>--%>
    <script src="../Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>

    <script src="../Scripts/jtablesite.js" type="text/javascript"></script>
    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="../Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="../Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="../Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>
        <asp:Button ID="todayAppointmentsButton" runat="server" onclick="todayAppointmentsButton_Click" Text="Today's Appointments" />
        <asp:Button ID="futureAppointmentsButton" runat="server" onclick="futureAppointmentsButton_Click" Text="My Future Appointments" />
        <asp:Button ID="futureAvailableAppointmentButton" runat="server" onclick="futureAvailableAppointmentButton_Click" Text="Future Available Appointments" />
        <asp:Button ID="myRoomButton" runat="server" onclick="myRoomButton_Click" Text="My Room" />
        <asp:Button ID="mySchedulerButton" runat="server" onclick="mySchedulerButton_Click" Text="My Scheduler" /> 
        <asp:Button ID="myProfileButton" runat="server" onclick="myProfileButton_Click" Text="My Profile" />   
        <asp:Button ID="messagesButton" runat="server" onclick="messagesButton_Click" Text="Messages" />   
        <asp:Button ID="myPatientsButton" runat="server" onclick="myPatientsButton_Click" Text="My Patients" />      
        <asp:Button ID="clinicalGuidelinesButton" runat="server" onclick="clinicalGuidelinesButton_Click" Text="Clinical Guidelines" />  
        <asp:Button ID="myBillingButton" runat="server" onclick="myBillingButton_Click" Text="My Billing" />
        <asp:Button ID="accountSettingsButton" runat="server" onclick="accountSettingsButton_Click" Text="Account Settings" />
        <asp:Button ID="systemTestButton" runat="server" onclick="systemTestButton_Click" Text="System Test" />
        <asp:Button ID="btnConsultation" runat="server" onclick="Consultation_Click" Text="Consultation" />

        <script type="text/javascript">

            $(document).ready(function () {

                load_FutureAppts();


            });

            function load_FutureAppts() {

                $('#tblFutureAlailAppointments').jtable({
                    title: 'Patients in Queue',
                    pagesize: 10,
                    paging: true,
                    sorting: true,
                    defaultSorting: 'Name ASC',
                    selecting: true, //Enable selecting
                    //multiselect: false, //Allow multiple selecting
                    //selectingCheckboxes: true, //Show checkboxes on first column
                    //selectOnRowClick: false, //Enable this to only select using checkboxes
                    actions: {
                        listAction: 'DoctorPortal.aspx/PatientQueue'
                        //createAction: 'SimplePeopleList.aspx/CreatePerson',
                        //updateAction: 'SimplePeopleList.aspx/UpdatePerson',
                        //deleteAction: 'MyDocuments.aspx/DeleteFile'
                    },
                    fields: {
                        ApptID: {
                            key: true,
                            create: false,
                            edit: false,
                            list: false

                        },
                        PatientID: {
                            title: 'Name',
                            width: '20%'

                        },
                        ApptTime: {
                            title: 'Time',
                            width: '20%',
                          

                        },
                        ApptDate: {
                            title: 'Date',
                            width: '20%'

                        },
                        ApptType: {
                            title: 'Consultation Mode',
                            width: '20%'

                        },
                        Reason: {
                            title: 'Visit Type',
                            width: '20%'

                        },
                        Status: {
                            title: 'Status',
                            width: '20%'

                        }
                    }
                });
                $('#tblFutureAlailAppointments').jtable('load');
               
                $('#btnAccept').button().click(function () {
                    var $selectedRows = $('#tblFutureAlailAppointments').jtable('selectedRows');

                    
                    if ($selectedRows.length > 0) {
                        //Show selected rows
                        $selectedRows.each(function () {
                            var record = $(this).data('record');


                           
                            var patientID = record.PatientID;
                            var appTime = record.ApptTime;
                            var appDate = record.ApptDate;
                            var appType = record.ApptType;
                            var reason = record.Reason;

                            var jsonObj = { "patientID": patientID, "appTime": appTime, "appDate": appDate, "appType": appType, "reason": reason };

                            $.ajax({
                                type: "POST",
                                url: "DoctorPortal.aspx/acceptAppointment",
                                data: JSON.stringify(jsonObj),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (result) {

                                

                                
                                    load_FutureAppts();
                                    window.location = 'Consultation.aspx';

                                },
                                error: function (xmlhttprequest, textstatus, errorthrown) {
                                    alert(" conection to the server failed ");
                                    console.log("error: " + errorthrown);
                                }
                            });


                        });
                    } else {
                        alert("Please select a Patient First");
                    }
                });

            }
           
         </script>
     <br/>
    <br/>
    <br/>
<div class="container" >
    <div id="tblFutureAlailAppointments">
    </div>
    <br/>
    <br/>
    <button type="button" id="btnAccept" class="btn btn-success">Accept</button>
</div>
</asp:Content>