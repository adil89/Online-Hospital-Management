<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="Messaging.aspx.cs" Inherits="drchrono.Patients.Messaging" %>

  <asp:Content  ContentPlaceHolderID="ContentPlaceHolder1"   runat="server" >


     <link href="//cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
        <script src="//cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js" type="text/javascript"></script> 
      <script src="../Scripts/jquery.avgrund.js"></script>
      <script src="../Scripts/jquery.avgrund.min.js"></script>
      <link href="../Content/avgrund.css" rel="stylesheet" />
      <link href="../Content/themes/bootstrap.css" rel="stylesheet" />
      <link href="../Content/themes/bootstrap.min.css" rel="stylesheet" />
      <link href="../Content/themes/bootstrap-theme.min.css" rel="stylesheet" />
      <script src="../Scripts/bootstrap.js"></script>
      <script src="../Scripts/bootstrap.min.js"></script>
      
      <link href='http://fonts.googleapis.com/css?family=Headland+One|Open+Sans:400,300&subset=latin,cyrillic' rel='stylesheet' type='text/css'/>
      
      <div class="container" >
       <table id="table_id" class="display">
     
    <thead>

         <tr>
                <th>From</th>
                <th>Time</th>
                <th>Subject</th>
            
  
  


            </tr>
    </thead>
        
      
      </table>

     <input type="button" value="Compose" id="compose"/>
        <input type="button" value="Inbox" id="inbox"/> 
        <input type="button" value="Sent" id="sent"/>

               <div class="modal fade" id="myModal2">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Compose Message</h4>
      </div>
      <div class="modal-body">
                      To:                                          
                      <input type="radio" id="provider"   />Provider
                     <input type="radio" id="support" /> Support
     
          <br />
          <br />
          <br />
          Subject:
          <input type="text" />
          <br />
          <br />
          <textarea rows="10" cols="50">
            </textarea>
                
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
         <button type="button" class="btn btn-primary">Save changes</button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->


          
        <div class="modal fade" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Message</h4>
      </div>
      <div class="modal-body">
        <p><label  class="input-sm" id="txtfname"/></p>
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

      </div>
      <script type="text/javascript">
          $(document).ready(function () {
             


                $.ajax({
                      
                    type: "POST",
                    url: "Messaging.aspx/GetRecievedMessages",
                    data: {},
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    async: "true",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
  
                    },
                    success: function (result) { //Initialize data table here
                    
                        
                         $('#table_id').dataTable({
                             data:result.aData,
                            "columns": [
                               { "data": "from" },
                                { "data": "Time" },
                                { "data": "Subject" }
                            ],

                            fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                                // Row click


                                $(nRow).on('click', function () {
                                    $("#myModal").modal("show");
                                    $("#txtfname").text(aData['body']);

                                });


                            }
                        });
                    }


                });





              $('#sent').click(function () { //When sent Button is clicked

                  $.ajax({

                      type: "GET",
                      url: "Messaging.aspx/GetSentMessages",
                      data: {},
                      contentType: 'application/json; charset=utf-8',
                      dataType: 'json',
                      async: "true",
                      error: function (XMLHttpRequest, textStatus, errorThrown) {
                          alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                      },
                      success: function (result) { //Initialize data table here

                         
                      }
                  });


              });





           
          });
          
      </script>
     
       <script type="text/javascript">

          $("#compose").on("click", function () { //When compose button is clicked

              console.log("compose");
              $("#myModal2").modal("show");

          });

      </script>


      

      </asp:Content>