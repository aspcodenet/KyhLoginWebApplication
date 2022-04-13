using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KyhLoginWebApplication.Pages
{
    // [Authorize] // Alla som är inloggade!
    [Authorize(Roles="Admin")] //  Bara admins
    //[Authorize(Roles = "Customer")] //  Bara customers
    //[Authorize(Roles="Admin, Players, Referee")] // 
        public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}