namespace DotNetResourcer
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.grdReplaceMapTable = new System.Windows.Forms.DataGridView();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLegalLetters = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdReplaceMapTable)).BeginInit();
            this.SuspendLayout();
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.AutoSize = true;
            this.chkKeepOnTop.Location = new System.Drawing.Point(12, 12);
            this.chkKeepOnTop.Name = "chkKeepOnTop";
            this.chkKeepOnTop.Size = new System.Drawing.Size(90, 17);
            this.chkKeepOnTop.TabIndex = 0;
            this.chkKeepOnTop.Text = "Keep On Top";
            this.chkKeepOnTop.UseVisualStyleBackColor = true;
            // 
            // grdReplaceMapTable
            // 
            this.grdReplaceMapTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReplaceMapTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.From,
            this.To});
            this.grdReplaceMapTable.Location = new System.Drawing.Point(12, 35);
            this.grdReplaceMapTable.Name = "grdReplaceMapTable";
            this.grdReplaceMapTable.RowHeadersWidth = 30;
            this.grdReplaceMapTable.Size = new System.Drawing.Size(231, 354);
            this.grdReplaceMapTable.TabIndex = 1;
            this.grdReplaceMapTable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdReplaceMapTable_CellValidating);
            // 
            // From
            // 
            this.From.HeaderText = "From";
            this.From.Name = "From";
            // 
            // To
            // 
            this.To.FillWeight = 99F;
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.Width = 99;
            // 
            // lblLegalLetters
            // 
            this.lblLegalLetters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegalLetters.Location = new System.Drawing.Point(12, 392);
            this.lblLegalLetters.Name = "lblLegalLetters";
            this.lblLegalLetters.Size = new System.Drawing.Size(231, 49);
            this.lblLegalLetters.TabIndex = 2;
            this.lblLegalLetters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 450);
            this.Controls.Add(this.lblLegalLetters);
            this.Controls.Add(this.grdReplaceMapTable);
            this.Controls.Add(this.chkKeepOnTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(271, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(271, 489);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = ".Net Resourcer - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReplaceMapTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkKeepOnTop;
        private System.Windows.Forms.DataGridView grdReplaceMapTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.Label lblLegalLetters;
    }
}