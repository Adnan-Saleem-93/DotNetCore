using BooksRazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksRazorApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public Book Book { get; set; }
        public IActionResult GetBooks()
        {
            return Json(new { data = _db.Book.Find() });
        }
    }
}
