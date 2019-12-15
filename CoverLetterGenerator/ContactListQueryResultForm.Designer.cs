namespace CoverLetterGenerator
{
    partial class ContactListQueryResultForm
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
            this.dataGridView_CLM = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBox_CLM_QueryResults = new System.Windows.Forms.ListBox();
            this.button_CLM_Bring = new System.Windows.Forms.Button();
            this.label_CLM_ItemCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CLM)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_CLM
            // 
            this.dataGridView_CLM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CLM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Value});
            this.dataGridView_CLM.Location = new System.Drawing.Point(699, 48);
            this.dataGridView_CLM.Name = "dataGridView_CLM";
            this.dataGridView_CLM.RowTemplate.Height = 24;
            this.dataGridView_CLM.Size = new System.Drawing.Size(345, 494);
            this.dataGridView_CLM.TabIndex = 0;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // listBox_CLM_QueryResults
            // 
            this.listBox_CLM_QueryResults.FormattingEnabled = true;
            this.listBox_CLM_QueryResults.ItemHeight = 16;
            this.listBox_CLM_QueryResults.Location = new System.Drawing.Point(38, 48);
            this.listBox_CLM_QueryResults.Name = "listBox_CLM_QueryResults";
            this.listBox_CLM_QueryResults.Size = new System.Drawing.Size(328, 388);
            this.listBox_CLM_QueryResults.TabIndex = 1;
            this.listBox_CLM_QueryResults.SelectedIndexChanged += new System.EventHandler(this.listBox_CLM_QueryResults_SelectedIndexChanged);
            // 
            // button_CLM_Bring
            // 
            this.button_CLM_Bring.Location = new System.Drawing.Point(436, 68);
            this.button_CLM_Bring.Name = "button_CLM_Bring";
            this.button_CLM_Bring.Size = new System.Drawing.Size(75, 23);
            this.button_CLM_Bring.TabIndex = 2;
            this.button_CLM_Bring.Text = "Bring";
            this.button_CLM_Bring.UseVisualStyleBackColor = true;
            this.button_CLM_Bring.Click += new System.EventHandler(this.button_CLM_Bring_Click);
            // 
            // label_CLM_ItemCount
            // 
            this.label_CLM_ItemCount.AutoSize = true;
            this.label_CLM_ItemCount.Location = new System.Drawing.Point(131, 464);
            this.label_CLM_ItemCount.Name = "label_CLM_ItemCount";
            this.label_CLM_ItemCount.Size = new System.Drawing.Size(16, 17);
            this.label_CLM_ItemCount.TabIndex = 7;
            this.label_CLM_ItemCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Count:";
            // 
            // ContactListQueryResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 716);
            this.Controls.Add(this.label_CLM_ItemCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_CLM_Bring);
            this.Controls.Add(this.listBox_CLM_QueryResults);
            this.Controls.Add(this.dataGridView_CLM);
            this.Name = "ContactListQueryResultForm";
            this.Text = "ContactListQueryResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CLM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_CLM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.ListBox listBox_CLM_QueryResults;
        private System.Windows.Forms.Button button_CLM_Bring;
        private System.Windows.Forms.Label label_CLM_ItemCount;
        private System.Windows.Forms.Label label1;
    }
}