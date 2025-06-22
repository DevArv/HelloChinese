using HelloChinese.Enums;

namespace HelloChinese.Models;

public class Dictionary
{
    public Guid ID { get; set; }
    
    public DateTime Date { get; set; }

    public string Handwriting { get; set; } = "";

    public string Pronunciation { get; set; } = "";
    
    public string Meaning { get; set; } = "";

    public CategoriesEnum Category { get; set; }
}