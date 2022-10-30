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

        public async Task OnGetAsync(int? id)
        {


            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            var response = await client.GetAsync($"api/Product/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            Products = JsonConvert.DeserializeObject<ProductDTO>(result) ?? new ProductDTO();
            //try
            //{

            //    Products = products;
            //}
            //catch
            //{
            //    Console.WriteLine("Null");
            //}
        }
    }
}
