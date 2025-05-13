using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework_SkillTree.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent RenderTypeName(this IHtmlHelper htmlHelper, string typeName)
        {
            // �P�_�����ó]�w������ CSS ���O
            var cssClass = typeName == "��X" ? "text-white-50 bg-danger" : "text-white-50 bg-success";
            var html = $"<span class='{cssClass}'>{typeName}</span>";
            return new HtmlString(html);
        }
    }
}
