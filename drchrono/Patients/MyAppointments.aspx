<%@ Page Title="" Language="C#" MasterPageFile="~/Patients/Layout.Master" AutoEventWireup="true" CodeBehind="MyAppointments.aspx.cs" Inherits="drchrono.Patients.MyAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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

    
    <h1>My Appointments</h1>
    
    <div style="margin-left: 1%;" class="row">
       <div  class="col-sm-5">
          <button type="button" class="btn btn-info" onclick="btnUpComingAtpClick();" >Upcomming Appointments</button>   
       </div>
        <div class="col-sm-5">
          <button type="button" class="btn btn-info" onclick="btnPastAtp_click();">Past Appointments</button>     
        </div>
    </div>
   
    <script type="text/javascript">

        $(document).ready(function () {

            load_upcommingAppts();
            

        });


        function load_upcommingAppts() {

            $('#tblUpComingAppointments').jtable({
                title: 'Upcoming Appointments',
                pagesize: 10,
                paging: true,
                sorting: true,
                defaultSorting: 'Name ASC',
                //selecting: true, //Enable selecting
                //multiselect: false, //Allow multiple selecting
                //selectingCheckboxes: true, //Show checkboxes on first column
                //selectOnRowClick: false, //Enable this to only select using checkboxes
                actions: {
                    listAction: 'MyAppointments.aspx/GetAllUpcomingAppointments'
                    //createAction: 'SimplePeopleList.aspx/CreatePerson',
                    //updateAction: 'SimplePeopleList.aspx/UpdatePerson',
                    //deleteAction: 'MyDocuments.aspx/DeleteFile'
                },
                fields: {
                    FileId: {
                        key: true,
                        //create: false,
                        //edit: false,
                        list: false

                    },
                    appTime: {
                        title: 'Time',
                        width: '30%'

                    },
                    appDate: {
                        title: 'Date',
                        width: '30%'

                    },
                    Status: {
                        title: 'Status',
                        width: '40%'
                    }
                }
            });
            $('#tblUpComingAppointments').jtable('load');
            
        }

        function btnUpComingAtpClick() {

            $('#tblPastAppointmrnts').jtable('destroy');
            load_upcommingAppts();

        }

        function btnPastAtp_click() {
         
            $('#tblUpComingAppointments').jtable('destroy');


            $('#tblPastAppointmrnts').jtable({
                title: 'Past Appointments',
                pagesize: 10,
                paging: true,
                sorting: true,
                defaultSorting: 'Name ASC',
                //selecting: true, //Enable selecting
                //multiselect: false, //Allow multiple selecting
                //selectingCheckboxes: true, //Show checkboxes on first column
                //selectOnRowClick: false, //Enable this to only select using checkboxes
                actions: {
                    listAction: 'MyAppointments.aspx/GetAllPastAppointments'
                    //createAction: 'SimplePeopleList.aspx/CreatePerson',
                    //updateAction: 'SimplePeopleList.aspx/UpdatePerson',
                    //deleteAction: 'MyDocuments.aspx/DeleteFile'
                },
                fields: {
                    FileId: {
                        key: true,
                        //create: false,
                        //edit: false,
                        list: false

                    },
                    appTime: {
                        title: 'Time',
                        width: '10%'

                    },
                    appDate: {
                        title: 'Date',
                        width: '10%'

                    },
                    patientID: {
                        title: 'Patient',
                        width: '20%'
                    },
                    ProviderID: {
                        title: 'Provider',
                        width: '20%'
                    },
                    Status: {
                        title: 'Status',
                        width: '10%'
                    },
                    Feedback: {
                        title: 'Feedback',
                        width: '30%'
                    }

                }
            });

           





            $('#tblPastAppointmrnts').jtable('load');
        };

 </script>
    <br/>
    <br/>
    <br/>
<div class="container" >
    <div id="tblUpComingAppointments">
    </div>
    <div id="tblPastAppointmrnts">
    </div>
</div>

</asp:Content>
