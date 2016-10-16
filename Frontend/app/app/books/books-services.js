(function () {
    'use strict';

    angular.module('bookworms')
        .factory('books', [
            'requester',
            'BASE_URL',
            function(requester, BASE_URL) {
                
                function getAllBooks() {
                    return requester.get(BASE_URL + '/api/books', false);
                }

                return {
                    getAllBooks: getAllBooks
                };
            }
        ]);
}());