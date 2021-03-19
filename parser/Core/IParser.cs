using AngleSharp.Html.Dom;

namespace parser.Core
{
    interface IParser<T> where T: class
    {
        T Parse(IHtmlDocument doc);
    }
}
