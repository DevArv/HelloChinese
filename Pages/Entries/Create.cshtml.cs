using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HelloChinese.ViewModels;

namespace HelloChinese.Pages.Entries;

[IgnoreAntiforgeryToken]
public class Create : PageModel
{
    [BindProperty]
    public DictionarySimpleViewModel Record { get; set; } = new();
    
    public IActionResult OnGet()
    {
        Record.Date = DateTime.UtcNow.Date;
        return Page();
    }
}