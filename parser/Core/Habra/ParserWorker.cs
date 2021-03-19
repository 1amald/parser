using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser.Core.Habra
{
    class ParserWorker<T> where T :class
    {
        IParser<T> parser;
        IParserSettings parcerSettings;
        private bool isActive;
        HtmlLoader loader;

        public bool IsActive => isActive;
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings Settings
        {
            get
            {
                return parcerSettings;
            }
            set
            {
                parcerSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings settings) : this(parser)
        {
            this.parcerSettings = settings;
        }

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        public async void Worker()
        {
            for(int i= parcerSettings.StartPoint; i <= parcerSettings.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);

                OnNewData?.Invoke(this, result);
            }

            OnCompleted?.Invoke(this);
        }
    }
}
