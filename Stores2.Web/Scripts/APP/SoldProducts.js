$(document).ready(function () {
  loadData();
});

function loadData() {
  $.ajax({
    url: "/SoldProducts/GetSoldProducts",
    type: "GET",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      var html = '';
      $.each(result, function (key, item) {
        html += '<tr>';
        html += '<td hidden="hidden">' + item.Id + '</td>';
        html += '<td>' + item.Customer.Name + '</td>';
        html += '<td>' + item.Product.Name + '</td>';
        html += '<td>' + item.Store.Name + '</td>';
        html += '<td>' + parseJsonDate(item.SoldDate) + '</td>';
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
  var SoldProductObj = {
    Name: $('#CustomerName').val(),
    Address: $('#ProductName').val(),
    Address: $('#StoreName').val(),
    Address: $('#SoldDate').val()
  };
  $.ajax({
    url: "/SoldProducts/Create",
    data: JSON.stringify(SoldProductObj),
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

function getbyID(SoldProductId) {
  $('#Name').css('border-color', 'lightgrey');
  $('#Address').css('border-color', 'lightgrey');
  $.ajax({
    url: "/SoldProducts/GetbyId/" + SoldProductId,
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
      $('#myModalLabel').append('Edit SoldProduct');
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
  return false;
}

function Update() {
  var SoldProductObj = {
    Id: $('#Id').val(),
    Name: $('#Name').val(),
    Address: $('#Address').val()
  };
  $.ajax({
    url: "/SoldProducts/Edit",
    data: JSON.stringify(SoldProductObj),
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
  var answer = confirm("Are you sure you want to delete this SoldProduct?");
  if (answer) {
    $.ajax({
      url: "/SoldProducts/Delete/" + Id,
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

function parseJsonDate(jsonDateString) {

  var date; var newDate;
  if (jsonDateString) {
    date = new Date(parseInt(jsonDateString.replace('/Date(', '')));
    newDate = date.getMonth() + 1 + '/' + date.getDate() + '/' + date.getFullYear();

    return newDate;
  }
}