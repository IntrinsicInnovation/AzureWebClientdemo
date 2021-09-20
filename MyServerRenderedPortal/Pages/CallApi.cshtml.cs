using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MyServerRenderedPortal.Pages
{
    [AuthorizeForScopes(Scopes = new string[] { "api://5764e5de-85e1-4d8c-b9c0-6d939025798c/access_as_user" })]
    public class CallApiModel : PageModel
    {
        private readonly ApiService _apiService;

        public JArray DataFromApi { get; set; }
        public CallApiModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            DataFromApi = await _apiService.GetApiDataAsync()
                .ConfigureAwait(false);
        }
    }
}