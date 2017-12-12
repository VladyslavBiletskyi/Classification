using System.Collections.Generic;

namespace Classification
{
    internal class BayesClass
    {
        public string Name { get; set; }

        public int DocumentsCount { get; set; }

        public IDictionary<string, int> UniqueWords { get; set; }
    }
}
