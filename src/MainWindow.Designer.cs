/*
 * PadlockU - an encryption application written in C# that uses the AES-256 algorithm.
 * Copyright (C) 2018-2019 UnexomWid

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
namespace PadlockU
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.InputGroup = new System.Windows.Forms.GroupBox();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.Folder = new System.Windows.Forms.TextBox();
            this.File = new System.Windows.Forms.TextBox();
            this.FolderRadio = new System.Windows.Forms.RadioButton();
            this.FileRadio = new System.Windows.Forms.RadioButton();
            this.ModeGroup = new System.Windows.Forms.GroupBox();
            this.Decrypt = new System.Windows.Forms.RadioButton();
            this.Encrypt = new System.Windows.Forms.RadioButton();
            this.KeyGroup = new System.Windows.Forms.GroupBox();
            this.ShowButton = new System.Windows.Forms.Button();
            this.Key = new System.Windows.Forms.TextBox();
            this.StrengthGroup = new System.Windows.Forms.GroupBox();
            this.Strength = new System.Windows.Forms.ComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ProgressGroup = new System.Windows.Forms.GroupBox();
            this.Status = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.SelectFile = new System.Windows.Forms.OpenFileDialog();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.InputGroup.SuspendLayout();
            this.ModeGroup.SuspendLayout();
            this.KeyGroup.SuspendLayout();
            this.StrengthGroup.SuspendLayout();
            this.ProgressGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputGroup
            // 
            this.InputGroup.Controls.Add(this.SelectFolderButton);
            this.InputGroup.Controls.Add(this.SelectFileButton);
            this.InputGroup.Controls.Add(this.Folder);
            this.InputGroup.Controls.Add(this.File);
            this.InputGroup.Controls.Add(this.FolderRadio);
            this.InputGroup.Controls.Add(this.FileRadio);
            this.InputGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.InputGroup.Location = new System.Drawing.Point(12, 12);
            this.InputGroup.Name = "InputGroup";
            this.InputGroup.Size = new System.Drawing.Size(309, 65);
            this.InputGroup.TabIndex = 0;
            this.InputGroup.TabStop = false;
            this.InputGroup.Text = "Input";
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Enabled = false;
            this.SelectFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFolderButton.Location = new System.Drawing.Point(236, 37);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(67, 21);
            this.SelectFolderButton.TabIndex = 5;
            this.SelectFolderButton.Text = "Select";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFileButton.Location = new System.Drawing.Point(236, 15);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(67, 21);
            this.SelectFileButton.TabIndex = 4;
            this.SelectFileButton.Text = "Select";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // Folder
            // 
            this.Folder.BackColor = System.Drawing.Color.White;
            this.Folder.Enabled = false;
            this.Folder.Location = new System.Drawing.Point(83, 37);
            this.Folder.Name = "Folder";
            this.Folder.ReadOnly = true;
            this.Folder.Size = new System.Drawing.Size(147, 21);
            this.Folder.TabIndex = 3;
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.White;
            this.File.Location = new System.Drawing.Point(83, 15);
            this.File.Name = "File";
            this.File.ReadOnly = true;
            this.File.Size = new System.Drawing.Size(147, 21);
            this.File.TabIndex = 2;
            // 
            // FolderRadio
            // 
            this.FolderRadio.AutoSize = true;
            this.FolderRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FolderRadio.Location = new System.Drawing.Point(6, 38);
            this.FolderRadio.Name = "FolderRadio";
            this.FolderRadio.Size = new System.Drawing.Size(63, 19);
            this.FolderRadio.TabIndex = 1;
            this.FolderRadio.Text = "Folder:";
            this.FolderRadio.UseVisualStyleBackColor = true;
            // 
            // FileRadio
            // 
            this.FileRadio.AutoSize = true;
            this.FileRadio.Checked = true;
            this.FileRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FileRadio.Location = new System.Drawing.Point(6, 16);
            this.FileRadio.Name = "FileRadio";
            this.FileRadio.Size = new System.Drawing.Size(48, 19);
            this.FileRadio.TabIndex = 0;
            this.FileRadio.TabStop = true;
            this.FileRadio.Text = "File:";
            this.FileRadio.UseVisualStyleBackColor = true;
            this.FileRadio.CheckedChanged += new System.EventHandler(this.FileRadio_CheckedChanged);
            // 
            // ModeGroup
            // 
            this.ModeGroup.Controls.Add(this.Decrypt);
            this.ModeGroup.Controls.Add(this.Encrypt);
            this.ModeGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ModeGroup.Location = new System.Drawing.Point(327, 12);
            this.ModeGroup.Name = "ModeGroup";
            this.ModeGroup.Size = new System.Drawing.Size(80, 65);
            this.ModeGroup.TabIndex = 1;
            this.ModeGroup.TabStop = false;
            this.ModeGroup.Text = "Mode";
            // 
            // Decrypt
            // 
            this.Decrypt.AutoSize = true;
            this.Decrypt.Location = new System.Drawing.Point(6, 37);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(66, 19);
            this.Decrypt.TabIndex = 1;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            // 
            // Encrypt
            // 
            this.Encrypt.AutoSize = true;
            this.Encrypt.Checked = true;
            this.Encrypt.Location = new System.Drawing.Point(6, 15);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(65, 19);
            this.Encrypt.TabIndex = 0;
            this.Encrypt.TabStop = true;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            // 
            // KeyGroup
            // 
            this.KeyGroup.Controls.Add(this.ShowButton);
            this.KeyGroup.Controls.Add(this.Key);
            this.KeyGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.KeyGroup.Location = new System.Drawing.Point(12, 80);
            this.KeyGroup.Name = "KeyGroup";
            this.KeyGroup.Size = new System.Drawing.Size(195, 44);
            this.KeyGroup.TabIndex = 2;
            this.KeyGroup.TabStop = false;
            this.KeyGroup.Text = "Key";
            // 
            // ShowButton
            // 
            this.ShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowButton.Location = new System.Drawing.Point(144, 17);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(45, 19);
            this.ShowButton.TabIndex = 1;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // Key
            // 
            this.Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key.Location = new System.Drawing.Point(6, 18);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(132, 20);
            this.Key.TabIndex = 0;
            this.Key.UseSystemPasswordChar = true;
            // 
            // StrengthGroup
            // 
            this.StrengthGroup.Controls.Add(this.Strength);
            this.StrengthGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.StrengthGroup.Location = new System.Drawing.Point(213, 80);
            this.StrengthGroup.Name = "StrengthGroup";
            this.StrengthGroup.Size = new System.Drawing.Size(108, 44);
            this.StrengthGroup.TabIndex = 3;
            this.StrengthGroup.TabStop = false;
            this.StrengthGroup.Text = "Strength";
            // 
            // Strength
            // 
            this.Strength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Strength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Strength.FormattingEnabled = true;
            this.Strength.Items.AddRange(new object[] {
            "Default",
            "Weak",
            "Normal",
            "Tough",
            "Very Tough",
            "Extreme"});
            this.Strength.Location = new System.Drawing.Point(5, 16);
            this.Strength.Name = "Strength";
            this.Strength.Size = new System.Drawing.Size(98, 23);
            this.Strength.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.StartButton.Location = new System.Drawing.Point(327, 83);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(80, 41);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ProgressGroup
            // 
            this.ProgressGroup.Controls.Add(this.Status);
            this.ProgressGroup.Controls.Add(this.StatusLabel);
            this.ProgressGroup.Controls.Add(this.Progress);
            this.ProgressGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ProgressGroup.Location = new System.Drawing.Point(12, 126);
            this.ProgressGroup.Name = "ProgressGroup";
            this.ProgressGroup.Size = new System.Drawing.Size(395, 59);
            this.ProgressGroup.TabIndex = 5;
            this.ProgressGroup.TabStop = false;
            this.ProgressGroup.Text = "Progress";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(48, 37);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(27, 15);
            this.Status.TabIndex = 2;
            this.Status.Text = "Idle";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusLabel.Location = new System.Drawing.Point(6, 37);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(44, 15);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Status:";
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(6, 18);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(383, 18);
            this.Progress.TabIndex = 0;
            // 
            // SelectFile
            // 
            this.SelectFile.Title = "Select File...";
            // 
            // SelectFolder
            // 
            this.SelectFolder.Description = "Select Folder...";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 193);
            this.Controls.Add(this.ProgressGroup);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StrengthGroup);
            this.Controls.Add(this.KeyGroup);
            this.Controls.Add(this.ModeGroup);
            this.Controls.Add(this.InputGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PadlockU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.InputGroup.ResumeLayout(false);
            this.InputGroup.PerformLayout();
            this.ModeGroup.ResumeLayout(false);
            this.ModeGroup.PerformLayout();
            this.KeyGroup.ResumeLayout(false);
            this.KeyGroup.PerformLayout();
            this.StrengthGroup.ResumeLayout(false);
            this.ProgressGroup.ResumeLayout(false);
            this.ProgressGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox InputGroup;
        private System.Windows.Forms.TextBox File;
        private System.Windows.Forms.RadioButton FolderRadio;
        private System.Windows.Forms.RadioButton FileRadio;
        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.TextBox Folder;
        private System.Windows.Forms.GroupBox ModeGroup;
        private System.Windows.Forms.RadioButton Decrypt;
        private System.Windows.Forms.RadioButton Encrypt;
        private System.Windows.Forms.GroupBox KeyGroup;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.GroupBox StrengthGroup;
        private System.Windows.Forms.ComboBox Strength;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox ProgressGroup;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.OpenFileDialog SelectFile;
        private System.Windows.Forms.FolderBrowserDialog SelectFolder;
    }
}