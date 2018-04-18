function CustomerViewModel() {
  var self = this;
  self.Id = ko.observable("");
  self.Name = ko.observable("");
  self.Address = ko.observable("");

  var Customer = {
    Id: self.Id,
    Name: self.Name,
    Address: self.Address
  };

  self.Customer = ko.observable();
  self.Customers = ko.observableArray();
  
  $.ajax({
    url: '/Customers/GetCustomers',
    cache: false,
    type: 'GET',
    contentType: 'application/json; charset=utf-8',
    data: {},
    success: function (data) {
      self.Customers = data;
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    }

  });
}

var viewModel = new CustomerViewModel();
ko.applyBindings(viewModel);
