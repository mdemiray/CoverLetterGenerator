namespace CoverLetterGenerator
{
    partial class QueryResultForm
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
            this.listBox_Query_Results = new System.Windows.Forms.ListBox();
            this.dataGridView_SelectedDB_item = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Bring = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ItemCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectedDB_item)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Query_Results
            // 
            this.listBox_Query_Results.FormattingEnabled = true;
            this.listBox_Query_Results.ItemHeight = 16;
            this.listBox_Query_Results.Location = new System.Drawing.Point(42, 55);
            this.listBox_Query_Results.Name = "listBox_Query_Results";
            this.listBox_Query_Results.Size = new System.Drawing.Size(248, 372);
            this.listBox_Query_Results.TabIndex = 1;
            this.listBox_Query_Results.SelectedIndexChanged += new System.EventHandler(this.listBox_Query_Results_SelectedIndexChanged);
            // 
            // dataGridView_SelectedDB_item
            // 
            this.dataGridView_SelectedDB_item.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_SelectedDB_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SelectedDB_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Value});
            this.dataGridView_SelectedDB_item.Location = new System.Drawing.Point(474, 55);
            this.dataGridView_SelectedDB_item.Name = "dataGridView_SelectedDB_item";
            this.dataGridView_SelectedDB_item.RowHeadersWidth = 50;
            this.dataGridView_SelectedDB_item.RowTemplate.Height = 24;
            this.dataGridView_SelectedDB_item.Size = new System.Drawing.Size(885, 732);
            this.dataGridView_SelectedDB_item.TabIndex = 2;
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
            // button_Bring
            // 
            this.button_Bring.Location = new System.Drawing.Point(318, 55);
            this.button_Bring.Name = "button_Bring";
            this.button_Bring.Size = new System.Drawing.Size(109, 36);
            this.button_Bring.TabIndex = 3;
            this.button_Bring.Text = "Bring";
            this.button_Bring.UseVisualStyleBackColor = true;
            this.button_Bring.Click += new System.EventHandler(this.button_Bring_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Count:";
            // 
            // label_ItemCount
            // 
            this.label_ItemCount.AutoSize = true;
            this.label_ItemCount.Location = new System.Drawing.Point(131, 453);
            this.label_ItemCount.Name = "label_ItemCount";
            this.label_ItemCount.Size = new System.Drawing.Size(16, 17);
            this.label_ItemCount.TabIndex = 5;
            this.label_ItemCount.Text = "0";
            // 
            // QueryResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 822);
            this.Controls.Add(this.label_ItemCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Bring);
            this.Controls.Add(this.dataGridView_SelectedDB_item);
            this.Controls.Add(this.listBox_Query_Results);
            this.Name = "QueryResultForm";
            this.Text = "QueryResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectedDB_item)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Query_Results;
        private System.Windows.Forms.DataGridView dataGridView_SelectedDB_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button button_Bring;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_ItemCount;
    }
}