using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classification
{
    class BayesClassifier
    {
        public int TotalDocumentsCount { get { return bayesClassList.Select(x => x.DocumentsCount).Sum(); } }
        public int TotalWordsCount { get { return bayesClassList.Select(x => x.UniqueWords.Count).Sum(); } }

        public IEnumerable<string> ClassNames { get { return bayesClassList.Select(x => x.Name); } }

        private const string FileName = "dumb.dat";
        private const int MinimalWordsLength = 2;

        private BayesClassList bayesClassList { get; set; }

        public BayesClassifier()
        {
            bayesClassList = new BayesClassList();
            Load();
        }

        ~BayesClassifier()
        {
            Save();
        }

        public string GetPossibleClass(string document)
        {
            var possibleClassName = "";
            var possibility = 0.0;
            foreach (var classInstance in bayesClassList)
            {
                var documentsParameter = Math.Log((double)classInstance.DocumentsCount / TotalDocumentsCount);
                var wordsParameter = 0.0;
                foreach (var word in document.Split(' ').Where(x => x.Length > MinimalWordsLength))
                {
                    var wordAppearingCount = classInstance.UniqueWords.ContainsKey(word) ? classInstance.UniqueWords[word] + 1 : 1;
                    wordsParameter += Math.Log(wordAppearingCount / (double)(TotalWordsCount + classInstance.UniqueWords.Count));
                }
                var classPossiblity = documentsParameter + wordsParameter;
                if (classPossiblity > possibility)
                {
                    possibility = classPossiblity;
                    possibleClassName = classInstance.Name;
                }
            }
            return possibleClassName;
        }

        public void AddDocumentToClass(string document, string className)
        {
            var classInstance = bayesClassList.FirstOrDefault(x => x.Name == className);
            if (className == null)
            {
                classInstance = new BayesClass();
                bayesClassList.Add(classInstance);
            }
            var words = document.Split(' ').Where(x => x.Length > MinimalWordsLength);
            foreach (var word in words)
            {
                AddWordToClass(word, classInstance);
            }
            classInstance.DocumentsCount++;
        }

        private void Save()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(fs, bayesClassList);
            }
        }

        private void Load()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                try
                {
                    bayesClassList = (BayesClassList)new BinaryFormatter().Deserialize(fs);
                }
                catch
                {
                    bayesClassList = new BayesClassList();
                }
            }
        }

        private void AddWordToClass(string word, BayesClass classInstance)
        {
            if (classInstance.UniqueWords.ContainsKey(word))
            {
                classInstance.UniqueWords[word]++;
            }
            else
            {
                classInstance.UniqueWords.Add(word, 1);
            }
        }
    }
}
