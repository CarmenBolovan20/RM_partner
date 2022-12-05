
namespace WindowsFormsApp1
{
    partial class MainForm1
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
            this.labelMainForm = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMainForm
            // 
            this.labelMainForm.AutoSize = true;
            this.labelMainForm.BackColor = System.Drawing.Color.LightBlue;
            this.labelMainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainForm.Location = new System.Drawing.Point(80, 138);
            this.labelMainForm.Name = "labelMainForm";
            this.labelMainForm.Size = new System.Drawing.Size(375, 71);
            this.labelMainForm.TabIndex = 20;
            this.labelMainForm.Text = "MAIN FORM";
            this.labelMainForm.Click += new System.EventHandler(this.label6_Click);
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.Location = new System.Drawing.Point(493, 9);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(26, 25);
            this.labelClose.TabIndex = 19;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(531, 357);
            this.Controls.Add(this.labelClose);
            this.Controls.Add(this.labelMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm1";
            this.Load += new System.EventHandler(this.MainForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMainForm;
        private System.Windows.Forms.Label labelClose;
    }
}