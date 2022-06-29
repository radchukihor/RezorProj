using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProjectWeb.Data;
using RazorProjectWeb.Model;

namespace RazorProjectWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db) => _db = db;

        public void OnGet(int id) => Category = _db.Category.FirstOrDefault(x => x.Id == id);

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _db.Category.FirstOrDefault(x => x.Id == Category.Id);

            if (categoryFromDb != null)
            {
                _db.Category.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "CATEGORY DELETED";
                return RedirectToPage("Index");
            }

            return Page();
        }


    }
}

