using System;
using System.Windows.Forms;

namespace SimplePhotoDedup
{
    public partial class MainForm : Form
    {
        const string WebSite = "https://github.com/thecoderok";
        public MainForm()
        {
            InitializeComponent();
            this.WebsiteLabel.Text = WebSite;
        }

        private void WebsiteLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(WebSite);
        }
    }
}
