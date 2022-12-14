using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerSite.Helper;
using ShareModel.DTO.Login;

namespace CustomerSite.Pages;

public class RegisterModel : PageModel
{
    private APIHelper _api = new APIHelper();
    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(ILogger<RegisterModel> logger)
    {
        _logger = logger;
    }
    [BindProperty]
    public RegisterFormDTO RegisterForm { get; set; } = new RegisterFormDTO();
    public async Task<IActionResult> OnPostAsync()
    {
        HttpClient client = _api.initial();
        var response = await client.PostAsJsonAsync("User/Register", RegisterForm);
        if ((int)response.StatusCode == 200)
        {
            return RedirectToPage("Login");
        }
        return RedirectToPage("Index");
    }
}

