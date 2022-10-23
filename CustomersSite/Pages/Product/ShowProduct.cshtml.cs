using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;
using ShareModel.DTO;


namespace CustomersSite.Pages.Product
{
    public class ShowProductModel : PageModel
    {
        public IList<ProductDTO>? Products { get; set; }

        public async Task OnGetAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            var response = await client.GetAsync("api/Product");
            var result = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<ProductDTO>>(result);
            try
            {

                Products = products;
            }
            catch
            {
                Console.WriteLine("Null");
            }
            
            
            
        

            
        }
    }
}
