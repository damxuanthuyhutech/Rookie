using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShareModel.DTO;
using ShareModel.DTO.OrderLines;

namespace CustomersSite.Pages
{
    public class OrderLinesModel : PageModel
    {
        private APIHelper _api = new APIHelper();
        public OrderLinesFormDTO orderLinesFormDTO { get; set; } = new OrderLinesFormDTO();

        public IList<OrderLinesDTO>? OrderLines { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string token = Request.Cookies["access_token"] ?? "";
            if (token != "")
            {
                HttpClient client = _api.initial();
                string userId = Request.Cookies["Id"]!;
                int id = Int32.Parse(userId);
                var response = await client.GetAsync($"api/OrderLines/{id}");
                var result = response.Content.ReadAsStringAsync().Result;
                OrderLines = JsonConvert.DeserializeObject<List<OrderLinesDTO>>(result);
                return Page();
            }
            return RedirectToPage($"Login");

        }

        public async Task<IActionResult> OnGetAddToCartAsync(int id)
        {
            string token = Request.Cookies["access_token"] ?? "";
            if (token != "")
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7182/");
                orderLinesFormDTO.Product = id;
                string userId = Request.Cookies["Id"]!;
                orderLinesFormDTO.Order = Int32.Parse(userId);
                orderLinesFormDTO.Quantity = 1;
                await client.PostAsJsonAsync("api/OrderLines/OrderLineForm", orderLinesFormDTO);
                return RedirectToPage($"showproduct");
            }
            return RedirectToPage($"Login");




        }

        public async Task OnGetAddToAsync(int idAdd)
        {
            HttpClient client = _api.initial();          
            var response = await client.GetAsync($"api/OrderLines/AddQuantity/{idAdd}");

            string userId = Request.Cookies["Id"]!;
            int id = Int32.Parse(userId);
            var response1 = await client.GetAsync($"api/OrderLines/{id}");
            var result = response1.Content.ReadAsStringAsync().Result;
            OrderLines = JsonConvert.DeserializeObject<List<OrderLinesDTO>>(result);

        }

        public async Task OnGetTruToAsync(int idTru)
        {
            HttpClient client = _api.initial();
            var response = await client.GetAsync($"api/OrderLines/TruQuantity/{idTru}");
        
            string userId = Request.Cookies["Id"]!;
            int id = Int32.Parse(userId);
            var response1 = await client.GetAsync($"api/OrderLines/{id}");
            var result = response1.Content.ReadAsStringAsync().Result;
            OrderLines = JsonConvert.DeserializeObject<List<OrderLinesDTO>>(result);

        }

        public async Task OnGetRemoveAllAsync(int idRemove)
        {
            HttpClient client = _api.initial();
            var response = await client.GetAsync($"api/OrderLines/Delete/{idRemove}");

            string userId = Request.Cookies["Id"]!;
            int id = Int32.Parse(userId);
            var response1 = await client.GetAsync($"api/OrderLines/{id}");
            var result = response1.Content.ReadAsStringAsync().Result;
            OrderLines = JsonConvert.DeserializeObject<List<OrderLinesDTO>>(result);


        }
    }
}
