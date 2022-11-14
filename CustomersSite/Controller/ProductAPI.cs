using Newtonsoft.Json;
using ShareModel.DTO.Product;

namespace CustomersSite.Controller
{
    public class ProductAPI : IGen<ProductDTO>
    {
        private HttpClient client;

        public ProductAPI()
        {
            this.client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var response = await client.GetAsync($"api/Product");
            var result = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<ProductDTO>>(result);

            return products!;
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var response = await client.GetAsync($"api/Product/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);

            return product!;
        }
    }
}
