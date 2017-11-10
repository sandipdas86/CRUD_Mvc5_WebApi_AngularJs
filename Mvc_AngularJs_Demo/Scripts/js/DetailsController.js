

var app = angular.module('App', []);
app.controller('DetailsController', function ($scope,$http) {
    $scope.init = function () {
        $http({
            method:'GET',
            url: 'http://localhost:2569/api/employee/GetEmployees'
        }).then(function (response) {
            console.log(response.data);
            $scope.employees = JSON.parse(response.data);
        }, function (err) {
            console.log(err);
        });
    }
    $scope.edit = function (emp) {
        console.log(emp)
        document.getElementById("EmpID_").value = emp.Emp_Id;
        $scope.name = emp.Name;
        $scope.sex = emp.Sex;
        $scope.dob = emp.DOB.replace('/Date(','').replace(')/','');
        $scope.city = emp.City;
        $scope.address = emp.Address;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("spn").innerHTML = "Update Employee";
    }
    $scope.delete = function (Id) {
        $http({
            method: 'DELETE',
            url: 'http://localhost:2569/api/employee/DeleteEmployee?Id='+Id
        }).then(function (response) {
            console.log(response);
            window.location = "/employee/index";
        }, function (err) {
            console.log(err);
        });
    }
    $scope.save = function (name, sex, dob, city, address) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        console.log(name, sex, dob, city, address);
        if (Action == "Save") {
            $http({
                method: 'POST',
                url: 'http://localhost:2569/api/employee/AddEmployee',
                data: {
                    Name: name, Sex: sex, DOB: dob, City: city, Address: address
                }
            }).then(function (response) {
                console.log(response);
                window.location = "/employee/index";
            }, function (err) {
                console.log(err);
            });
        }
        else {
            var Id = document.getElementById("EmpID_").value;
            $http({
                method: 'PUT',
                url: 'http://localhost:2569/api/employee/EditEmployee?Id='+Id,
                data: {
                    Name: name, Sex: sex, DOB: dob, City: city, Address: address
                }
            }).then(function (response) {
                console.log(response);
                window.location = "/employee/index";
            }, function (err) {
                console.log(err);
            });
        }
    }
});