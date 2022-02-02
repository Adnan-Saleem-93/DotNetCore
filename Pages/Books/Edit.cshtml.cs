using BooksRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace BooksRazorApp.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int ID)
        {
            Book = await _db.Book.FindAsync(ID);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookResult = await _db.Book.FindAsync(Book.ID);
                if (bookResult != null)
                {
                    bookResult.Name = Book.Name;
                    bookResult.Author = Book.Author;
                    bookResult.ISBN = Book.ISBN;
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
