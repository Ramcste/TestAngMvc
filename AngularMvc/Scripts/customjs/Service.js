app.service("crudAJService", function ($http) {
 
    //get All Books
    this.getBooks = function () {
        return $http.get("Books/GetAllBooks");
    };
 
    // get Book by bookId
    this.getBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "Books/GetBookById",
            params: {
                id: JSON.stringify(bookId)
            }
        });
        return response;
    }
 
    // Update Book 
    this.updateBook = function (book) {
        var response = $http({
            method: "post",
            url: "Books/UpdateBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }
 
    // Add Book
    this.AddBook = function (book) {
        var response = $http({
            method: "post",
            url: "Books/AddBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }
 
    //Delete Book
    this.DeleteBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "Books/DeleteBook",
            params: {
                bookId: JSON.stringify(bookId)
            }
        });
        return response;
    }
});