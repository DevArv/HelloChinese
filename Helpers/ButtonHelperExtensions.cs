using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloChinese.Helpers;

public static class ButtonHelperExtensions
{
    public static IHtmlContent HcSaveButton(this IHtmlHelper HTMLHelper, string ID = "btnSave", string OnClick = "")
    {
        var button = new TagBuilder(tagName: "button");
        button.Attributes["type"] = "button";
        button.Attributes["id"] = ID;

        if (!string.IsNullOrWhiteSpace(OnClick))
        {
            button.Attributes["onclick"] = OnClick;
        }
        
        button.AddCssClass("btn btn-success");
        button.InnerHtml.Append("Guardar");
        return button;
    }
    
    public static IHtmlContent HcListButton(this IHtmlHelper HTMLHelper, string Page = "/Index")
    {
        var anchor = new TagBuilder(tagName: "a");
        anchor.Attributes["href"] = Page;
        anchor.AddCssClass("btn btn-primary");
        anchor.InnerHtml.Append("Listado");
        return anchor;
    }
    
    public static IHtmlContent HcDeleteButton(this IHtmlHelper HTMLHelper, string ID = "btnDelete", string OnClick = "")
    {
        var button = new TagBuilder(tagName: "button");
        button.Attributes["type"] = "button";
        button.Attributes["id"] = ID;

        if (!string.IsNullOrWhiteSpace(OnClick))
        {
            button.Attributes["onclick"] = OnClick;
        }
        
        button.AddCssClass("btn btn-danger");
        button.InnerHtml.Append("Eliminar");
        return button;
    }
    
    public static IHtmlContent HcEditButton(this IHtmlHelper HTMLHelper, string ID = "btnEdit", string OnClick = "")
    {
        var button = new TagBuilder(tagName: "button");
        button.Attributes["type"] = "button";
        button.Attributes["id"] = ID;

        if (!string.IsNullOrWhiteSpace(OnClick))
        {
            button.Attributes["onclick"] = OnClick;
        }
        
        button.AddCssClass("btn btn-primary");
        button.InnerHtml.Append("Editar");
        return button;
    }
}