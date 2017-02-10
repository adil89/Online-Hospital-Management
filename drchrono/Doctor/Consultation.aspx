<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Layout.Master" AutoEventWireup="true" CodeBehind="Consultation.aspx.cs" Inherits="drchrono.Doctor.Consultation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    <link href="../Content/tableStyle.css" rel="stylesheet" />
    
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
    


    <div class="container">
        <h1>Consultation</h1>

         <script type="text/javascript">

             $(document).ready(function () {

                 var navListItems = $('ul.setup-panel li a'),
                     allWells = $('.setup-content');

                 allWells.hide();

                 navListItems.click(function (e) {
                     e.preventDefault();
                     var $target = $($(this).attr('href')),
                         $item = $(this).closest('li');

                     if (!$item.hasClass('disabled')) {
                         navListItems.closest('li').removeClass('active');
                         $item.addClass('active');
                         allWells.hide();
                         $target.show();
                     }
                 });

                 $('ul.setup-panel li.active a').trigger('click');

                 // DEMO ONLY //
                 $('#activate-step-2').on('click', function (e) {
                     $('ul.setup-panel li:eq(1)').removeClass('disabled');
                     $('ul.setup-panel li a[href="#step-2"]').trigger('click');
                     $(this).remove();
                 })

                 $('#activate-step-3').on('click', function (e) {
                     $('ul.setup-panel li:eq(2)').removeClass('disabled');
                     $('ul.setup-panel li a[href="#step-3"]').trigger('click');
                     $(this).remove();
                 })

                 $('#activate-step-4').on('click', function (e) {
                     $('ul.setup-panel li:eq(3)').removeClass('disabled');
                     $('ul.setup-panel li a[href="#step-4"]').trigger('click');
                     $(this).remove();
                 })

                 $('#activate-step-3').on('click', function (e) {
                     $('ul.setup-panel li:eq(2)').removeClass('disabled');
                     $('ul.setup-panel li a[href="#step-3"]').trigger('click');
                     $(this).remove();
                 })
             });


             // Add , Dlelete row dynamically

             $(document).ready(function () {
                 var i = 1;
                 $("#add_row").click(function () {
                     $('#addr' + i).html("<td>" + (i + 1) + "</td><td><input name='name" + i + "' type='text' placeholder='Name' class='form-control input-md'  /> </td><td><input  name='sur" + i + "' type='text' placeholder='Surname'  class='form-control input-md'></td><td><input  name='email" + i + "' type='text' placeholder='Email'  class='form-control input-md'></td>");

                     $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
                     i++;
                 });
                 $("#delete_row").click(function () {
                     if (i > 1) {
                         $("#addr" + (i - 1)).html('');
                         i--;
                     }
                 });

             });


         </script>
        <div class="container">
	<div class="row form-group">
        <div class="col-xs-12">
            <ul class="nav nav-pills nav-justified thumbnail setup-panel">
                <li class="active"><a href="#step-1">
                    <h4 class="list-group-item-heading">Step 1</h4>
                    <p class="list-group-item-text">Patients Information</p>
                </a></li>
                <li class="disabled"><a href="#step-2">
                    <h4 class="list-group-item-heading">Step 2</h4>
                    <p class="list-group-item-text">Verification</p>
                </a></li>
                <li class="disabled"><a href="#step-3">
                    <h4 class="list-group-item-heading">Step 3</h4>
                    <p class="list-group-item-text">Consultation</p>
                </a></li>
                
                
                
            </ul>
        </div>
	</div>
    <div class="row setup-content" id="step-1">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1> STEP 1</h1>
                
<form>                
<div class="container">
    <div class="row clearfix">
			<div class="col-md-12 column">
	      <div class="row">
              <div class="col-lg-1">
                  <label>Name:</label>
              </div>
              <div class="col-lg-2">
                  <label>XYZ Patient</label>
              </div>
           </div>
            <div class="row">
              <div class="col-lg-1">
                  <label>Gender:</label>
              </div>
              <div class="col-lg-2">
                  <label>Male</label>
              </div>
           </div>
            <div class="row">
              <div class="col-lg-1">
                  <label>DOB:</label>
              </div>
              <div class="col-lg-2">
                  <label>17/10/1989(27)</label>
              </div>
           </div>
            <div class="row">
              <div class="col-lg-1">
                  <label>BMI:</label>
              </div>
              <div class="col-lg-2">
                  <label>xyz bmi</label>
              </div>
           </div>
            <div class="row">
              <div class="col-lg-1">
                  <label>BMI:</label>
              </div>
              <div class="col-lg-2">
                  <label>xyz bmi</label>
              </div>
           </div>
            <br/>
            <div class="row">
              <div class="col-lg-1">
                  <label>Primary Health Provider:</label>
              </div>
              <div class="col-lg-2">
                  <label>xyz health provider</label>
              </div>
           </div>
            <div class="row">
              <div class="col-lg-1">
                  <label>Pharmacy:</label>
              </div>
              <div class="col-lg-2">
                  <label>xyz pharmacy</label>
              </div>
           </div>  
            <div class="row">
              <div class="col-lg-1">
                  <input type="checkbox"/>
              </div>
              <div class="col-lg-3">
                  <label>Reviewed Patient Information</label>
              </div>
           </div>                       
          
	</div>
	</div>
	<!-- <a id="add_row" class="btn btn-success pull-left">Add Row</a><a id='delete_row' class="btn btn-danger pull-right">Delete Row</a> -->
</div>
</form>
                
                
                <button id="activate-step-2" class="btn btn-primary btn-md">Proceed</button>
            </div>
        </div>
    </div>
    <div class="row setup-content" id="step-2">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1 class="text-center"> STEP 2</h1>
 
    <div class="container">
 
        <div style="text-align: left" class="row">
            <b>Before you start the consultation, ask the following questions from the patient</b>
         </div>
        <br/>
        <br/>
        <div style="text-align: left" class="row">
            Do you certify that you have provided true and complete medical history to goMDnow?
        </div>
        <div style="text-align: left" class="row">
            Do you certify that you have provided true and complete medical history to goMDnow?
        </div>
          
    </div> 
    <!-- /container -->
    


                
                <button id="activate-step-3" class="btn btn-primary btn-md">Proceed</button>
            </div>
        </div>
    </div>
    <div class="row setup-content" id="step-3">
        <div class="col-xs-12">
            <div class="col-md-12 well text-center">
                <h1 class="text-center"> STEP 3</h1>
                
<form></form>
                
                
            </div>
        </div>
    </div>
    
    
    
</div>
	
</asp:Content>
