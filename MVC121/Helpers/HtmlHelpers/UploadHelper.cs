using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

public static class UploadHelper
{
    public static MvcHtmlString Upload(this HtmlHelper helper, string name, object htmlAttributes = null)
    {
        //helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression))
        TagBuilder input = new TagBuilder("input");
        input.Attributes.Add("type", "file");
        input.Attributes.Add("id", helper.ViewData.TemplateInfo.GetFullHtmlFieldId(name));
        input.Attributes.Add("name", helper.ViewData.TemplateInfo.GetFullHtmlFieldName(name));

        if (htmlAttributes != null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            input.MergeAttributes(attributes);
        }

        return new MvcHtmlString(input.ToString());
    }
   
}