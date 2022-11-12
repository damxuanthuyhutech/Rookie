using CustomersSite.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShareModel.DTO;

namespace CustomersSite.Pages
{
    public class ShowDetailModel : PageModel
    {
        public ProductDTO Products { get; set; } = default!;
        //private readonly ProductAPI _productAPI = new ProductAPI();

        [BindProperty]
        public string Stars { get; set; } = "5";
        [BindProperty]
        
        public ReviewProductFormDTO ReviewForm { get; set; } = default!;
        public List<RatingDTO> RatingList { get; set; } = new List<RatingDTO>();
        

        public async Task OnGetAsync(int? id)
        {


            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            var response = await client.GetAsync($"api/Product/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            Products = JsonConvert.DeserializeObject<ProductDTO>(result) ?? new ProductDTO();
       

          

            response = await client.GetAsync($"api/Rating/{id}");
            result = response.Content.ReadAsStringAsync().Result;
            RatingList = JsonConvert.DeserializeObject<List<RatingDTO>>(result) ?? new List<RatingDTO>();

    

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            ReviewForm.ProductId = id;
            string userId = Request.Cookies["Id"]!;
            ReviewForm.UserId = Int32.Parse(userId);
            ReviewForm.Star = Int32.Parse(Stars);
            await client.PostAsJsonAsync("api/Rating", ReviewForm);

            //return RedirectToPage($"showdetaill/{id}");
            return RedirectToPage($"showproduct1");
            
            //return Page();
        }
    }
}
