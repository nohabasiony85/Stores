$(document).ready(function () {
  loadData();
});

function loadData() {
  $.ajax({
    url: "/Stores/GetStores",
    type: "GET",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      var html = '';
      $.each(result, function (key, item) {
        html += '<tr>';
        html += '<td hidden="hidden">' + item.Id + '</td>';
        html += '<td>' + item.Name + '</td>';
        html += '<td>' + item.Address + '</td>';
        html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.Id + ')">Delete</a></td>';
        html += '</tr>';
      });
      $('.tbody').html(html);
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
}  

function Add() {
  var customerObj = {
    Name: $('#Name').val(),
    Address: $('#Address').val()
  };
  $.ajax({
    url: "/Stores/Create",
    data: JSON.stringify(customerObj),
    type: "POST",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      loadData();
      $('#myModal').modal('hide');
      $('.modal-backdrop').hide();
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
}

function clearControls() {
    $('#Name').val("");
    $('#Address').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
  $('#Address').css('border-color', 'lightgrey');
}  

function getbyID(customerId) {
  $('#Name').css('border-color', 'lightgrey');
  $('#Address').css('border-color', 'lightgrey');
  $.ajax({
    url: "/Stores/GetbyId/" + customerId,
    typr: "GET",
    contentType: "application/json;charset=UTF-8",
    dataType: "json",
    success: function (result) {
      $('#Id').val(result.Id);
      $('#Name').val(result.Name);
      $('#Address').val(result.Address);
      $('#myModal').modal('show');
      $('#btnUpdate').show();
      $('#btnAdd').hide();
      $('#myModalLabel').empty();
      $('#myModalLabel').append('Edit Store');
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
  return false;
}

function Update() {
  var customerObj = {
    Id: $('#Id').val(),
    Name: $('#Name').val(),
    Address: $('#Address').val()
  };
  $.ajax({
    url: "/Stores/Edit",
    data: JSON.stringify(customerObj),
    type: "POST",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      loadData();
      $('#myModal').modal('hide');
      $('#Name').val("");
      $('#Address').val("");
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
}  

function Delete(Id) {
  var answer = confirm("Are you sure you want to delete this customer?");
  if (answer) {
    $.ajax({
      url: "/Stores/Delete/" + Id,
      type: "POST",
      contentType: "application/json;charset=UTF-8",
      dataType: "json",
      success: function (result) {
        loadData();
      },
      error: function (errormessage) {
        alert(errormessage.responseText);
      }
    });
  }
}  