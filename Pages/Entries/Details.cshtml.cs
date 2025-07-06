using HelloChinese.Repositories;
using HelloChinese.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloChinese.Pages.Entries;

public class Details : PageModel
{
    public DictionarySimpleViewModel Record { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid ID)
    {
        var repo = new DictionaryRepository();
        var record = await repo.GetRecordAsync(ID);
        if (record == null)
            return NotFound();

        Record = record;
        return Page();
    }
}
