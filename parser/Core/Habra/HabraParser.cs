using AngleSharp.Html.Dom;
using System;
using System.Linq;
using System.Collections.Generic;

namespace parser.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument doc)
        {
            List<string> res = new List<string>();
            var items = doc.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName == "post_title_link");
            
            foreach(var item in items)
            {
                res.Add(item.TextContent);
            }

            return res.ToArray();
            
        }
    }
}
