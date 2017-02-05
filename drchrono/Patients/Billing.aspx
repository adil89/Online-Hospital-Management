<%@ Page Title="" Language="C#" MasterPageFile="~/Patients/Layout.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="drchrono.Patients.Billing" %>

<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   
     <link href="../Scripts/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    
     <br/>
    <br/>
    <label style="margin-left: 1%"><b>Card Type: Visa,Master,Discovery,AMEX</b></label>
    <br/>
    
    <script type="text/javascript">


        $(document).ready(function() {
        
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


        });

        


    </script>
    
 <div style="margin-left: 1%" class="row">
<div class="col-md-2 ">  
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
  <div class="form-group">
    <button type="button" style="width: 100%;" id="btnSave"  class="btn btn-success">Save</button>    
  </div>
</div>
</div>
    <br/>
    <br/>
    <br/>
    <br/>
</asp:Content>
