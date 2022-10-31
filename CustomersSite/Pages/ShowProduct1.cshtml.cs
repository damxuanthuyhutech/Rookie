using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShareModel.DTO;

namespace CustomersSite.Pages
{
    public class ShowProduct1Model : PageModel
    {
        private APIHelper _api = new APIHelper();

        public IList<ProductDTO>? Products { get; set; }
        public IList<CategoryDTO>? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? OptionCategories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedCategory { get; set; }

        public async Task OnGetAsync()
        {
            HttpClient client = _api.initial();
            var response = await client.GetAsync("api/Product/get-all-products");
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
    }

}
