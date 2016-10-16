(function () {
    'use strict';

    angular.module('bookworms')
        .controller('HomeController', [
            'books',
            function (books) {

                books.getAllBooks()
                    .then(function (resp) {
                        console.log(resp);
                    });
            }
        ]);
} ());