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

        private void getClassButton_Click(object sender, System.EventArgs e)
        {
            var document = documentTextBox.Text;
            var possibleClass = bayesClassifier.GetPossibleClass(document);
            MessageBox.Show($"The most possible class is {possibleClass}");
        }

        private void teachButton_Click(object sender, System.EventArgs e)
        {
            if (classBox.SelectedIndex == -1 || (string) classBox.SelectedItem == "")
            {
                MessageBox.Show("Target class needs to be choosen");
                return;
            }
            var document = documentTextBox.Text;
            var className = (string) classBox.SelectedItem;
            bayesClassifier.AddDocumentToClass(document, className);
        }
    }
}
