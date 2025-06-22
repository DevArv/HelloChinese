using HelloChinese.Enums;

namespace HelloChinese.ViewModels;

public class DictionarySimpleViewModel
{
    public Guid ID { get; set; }
    public DateTime Date { get; set; }
    public string Handwriting { get; set; } = "";
    public string Pronunciation { get; set; } = "";
    public string Meaning { get; set; } = "";
    public CategoriesEnum Category { get; set; }
}