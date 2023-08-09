using Microsoft.AspNetCore.Mvc;

namespace Assessment.Task1.Models
{
    public class IndexModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;
    }
}
