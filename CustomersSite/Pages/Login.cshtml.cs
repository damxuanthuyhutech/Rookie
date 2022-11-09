using CustomerSite.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SharedViewModels;

namespace CustomersSite.Pages
{
    public class LoginModel : PageModel
    {
        private APIHelper _api = new APIHelper();
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public LoginFormDTO? LoginForm { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient client = _api.initial();
            var response = await client.PostAsJsonAsync("User/Login", LoginForm);
            var result = response.Content.ReadAsStringAsync().Result;

            var definition = new
            {
                Name = "",
                Id = "",
                AccessToken = "",
                Expiration = new DateTime()
            };
            var info = JsonConvert.DeserializeAnonymousType(result, definition);

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);

            if (info!.AccessToken == null)
            {
                return RedirectToPage("index");
            }

            if ((int)response.StatusCode == 200)
            {
                Response.Cookies.Append("access_token", info.AccessToken, options);
                Response.Cookies.Append("name", info.Name, options);
                Response.Cookies.Append("Id", info.Id, options);
                return RedirectToPage("Index");
            }
            return RedirectToPage("Login");
        }



        public async Task<IActionResult> Logout()
        {       
            Response.Cookies.Delete("access_token");
            Response.Cookies.Delete("Id");
            Response.Cookies.Delete("name");
            Response.Cookies.Delete(".AspNetCore.Antiforgery.V5xRoiv8DEY");
            return RedirectToPage("index");
        }

    }
}
