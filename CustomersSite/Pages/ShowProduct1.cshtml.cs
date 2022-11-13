using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShareModel.DTO;
using ShareModel.DTO.Product;
using System.Text.Json;
using System.Web;

namespace CustomersSite.Pages
{
    

    public class ShowProduct1Model : PageModel
    {
        private APIHelper _api = new APIHelper();

        public IList<ProductDTO>? Products { get; set; }
        public IList<CategoryDTO>? Categories { get; set; }

        //[BindProperty]
        public SearchProductDto searchProductDto { get; set; } = new SearchProductDto();
       
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? OptionCategories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedCategory { get; set; }

        public int TotalPages { get; set; } = 20;
        public int CurrentPage { get; set; } = 1;

        public async Task OnGetAsync()
        {
            //SearchProductDto input = new SearchProductDto();
            //input.Search = SearchString;
            //input.Category = SelectedCategory;

            HttpClient client = _api.initial();
            if (CurrentPage == 0)
            {
                CurrentPage = 1;
            }
            searchProductDto.CurrentPage = CurrentPage;
            searchProductDto.SelectedCategory = SelectedCategory;
            searchProductDto.SearchString = SearchString;



            var repon = await client.PostAsJsonAsync($"api/Product/search", searchProductDto);
            var result = repon.Content.ReadAsStringAsync().Result;
            var Product = JsonConvert.DeserializeObject<List<CategoryDTO>>(result);


            //var url = HttpUtility.ParseQueryString(string.Empty);
            //if (!string.IsNullOrWhiteSpace(input.Search))
            //{
            //    url["search"] = input.Search;
            //}
            //if (!string.IsNullOrWhiteSpace(input.Category))
            //{
            //    url["category"] = input.Category;
            //}
            //url["page"] = input.Page.Value.ToString();
            //url["maxResponse"] = input.MaxResponse.Value.ToString();
            //url["skip"] = input.Skip.Value.ToString();

            //var abc = await client.GetAsync("api/Product/search?" + url.ToString());
            //var abc = client.GetAsync("api/Product/search?" + url.ToString());



            var response1 = await client.GetAsync("api/Category");
            var result1 = response1.Content.ReadAsStringAsync().Result;
            Categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(result1);

            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    {
            //        Products = Products!.Where(s => s.Name.ToLower().Contains(SearchString.ToLower())).ToList();
            //    }

            //}

            //if (!string.IsNullOrEmpty(SelectedCategory))
            //{
            //    //Products = from s in Products where (s.Category == SelectedCategory;
            //    //Products = Products!.Where(s => s.ProductId == SelectedCategory).ToList();
            //    Products = Products!.Where(x => x.Category == SelectedCategory).ToList(); // ID have index query
          
            //}
            

            OptionCategories = new SelectList(Categories?.Select(x => x.Name));




        }
    }

}
