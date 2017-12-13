using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classification
{
    internal class BayesClassList
    {
        public int TotalDocumentsCount { get { return Classes.Select(x => x.DocumentsCount).Sum(); } }
        public int TotalWordsCount { get { return Classes.Select(x => x.UniqueWords.Count).Sum(); } }

        private List<BayesClass> Classes { get; set; }

        private const string FileName = "dumb.dat";
        private const int MinimalWordsLength = 2;

        public string GetPossibleClass(string document)
        {
            var possibleClassName = "";
            var possibility = 0.0;
            foreach (var classInstance in Classes)
            {
                var documentsParameter = Math.Log((double) classInstance.DocumentsCount / TotalDocumentsCount);
                var wordsParameter = 0.0;
                foreach (var word in document.Split(' ').Where(x => x.Length > MinimalWordsLength))
                {
                    var wordAppearingCount = classInstance.UniqueWords.ContainsKey(word)? classInstance.UniqueWords[word] + 1 : 1;
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
            var classInstance = Classes.FirstOrDefault(x => x.Name == className);
            if (className == null)
            {
                classInstance = new BayesClass();
                Classes.Add(classInstance);
            }
            var words = document.Split(' ').Where(x => x.Length > MinimalWordsLength);
            foreach (var word in words)
            {
                AddWordToClass(word, classInstance);
            }
            classInstance.DocumentsCount++;
        }

        public BayesClass GetInstanceByName(string name)
        {
            return Classes.FirstOrDefault(x => x.Name == name);
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(fs, Classes);
            }
        }

        public void Load()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                try
                {
                    Classes = (List<BayesClass>) new BinaryFormatter().Deserialize(fs);
                }
                catch
                {
                    Classes = new List<BayesClass>();
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
