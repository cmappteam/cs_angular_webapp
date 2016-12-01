﻿angular.module('app', [])
    .controller('AppCtrl', AppCtrl)
    .service('ApiService', ApiService)
;

AppCtrl.$inject = ['ApiService'];
function AppCtrl(apiService) {
    const vm = this;
    vm.msg = null;
    vm.saveMsg = function () {
        apiService.post('/storage', vm.msg)
        .then(res => {
            console.log("res is:", res);
            vm.messages = res.data;
        });
        console.log("saving:", vm.msg);
    };
    apiService.get('/storage')
    .then(res => {
        vm.messages = res.data;
        console.log('res is:', res);
    });
}

ApiService.$inject = ['$http'];
function ApiService($http) {
    var apiUri = 'http://localhost:5000';
    this.get = function (url) {
        return $http({
            method: 'GET',
            url: apiUri + url,
            headers: {
                'Accept': "application/json"
            }
        })
        .then(res => res);
    };

    this.post = function (url, data) {
        let payload = { data: data };
        return $http({
            method: 'POST',
            url: apiUri + url,
            data: angular.toJson(payload),
            headers: {
                'Content-Type': "application/json"
            }
        })
        .then(res => {
            return res;
        })
    }
}