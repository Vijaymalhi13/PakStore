using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.Common.Utils
{
    public class SearchOptions
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortExpression { get; set; }
        public string SortDirection { get; set; }
    }
}
