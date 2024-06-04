namespace EmployeesProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewResults = new DataGridView();
            btnLoadFile = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(12, 12);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersWidth = 45;
            dataGridViewResults.Size = new Size(491, 370);
            dataGridViewResults.TabIndex = 0;
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(343, 438);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(160, 59);
            btnLoadFile.TabIndex = 1;
            btnLoadFile.Text = "Load CSV File";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 509);
            Controls.Add(btnLoadFile);
            Controls.Add(dataGridViewResults);
            Name = "Form1";
            Text = "Overlapper";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewResults;
        private Button btnLoadFile;
    }
}
