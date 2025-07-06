using HelloChinese.Repositories;
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
    
    public async Task<IActionResult> OnPostSaveAsync([FromBody] DictionarySimpleViewModel Record)
    {
        try
        {
            var repo = new DictionaryRepository();
            bool isValid = await repo.ValidateAsync(Obj: Record);

            if (isValid == false)
                return BadRequest("La validación falló.");

            var ID = await repo.SaveRecordAsync(ViewModel: Record);
            return new JsonResult(new
            {
                success = true, 
                ID = ID
            });
        }
        catch (ApplicationException aex)
        {
            return new JsonResult(new
            {
                success = false, 
                message = aex.Message
            });
        }
        catch (Exception)
        {
            return new JsonResult(new
            {
                success = false, 
                message = "Ocurrió un error inesperado al guardar el registro."
            });
        }
    }
}