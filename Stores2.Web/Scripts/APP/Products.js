$(document).ready(function () {
  loadData();
});

function loadData() {
  $.ajax({
    url: "/Products/GetProducts",
    type: "GET",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      var html = '';
      $.each(result, function (key, item) {
        html += '<tr>';
        html += '<td hidden="hidden">' + item.Id + '</td>';
        html += '<td>' + item.Name + '</td>';
        html += '<td>' + item.Price + '</td>';
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
  var ProductObj = {
    Name: $('#Name').val(),
    Price: $('#Price').val()
  };
  $.ajax({
    url: "/Products/Create",
    data: JSON.stringify(ProductObj),
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
    $('#Price').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
  $('#Price').css('border-color', 'lightgrey');
}  

function getbyID(ProductId) {
  $('#Name').css('border-color', 'lightgrey');
  $('#Price').css('border-color', 'lightgrey');
  $.ajax({
    url: "/Products/GetbyId/" + ProductId,
    typr: "GET",
    contentType: "application/json;charset=UTF-8",
    dataType: "json",
    success: function (result) {
      $('#Id').val(result.Id);
      $('#Name').val(result.Name);
      $('#Price').val(result.Price);
      $('#myModal').modal('show');
      $('#btnUpdate').show();
      $('#btnAdd').hide();
      $('#myModalLabel').empty();
      $('#myModalLabel').append('Edit Product');
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
  return false;
}

function Update() {
  var ProductObj = {
    Id: $('#Id').val(),
    Name: $('#Name').val(),
    Price: $('#Price').val()
  };
  $.ajax({
    url: "/Products/Edit",
    data: JSON.stringify(ProductObj),
    type: "POST",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      loadData();
      $('#myModal').modal('hide');
      $('#Name').val("");
      $('#Price').val("");
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }
  });
}  

function Delete(Id) {
  var answer = confirm("Are you sure you want to delete this Product?");
  if (answer) {
    $.ajax({
      url: "/Products/Delete/" + Id,
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