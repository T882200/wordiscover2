namespace ProximitySearchAddin
{
    partial class ProximitySearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchTerm1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchTerm2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericParaProximity = new System.Windows.Forms.NumericUpDown();
            this.chkParaProximity = new System.Windows.Forms.CheckBox();
            this.numericWordProximity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLogicalNot = new System.Windows.Forms.CheckBox();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listResults = new System.Windows.Forms.ListView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnClearHighlights = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericParaProximity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWordProximity)).BeginInit();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Term 1:";
            //
            // txtSearchTerm1
            //
            this.txtSearchTerm1.Location = new System.Drawing.Point(15, 31);
            this.txtSearchTerm1.Name = "txtSearchTerm1";
            this.txtSearchTerm1.Size = new System.Drawing.Size(250, 20);
            this.txtSearchTerm1.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search Term 2:";
            //
            // txtSearchTerm2
            //
            this.txtSearchTerm2.Location = new System.Drawing.Point(15, 74);
            this.txtSearchTerm2.Name = "txtSearchTerm2";
            this.txtSearchTerm2.Size = new System.Drawing.Size(250, 20);
            this.txtSearchTerm2.TabIndex = 3;
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.numericParaProximity);
            this.groupBox1.Controls.Add(this.chkParaProximity);
            this.groupBox1.Controls.Add(this.numericWordProximity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkLogicalNot);
            this.groupBox1.Controls.Add(this.chkCaseSensitive);
            this.groupBox1.Location = new System.Drawing.Point(15, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            //
            // numericParaProximity
            //
            this.numericParaProximity.Enabled = false;
            this.numericParaProximity.Location = new System.Drawing.Point(178, 114);
            this.numericParaProximity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericParaProximity.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericParaProximity.Name = "numericParaProximity";
            this.numericParaProximity.Size = new System.Drawing.Size(50, 20);
            this.numericParaProximity.TabIndex = 6;
            this.numericParaProximity.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            //
            // chkParaProximity
            //
            this.chkParaProximity.AutoSize = true;
            this.chkParaProximity.Location = new System.Drawing.Point(12, 115);
            this.chkParaProximity.Name = "chkParaProximity";
            this.chkParaProximity.Size = new System.Drawing.Size(127, 17);
            this.chkParaProximity.TabIndex = 5;
            this.chkParaProximity.Text = "Paragraph Proximity:";
            this.chkParaProximity.UseVisualStyleBackColor = true;
            this.chkParaProximity.CheckedChanged += new System.EventHandler(this.chkParaProximity_CheckedChanged);
            //
            // numericWordProximity
            //
            this.numericWordProximity.Location = new System.Drawing.Point(178, 85);
            this.numericWordProximity.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericWordProximity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWordProximity.Name = "numericWordProximity";
            this.numericWordProximity.Size = new System.Drawing.Size(50, 20);
            this.numericWordProximity.TabIndex = 4;
            this.numericWordProximity.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Para";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Word Proximity:";
            //
            // chkLogicalNot
            //
            this.chkLogicalNot.AutoSize = true;
            this.chkLogicalNot.Location = new System.Drawing.Point(12, 54);
            this.chkLogicalNot.Name = "chkLogicalNot";
            this.chkLogicalNot.Size = new System.Drawing.Size(127, 17);
            this.chkLogicalNot.TabIndex = 1;
            this.chkLogicalNot.Text = "Logical NOT (exclude)";
            this.chkLogicalNot.UseVisualStyleBackColor = true;
            //
            // chkCaseSensitive
            //
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Location = new System.Drawing.Point(12, 25);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(96, 17);
            this.chkCaseSensitive.TabIndex = 0;
            this.chkCaseSensitive.Text = "Case Sensitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            //
            // btnSearch
            //
            this.btnSearch.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(15, 265);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnCancel
            //
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(121, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // listResults
            //
            this.listResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(280, 15);
            this.listResults.MultiSelect = false;
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(505, 405);
            this.listResults.TabIndex = 9;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(15, 305);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(250, 20);
            this.progressBar.TabIndex = 7;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 335);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Ready";
            //
            // btnClearHighlights
            //
            this.btnClearHighlights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHighlights.Location = new System.Drawing.Point(15, 365);
            this.btnClearHighlights.Name = "btnClearHighlights";
            this.btnClearHighlights.Size = new System.Drawing.Size(120, 25);
            this.btnClearHighlights.TabIndex = 10;
            this.btnClearHighlights.Text = "Clear Highlights";
            this.btnClearHighlights.UseVisualStyleBackColor = true;
            this.btnClearHighlights.Click += new System.EventHandler(this.btnClearHighlights_Click);
            //
            // ProximitySearchForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 435);
            this.Controls.Add(this.btnClearHighlights);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listResults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearchTerm2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchTerm1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 474);
            this.Name = "ProximitySearchForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proximity Search";
            this.Load += new System.EventHandler(this.ProximitySearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericParaProximity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWordProximity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchTerm1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchTerm2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.CheckBox chkLogicalNot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericWordProximity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericParaProximity;
        private System.Windows.Forms.CheckBox chkParaProximity;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listResults;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnClearHighlights;
    }
}
