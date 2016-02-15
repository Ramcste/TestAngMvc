using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularMvc.Models;

namespace AngularMvc.Controllers
{
    public class BooksController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: Books
        public ActionResult Index()
        {
            //var books = db.Books.ToList();

            return View();
        }


        // GET: All books
            public JsonResult GetAllBooks()
        {
            var bookslist = db.Books.ToList();

            return Json(bookslist, JsonRequestBehavior.AllowGet);

        }

      
        // GET: Book by Id
        public JsonResult GetBookById(string id)
        {
            int bookId = int.Parse(id);
            var getBooksById = db.Books.Find(bookId);
            return Json(getBooksById, JsonRequestBehavior.AllowGet);
        }



        //Update: Book

        public string UpdateBook(Book book)
        {
            if (book != null)
            {
                int bookId = book.Id;

                Book updatebook = db.Books.Where(b => b.Id == bookId).FirstOrDefault();
                updatebook.Title = book.Title;
                updatebook.Author = book.Author;
                updatebook.Publisher = book.Publisher;
                updatebook.Isbn = book.Isbn;
                db.SaveChanges();

                return "Book Record Updated Successfully";

            }
            else
            {
                return "Invalid Book Record";
            }
        }

        // Add Book

        public  string AddBook(Book book)
        {
            if (book != null)
            {
                db.Books.Add(book);
                db.SaveChanges();

                return "Book Record Added Successfully";
            }

            else
            {
                return "Invalid book record";
            }
        }

        // Delete Book

        public string DeleteBook(string bookId)
        {
            if (!String.IsNullOrEmpty(bookId))
            {
                try
                {
                    int _bookId = int.Parse(bookId);

                    var _book = db.Books.Find(_bookId);
                    db.Books.Remove(_book);
                    db.SaveChanges();

                    return "Selected book record deleted successfully";
                }

                catch (Exception)
                {
                    return "Book details not found";
                }
            }
            else{

                return "Invalid operation";
            }
        }
    }
}
