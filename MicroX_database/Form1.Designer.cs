namespace MicroX_database
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.newTube = new System.Windows.Forms.LinkLabel();
            this.EOLReport = new System.Windows.Forms.LinkLabel();
            this.SystemChange = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // newTube
            // 
            this.newTube.AutoSize = true;
            this.newTube.Location = new System.Drawing.Point(146, 91);
            this.newTube.Name = "newTube";
            this.newTube.Size = new System.Drawing.Size(79, 13);
            this.newTube.TabIndex = 0;
            this.newTube.TabStop = true;
            this.newTube.Text = "New Tube GUI";
            this.newTube.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newTube_LinkClicked);
            // 
            // EOLReport
            // 
            this.EOLReport.AutoSize = true;
            this.EOLReport.Location = new System.Drawing.Point(146, 127);
            this.EOLReport.Name = "EOLReport";
            this.EOLReport.Size = new System.Drawing.Size(85, 13);
            this.EOLReport.TabIndex = 1;
            this.EOLReport.TabStop = true;
            this.EOLReport.Text = "EOL Report GUI";
            this.EOLReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EOLReport_LinkClicked);
            // 
            // SystemChange
            // 
            this.SystemChange.AutoSize = true;
            this.SystemChange.Location = new System.Drawing.Point(146, 159);
            this.SystemChange.Name = "SystemChange";
            this.SystemChange.Size = new System.Drawing.Size(103, 13);
            this.SystemChange.TabIndex = 2;
            this.SystemChange.TabStop = true;
            this.SystemChange.Text = "System Change GUI";
            this.SystemChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SystemChange_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 267);
            this.Controls.Add(this.SystemChange);
            this.Controls.Add(this.EOLReport);
            this.Controls.Add(this.newTube);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel newTube;
        private System.Windows.Forms.LinkLabel EOLReport;
        private System.Windows.Forms.LinkLabel SystemChange;
    }
}