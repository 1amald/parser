namespace parser.Core.Habra
{
    class HabraParserSettings : IParserSettings
    {
        public HabraParserSettings(int start,int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://habr.com/ru/";
        public string Prefix { get; set; } = "page{CurrentId}/";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
