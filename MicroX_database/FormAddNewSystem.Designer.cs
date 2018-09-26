namespace MicroX_database
{
    partial class FormAddNewSystem
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
            this.labelSystemNumber = new System.Windows.Forms.Label();
            this.textBoxSystemNumber = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSystemNumber
            // 
            this.labelSystemNumber.AutoSize = true;
            this.labelSystemNumber.Location = new System.Drawing.Point(28, 30);
            this.labelSystemNumber.Name = "labelSystemNumber";
            this.labelSystemNumber.Size = new System.Drawing.Size(84, 13);
            this.labelSystemNumber.TabIndex = 0;
            this.labelSystemNumber.Text = "System Number:";
            // 
            // textBoxSystemNumber
            // 
            this.textBoxSystemNumber.Location = new System.Drawing.Point(118, 27);
            this.textBoxSystemNumber.Name = "textBoxSystemNumber";
            this.textBoxSystemNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxSystemNumber.TabIndex = 1;
            this.textBoxSystemNumber.TextChanged += new System.EventHandler(this.textBoxSystemNumber_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(53, 63);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(134, 63);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormAddNewSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 103);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSystemNumber);
            this.Controls.Add(this.labelSystemNumber);
            this.Name = "FormAddNewSystem";
            this.Text = "Add New System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSystemNumber;
        private System.Windows.Forms.TextBox textBoxSystemNumber;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
    }
}