using System;
using System.Collections.Generic;

namespace Classification
{
    [Serializable]
    internal class BayesClass
    {
        public string Name { get; set; }

        public int DocumentsCount { get; set; }

        public IDictionary<string, int> UniqueWords { get; set; }
    }
}
