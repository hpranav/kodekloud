using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KodeKloudApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _contextAccessor;
    public string IPAddress { get; set; }
    public string Messsage { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _logger = logger;
        _configuration = configuration;
        _contextAccessor = contextAccessor;
    }

    public void OnGet()
    {
        Messsage = _configuration["Message"] ?? "Hello World";
        IPAddress = _contextAccessor.HttpContext.Connection.LocalIpAddress.ToString();

    }
}