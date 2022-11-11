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
        public OrderLinesFormDTO orderLinesFormDTO { get; set; } = default!;

        public IList<OrderLinesDTO>? OrderLines { get; set; }
        
        public async Task OnGetAsync(int id)
        {
            HttpClient client = _api.initial();
            string userId = Request.Cookies["Id"]!;
            id = Int32.Parse(userId);
            var response = await client.GetAsync($"api/OrderLines/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            OrderLines = JsonConvert.DeserializeObject<List<OrderLinesDTO>>(result);
         
        }

        //public async Task<IActionResult> OnPostAsync(int id)
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7182/");
        //    orderLinesFormDTO.Product = id;
        //    string userId = Request.Cookies["Id"]!;
        //    orderLinesFormDTO.Order = Int32.Parse(userId);     
        //    await client.PostAsJsonAsync("api/OrderLines/OrderLineForm", orderLinesFormDTO);      
        //    return RedirectToPage($"showproduct1");

        //    //return Page();
        //}
    }
}
