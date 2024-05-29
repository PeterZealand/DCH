using DCH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DCH.Models;

namespace DCH.Pages.AdminLogin
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public @DCH.Models.AdminLogin adminLogin {  get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (adminLogin.UserName == "admin" && adminLogin.Password == "1234")
            {
                return RedirectToPage("/Login/Administration");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }
        }
    }
}
