using System.Windows.Forms;

namespace Classification
{
    public partial class MainForm : Form
    {
        private BayesClassifier bayesClassifier;

        public MainForm()
        {
            InitializeComponent();
            bayesClassifier = new BayesClassifier();
        }
    }
}
