<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Patients/Layout.Master" CodeBehind="editprofile.aspx.cs" Inherits="drchrono.editprofile" %>

<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

     <script type="text/javascript">
       
         $(document).ready(function () {

             //LoadProfile here
             $.ajax({
                 type: "POST",
                 url: "editprofile.aspx/LoadProfile",
                 data: {},
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'json',
                 async: "true",

                 success: function (result) { //here set the values of text box
                     result.d;
                     $("#firstNameTextbox").val(result.d[0]);
                     $("#middleNameTextBox").val(result.d[1]);
                     $("#lastNameTextbox").val(result.d[2]);
                     $("#addressTextbox").val(result.d[3]);
                    
                     $("input[name=gender][value=" + result.d[4] + "]").attr('checked', 'checked');
                    
                     $("#dateOfBirthTextbox").val(result.d[5]);
                     $("#cellNumberTextbox").val(result.d[6]);
                     $("#homeNumberTextbox").val(result.d[7]);
                     $("#zipcode").val(result.d[8]);
                     $("#cityTextBox").val(result.d[9]);
                     $("#stateTextBox").val(result.d[10]);



                 },
                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                     alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                 }
             });
      



             $("#saveprofile").on("click", function () {

                 var firstname = $("#firstNameTextbox").val();
                 var lastname = $("#lastNameTextbox").val();
                 var middlename = $("#middleNameTextBox").val();
                 var dateofbirth = $("#dateOfBirthTextbox").val();
                 var gender = $('input[name=gender]:checked').val();
                 var cellno = $("#cellNumberTextbox").val();
                 var address = $("#addressTextbox").val();
                 var zipcode = $("#zipcode").val();
                 var city = $("#cityTextBox").val();
                 var state = $("#stateTextBox").val();
                 var homephone = $("#homeNumberTextbox").val();

                 
                
               

                  if ($("#checkzipcode").text() == "zipcode is invalid") {
                      alert("Zip code is invalid");
                      return false;

                 }
                  

                      //if (validateFirstName(firstname))

                      //if (validateAddress(address))

                     // if (validateLastName(lastname))

                     /* if (getAge(dateofbirth) < 18)
                      {
                          alert("Age must be 18 years or above")
                          return false;
                      }*/

             /*    if ($("#cell").text() == "Phone number is invalid") {
                     alert("Phone number is invalid");
                     return false;
                 }*/

                 
               

                 else {
                    // alert(JSON.stringify({ first: firstname,middle:middlename, last: lastname, dob: dateofbirth, sex: gender, cell: cellno, home:homephone, add: address,zip:zipcode,citykey:city,statekey:state }));
                     $.ajax({
                         type: "POST",
                         url: "editprofile.aspx/UpdatePatient",
                         data: JSON.stringify({ first: firstname, middle: middlename, last: lastname, dob: dateofbirth, sex: gender, cell: cellno, home: homephone, add: address, zip: zipcode, citykey: city, statekey: state }),
                         contentType: 'application/json; charset=utf-8',
                         dataType: 'json',
                         async: "true",

                         success: function (result) {

                             window.location = "PatientProfile.aspx";



                         },
                         error: function (XMLHttpRequest, textStatus, errorThrown) {
                             alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                         }
                     });
                 }
             });

             $("#dateOfBirthTextbox").blur(function () {

                 if ($("#dateOfBirthTextbox").val().length > 0) {

                     $("#age").html("Age:" + getAge($(this).val()));
                     $('#age').css("color", "red");
                 }
                 else {
                     $("#age").html("");
                 }
             });

             $("#cellNumberTextbox").blur(function () {

                 if ($(this).val().length > 0) {
                     var regex = new Array();
                     regex.push(/^(\()?\d{3}(\))?(-|\s)?\d{3}(-|\s)\d{4}$/);
                     for (var i = 0; i < regex.length; i++) {
                         if (new RegExp(regex[i]).test($(this).val())) {
                             $("#cell").html("Phone number is valid");
                             $("#cell").css('color', 'green')
                         }
                         else {
                             $("#cell").html("Phone number is invalid");
                             $("#cell").css('color', 'red')
                         }
                     }
                 }
                 else {
                     $("#cell").html("");
                 }

             });

             $("#zipcode").blur(function () {


                 var zipcode = $("#zipcode").val();
                 if (zipcode.length > 0) {

                     $.ajax({
                         type: "POST",
                         url: "RegisterPatient.aspx/LoadZipCode",
                         data: JSON.stringify({ zipcodevalue: zipcode }),
                         contentType: 'application/json; charset=utf-8',
                         dataType: 'json',
                         async: "true",
                         error: function (XMLHttpRequest, textStatus, errorThrown) {
                             alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                         },
                         success: function (result) {


                             if (result.d == 1) { //zipcode is valid
                                 $("#checkzipcode").html("zipcode is valid");
                                 $('#checkzipcode').css("color", "green");

                                 $.ajax({
                                     type: "POST",
                                     url: "RegisterPatient.aspx/SetCityState",
                                     data: JSON.stringify({ zipcodevalue: $("#zipcode").val() }),
                                     contentType: 'application/json; charset=utf-8',
                                     dataType: 'json',
                                     async: "true",
                                     error: function (XMLHttpRequest, textStatus, errorThrown) {
                                         alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                                     },
                                     success: function (result) {



                                         $.each(result, function (key, value) {

                                             for (var i = 0 ; i < value.length; i++) {


                                                 if (i == 0) {
                                                     $('#cityTextBox').val(value[i]);
                                                 }
                                                 else {
                                                     $('#stateTextBox').val(value[i]);
                                                 }
                                             }
                                         });
                                     }
                                 });
                             }

                             else {
                                 $("#checkzipcode").html("zipcode is invalid");
                                 $('#checkzipcode').css("color", "red");
                                 $('#cityTextBox').val(" ");
                                 $('#stateTextBox').val(" ");

                             }



                         }
                     });
                 }
                 else {
                     $("#checkzipcode").html("");
                     $('#cityTextBox').val(" ");
                     $('#stateTextBox').val(" ");

                 }
             });
         });
    </script> 
        <script>

            function validateFirstName(firstname) {
                var letters = /^[A-Za-z]+$/;

                if (new RegExp(letters).test(firstname)) {
                    return true;
                }
                else {
                    alert('firstname must have alphabet characters only');
                    firstname.focus();
                    return false;
                }
            }

            function validateLastName(lastname) {

                var letters = /^[A-Za-z]+$/;
                if (new RegExp(letters).test(lastname)) {
                    return true;
                }
                else {
                    alert('lastname must have alphabet characters only');
                    lastname.focus();
                    return false;
                }
            }

            function validateAddress(address) {
                var letters = /^[0-9a-zA-Z]+$/;
                if (new RegExp(letters).test(address)) {
                    return true;
                }
                else {
                    alert('Address must have alphanumeric characters only');
                    address.focus();
                    return false;
                }


            }

        function getAge(dateString) {
         var today = new Date();
         var birthDate = new Date(dateString);
         var age = today.getFullYear() - birthDate.getFullYear();
         var m = today.getMonth() - birthDate.getMonth();
         if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
             age--;
         }
         return age;
     }
        </script>

    




    <table>
        <tr>
            <td>
                <asp:Label ID="firstNameLabel" runat="server" Text="Firstname"></asp:Label>
            </td>
            <td>
                <input id="firstNameTextbox"  type="text" />
            </td>
        </tr>
             <tr>
            <td>
                <asp:Label ID="middleNameLabel" runat="server" Text="Middlename"></asp:Label>
            </td>
            <td>
                <input id="middleNameTextBox" type="text" />
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Label ID="lastNameLabel" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <input  id="lastNameTextbox" type="text"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="dateOfBirthLabel" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td colspan="1">
                <input id="dateOfBirthTextbox" type="date" />

            </td>
            <td>

                <label id="age"></label>
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="genderLabel" runat="server" Text="Gender"></asp:Label>
            </td>
            <td colspan="2">
             Male   <input id="radioButtonMale" name="gender" value="Male"  type="radio" />
             Female   <input id="radioButtonFemale" name="gender" value="Female"  type="radio"/>
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="cellNumberLabel" runat="server" Text="Cell Number"></asp:Label>
            </td>
            <td colspan="2"> 
                <input  id="cellNumberTextbox" type="text" />                
            </td>
            <td>

                <label id="cell"></label>
            </td>
        </tr> 
             <tr>
            <td>
                <asp:Label ID="homePhoneLabel" runat="server" Text="Home(Phone)"></asp:Label>
            </td>
            <td colspan="2"> 
                <input id="homeNumberTextbox" type="text" />                
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="addressLabel" runat="server" Text="Address"></asp:Label>
            </td>
            <td colspan="3"> 
                <input id="addressTextbox" />                
            </td>
        </tr> 

          <tr>
            <td>
                <asp:Label ID="zipLabel" runat="server" Text="Zip"></asp:Label>
            </td>
            <td colspan="3"> 
                
                <input id="zipcode" />
                  
                          
            </td>
              <td>
                <label id="checkzipcode"  />

            </td>
        </tr> 

         <tr>
            <td>
                
                <asp:Label ID="ctyLabel" runat="server" Text="City"></asp:Label>
            </td>
            <td colspan="3"> 
                <input id="cityTextBox" type="text"   />                
            </td>
        </tr> 


        <tr>
            <td>
                <asp:Label ID="stateLabel" runat="server" Text="State"></asp:Label>
            </td>
            <td colspan="3"> 
                <input id="stateTextBox" type="text"/>                 
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="countryLabel" runat="server" Text="Country"></asp:Label>
            </td>
            <td>
                US 
            </td>
        </tr> <tr>

          
            <td>
                <button id="saveprofile">Save</button>
            </td>
           
        </tr> 
        
            </table>
      
</asp:Content>