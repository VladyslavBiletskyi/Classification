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

        private List<BayesClass> Classes { get; set; }

        private const string FileName = "dumb.dat";

        public BayesClass AddWordToClass(string word, string className)
        {
            var classInstance = Classes.FirstOrDefault(x => x.Name == className);
            if (className == null)
            {
                classInstance = new BayesClass();
                Classes.Add(classInstance);
            }
            if (classInstance.UniqueWords.ContainsKey(word))
            {
                classInstance.UniqueWords[word]++;
            }
            else
            {
                classInstance.UniqueWords.Add(word, 1);
            }
            return classInstance;
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
                Classes = (List<BayesClass>)new BinaryFormatter().Deserialize(fs);
            }
        }
    }
}
