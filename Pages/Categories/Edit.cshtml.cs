using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProjectWeb.Data;
using RazorProjectWeb.Model;

namespace RazorProjectWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db) => _db = db;

        public void OnGet(int id) => Category = _db.Category.FirstOrDefault(x => x.Id == id);

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
                ModelState.AddModelError("Category.Name", "the NAME can't match the DISPLAY ORDER");

            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "CATEGORY EDITED";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
