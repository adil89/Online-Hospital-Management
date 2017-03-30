<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="drchrono.content" %>

<!DOCTYPE html>
<html>
<head>
	<script src="lib/jquery-1.11.3.min.js"></script>
</head>
<body onload="localStorage.clear()">


<form id="reverser">
	  <input type="input" id="toBeReversed" >
	  <input id="submitReverser" onclick="rev()" type="submit" value="Submit">
</form>
	  <input id="clearInput"  onclick="Clr()" type="submit" value="Clear Input">


<script type="text/javascript">
    document.getElementById("toBeReversed").value = localStorage.getItem("comment");
    function rev() {
        s = document.getElementById("toBeReversed").value;
        var str = s.split("").reverse().join("");
        msg = { payload: str.join('') };
        window.parent.postMessage(msg, "*");
    }

    function Clr() {
        if (document.getElementById("toBeReversed").value == "") return null;
        document.getElementById("toBeReversed").value = "";
        msg = { payload: 'INPUT CLEARED' };
        window.parent.postMessage(msg, "*");
    }
</script>
</body>
</html>

