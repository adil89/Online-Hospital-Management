<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="AccountActivity.aspx.cs" Inherits="drchrono.Patients.AccountActivity" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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

    <script type="text/javascript">

        $(document).ready(function () {

            load_logindetails();
        });

    </script>
    <script type="text/javascript"> 

        function load_logindetails() {

    $('#loginhistory').jtable({
                title: 'Login History',
                pagesize: 10,
                paging: true,
                sorting: true,
                defaultSorting: 'Name ASC',
                actions: {
                    listAction: 'AccountActivity.aspx/GetAccountHistory'
                },
                fields: {
                    patientID: {
                        key: true,
                        list: false

                    },
                    lastlogindate: {
                        title: 'Date',
                        width: '30%'

                    },
                    lastlogintime: {
                        title: 'Time',
                        width: '30%'

                    },
                    browser: {
                        title: 'Browser',
                        width: '30%'
                    },
                   ipaddress: {
                        title: 'IP',
                        width: '40%'
                    }
                }
            });
            $('#loginhistory').jtable('load');
            
        }

    </script>
   <div class="container" >
    
       <div id="loginhistory">

    
    </div>
    
</div>
     
   </asp:Content>