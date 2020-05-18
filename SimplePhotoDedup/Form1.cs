using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplePhotoDedup
{
    public partial class MainForm : Form
    {
        const string WebSite = "https://github.com/thecoderok";
        private PhotoDeduplicator deduplicator;

        public MainForm()
        {
            InitializeComponent();
            this.WebsiteLabel.Text = WebSite;
            this.deduplicator = new PhotoDeduplicator();
            this.StatusLabel.Text = deduplicator.CurrentStatus.ToString();
            this.deduplicator.StatusChangeEvent += Deduplicator_StatusChangeEvent;
        }

        private void Deduplicator_StatusChangeEvent(Status newStatus)
        {
            this.StatusLabel.Text = newStatus.ToString();
        }

        private void WebsiteLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(WebSite);
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (this.selectedDirectoriesList.Items.Contains(folderBrowserDialog.SelectedPath))
            {
                // Such folder already selected
                return;
            }
            this.selectedDirectoriesList.Items.Add(folderBrowserDialog.SelectedPath);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            this.IdleComponentsPanel.Enabled = false;
            this.RunningStatusPanel.Enabled = true;
            var directories = new HashSet<string>();
            foreach (object item in this.selectedDirectoriesList.Items)
            {
                directories.Add(item.ToString());
            }
            this.deduplicator.Run(directories);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.IdleComponentsPanel.Enabled = true;
            this.RunningStatusPanel.Enabled = false;
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            this.selectedDirectoriesList.Items.Clear();
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            if (this.selectedDirectoriesList.SelectedItem != null)
            {
                this.selectedDirectoriesList.Items.Remove(this.selectedDirectoriesList.SelectedItem);
            }
        }
    }
}
