<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cross.aspx.cs" Inherits="drchrono.cross" %>

<!DOCTYPE html>

<html>
  <head>
     <meta charset="UTF-8">
     <title>cross</title>
  </head>
    <body>
        <iframe id ="encoder_iframe"  src="http://localhost:65358/content.aspx" frameborder="1"></iframe>
        <button id="postMessage">Post Message from iframe</button>

      <script type="text/javascript">

          window.onload = function () {

              var receiverWindow = document.getElementById('encoder_iframe').contentWindow;
              receiverWindow.postMessage('hello to content', 'http://localhost:65358');

              document.getElementById('postMessage').addEventListener('click', function () {
                  receiverWindow.postMessage('hello', 'http://localhost:65358');
              });
          };
      </script>

    </body>
</html>