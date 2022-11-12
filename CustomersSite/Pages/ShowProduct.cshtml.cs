using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShareModel.DTO;
using ShareModel.DTO.OrderLines;
using ShareModel.DTO.Product;
using System.Drawing.Printing;
using System.Text.Json;
using System.Web;

namespace CustomersSite.Pages
{
    

    public class ShowProductModel : PageModel
    {
        private APIHelper _api = new APIHelper();

        public IList<ProductDTO>? Products { get; set; }
        public IList<CategoryDTO>? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? OptionCategories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedCategory { get; set; }


        public int TotalPages { get; set; } = 20;
        public int CurrentPage { get; set; } = 1;

       

        public async Task OnGetAsync(int CurrentPage)
        {

            HttpClient client = _api.initial();
            if (CurrentPage == 0)
            {
                CurrentPage = 1;
            }
            this.CurrentPage = CurrentPage;
            var response = await client.GetAsync($"api/Product/Paging/{CurrentPage}");
            var result = response.Content.ReadAsStringAsync().Result;         
            Products = JsonConvert.DeserializeObject<List<ProductDTO>>(result);

            var response1 = await client.GetAsync("api/Category");
            var result1 = response1.Content.ReadAsStringAsync().Result;
            Categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(result1);

            if (!string.IsNullOrEmpty(SearchString))
            {
                {
                    Products = Products!.Where(s => s.Name.ToLower().Contains(SearchString.ToLower())).ToList();
                }

            }

            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                //Products = from s in Products where (s.Category == SelectedCategory;
                //Products = Products!.Where(s => s.ProductId == SelectedCategory).ToList();
                Products = Products!.Where(x => x.Category == SelectedCategory).ToList(); // ID have index query
          
            }

            OptionCategories = new SelectList(Categories?.Select(x => x.Name));




        }

        //public async Task<IActionResult> OnGetAddToCartAsync(int id)
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7182/");
        //    orderLinesFormDTO.Product = id;
        //    string userId = Request.Cookies["Id"]!;
        //    orderLinesFormDTO.Order = Int32.Parse(userId);
        //    await client.PostAsJsonAsync("api/OrderLines/OrderLineForm", orderLinesFormDTO);
        //    return RedirectToPage($"showproduct");

        //    //return Page();
        //}
    }

}
