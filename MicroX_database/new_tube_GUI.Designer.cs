using System;

namespace MicroX_database
{
    partial class new_tube_GUI
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
            this.LabelH2 = new System.Windows.Forms.Label();
            this.LabelH1 = new System.Windows.Forms.Label();
            this.TextBoxV0 = new System.Windows.Forms.TextBox();
            this.LabelRefV = new System.Windows.Forms.Label();
            this.TextBoxRgrid = new System.Windows.Forms.TextBox();
            this.LabelGridR = new System.Windows.Forms.Label();
            this.TextBoxTubeNum = new System.Windows.Forms.TextBox();
            this.LabelTubeNum = new System.Windows.Forms.Label();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.TextBoxIc = new System.Windows.Forms.TextBox();
            this.LabelIc = new System.Windows.Forms.Label();
            this.TextBoxIa = new System.Windows.Forms.TextBox();
            this.LabelIa = new System.Windows.Forms.Label();
            this.LabelTxR = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.LabelRgridError = new System.Windows.Forms.Label();
            this.LabelV0Error = new System.Windows.Forms.Label();
            this.LabelIaError = new System.Windows.Forms.Label();
            this.LabelIcError = new System.Windows.Forms.Label();
            this.LabelTubeNumError = new System.Windows.Forms.Label();
            this.LabelFocus = new System.Windows.Forms.Label();
            this.LabelVfError = new System.Windows.Forms.Label();
            this.TextBoxVf = new System.Windows.Forms.TextBox();
            this.LabelVf = new System.Windows.Forms.Label();
            this.buttonCheckNum = new System.Windows.Forms.Button();
            this.LabelTxError = new System.Windows.Forms.Label();
            this.LabelStartingSystemError = new System.Windows.Forms.Label();
            this.TextBoxStartingSystem = new System.Windows.Forms.TextBox();
            this.LabelStartingSystem = new System.Windows.Forms.Label();
            this.LabelSystem = new System.Windows.Forms.Label();
            this.DateTimePickerStartingDate = new System.Windows.Forms.DateTimePicker();
            this.LabelStartingDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelH2
            // 
            this.LabelH2.AutoSize = true;
            this.LabelH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelH2.Location = new System.Drawing.Point(51, 283);
            this.LabelH2.Name = "LabelH2";
            this.LabelH2.Size = new System.Drawing.Size(141, 20);
            this.LabelH2.TabIndex = 31;
            this.LabelH2.Text = "Transmission Rate";
            // 
            // LabelH1
            // 
            this.LabelH1.AutoSize = true;
            this.LabelH1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelH1.Location = new System.Drawing.Point(51, 109);
            this.LabelH1.Name = "LabelH1";
            this.LabelH1.Size = new System.Drawing.Size(104, 20);
            this.LabelH1.TabIndex = 30;
            this.LabelH1.Text = "Tube Voltage";
            // 
            // TextBoxV0
            // 
            this.TextBoxV0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxV0.Enabled = false;
            this.TextBoxV0.Location = new System.Drawing.Point(528, 152);
            this.TextBoxV0.Name = "TextBoxV0";
            this.TextBoxV0.Size = new System.Drawing.Size(136, 20);
            this.TextBoxV0.TabIndex = 10;
            this.TextBoxV0.TextChanged += new System.EventHandler(this.TextBoxV0_TextChanged);
            // 
            // LabelRefV
            // 
            this.LabelRefV.AutoSize = true;
            this.LabelRefV.Location = new System.Drawing.Point(379, 155);
            this.LabelRefV.Name = "LabelRefV";
            this.LabelRefV.Size = new System.Drawing.Size(146, 13);
            this.LabelRefV.TabIndex = 26;
            this.LabelRefV.Text = "Tube Reference Voltage (V): ";
            // 
            // TextBoxRgrid
            // 
            this.TextBoxRgrid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxRgrid.Enabled = false;
            this.TextBoxRgrid.Location = new System.Drawing.Point(212, 152);
            this.TextBoxRgrid.Name = "TextBoxRgrid";
            this.TextBoxRgrid.Size = new System.Drawing.Size(136, 20);
            this.TextBoxRgrid.TabIndex = 5;
            this.TextBoxRgrid.TextChanged += new System.EventHandler(this.TextBoxGridR_TextChanged);
            // 
            // LabelGridR
            // 
            this.LabelGridR.AutoSize = true;
            this.LabelGridR.Location = new System.Drawing.Point(65, 155);
            this.LabelGridR.Name = "LabelGridR";
            this.LabelGridR.Size = new System.Drawing.Size(144, 13);
            this.LabelGridR.TabIndex = 24;
            this.LabelGridR.Text = "Tube Grid Resistance (Ohm):";
            // 
            // TextBoxTubeNum
            // 
            this.TextBoxTubeNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxTubeNum.Location = new System.Drawing.Point(304, 73);
            this.TextBoxTubeNum.Name = "TextBoxTubeNum";
            this.TextBoxTubeNum.Size = new System.Drawing.Size(136, 20);
            this.TextBoxTubeNum.TabIndex = 1;
            this.TextBoxTubeNum.Enter += new System.EventHandler(this.TextBoxTubeNum_Enter);
            this.TextBoxTubeNum.Leave += new System.EventHandler(this.TextBoxTubeNum_Leave);
            // 
            // LabelTubeNum
            // 
            this.LabelTubeNum.AutoSize = true;
            this.LabelTubeNum.Location = new System.Drawing.Point(262, 77);
            this.LabelTubeNum.Name = "LabelTubeNum";
            this.LabelTubeNum.Size = new System.Drawing.Size(39, 13);
            this.LabelTubeNum.TabIndex = 22;
            this.LabelTubeNum.Text = "Tube#";
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.Location = new System.Drawing.Point(316, 24);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(109, 25);
            this.LabelTitle.TabIndex = 21;
            this.LabelTitle.Text = "New Tube";
            // 
            // TextBoxIc
            // 
            this.TextBoxIc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxIc.Enabled = false;
            this.TextBoxIc.Location = new System.Drawing.Point(213, 323);
            this.TextBoxIc.Name = "TextBoxIc";
            this.TextBoxIc.Size = new System.Drawing.Size(136, 20);
            this.TextBoxIc.TabIndex = 20;
            this.TextBoxIc.TextChanged += new System.EventHandler(this.TextBoxIc_TextChanged);
            // 
            // LabelIc
            // 
            this.LabelIc.AutoSize = true;
            this.LabelIc.Location = new System.Drawing.Point(96, 326);
            this.LabelIc.Name = "LabelIc";
            this.LabelIc.Size = new System.Drawing.Size(114, 13);
            this.LabelIc.TabIndex = 34;
            this.LabelIc.Text = "Cathode Current (mA): ";
            // 
            // TextBoxIa
            // 
            this.TextBoxIa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxIa.Enabled = false;
            this.TextBoxIa.Location = new System.Drawing.Point(528, 323);
            this.TextBoxIa.Name = "TextBoxIa";
            this.TextBoxIa.Size = new System.Drawing.Size(136, 20);
            this.TextBoxIa.TabIndex = 25;
            this.TextBoxIa.TextChanged += new System.EventHandler(this.TextBoxIa_TextChanged);
            // 
            // LabelIa
            // 
            this.LabelIa.AutoSize = true;
            this.LabelIa.Location = new System.Drawing.Point(420, 326);
            this.LabelIa.Name = "LabelIa";
            this.LabelIa.Size = new System.Drawing.Size(105, 13);
            this.LabelIa.TabIndex = 32;
            this.LabelIa.Text = "Anode Current (mA): ";
            // 
            // LabelTxR
            // 
            this.LabelTxR.AutoSize = true;
            this.LabelTxR.Location = new System.Drawing.Point(221, 288);
            this.LabelTxR.Name = "LabelTxR";
            this.LabelTxR.Size = new System.Drawing.Size(100, 13);
            this.LabelTxR.TabIndex = 36;
            this.LabelTxR.Text = "Transmission Rate: ";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.Location = new System.Drawing.Point(349, 508);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 50;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // LabelRgridError
            // 
            this.LabelRgridError.AutoSize = true;
            this.LabelRgridError.BackColor = System.Drawing.Color.White;
            this.LabelRgridError.ForeColor = System.Drawing.Color.Red;
            this.LabelRgridError.Location = new System.Drawing.Point(335, 155);
            this.LabelRgridError.Name = "LabelRgridError";
            this.LabelRgridError.Size = new System.Drawing.Size(10, 13);
            this.LabelRgridError.TabIndex = 38;
            this.LabelRgridError.Text = "!";
            this.LabelRgridError.Visible = false;
            // 
            // LabelV0Error
            // 
            this.LabelV0Error.AutoSize = true;
            this.LabelV0Error.BackColor = System.Drawing.Color.White;
            this.LabelV0Error.ForeColor = System.Drawing.Color.Red;
            this.LabelV0Error.Location = new System.Drawing.Point(651, 155);
            this.LabelV0Error.Name = "LabelV0Error";
            this.LabelV0Error.Size = new System.Drawing.Size(10, 13);
            this.LabelV0Error.TabIndex = 39;
            this.LabelV0Error.Text = "!";
            this.LabelV0Error.Visible = false;
            // 
            // LabelIaError
            // 
            this.LabelIaError.AutoSize = true;
            this.LabelIaError.BackColor = System.Drawing.Color.White;
            this.LabelIaError.ForeColor = System.Drawing.Color.Red;
            this.LabelIaError.Location = new System.Drawing.Point(652, 326);
            this.LabelIaError.Name = "LabelIaError";
            this.LabelIaError.Size = new System.Drawing.Size(10, 13);
            this.LabelIaError.TabIndex = 40;
            this.LabelIaError.Text = "!";
            this.LabelIaError.Visible = false;
            // 
            // LabelIcError
            // 
            this.LabelIcError.AutoSize = true;
            this.LabelIcError.BackColor = System.Drawing.Color.White;
            this.LabelIcError.ForeColor = System.Drawing.Color.Red;
            this.LabelIcError.Location = new System.Drawing.Point(336, 326);
            this.LabelIcError.Name = "LabelIcError";
            this.LabelIcError.Size = new System.Drawing.Size(10, 13);
            this.LabelIcError.TabIndex = 41;
            this.LabelIcError.Text = "!";
            this.LabelIcError.Visible = false;
            // 
            // LabelTubeNumError
            // 
            this.LabelTubeNumError.AutoSize = true;
            this.LabelTubeNumError.BackColor = System.Drawing.Color.White;
            this.LabelTubeNumError.ForeColor = System.Drawing.Color.Red;
            this.LabelTubeNumError.Location = new System.Drawing.Point(427, 76);
            this.LabelTubeNumError.Name = "LabelTubeNumError";
            this.LabelTubeNumError.Size = new System.Drawing.Size(10, 13);
            this.LabelTubeNumError.TabIndex = 42;
            this.LabelTubeNumError.Text = "!";
            this.LabelTubeNumError.Visible = false;
            // 
            // LabelFocus
            // 
            this.LabelFocus.AutoSize = true;
            this.LabelFocus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelFocus.Location = new System.Drawing.Point(51, 191);
            this.LabelFocus.Name = "LabelFocus";
            this.LabelFocus.Size = new System.Drawing.Size(196, 20);
            this.LabelFocus.TabIndex = 44;
            this.LabelFocus.Text = "Focal Spot Measurements";
            // 
            // LabelVfError
            // 
            this.LabelVfError.AutoSize = true;
            this.LabelVfError.BackColor = System.Drawing.Color.White;
            this.LabelVfError.ForeColor = System.Drawing.Color.Red;
            this.LabelVfError.Location = new System.Drawing.Point(335, 238);
            this.LabelVfError.Name = "LabelVfError";
            this.LabelVfError.Size = new System.Drawing.Size(10, 13);
            this.LabelVfError.TabIndex = 47;
            this.LabelVfError.Text = "!";
            this.LabelVfError.Visible = false;
            // 
            // TextBoxVf
            // 
            this.TextBoxVf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxVf.Enabled = false;
            this.TextBoxVf.Location = new System.Drawing.Point(212, 235);
            this.TextBoxVf.Name = "TextBoxVf";
            this.TextBoxVf.Size = new System.Drawing.Size(136, 20);
            this.TextBoxVf.TabIndex = 15;
            this.TextBoxVf.TextChanged += new System.EventHandler(this.TextBoxVf_TextChanged);
            // 
            // LabelVf
            // 
            this.LabelVf.AutoSize = true;
            this.LabelVf.Location = new System.Drawing.Point(63, 238);
            this.LabelVf.Name = "LabelVf";
            this.LabelVf.Size = new System.Drawing.Size(145, 13);
            this.LabelVf.TabIndex = 45;
            this.LabelVf.Text = "Focus Correction Voltage (V):";
            // 
            // buttonCheckNum
            // 
            this.buttonCheckNum.Location = new System.Drawing.Point(462, 71);
            this.buttonCheckNum.Name = "buttonCheckNum";
            this.buttonCheckNum.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckNum.TabIndex = 2;
            this.buttonCheckNum.Text = "check";
            this.buttonCheckNum.UseVisualStyleBackColor = true;
            this.buttonCheckNum.Click += new System.EventHandler(this.ButtonCheckNumClick);
            // 
            // LabelTxError
            // 
            this.LabelTxError.AutoSize = true;
            this.LabelTxError.ForeColor = System.Drawing.Color.Red;
            this.LabelTxError.Location = new System.Drawing.Point(209, 288);
            this.LabelTxError.Name = "LabelTxError";
            this.LabelTxError.Size = new System.Drawing.Size(10, 13);
            this.LabelTxError.TabIndex = 50;
            this.LabelTxError.Text = "!";
            this.LabelTxError.Visible = false;
            // 
            // LabelStartingSystemError
            // 
            this.LabelStartingSystemError.AutoSize = true;
            this.LabelStartingSystemError.BackColor = System.Drawing.Color.White;
            this.LabelStartingSystemError.ForeColor = System.Drawing.Color.Red;
            this.LabelStartingSystemError.Location = new System.Drawing.Point(337, 403);
            this.LabelStartingSystemError.Name = "LabelStartingSystemError";
            this.LabelStartingSystemError.Size = new System.Drawing.Size(10, 13);
            this.LabelStartingSystemError.TabIndex = 53;
            this.LabelStartingSystemError.Text = "!";
            this.LabelStartingSystemError.Visible = false;
            // 
            // TextBoxStartingSystem
            // 
            this.TextBoxStartingSystem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxStartingSystem.Enabled = false;
            this.TextBoxStartingSystem.Location = new System.Drawing.Point(213, 400);
            this.TextBoxStartingSystem.Name = "TextBoxStartingSystem";
            this.TextBoxStartingSystem.Size = new System.Drawing.Size(136, 20);
            this.TextBoxStartingSystem.TabIndex = 30;
            this.TextBoxStartingSystem.TextChanged += new System.EventHandler(this.TextBoxStartingSystem_TextChanged);
            this.TextBoxStartingSystem.Leave += new System.EventHandler(this.TextBoxStartingSystem_Leave);
            // 
            // LabelStartingSystem
            // 
            this.LabelStartingSystem.AutoSize = true;
            this.LabelStartingSystem.Location = new System.Drawing.Point(124, 404);
            this.LabelStartingSystem.Name = "LabelStartingSystem";
            this.LabelStartingSystem.Size = new System.Drawing.Size(86, 13);
            this.LabelStartingSystem.TabIndex = 52;
            this.LabelStartingSystem.Text = "Starting System: ";
            // 
            // LabelSystem
            // 
            this.LabelSystem.AutoSize = true;
            this.LabelSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelSystem.Location = new System.Drawing.Point(51, 367);
            this.LabelSystem.Name = "LabelSystem";
            this.LabelSystem.Size = new System.Drawing.Size(122, 20);
            this.LabelSystem.TabIndex = 54;
            this.LabelSystem.Text = "Starting System";
            // 
            // DateTimePickerStartingDate
            // 
            this.DateTimePickerStartingDate.CalendarTitleBackColor = System.Drawing.Color.LawnGreen;
            this.DateTimePickerStartingDate.CustomFormat = "ddd, d MMM yyyy - h:mm tt";
            this.DateTimePickerStartingDate.Enabled = false;
            this.DateTimePickerStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerStartingDate.Location = new System.Drawing.Point(212, 441);
            this.DateTimePickerStartingDate.MaxDate = new System.DateTime(2018, 9, 25, 17, 25, 25, 469);
            this.DateTimePickerStartingDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerStartingDate.Name = "DateTimePickerStartingDate";
            this.DateTimePickerStartingDate.ShowUpDown = true;
            this.DateTimePickerStartingDate.Size = new System.Drawing.Size(205, 20);
            this.DateTimePickerStartingDate.TabIndex = 35;
            this.DateTimePickerStartingDate.Value = new System.DateTime(2018, 9, 11, 0, 0, 0, 0);
            // 
            // LabelStartingDate
            // 
            this.LabelStartingDate.AutoSize = true;
            this.LabelStartingDate.Location = new System.Drawing.Point(135, 444);
            this.LabelStartingDate.Name = "LabelStartingDate";
            this.LabelStartingDate.Size = new System.Drawing.Size(75, 13);
            this.LabelStartingDate.TabIndex = 56;
            this.LabelStartingDate.Text = "Starting Date: ";
            // 
            // new_tube_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 562);
            this.Controls.Add(this.LabelStartingDate);
            this.Controls.Add(this.DateTimePickerStartingDate);
            this.Controls.Add(this.LabelSystem);
            this.Controls.Add(this.LabelStartingSystemError);
            this.Controls.Add(this.TextBoxStartingSystem);
            this.Controls.Add(this.LabelStartingSystem);
            this.Controls.Add(this.LabelTxError);
            this.Controls.Add(this.buttonCheckNum);
            this.Controls.Add(this.LabelVfError);
            this.Controls.Add(this.TextBoxVf);
            this.Controls.Add(this.LabelVf);
            this.Controls.Add(this.LabelFocus);
            this.Controls.Add(this.LabelTubeNumError);
            this.Controls.Add(this.LabelIcError);
            this.Controls.Add(this.LabelIaError);
            this.Controls.Add(this.LabelV0Error);
            this.Controls.Add(this.LabelRgridError);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.LabelTxR);
            this.Controls.Add(this.TextBoxIc);
            this.Controls.Add(this.LabelIc);
            this.Controls.Add(this.TextBoxIa);
            this.Controls.Add(this.LabelIa);
            this.Controls.Add(this.LabelH2);
            this.Controls.Add(this.LabelH1);
            this.Controls.Add(this.TextBoxV0);
            this.Controls.Add(this.LabelRefV);
            this.Controls.Add(this.TextBoxRgrid);
            this.Controls.Add(this.LabelGridR);
            this.Controls.Add(this.TextBoxTubeNum);
            this.Controls.Add(this.LabelTubeNum);
            this.Controls.Add(this.LabelTitle);
            this.Name = "new_tube_GUI";
            this.Text = "New Tube";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelH2;
        private System.Windows.Forms.Label LabelH1;
        private System.Windows.Forms.TextBox TextBoxV0;
        private System.Windows.Forms.Label LabelRefV;
        private System.Windows.Forms.TextBox TextBoxRgrid;
        private System.Windows.Forms.Label LabelGridR;
        private System.Windows.Forms.TextBox TextBoxTubeNum;
        private System.Windows.Forms.Label LabelTubeNum;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.TextBox TextBoxIc;
        private System.Windows.Forms.Label LabelIc;
        private System.Windows.Forms.TextBox TextBoxIa;
        private System.Windows.Forms.Label LabelIa;
        private System.Windows.Forms.Label LabelTxR;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label LabelRgridError;
        private System.Windows.Forms.Label LabelV0Error;
        private System.Windows.Forms.Label LabelIaError;
        private System.Windows.Forms.Label LabelIcError;
        private System.Windows.Forms.Label LabelTubeNumError;
        private System.Windows.Forms.Label LabelFocus;
        private System.Windows.Forms.Label LabelVfError;
        private System.Windows.Forms.TextBox TextBoxVf;
        private System.Windows.Forms.Label LabelVf;
        private System.Windows.Forms.Button buttonCheckNum;
        private System.Windows.Forms.Label LabelTxError;
        private System.Windows.Forms.Label LabelStartingSystemError;
        private System.Windows.Forms.TextBox TextBoxStartingSystem;
        private System.Windows.Forms.Label LabelStartingSystem;
        private System.Windows.Forms.Label LabelSystem;
        private System.Windows.Forms.DateTimePicker DateTimePickerStartingDate;
        private System.Windows.Forms.Label LabelStartingDate;
    }
}