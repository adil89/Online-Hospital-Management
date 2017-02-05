<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="drchrono.forgetpassword" %>

<html>
    <head>

        <title></title>
        <link href="../Content/themes/bootstrap.css" rel="stylesheet" />
    </head>
    <body>

    <form runat="server">

    
    <div>
        <h2>Password Recovery Page</h2>
        Please enter your DOB and email address that you used to create your account. We will send you an e-mail with instructions to reset the password.<br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="dateOfBirthLabel" Text="Date of birth:" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dateOfBirthTextbox" runat="server"  BorderStyle="Inset" TextMode="Date" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="emailAddressLabel" runat="server" Text="Email:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="emailAddressTextbox" runat="server" Width="200px" BorderStyle="Inset" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                In case you have forgotten the email address, please contact us at admin@goMDnow.com with your name, date of birth and contact number.<br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="recoverPasswordButton" runat="server" Text="Recover Password" OnClick="recoverPasswordButton_Click" OnClientClick="return validate()"> </asp:Button>
                </td>
            </tr>
        </table>
        </div>
    
    <script type="text/javascript">


        function validate()
        {
            var dob = document.getElementById("dateOfBirthTextbox").value;
            var pass = document.getElementById("emailAddressTextbox").value;

            if (dob=="" || pass=="")
            {

                alert("Please fill all the required fields");
                return false;
            }

            return true;

        }

    </script>
        </form>
    </body>
    </html>