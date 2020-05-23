using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplePhotoDedup
{
    public partial class MainForm : Form
    {
        const string WebSite = "https://github.com/thecoderok";
        private PhotoDeduplicator deduplicator;
        delegate void SetTextCallback(string text, ToolStripItem label);
        delegate void StatusChangeCallback(Status status);

        public MainForm()
        {
            InitializeComponent();
            this.WebsiteLabel.Text = WebSite;
            this.deduplicator = new PhotoDeduplicator();
            this.StatusLabel.Text = deduplicator.CurrentStatus.ToString();
            this.deduplicator.StatusChangeEvent += Deduplicator_StatusChangeEvent;
            this.selectedDirectoriesList.Items.Add(@"E:\temp");
        }

        private void Deduplicator_StatusChangeEvent(Status newStatus)
        {
            if (this.InvokeRequired)
            {
                StatusChangeCallback d = new StatusChangeCallback(Deduplicator_StatusChangeEvent);
                this.Invoke(d, new object[] { newStatus });
            } else
            {
                this.SetText(newStatus.ToString(), this.StatusLabel);
                this.EnableIdleState();
            }
        }

        private void SetText(string text, ToolStripItem label)
        {
            if (this.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, label });
            } 
            else
            {
                label.Text = text;
            }
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
            this.EnableIdleState();
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

        private void EnableIdleState()
        {
            this.IdleComponentsPanel.Enabled = true;
            this.RunningStatusPanel.Enabled = false;
        }
    }
}
