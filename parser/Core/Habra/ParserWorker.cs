using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser.Core.Habra
{
    class ParserWorker<T> where T :class
    {
        readonly IParser<T> parser;
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
    }
}
