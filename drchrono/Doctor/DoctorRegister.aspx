<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorRegister.aspx.cs" Inherits="drchrono.Doctor.DoctorRegister" %>

<!DOCTYPE html>

 <html>
     <script src="http://code.jquery.com/jquery-2.1.4.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            var a = "1";
            $("#registerButton").on("click", function () {

                var firstname = $("#firstNameTextbox").val();
                var lastname = $("#lastNameTextbox").val();
                var email = $("#emailTexbox").val();
                var pass = $("#repasswordTextbox").val();
                var confirmpass = $("#passwordTextbox").val();
                var dateofbirth = $("#dateOfBirthTextbox").val();
                var gender = $('input[name=gender]:checked').val();
                var boardcertified = $('input[name=board]:checked').val();
                var practice = $("#practiceTextbox").val();
                var cellno = $("#cellNumberTextbox").val();
                var address = $("#addressTextbox").val();
                var title = $("#professionaltitleTextbox").val();
                var npi = $("#NPITextbox").val();
                var statelicense = $("#statelicenseTextbox").val();
                var otherlicense = $("#otherlicenseTextbox").val();
                var skype = $("#skypeTextBox").val();
                var referredby = $("#referredbyTextBox").val();
                var primary = $("#primaryspecialityTextbox").val();

              /*  if (firstname == "" || lastname == "" || email == "" || pass == "" || dateofbirth == "" || gender == "" || cellno == "" || address == "") {

                    alert("Please fill all the required fields");
                }

                else if (pass != confirmpass) {
                    alert("Password and confirm password donot match");

                }

                else if ($("#checkemaillabel").text() == "email address already exists") {

                    alert("This Email address is taken. Please choose another email address");
                }

                else if ($("#checkzipcode").text() == "zipcode is invalid") {
                    alert("Zip code is invalid");

                }


                else if ($("#checkemaillabel").text() == "Invalid Email") {

                    alert("Email Address is invalid");
                }*/
                if(a=="0")
                {

                }

                else {
                 
                    alert(JSON.stringify({
                        primaryspeciality: primary,
                        DocTitle: title,
                        board: boardcertified,
                        practiceyears: practice,
                        NpiNo: npi,
                        statelicenseno: statelicense,
                        otherlicenseno: otherlicense,
                        skypeid: skype,
                        referrer: referredby,
                        first: firstname,
                        last: lastname,
                        emailaddress: email,
                        password: pass,
                        dob: dateofbirth,
                        sex: gender,
                        cell: cellno, add: address
                    }));
                    alert(JSON.stringify({
                      
                        skypeid: skype,
                        referrer: referredby

                    }));
                    $.ajax({
                        type: "POST",
                        url: "DoctorRegister.aspx/Register",

                        data: JSON.stringify({
                            primaryspeciality: primary,
                            DocTitle: title,
                            board: boardcertified,
                            practiceyears: practice,
                            NpiNo: npi,
                            statelicenseno: statelicense,
                            otherlicenseno: otherlicense,
                            skypeid: skype,
                            referrer: referredby,
                            first: firstname,
                            last: lastname,
                            emailaddress: email,
                            password: pass,
                            dob: dateofbirth,
                            sex: gender,
                            cell: cellno,
                            add: address
                        }),
                       
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        async: "true",
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);

                        },
                        success: function (result) {





                        }
                    });
                }
            });




            $("#zipcode").blur(function () {


                var zipcode = $("#zipcode").val();
               
                if (zipcode.length > 0) {
                   
                    $.ajax({
                        type: "POST",
                        url: "../Patients/RegisterPatient.aspx/LoadZipCode",
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
                                    url: "../Patients//RegisterPatient.aspx/SetCityState",
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
                            url: "DoctorRegister.aspx/EmailAddExist",
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


          function CheckPasswordStrength(password) {
              var password_strength = document.getElementById("password_strength");

              //TextBox left blank.
              if (password.length == 0) {
                  password_strength.innerHTML = "";
                  return;
              }

              //Regular Expressions.
              var regex = new Array();
              regex.push("[A-Z]"); //Uppercase Alphabet.
              regex.push("[a-z]"); //Lowercase Alphabet.
              regex.push("[0-9]"); //Digit.
              regex.push("[$@$!%*#?&]"); //Special Character.

              var passed = 0;

              //Validate for each Regular Expression.
              for (var i = 0; i < regex.length; i++) {
                  if (new RegExp(regex[i]).test(password)) {
                      passed++;
                  }
              }

              //Validate for length of Password.
              if (passed > 2 && password.length > 8) {
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
              password_strength.innerHTML = strength;
              password_strength.style.color = color;
          }
</script>

  <script type="text/javascript">


      $(function () {
          $("#passwordTextbox").bind("keyup", function () {
              //TextBox left blank.
              if ($(this).val().length == 0) {
                  $("#password_strength").html("");
                  return;
              }

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


           
      </script>
    
   
   
  
       <body onload="onLoadBody()">
           <form runat="server">
    <div>
        <h2>Registration Page</h2>
    <table>
         <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Professional Title"></asp:Label>
            </td>
            <td>
                <input id="professionaltitleTextbox"  type="text" />
            </td>
        </tr>    
         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Primary Speciality"></asp:Label>
            </td>
            <td>
                <input id="primaryspecialityTextbox"  type="text" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Board Certified"></asp:Label>
            </td>
          <td colspan="2">
             Yes   <input id="radioButtonYes" name="board" value="Y"  type="radio" />
             No   <input id="radioButtonNo" name="board" value="N"  type="radio"/>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Years In Practice"></asp:Label>
            </td>
           <td>
                <input id="practiceTextbox"  type="text" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="State License"></asp:Label>
            </td>
           <td>
                <input id="statelicenseTextbox"  type="text" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Other Licenses"></asp:Label>
            </td>
           <td>
                <input id="otherlicenseTextbox"  type="text" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="NPI No:"></asp:Label>
            </td>
           <td>
                <input id="NPITextbox"  type="text" />
            </td>
        </tr>
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
        </tr>
        <tr>
            <td>
                <asp:Label ID="dateOfBirthLabel" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td colspan="1">
                <input id="dateOfBirthTextbox" type="date" />

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
            <td>
                <asp:Label ID="Label8" runat="server" Text="Skype"></asp:Label>
            </td>
            <td colspan="3"> 
                <input id="skypeTextBox" type="text"/>                 
            </td>
        </tr> 
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Referred by"></asp:Label>
            </td>
            <td colspan="3"> 
                <input id="referredbyTextBox" type="text"/>                 
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
