angular.module('app', [])
    .controller('AppCtrl', AppCtrl)
    .service('ApiService', ApiService)
;

AppCtrl.$inject = ['ApiService'];
function AppCtrl(apiService) {
    const vm = this;
    vm.msg = null;
    vm.saveMsg = function () {
        apiService.post('api/storage', vm.msg)
        .then(res => {
            console.log("res is:", res);
            vm.messages = res.data;
        });
        console.log("saving:", vm.msg);
    };
    apiService.get('/api/storage')
    .then(res => {
        vm.messages = res.data;
        console.log('res is:', res.data);
    });
}

ApiService.$inject = ['$http'];
function ApiService($http) {
    var apiUri = 'http://localhost:35469';
    this.get = function (url) {
        return $http({
            method: 'GET',
            url: url,
            headers: {
                'Accept': "application/json"
            }
        })
        .then(res => res);
    };

    this.post = function (url, data) {
        let payload = { message : data };
        return $http({
            method: 'POST',
            url: url,
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