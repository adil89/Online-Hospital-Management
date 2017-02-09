<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="RequestConsultant.aspx.cs" Inherits="drchrono.MakeAppointment" %>

<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/MultiStep.js"></script>
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/MultiStep.css" rel="stylesheet" />
    <!-- jTable style file -->
    
    <link href="../Scripts/jtable/themes/metro/blue/jtable.css" rel="stylesheet" />
    <script src="../Scripts/modernizr-2.6.2.js" type="text/javascript"></script>
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
    
    
   
  
   
    
    
    <div class="container">
	<div class="row form-group">
        <div class="col-xs-12">
            <ul class="nav nav-pills nav-justified thumbnail setup-panel">
                <li class="active"><a href="#step-1">
                    <h4 class="list-group-item-heading">Appointment</h4>
                    <p class="list-group-item-text"></p>
                </a></li>
                <li class="disabled"><a href="#step-2">
                    <h4 class="list-group-item-heading">Medical History</h4>
                    <p class="list-group-item-text"></p>
                </a></li>
                <li class="disabled"><a href="#step-3">
                    <h4 class="list-group-item-heading">Billing</h4>
                    <p class="list-group-item-text"></p>
                </a></li>
                
                <li class="disabled"><a href="#step-4">
                    <h4 class="list-group-item-heading">Confirmation</h4>
                    <p class="list-group-item-text"></p>
                </a></li>
                 <li class="disabled"><a href="#step-4">
                    <h4 class="list-group-item-heading">Video</h4>
                    <p class="list-group-item-text"></p>
                </a></li>
               
                
            </ul>
        </div>
	</div>
    <div class="row setup-content" id="step-1">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1> Appointment</h1>
                
                
<div class="container">
    <div class="row clearfix">
		<div class="col-md-12 column">
		    		    
			<table class="table">
				<tr>
                <td>
                    <label id="patientLabel"  >Patient</label>
                </td>
                <td>
                
                     <input id="patient" type="radio"/> Me

                </td>
            </tr>
            <tr>
                <td>
                    <label id="consultationLabel">Consultation Mode</label>
                </td>
                <td >
                    <input id="telephone" name="ConsultationMode" value="Telephone" type="radio" />  Telephonic Call
                </td>
                <td>
                 <input id="video" name="ConsultationMode" value="video" type="radio" />   Video call
                </td>
            </tr>
            <tr>
                <td>
                    <label id="appointmentTypeLabel" >Appointment Type</label>
                </td>
                <td>
              <input id="seeDoctorNow" type="radio" value="SeeDoctorNow" name="AppointmentType" />    See a Doctor Now 
                 
                </td>
                <td>
                   <input id="TakeAppointment" type="radio" value="TakeAppointment"  name="AppointmentType" /> Take Appointment
                 
                </td>
            </tr>
            <tr>
                <td>
                    <label id="whenLabel" >When</label>
                </td>
                <td>
                <input id="apptDate" type="date" />
                </td>
            </tr>
            <tr>
                
                <td>
                 <div id="all-slots">
                    

                 </div>
                </td>
            </tr>
            <tr>
                <td>
                    <label id="reasonLabel" >Reason for visit</label>
                </td>
                <td>
                    <textarea id="reasonTextBox" rows="4" cols="50"  ></textarea>
                </td>
            </tr>
            <tr>
               
            </tr>			</table>
		</div>
	</div>
	
