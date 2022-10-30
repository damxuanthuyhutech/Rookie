using Newtonsoft.Json;
using ShareModel.DTO;

namespace CustomersSite.Pages.Shared
{
    public class _text
    {
        public IList<CategoryDTO>? categoryDTOs { get; set; }
        public Array t { get; set; }

        public async Task OnGetAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            var response = await client.GetAsync("api/Categories");
            var result = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<CategoryDTO>>(result);
            try
            {

                categoryDTOs = products;
                 t = categoryDTOs.ToArray();
            }
            catch
            {
                Console.WriteLine("Null");
            }
        }
    }
}
