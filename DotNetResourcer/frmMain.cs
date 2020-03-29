using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DotNetResourcer
{
    public partial class frmMain : Form
    {
        Dictionary<string, string> ReplaceLetters = new Dictionary<string, string>();

        private void LoadSettings()
        {
            #region SettingsFilePath
            if (File.Exists(Settings.SettingsFilePath))
            {
                try
                {
                    string savedSettings = File.ReadAllText(Settings.SettingsFilePath);

                    string[] settings = savedSettings.Split('#');
                    string controlName = string.Empty;
                    object value = null;

                    for (int i = 0; i < settings.Length; i++)
                    {
                        try
                        {
                            controlName = settings[i].Split('|')[0];
                            value = settings[i].Split('|')[1];

                            if (controlName.Equals("chkKeepOnTop"))
                            {
                                this.TopMost = value.ToString().ToLower().Equals("true");
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {
                }
            }
            #endregion

            #region LettersFilePath
            if (File.Exists(Settings.LettersFilePath))
            {
                ReplaceLetters = new Dictionary<string, string>();

                DataSet ds = new DataSet();

                try
                {
                    ds.ReadXml(Settings.LettersFilePath);

                    if (ds != null
                        && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow row in dt.Rows)
                        {
                            ReplaceLetters.Add(row[0].ToString(), row[1].ToString());
                        }
                    }
                }
                catch
                {

                }
            }
            #endregion
        }

        private string ConvertKey(string text)
        {
            foreach (var item in ReplaceLetters)
            {
                text = text.Replace(item.Key, item.Value);
            }

            text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());

            foreach (var item in ReplaceLetters)
            {
                text = text.Replace(item.Key, item.Value);
            }

            char[] letters = text.Where(c => Settings.LegalLetters.Contains(c)).ToArray();

            text = new string(letters);

            do
            {
                text = text.Replace(" ", string.Empty);
            } while (text.Contains(" "));

            if (text.Length > 0
                && Settings.Numbers.Contains(text[0]))
            {
                text = "_" + text;
            }
            return text;
        }

        public frmMain()
        {
            InitializeComponent();

            //txtText.Multiline = false;
            //txtText.AutoSize = false;
            //txtText.Height = 85;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();

            lblTextMaxLength.Text = txtText.MaxLength.ToString();

            this.ActiveControl = txtText;
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            txtText.Text = txtText.Text.Replace(Environment.NewLine, "");
            txtKey.Text = this.ConvertKey(txtText.Text);

            lblTextMaxLength.Text = (txtText.MaxLength - txtText.TextLength).ToString();
        }
        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtText.Text = Clipboard.GetText();
        }

        private void btnCopyForResource_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtKey.Text + "\t" + txtText.Text);
        }
        private void btnCopyForCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPrefix.Text))
            {
                Clipboard.SetText(txtPrefix.Text + "." + txtKey.Text);
            }
            else
            {
                Clipboard.SetText(txtKey.Text);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog(this);

            LoadSettings();

            txtKey.Text = this.ConvertKey(txtText.Text);
        }
    }
}