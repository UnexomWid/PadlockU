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
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PadlockU
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Strength.SelectedItem = "Default";
        }

        #region Fields

        private ICryptoTransform Cipher;

        #endregion

        #region Events

        private void FileRadio_CheckedChanged(object sender, EventArgs e)
        {
            Folder.Enabled = !FileRadio.Checked;
            Folder.Refresh();

            SelectFolderButton.Enabled = !FileRadio.Checked;
            SelectFolderButton.Refresh();

            File.Enabled = FileRadio.Checked;
            File.Refresh();

            SelectFileButton.Enabled = FileRadio.Checked;
            SelectFileButton.Refresh();
        }
        private void ShowButton_Click(object sender, EventArgs e)
        {
            if(Key.UseSystemPasswordChar)
            {
                ShowButton.Text = "Hide";
                ShowButton.Refresh();
                Key.UseSystemPasswordChar = false;
            }
            else
            {
                ShowButton.Text = "Show";
                ShowButton.Refresh();
                Key.UseSystemPasswordChar = true;
            }

            Key.Refresh();
        }
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if(SelectFile.ShowDialog() == DialogResult.OK)
            {
                File.Text = SelectFile.FileName;
                File.Refresh();
            }
        }
        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            if (SelectFolder.ShowDialog() == DialogResult.OK)
            {
                Folder.Text = SelectFolder.SelectedPath;
                Folder.Refresh();
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        #endregion

        #region Work

        private void StartButton_Click(object sender, EventArgs e)
        {
            Thread MainWorker = new Thread(StartWork);
            MainWorker.Start();
        }

        private void StartWork()
        {
            try
            {
                bool eRR = false;

                #region CheckInput

                if (FileRadio.Checked)
                {
                    if (!System.IO.File.Exists(File.Text))
                    {
                        MessageBox.Show("Invalid input file!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        eRR = true;
                    }
                }
                else if (!System.IO.Directory.Exists(Folder.Text))
                {
                    MessageBox.Show("Invalid input folder!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eRR = true;
                }

                #endregion

                #region CheckKey

                if (!eRR && (String.IsNullOrEmpty(Key.Text) || String.IsNullOrWhiteSpace(Key.Text)))
                {
                    MessageBox.Show("Invalid Key!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eRR = true;
                }

                #endregion

                if (!eRR)
                {
                    ChangeControlStatus(false);
                    if (FileRadio.Checked)
                    {
                        ChangeProgress(0);
                        ChangeProgressMaximum(2);

                        ChangeStatus("Preparing cipher...");

                        PrepareCipher();

                        ProcessFile(File.Text);

                        IncrementProgress();

                        ChangeStatus("Idle");
                    }
                    else
                    {
                        ChangeProgress(0);

                        ChangeStatus("Parsing files...");

                        string[] files = System.IO.Directory.EnumerateFiles(Folder.Text, "*", SearchOption.AllDirectories).ToArray();

                        ChangeProgressMaximum(1 + files.Length);

                        ChangeStatus("Preparing cipher...");

                        PrepareCipher();

                        foreach(string file in files)
                            ProcessFile(file);

                        IncrementProgress();

                        ChangeStatus("Idle");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred!\r\nCode:\r\n" + ex.ToString());
            }
            finally
            {
                ChangeControlStatus(true);
            }
        }

        private void ProcessFile(string fPath)
        {
            if(Encrypt.Checked)
            {
                bool doEnc = true;

                IncrementProgress();

                ChangeStatus("Working on " + Helper.SafeFileName(fPath) + "...");

                if(fPath.Substring(fPath.Length - 4, 4).ToLower().Equals(".pad"))
                {
                    if (MessageBox.Show("The following file might already be encrypted:\r\n" + fPath + "\r\nIf you encrypt again,it can become corrupted and can NOT be recovered.\r\nContinue?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        doEnc = false;
                }

                if(doEnc)
                {
                    try
                    {
                        Helper.RunAESAlgorithm(Helper.Action.Encrypt, fPath, fPath + ".pad", Cipher);
                    }
                    catch
                    {
                        try { System.IO.File.Delete(fPath + ".pad"); } catch { }
                        MessageBox.Show("An error has occurred while processing the following file:\r\n" + fPath + "\r\nThe file might pe too large.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                bool doDec = true;

                IncrementProgress();

                ChangeStatus("Working on " + Helper.SafeFileName(fPath) + "...");

                if (!(fPath.Substring(fPath.Length - 4, 4).ToLower().Equals(".pad")))
                {
                    // Invalid file.
                    doDec = false;
                }

                if (doDec)
                {
                    try
                    {
                        Helper.RunAESAlgorithm(Helper.Action.Decrypt, fPath, fPath.Substring(0, fPath.Length - 4), Cipher);
                    }
                    catch
                    {
                        try { System.IO.File.Delete(fPath.Substring(0, fPath.Length - 4)); } catch { }
                        MessageBox.Show("An error has occurred while processing the following file:\r\n" + fPath + "\r\nThe key or strength is invalid, or the file is corrupted.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Preparation

        private string PrepareKey()
        {
            string selectedStrength = "";
            string key = "";
            Invoke(new Action(() => {
                selectedStrength = Strength.SelectedItem as string;
                key = Key.Text;
            }));

            if (selectedStrength.Equals("Weak"))
                return Key.Text;
            if (selectedStrength.Equals("Normal") || selectedStrength.Equals("Default"))
                return Helper.GetSHA1(Encoding.UTF8.GetBytes(key));
            if (selectedStrength.Equals("Tough"))
                return Helper.GetSHA256(Encoding.UTF8.GetBytes(key));
            if (selectedStrength.Equals("Very Tough"))
                return Helper.GetSHA384(Encoding.UTF8.GetBytes(key));
            return Helper.GetSHA512(Encoding.UTF8.GetBytes(key));
        }

        private void PrepareCipher()
        {
            Cipher = Encrypt.Checked ? Helper.GetCipher(PrepareKey()).CreateEncryptor() : Helper.GetCipher(PrepareKey()).CreateDecryptor();
        }

        #endregion

        #region Control Updates

        private void ChangeControlStatus(bool status)
        {
            Invoke(new Action(() =>
            {
                InputGroup.Enabled = status;
                ModeGroup.Enabled = status;
                KeyGroup.Enabled = status;
                StrengthGroup.Enabled = status;
                StartButton.Enabled = status;
                StartButton.Text = status ? "Start" : "Working";

                InputGroup.Refresh();
                ModeGroup.Refresh();
                KeyGroup.Refresh();
                StrengthGroup.Refresh();
                StartButton.Refresh();
            }));
        }

        private void ChangeStatus(string status)
        {
            Invoke(new Action(() =>
            {
                Status.Text = status;
                Status.Refresh();
            }));
        }

        private void ChangeProgress(int progress)
        {
            Invoke(new Action(() =>
            {
                Progress.Value = progress;
                Progress.Refresh();
            }));
        }

        private void ChangeProgressMaximum(int max)
        {
            Invoke(new Action(() =>
            {
                Progress.Maximum = max;
                Progress.Refresh();
            }));
        }

        private void IncrementProgress()
        {
            Invoke(new Action(() =>
            {
                ++Progress.Value;
                Progress.Refresh();
            }));
        }

        #endregion
    }
}
