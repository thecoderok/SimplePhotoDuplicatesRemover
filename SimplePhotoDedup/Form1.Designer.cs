namespace SimplePhotoDedup
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.CurrentlyProcessingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.WebsiteLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectedDirectoriesList = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DeleteSelectedButton = new System.Windows.Forms.Button();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.RunningStatusPanel = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.IdleComponentsPanel = new System.Windows.Forms.Panel();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.RunningStatusPanel.SuspendLayout();
            this.IdleComponentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText,
            this.StatusLabel,
            this.ProgressBar,
            this.CurrentlyProcessingLabel,
            this.WebsiteLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 688);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(45, 17);
            this.StatusText.Text = "Status: ";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(42, 17);
            this.StatusLabel.Text = "<Idle>";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // CurrentlyProcessingLabel
            // 
            this.CurrentlyProcessingLabel.Name = "CurrentlyProcessingLabel";
            this.CurrentlyProcessingLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // WebsiteLabel
            // 
            this.WebsiteLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.WebsiteLabel.IsLink = true;
            this.WebsiteLabel.Name = "WebsiteLabel";
            this.WebsiteLabel.Size = new System.Drawing.Size(589, 17);
            this.WebsiteLabel.Spring = true;
            this.WebsiteLabel.Text = "https://github.com/thecoderok";
            this.WebsiteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WebsiteLabel.Click += new System.EventHandler(this.WebsiteLabel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 688);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.IdleComponentsPanel);
            this.panel2.Controls.Add(this.RunningStatusPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 688);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(352, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 688);
            this.panel3.TabIndex = 1;
            // 
            // selectedDirectoriesList
            // 
            this.selectedDirectoriesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedDirectoriesList.FormattingEnabled = true;
            this.selectedDirectoriesList.Location = new System.Drawing.Point(0, 0);
            this.selectedDirectoriesList.Name = "selectedDirectoriesList";
            this.selectedDirectoriesList.Size = new System.Drawing.Size(352, 563);
            this.selectedDirectoriesList.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(441, 688);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DeleteSelectedButton.Location = new System.Drawing.Point(0, 594);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(352, 31);
            this.DeleteSelectedButton.TabIndex = 2;
            this.DeleteSelectedButton.Text = "Delete Selected";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClearAllButton.Location = new System.Drawing.Point(0, 563);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(352, 31);
            this.ClearAllButton.TabIndex = 3;
            this.ClearAllButton.Text = "Clear all folders";
            this.ClearAllButton.UseVisualStyleBackColor = true;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.Location = new System.Drawing.Point(0, 625);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(352, 31);
            this.RunButton.TabIndex = 4;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // RunningStatusPanel
            // 
            this.RunningStatusPanel.Controls.Add(this.StopButton);
            this.RunningStatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RunningStatusPanel.Enabled = false;
            this.RunningStatusPanel.Location = new System.Drawing.Point(0, 656);
            this.RunningStatusPanel.Name = "RunningStatusPanel";
            this.RunningStatusPanel.Size = new System.Drawing.Size(352, 32);
            this.RunningStatusPanel.TabIndex = 5;
            // 
            // StopButton
            // 
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Location = new System.Drawing.Point(0, 1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(352, 31);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // IdleComponentsPanel
            // 
            this.IdleComponentsPanel.Controls.Add(this.SelectFolderButton);
            this.IdleComponentsPanel.Controls.Add(this.selectedDirectoriesList);
            this.IdleComponentsPanel.Controls.Add(this.ClearAllButton);
            this.IdleComponentsPanel.Controls.Add(this.DeleteSelectedButton);
            this.IdleComponentsPanel.Controls.Add(this.RunButton);
            this.IdleComponentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IdleComponentsPanel.Location = new System.Drawing.Point(0, 0);
            this.IdleComponentsPanel.Name = "IdleComponentsPanel";
            this.IdleComponentsPanel.Size = new System.Drawing.Size(352, 656);
            this.IdleComponentsPanel.TabIndex = 6;
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SelectFolderButton.Location = new System.Drawing.Point(0, 532);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(352, 31);
            this.SelectFolderButton.TabIndex = 5;
            this.SelectFolderButton.Text = "Select Folder with photos";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 710);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Simple Photo Deduplication";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.RunningStatusPanel.ResumeLayout(false);
            this.IdleComponentsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel WebsiteLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel CurrentlyProcessingLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox selectedDirectoriesList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button DeleteSelectedButton;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Panel RunningStatusPanel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Panel IdleComponentsPanel;
        private System.Windows.Forms.Button SelectFolderButton;
    }
}

