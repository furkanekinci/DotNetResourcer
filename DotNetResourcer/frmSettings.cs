using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DotNetResourcer
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();

            lblLegalLetters.Text = Settings.LegalLetters;
        }
        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grdReplaceMapTable.CurrentCell.ColumnIndex == 1
                && Settings.LegalLetters.Contains(grdReplaceMapTable.CurrentCell.EditedFormattedValue.ToString()))
            {
                grdReplaceMapTable.EndEdit();
            }
            else
            {
                grdReplaceMapTable.CurrentCell.Value = DBNull.Value;
                grdReplaceMapTable.CancelEdit();
            }

            SaveSettings();
        }

        private void LoadSettings()
        {
            #region SettingsFilePath
            if (File.Exists(Settings.SettingsFilePath))
            {
                try
                {
                    string lastSession = File.ReadAllText(Settings.SettingsFilePath);

                    string[] settings = lastSession.Split('#');
                    string controlName = string.Empty;
                    object value = null;

                    for (int i = 0; i < settings.Length; i++)
                    {
                        try
                        {
                            controlName = settings[i].Split('|')[0];
                            value = settings[i].Split('|')[1];

                            Control cont = this.Controls.Find(controlName, true)[0];

                            if (cont.GetType() == typeof(CheckBox))
                            {
                                (cont as CheckBox).Checked = Convert.ToBoolean(value);
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
                DataSet ds = new DataSet();

                try
                {
                    ds.ReadXml(Settings.LettersFilePath);

                    if (ds != null
                        && ds.Tables.Count > 0)
                    {
                        grdReplaceMapTable.Columns.Clear();

                        grdReplaceMapTable.DataSource = ds.Tables[0];
                    }
                }
                catch
                {

                }
            }
            #endregion
        }
        private void SaveSettings()
        {
            try
            {
                string settings = string.Empty;

                foreach (Control item in this.Controls)
                {
                    if (item.GetType() == typeof(CheckBox))
                    {
                        settings += string.Format("{0}|{1}#", item.Name, (item as CheckBox).Checked);
                    }
                }

                File.WriteAllText(Settings.SettingsFilePath, settings);
            }
            catch
            {

            }

            try
            {
                DataTable data = Settings.GetContentAsDataTable(grdReplaceMapTable);

                if (data != null)
                {
                    data.WriteXml(Settings.LettersFilePath);
                }
            }
            catch
            {

            }
        }

        private void grdReplaceMapTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1
                && !Settings.LegalLetters.Contains(e.FormattedValue.ToString()))
            {
                lblLegalLetters.ForeColor = System.Drawing.Color.Red;
                lblLegalLetters.Font = new System.Drawing.Font(lblLegalLetters.Font, System.Drawing.FontStyle.Bold);
                e.Cancel = true;
            }
            else
            {
                lblLegalLetters.ForeColor = System.Drawing.Color.Black;
                lblLegalLetters.Font = new System.Drawing.Font(lblLegalLetters.Font, System.Drawing.FontStyle.Regular);
            }
        }
    }
}