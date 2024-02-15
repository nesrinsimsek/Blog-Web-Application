using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Week5CaseStudy.Utility
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent Truncate(this IHtmlHelper helper, string input, int length)
        {
            if (input == null || input.Length <= length)
            {
                return new HtmlString(input);
            }

            int lastSpace = input.LastIndexOf(' ', length);

            if (lastSpace == -1)
            {
                lastSpace = length;
            }

            string truncated = input.Substring(0, lastSpace).TrimEnd();
            return new HtmlString($"{truncated}...");
        }
    }
}

