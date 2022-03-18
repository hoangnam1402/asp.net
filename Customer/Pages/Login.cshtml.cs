using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Customer.Pages
{
    [Authorize]
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
