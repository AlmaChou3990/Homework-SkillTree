using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework_SkillTree.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent RenderTypeName(this IHtmlHelper htmlHelper, string typeName)
        {
            // 判斷類型並設定對應的 CSS 類別
            var cssClass = typeName == "支出" ? "text-white-50 bg-danger" : "text-white-50 bg-success";
            var html = $"<span class='{cssClass}'>{typeName}</span>";
            return new HtmlString(html);
        }
    }
}
