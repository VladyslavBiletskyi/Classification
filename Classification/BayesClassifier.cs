namespace Classification
{
    class BayesClassifier
    {
        private BayesClassList bayesClassList = new BayesClassList();

        public BayesClassifier()
        {
            bayesClassList = new BayesClassList();
            bayesClassList.Load();
        }

        ~BayesClassifier()
        {
            bayesClassList.Save();
        }

        public void Teach(string document, string className)
        {
            bayesClassList.AddDocumentToClass(document, className);
        }

        public string GetPossibleClass(string document)
        {
            return bayesClassList.GetPossibleClass(document);
        }
    }
}
