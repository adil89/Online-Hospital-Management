<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Layout.Master" AutoEventWireup="true" CodeBehind="MyTodayApointments.aspx.cs" Inherits="drchrono.Doctor.MyTodayApointments" %>
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
    
    <h1>My Todays Appointments</h1>

    <script type="text/javascript">

        $(document).ready(function () {

            load_MyTodayAppts();

        });

        function load_MyTodayAppts() {

            $('#tblFutureAlailAppointments').jtable({
                title: 'Todays Appointments',
                pagesize: 10,
                paging: true,
                sorting: true,
                defaultSorting: 'Name ASC',
                selecting: true, //Enable selecting
                //multiselect: false, //Allow multiple selecting
                //selectingCheckboxes: true, //Show checkboxes on first column
                //selectOnRowClick: false, //Enable this to only select using checkboxes
                actions: {
                    listAction: 'MyTodayApointments.aspx/GetMyTodaysAppointments'
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
                    patientID: {
                        title: 'Name',
                        width: '20%'

                    },
                    appTime: {
                        title: 'Time',
                        width: '20%'

                    },
                    appDate: {
                        title: 'Date',
                        width: '20%'

                    },
                    appType: {
                        title: 'Consultation Mode',
                        width: '20%'

                    },
                    reason: {
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
</div>
</asp:Content>
