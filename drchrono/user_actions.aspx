<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_actions.aspx.cs" Inherits="drchrono.user_actions" %>

<!DOCTYPE html>

<html>
<head>
  <title>User Actions</title>
  <meta charset="utf-8">
  <script src="lib/jquery-1.11.3.min.js"></script>
  <script>
      /* global $ */
      $(document).ready(function () {
          'use strict';
          $(window).on('message', function (evt) {
              //Note that messages from all origins are accepted
              alert(evt);
              //Get data from sent message
              var data = evt.originalEvent.data;
              //Create a new list item based on the data
              var newItem = '\n\t<li>' + (data.payload || '') + '</li>';
              //Add the item to the beginning of the actions list
              $('#actions').prepend(newItem);
          });
      });
  </script>
</head>

<body>
  <iframe id="encoder_iframe" src="http://localhost:65358/content.aspx"></iframe>
  <ul id="actions">
  </ul>
</body>
</html>

