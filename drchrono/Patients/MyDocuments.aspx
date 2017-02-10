<%@ Page Language="C#" enableSessionState="true" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="MyDocuments.aspx.cs" Inherits="drchrono.Patients.MyDocuments" %>

<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
   
   
    
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

    $(document).ready(function () {

        
        $('#tblMyDocumnents').jtable({
            title: 'My Documents',
            pagesize: 10,
            paging: true,
            sorting: true,
            defaultSorting: 'Name ASC',
            selecting: true, //Enable selecting
            multiselect: false, //Allow multiple selecting
            selectingCheckboxes: true, //Show checkboxes on first column
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
                Name: {
                    title: 'Name',
                    width: '30%'

                },
                Date: {
                    title: 'Date',
                    width: '30%'
                    
                },
                Document: {
                    title: 'Document',
                    width: '40%'
                },

                //Register to selectionChanged event to hanlde events
                selectionChanged: function () {
                    //Get all selected rows
                    var $selectedRows = $('#StudentTableContainer').jtable('selectedRows');
                    alert("function file");
                    $('#SelectedRowList').empty();
                    if ($selectedRows.length > 0) {
                        //Show selected rows
                        $selectedRows.each(function () {
                            alert("function fire each");
                            var record = $(this).data('record');
                            $('#SelectedRowList').append(
                                '<b>StudentId</b>: ' + record.StudentId +
                                '<br /><b>Name</b>:' + record.Name + '<br /><br />'
                                );
                        });
                    } else {
                        //No rows selected
                        $('#SelectedRowList').append('No row selected! Select rows to see here...');
                    }
                }

            }
        });

        $('#tblMyDocumnents').jtable('load');

        $('#btnDownload').button().click(function () {
            var $selectedRows = $('#tblMyDocumnents').jtable('selectedRows');

            if ($selectedRows.length > 0) {
                //Show selected rows
                $selectedRows.each(function () {
                    var record = $(this).data('record');
                  


                    var FileId = record.FileId;
                    
                    $.ajax({
                          type: "POST",
                          url: "MyDocuments.aspx/downloadAttachment",
                          data: '{FileId: "' + FileId + '" }',  
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (result) {
                             
                              window.location.href = "/DownloadFile.ashx";

                              //window.setTimeout(stub, 5000);
                              //$.ajax({
                              //    type: "POST",
                              //    url: "MyDocuments.aspx/delFile",
                              //    contentType: "application/json; charset=utf-8",
                              //    dataType: "json",
                              //    success: function (result) {

                              //    },
                              //    error: function (xmlhttprequest, textstatus, errorthrown) {
                              //        alert(" conection to the server failed ");
                              //        console.log("error: " + errorthrown);
                              //    }
                              //});


                          },
                          error: function (xmlhttprequest, textstatus, errorthrown) {
                              alert(" conection to the server failed ");
                              console.log("error: " + errorthrown);
                          }
                      });


                });
            } else {
                alert("Please select a file to download");
            }
        });

        function stub() {
           
        };
        
          
  $("#btnUpDocument").on("click", function () { //When compose button is clicked
                var txtName = '#' + '<%= txtName.ClientID %>';
                <%--var txtDescription = '#' + '<%= txtDescription.ClientID %>';--%>
                var fileupload = '#' + '<%= FileUploadControl.ClientID %>';
                $(txtName).val("");
                //$(txtDescription).val("");
                $(fileupload).val("");
                $("#myModal2").modal("show");

            });



        
  });  
            
    
   function callMethod() {
        $("#myModal2").modal("hide");
    }
       

</script>


 <div class="container" >
    <div>
        <div id="preparing-file-modal" title="Preparing report..." style="display: none;">
	We are preparing your report, please wait...
 
	<!--Throw what you'd like for a progress indicator below-->
	<div class="ui-progressbar-value ui-corner-left ui-corner-right" style="width: 100%; height:22px; margin-top: 20px;"></div>
</div>
 
<div id="error-modal" title="Error" style="display: none;">
	There was a problem generating your report, please try again.
</div>
            
    <button type="button" style="margin-top: 1%;" id="btnUpDocument" class="btn btn-success">Upload Document</button>
    </div>
     <br/>
    <br/>
    <br/>
 <div id="tblMyDocumnents">
 </div>
     <br/>
    <br/>
    <br/> 
<button type="button" style="margin-top: 1%;" id="btnDownload" class="btn btn-success">Download File</button>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
 <div class="modal fade" id="myModal2">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Upload Document</h4>
      </div>
    
      <div class="modal-body">
      
     <div class="form-group">
        <label for="txtName">Name</label>
        <asp:TextBox  runat="server" id="txtName" type="text"/>
         
        <%--<label for="comment">Description</label>
        <asp:textbox class="form-control" TextMode="multiline" runat="server" rows="3" id="txtDescription"></asp:textbox>--%>
     </div>
  <asp:FileUpload id="FileUploadControl" runat="server" />  
  <asp:Label id="StatusLabel" runat="server"></asp:Label>
 </div>
    
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <asp:Button runat="server" class="btn btn-default" id="UploadButton" text="Upload" OnClientClick="callMethod();" onclick="UploadButton_Click" />
      </div>
        
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID = "UploadButton" />
    </Triggers>
   </asp:UpdatePanel> 
<br/>
        <br/>
        <br/>
        <br/>
</div>
  

</asp:Content>