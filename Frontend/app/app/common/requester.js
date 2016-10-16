(function () {
    'use strict';

    angular.module('bookworms')
        .factory('requester', [
            '$http',
            '$q',
            function ($http, $q) {

                function getItem(url, useSession) {
                    return makeRequest('GET', url, null, useSession);
                }

                function postItem(url, data, useSession) {
                    return makeRequest('POST', url, data, useSession);
                }

                function putItem(url, data, useSession) {
                    return makeRequest('PUT', url, data, useSession);
                }

                function deleteItem(url, useSession) {
                    return makeRequest('DELETE', url, null, useSession);
                }

                function makeRequest(method, url, data, headers) {
                    var defer = $q.defer(),
                        options = {},
                        token;

                    //set headers
                    if (headers) {
                        token = localStorage.userToken;
                        options['Authorization'] = 'Bearer ' + token;
                    }

                    if (data) {
                        options['Content-Type'] = 'application/json';
                    }

                    $http({
                        method: method,
                        url: url,
                        headers: options,
                        data: data
                    }).
                        then(function (data) {
                            defer.resolve(data);
                        },
                        function (error) {
                            defer.reject(error);
                        })
                        ;

                    return defer.promise;
                }

                return {
                    get: getItem,
                    post: postItem,
                    put: putItem,
                    delete: deleteItem
                };
            }
        ]);
} ());