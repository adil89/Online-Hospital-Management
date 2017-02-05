<%@ Page Title="" Language="C#" MasterPageFile="~/Patients/Layout.Master" AutoEventWireup="true" CodeBehind="MyBilling.aspx.cs" Inherits="drchrono.Patients.MyBilling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
  
    <!-- jTable style file -->
    
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

        $(document).ready(function() {
            
            $('#tblMyBillings').jtable({
                title: 'My Billing',
                pagesize: 10,
                paging: true,
                sorting: true,
                defaultSorting: 'Name ASC',
              //  selecting: true, //Enable selecting
               // multiselect: false, //Allow multiple selecting
                //selectingCheckboxes: true, //Show checkboxes on first column
                //selectOnRowClick: false, //Enable this to only select using checkboxes
                actions: {
                    listAction: 'MyDocuments.aspx/GetAllDocument',
                    //createAction: 'SimplePeopleList.aspx/CreatePerson',
                    //updateAction: 'SimplePeopleList.aspx/UpdatePerson',
                    deleteAction: 'MyDocuments.aspx/DeleteFile'
                },
                fields: {
                    FileId: {
                        key: true,
                        //create: false,
                        //edit: false,
                        list: false

                    },
                    visit: {
                        title: 'Visit ID',
                        width: '30%'

                    },
                    dos: {
                        title: 'Visit Date',
                        width: '30%'

                    },
                    fee: {
                        title: 'Amount',
                        width: '40%'
                    },
                    Paid: {
                        title: 'Paid via CC',
                        width: '40%'
                    },
                    id: {
                        title: 'Ref Number',
                        width: '40%'
                    },
                    VisitStatus: {
                        title: 'Visit Status',
                        width: '40%'
                    }
                }
            });

            $('#tblMyBillings').jtable('load');


        });
    </script>
    <div class="container" >
        <br/>
        <br/>
        <br/>
        <div id="tblMyBillings">
        </div>
    </div>
</asp:Content>
