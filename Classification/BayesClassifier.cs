using System;
using System.Collections.Generic;
using System.Linq;

namespace Classification
{
    class BayesClassifier
    {
        private BayesClassList bayesClassList = new BayesClassList();
        

        private double GetPossibility(string word, string className)
        {
            var classInstance = bayesClassList.GetInstanceByName(className);
            if (classInstance == null)
            {
                classInstance = bayesClassList.AddWordToClass(word, className);
            }

            var documentsParameter = Math.Log((double)classInstance.DocumentsCount / bayesClassList.TotalDocumentsCount);

            return 0;
        }
    }
}
