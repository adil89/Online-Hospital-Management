<%@ Page Language="C#" AutoEventWireup="true"   CodeBehind="RegisterPatient.aspx.cs" Inherits="drchrono.RegisterPatient" %>



  <html>
     <head>
    <title>Registration</title>
          <script src="http://code.jquery.com/jquery-2.1.4.js"></script>
         <script src="../Scripts/bootstrap.js"></script>
        
  <link href="../Content/themes/bootstrap.css" rel="stylesheet" />
         <script type="text/javascript">
             $(document).ready(function () {

                 document.getElementById("cellNumberTextbox").placeholder = "xxx-xxx-xxxx";
                 $("#registerButton").on("click", function () {

                     var firstname = $("#firstNameTextbox").val();
                     var lastname = $("#lastNameTextbox").val();
                     var email = $("#emailTexbox").val();
                     var pass = $("#repasswordTextbox").val();
                     var confirmpass = $("#passwordTextbox").val();
                     var dateofbirth = $("#dateOfBirthTextbox").val();
                     var gender = $('input[name=gender]:checked').val();
                     var cellno = $("#cellNumberTextbox").val();
                     var address = $("#addressTextbox").val();
                     var agreement = $('#checkAgreement').is(":checked")

            


                     if (firstname == "" || lastname == "" || email == "" || pass == "" || dateofbirth == ""  || cellno == "" || address == "") {

                         alert("Please fill all the required fields");
                         return false;
                     }

                     if (!$('#radioButtonMale').is(':checked') && !$('#radioButtonFemale').is(':checked'))
                     {
                         alert("Please select gender");
                         return false;
                     }

                     if (validateFirstName(firstname))
                     if (validateAddress(address))
                     if (validateLastName(lastname))

                     
                     if (!agreement) {
                         alert("Please accept to the terms of use and private policy")
                         return false;
                     }

                     if ($('#password_strength').text() == 'Password should have length of more than 8') {
                         alert("Password should have length of more than 8");
                         return false;
                     }

                       if (getAge(dateofbirth) < 18) {
                             alert("You must be 18 years or above to create an account")
                             return false;
                         }

                        if ($("#cell").text() == "Phone number is invalid") {
                           alert("Phone number is invalid");
                           return false;
                         }


                        if (pass != confirmpass) {
                             alert("Password and confirm password donot match");
                             return false;
                         }

                         if ($("#checkemaillabel").text() == "email address already exists") {

                             alert("This Email address is taken. Please choose another email address");
                             return false;
                         }

                         if ($("#checkzipcode").text() == "zipcode is invalid") {
                             alert("Zip code is invalid");
                             return false;

                         }


                         if ($("#checkemaillabel").text() == "Invalid Email") {

                             alert("Email Address is invalid");
                             return false;
                         }
               

                     else {

                         $.ajax({
                             type: "POST",
                             url: "RegisterPatient.aspx/Register",
                             data: JSON.stringify({ first: firstname, last: lastname, emailaddress: email, password: pass, dob: dateofbirth, sex: gender, cell: cellno, add: address }),
                             contentType: 'application/json; charset=utf-8',
                             dataType: 'json',
                             async: "true",

                             success: function (result) {

                                 $('#myModal').modal("show");





                             },
                             error: function (XMLHttpRequest, textStatus, errorThrown) {
                                 alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                             }
                         });
                     }
                 });


                 $("#repasswordTextbox").blur(function () {

                     if ($(this).val().length > 0) {
                         if ($(this).val() == $("#passwordTextbox").val()) {
                             $("#conpass").html("Password match");
                             $("#conpass").css('color', 'green')
                             //password match
                         }
                         else {
                             $("#conpass").html("Password donot match")
                             $("#conpass").css('color', 'red')

                             //password donot match
                         }
                     }
                     else
                     {
                         $("#conpass").html("");
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

                 $('#signin').click(function () {

                     $(location).attr('href', '../Default.aspx');
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

                     }
                 });


                 $("#cancelButton").on('click', function () {



                     $(location).attr('href', '../Default.aspx');


                 });




                 $("#emailTexbox").blur(function () {
                     var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

                     if (!emailReg.test($("#emailTexbox").val()) && $("#emailTexbox").val().length > 0) {

                         $("#checkemaillabel").html("Invalid Email");
                         $('#checkemaillabel').css("color", "red");
                     }
                     else {

                         if ($("#emailTexbox").val().length > 0) {
                             console.log($("#emailTexbox").val());
                             var email = $("#emailTexbox").val();
                             console.log(email);
                             $.ajax({
                                 type: "POST",
                                 url: "RegisterPatient.aspx/EmailAddExist",
                                 data: JSON.stringify({ emailaddress: email }),
                                 contentType: 'application/json; charset=utf-8',
                                 dataType: 'json',
                                 async: "true",
                                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                                     alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                                 },
                                 success: function (result) {


                                     if (result.d == 1) {
                                         $("#checkemaillabel").html("email address already exists");
                                         $('#checkemaillabel').css("color", "red");
                                     }

                                     else {
                                         $("#checkemaillabel").html("email address is available");
                                         $('#checkemaillabel').css("color", "green");

                                     }



                                 }
                             });
                         }

                         else {
                             $("#checkemaillabel").html("");

                         }

                     }
                 });







             });


    </script> 

    

  <script type="text/javascript">


      $(function () {
          $("#passwordTextbox").bind("keyup", function () {
              //TextBox left blank.
              if ($(this).val().length == 0) {
                  $("#password_strength").html("");
                  return;
              }

              if ($(this).val().length <= 8) {

                  $('#password_strength').html('Password should have length of more than 8');
                  $('#password_strength').css('color', 'red');
              }

              else {



                  //Regular Expressions.
                  var regex = new Array();
                  regex.push("[A-Z]"); //Uppercase Alphabet.
                  regex.push("[a-z]"); //Lowercase Alphabet.
                  regex.push("[0-9]"); //Digit.
                  regex.push("[$@$!%*#?&]"); //Special Character.

                  var passed = 0;

                  //Validate for each Regular Expression.
                  for (var i = 0; i < regex.length; i++) {
                      if (new RegExp(regex[i]).test($(this).val())) {
                          passed++;
                      }
                  }


                  //Validate for length of Password.
                  if (passed > 2 && $(this).val().length > 8) {
                      passed++;
                  }

                  //Display status.
                  var color = "";
                  var strength = "";
                  switch (passed) {
                      case 0:
                      case 1:
                          strength = "Weak";
                          color = "red";
                          break;
                      case 2:
                          strength = "Good";
                          color = "darkorange";
                          break;
                      case 3:
                      case 4:
                          strength = "Strong";
                          color = "green";
                          break;
                      case 5:
                          strength = "Very Strong";
                          color = "darkgreen";
                          break;
                  }
                  $("#password_strength").html(strength);
                  $("#password_strength").css("color", color);
              }
          });
      });
</script>


     
    

    <script type="text/javascript">

        function onLoadBody() {

            document.getElementById('cityTextBox').setAttribute("readonly", true);
            document.getElementById('stateTextBox').setAttribute("readonly", true);
        }

    </script>

       <script type="text/javascript">

           function validateFirstName(firstname)
           {
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

           function validateAddress(address)
           {
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
    
   


</head>
    
    
   
  
       <body onload="onLoadBody()">
           <form runat="server">

                 <div class="modal fade" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Sign up Completed</h4>
      </div>
      <div class="modal-body">
        <p><label  class="input-sm"/>Thank you for choosing goMDnow.We have sent you an email confirming your sign up</p>
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" id="signin" data-dismiss="modal">Sign in</button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
    <div>
        <h2>Registration Page</h2>
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
                <asp:Label ID="lastNameLabel" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <input  id="lastNameTextbox" type="text"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="emailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td colspan="3">
                <input id="emailTexbox" type="email"  />
            </td>
            <td>
                <label id="checkemaillabel"  />

            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="passwordLabel" runat="server" Text="Enter Password"></asp:Label>
            </td>
            <td>
                <input id="passwordTextbox" type="password" />
            </td>
            <td>
                <label id="password_strength"></label>

            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="repasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
            </td>
            <td>
                <input id="repasswordTextbox" type="password" />
            </td>
            <td>
                <label id="conpass"> </label>
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
                <label id="age"  />

            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="genderLabel" runat="server" Text="Gender"></asp:Label>
            </td>
            <td colspan="2">
             Male   <input id="radioButtonMale" name="gender" value="M"  type="radio" />
             Female   <input id="radioButtonFemale" name="gender" value="F"  type="radio"/>
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="cellNumberLabel" runat="server" Text="Cell Number"></asp:Label>
            </td>
            <td colspan="2"> 
                <input  id="cellNumberTextbox" />                
            </td>
            <td>
               <label id="cell"  />

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
                
                <input id="zipcode" type="text" />
                  
                          
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
        </tr> 
        <tr>
            <td colspan="4">
                <input id="checkAgreement" runat="server" type="checkbox" /> I agree to Terms of Use and Privacy Policy
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <input id="registerButton" value="register" type="button" />  
                <input id="cancelButton" value="cancel" type="button" />  
                
                
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
    </div> 
               </form>
       </body>
</html>