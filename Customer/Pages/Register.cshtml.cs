using BackEnd.DTO.CustomerDTO;
using ClassLibrary.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Customer.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ICustomerClass _metaIdentityUserService;

        [BindProperty]
        public CreateUserDto UserRegistration { get; set; }

        public RegisterModel(ICustomerClass metaIdentityUserService)
        {

            UserRegistration = new CreateUserDto();
            _metaIdentityUserService = metaIdentityUserService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostRegister()
        {
            if (ModelState.IsValid)
            {
                var result = await _metaIdentityUserService.Register(UserRegistration, "Customer");


                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = "Register Successfully";
                    return RedirectToPage("/Login");
                }
                else
                {
                    if (result.Errors != null)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("message", error.Description);
                        }
                    }

                }

            }
            return Page();
        }
    }
}
