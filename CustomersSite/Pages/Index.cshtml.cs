using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShareModel.DTO;
using CustomerSite.Helper;

namespace CustomersSite.Pages
{
    public class IndexModel : PageModel
    {
        private APIHelper _api = new APIHelper();
        public IList<ProductDTO>? ProductsNew { get; set; }
        public IList<ProductDTO>? ProductsHot { get; set; }

        public async Task OnGetAsync()
        {
            HttpClient client = _api.initial();
            var response = await client.GetAsync("api/Product");
            var result = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<List<ProductDTO>>(result);

            ProductsNew = product;
            ProductsNew = ProductsNew!.OrderByDescending(a => a.UpdatedDate).Take(6).ToList();

            ProductsHot = product;
            ProductsHot = ProductsHot!.OrderByDescending(a => a.AverageRating).Take(8).ToList();
           



        }
    }

}