</div>

                
                <button id="addDocument" type="button" class="btn btn-warning btn-md">Add Documents</button>
                <button id="activate-step-2" class="btn btn-primary btn-md">Continue</button>
                
            </div>
        </div>
    </div>
    <div class="row setup-content" id="step-2">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1 class="text-center"> Medical History</h1>
 
    <div class="container">
 
        <table class="table" >
        <tr>
            <td>
                <label id="Height" >Height</label>
            </td>
            <td>
                <input id="HeightTextbox"  type="text" />
            </td>
          
        <td>
                <label id="Weight" >Weight</label>
        </td>

            <td>
                <input  id="WeightTextbox" type="text" />
            </td>
              
                  <td>
                <label  id="BMI" >BMI</label>
            </td>
            <td >
                <input id="BMITextBox" type="text" />
            </td>



                  <td>
                <label id="BloodGroupLabel" >BloodGroup</label>
            </td>
            <td>
                <input id="BloodGroupTextBox" type="text" />
            </td>

            </tr>
                          </table>
         <div id="PersonTableContainer">
    </div>
    <div id="MedicationTableContainer"></div>
    <div></div>
    </div> 
    <!-- /container -->
    


                
                <button id="activate-step-3" class="btn btn-primary btn-md">Continue</button>
            </div>
        </div>
    </div>
    <div class="row setup-content" id="step-3">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1 class="text-center"> Billing</h1>
                
                  <br/>
                 <br/>
                <label style="margin-left: 1%"><b>Card Type: Visa,Master,Discovery,AMEX</b></label>
                 <br/>
    <div class="form-group">
    <label for="txtCard">Card Number</label>
       <input class="form-control input-sm" id="txtCard" type="text"/>
  </div>
  <div class="form-group">
    <label for="txtCVC">CVC Number</label>
      <input class="form-control input-sm" id="txtCVC" type="text"/>
  </div>
  <div class="form-group">
    <label >Expiry Date</label>
      <div class="row">
          <div class="col-lg-5">
              <label for="txtMonth">Month</label>
              <input class="form-control input-sm" placeholder="MM" id="txtMonth" type="text"/>        
          </div>
          <div class="col-lg-1" style="margin-top: 9%;">
              <label style="font-size: 200%;"><b>/</b></label>        
          </div>
          <div class="col-lg-5">
              <label for="txtYear">Year</label>
              <input class="form-control input-sm" id="txtYear" placeholder="YYYY" type="text"/>        
          </div>
      </div>
      
  </div>
  <div class="form-group">
    <label for="inputBill">Billing Name</label>
      <input class="form-control input-sm" id="inputBill" type="text"/>
  </div>
  <div class="form-group">
    <label for="inputCity">City</label>
    <input class="form-control input-sm" id="inputCity" type="text"/>
  </div>
  <div class="form-group">
    <label for="inputState">State</label>
    <input class="form-control input-sm" id="inputState" type="text"/>
  </div>
  <div class="form-group">
    <label for="inputZip">Zip</label>
    <input class="form-control input-sm" id="inputZip" type="text"/>
  </div>
                
                <button id="activate-step-4" class="btn btn-primary btn-md">Continue</button>
            </div>
        </div>
    </div>
    
    <div class="row setup-content" id="step-4">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1 class="text-center"> Confirmation</h1>
                <table class="table">
                    <tr>
                        <td>
                <p>Would you like to confirm your appointment?</p>
                       </td>
                             </tr>
                    <tr>
                        <td>
                Date: <input id="date" type="text" />
                </td>
                        <td>
                           Time: <input id="time" type="text" />

                        </td>
                       
                           
                        
                             </tr>

                    <tr>
                        <td>
                        <p>What's the best way to send you a reminder prior to your consultation? </p>
                            </td>
                    </tr>

                    <tr>

                        <td>
                            <input id="email" type="radio" name="reminder" value="email" />Email
                        </td>
                        <td>
                            <input id="textmessage" type="radio" name="reminder" value="textmessage" />Text Message
                        </td>
                        <td>
                            <input id="both" type="radio" name="reminder" value="both" /> Both
                        </td>
                    </tr>


                    <tr>

                        
                        <td>
                            <button id="cancel" class="btn btn-primary btn-md">cancel</button>
                        </td>
                        <td>
                            <button id="yes" class="btn btn-primary btn-md">Yes</button>
                        </td>

                    </tr>
                        </table>
                
                
                
            </div>
        </div>
    </div>
    
