using HelloChinese.Repositories;
using HelloChinese.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace HelloChinese.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    public List<DictionarySimpleViewModel> Record { get; set; } = new();
    
    [BindProperty(SupportsGet = true)]
    public string? Error { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        var repo = new DictionaryRepository();
        Record = await repo.GetTableFlightPlansAsync();
    }
}