</div>

   
 <div class="modal fade" id="myModal2">
  <div style="width:70%;" class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Select Documents</h4>
      </div>
    
      <div class="modal-body">
      
          <div id="tblMyDocumnents">
          </div>
 </div>
    
      <div class="modal-footer">
        <button type="button" class="btn btn-success" data-dismiss="modal">Add Documents</button>
        
      </div>
        
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
   
    <script type="text/javascript">

       

       $(document).ready(function () {
           

           $('#tblMyDocumnents').jtable({
               title: 'My Documents',
               pagesize: 10,
               paging: true,
               sorting: true,
               defaultSorting: 'Name ASC',
               selecting: true, //Enable selecting
               multiselect: true, //Allow multiple selecting
               selectingCheckboxes: false, //Show checkboxes on first column
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



           $.ajax({
               type: "POST",
               url: "Billing.aspx/GetPatientDemographics",
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: function (result) {

                   $("#inputBill").val(result.d.patientInfo.Name);
                   $("#inputCity").val(result.d.patientInfo.City);
                   $("#inputState").val(result.d.patientInfo.State);
                   $("#inputZip").val(result.d.patientInfo.Zip);

                   $("#inputBill").attr("disabled", "disabled");
                   $("#inputCity").attr("disabled", "disabled");
                   $("#inputState").attr("disabled", "disabled");
                   $("#inputZip").attr("disabled", "disabled");
               },
               error: function (xmlhttprequest, textstatus, errorthrown) {
                   alert(" conection to the server failed ");
                   console.log("error: " + errorthrown);
               }
           });


           $("#addDocument").click(function () {
               $("#myModal2").modal("show");
           });

           $("#btnSave").click(function () {

               var cardNum = $("#txtCard").val();
               var month = $("#txtMonth").val();
               var year = $("#txtYear").val();
               var zip = $("#inputZip").val();

               var jsonObj = { "cardNum": cardNum, "month": month, "year": year,"zip": zip };

               $.ajax({
                   type: "POST",
                   url: "Billing.aspx/VerifyCreditCard",
                   data: JSON.stringify(jsonObj), 
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (result) {

                       if (result.d.verify === 1) {
                           alert("credit card has been verified");
                       } else {
                           alert("credit card number Invalid");
                       }
                        
                   },
                   error: function (xmlhttprequest, textstatus, errorthrown) {
                       alert(" conection to the server failed ");
                       console.log("error: " + errorthrown);
                   }
               });


                
           });


     

        


            $('input:radio[name="AppointmentType"]').change(function () {
                if ($(this).val() == 'SeeDoctorNow') {
                    
                    $('#apptDate').css('visibility', 'hidden');
                }
                else
                {

      
                    $('#apptDate').css('visibility', 'visible');
                }
            });

            $(document).on('click', '#status', function () {
              
               
                $.ajax({
                    type: "POST",
                    url: "RequestConsultant.aspx/GetSelectedRoomTime",
                    data: JSON.stringify({ value: $('input[name=radiobuttonstatus]:checked').val() }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    async: "true",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                    },
                    success: function (result) { //Get list of  Booked Times with each room

                    }

                });
            });
            


         


       



           
            $("#apptDate").blur(function () {    //send this date onto server
                
                var apptDate = $("#apptDate").val();

                if (apptDate.length > 0) {

                    var today = new Date();
                    var myDate = new Date(apptDate);

                    if (myDate<today) {
                        alert(myDate);
                        alert(today);
                        alert("you cannot make an appointment on the previous date");
                    }
                    else {

                        $.ajax({
                            type: "POST",
                            url: "RequestConsultant.aspx/GetAvailableTimeSlots",
                            data: JSON.stringify({ date: apptDate }),
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            async: "true",
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                            },
                            success: function (result) { //Get list of  Booked Times with each room

                                $("#all-slots").empty();
                                for (var record in result.d) {


                                    $("#all-slots").append('<div><p>' + "Available Room:" + result.d[record]["ApptColumn"] + '<br>' + 'Available Time:' + result.d[record]["ApptTime"] + '<p><input id=status name=radiobuttonstatus value=' + result.d[record]["ApptColumn"] + ',' + result.d[record]["ApptTime"] + ' type=radio /></div>');

                                }
                            }

                        });
                    }
                       
                }
            });


       });

    </script>
    
    
    

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
                         type: 'date'
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
  
    <script>
        $("#activate-step-3").click(function(){
            //Populate here date and time

            $.ajax({
                type: "POST",
                url: "RequestConsultant.aspx/GetDateTime",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                async: "true",
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                },
                success: function (result) {
                   
                    $("#date").val(result.d[0]);
                    $("#time").val(result.d[1]);
                }


            });
        });

         
            $("#cancel").click(function () {

                window.location = "PatientPortal.aspx";
            });

            $("#yes").click(function () {
               
                // CALL APPOINTMENT REMINDER API

                
                $.ajax({
                    type: "POST",
                    url: "RequestConsultant.aspx/SaveReminder",
                    data: JSON.stringify({ reminderType: $('input[name=reminder]:checked').val() }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    async: "true",
                    success: function (result) {
                       
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {

                         alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                    }

                });


                //Make appointment and entry in database against all doctors when this button is clicked
                //get Type of Appointment
                $.ajax({
                    type: "POST",
                    url: "RequestConsultant.aspx/GetTypeAppt",
                    data: {},
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    async: "true",
                    
                    success: function (result) { 
                        //Now check which type of appointment is this 

                        var type = result.d;
                     
                        if (type == "TakeAppointment") {

                            $.ajax({
                                type: "POST",
                                url: "RequestConsultant.aspx/SaveAppointmentLocalDB", //Error is coming here
                                data: {},
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                async: "true",
                                success: function (result) { //Get list of  Booked Times with each room
                                    alert("You Appointment has been submitted. Please wait for doctor's approval");
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert('error');
                            }
                             

                            });
                        }
                        else
                        {

                            $.ajax({
                                type: "POST",
                                url: "RequestConsultant.aspx/SaveSeeDoctorNow",
                                data: {},
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                async: "true",
                                success: function (result) { //Get list of  Booked Times with each room
                                    alert('You Consultation is about to start');
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                                }


                            });
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                   
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                       
                },

                });
          

            });

            $("#activate-step-2").click(function()
            {

                //Send each data to server and save it in session
                var consultationmode = $('input[name=ConsultationMode]:checked').val();
                var appttype = $('input[name=AppointmentType]:checked').val();
                var apptDate = $('#apptDate').val();
                var reason = $('#reasonTextBox').val();

           
                $.ajax({
                    type: "POST",
                    url: "RequestConsultant.aspx/SaveValues",
                    data: JSON.stringify({ consultation: consultationmode, appt: appttype, date: apptDate, comments: reason }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    async: "true",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                    },
                    success: function (result) { //Get list of  Booked Times with each room
                       
                    }

                });
           

            });
       
        
     
    </script>


    </asp:Content>