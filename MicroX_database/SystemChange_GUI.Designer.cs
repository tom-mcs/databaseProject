using System;

namespace MicroX_database
{
    partial class SystemChange_GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemChange_GUI));
            this.LabelFrom = new System.Windows.Forms.Label();
            this.LabelTo = new System.Windows.Forms.Label();
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelNote = new System.Windows.Forms.Label();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.DateTimePickerChangeTime = new System.Windows.Forms.DateTimePicker();
            this.LabelTubeNum = new System.Windows.Forms.Label();
            this.TextBoxTubeNum = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCheckTubeNum = new System.Windows.Forms.Button();
            this.TubeNotFoundMessage = new System.Windows.Forms.Label();
            this.labelSysFrom = new System.Windows.Forms.Label();
            this.buttonCheckSys = new System.Windows.Forms.Button();
            this.labelSysNotFound = new System.Windows.Forms.Label();
            this.labelTubeTick = new System.Windows.Forms.Label();
            this.labelSysTick = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelFrom
            // 
            this.LabelFrom.AutoSize = true;
            this.LabelFrom.Location = new System.Drawing.Point(32, 99);
            this.LabelFrom.Name = "LabelFrom";
            this.LabelFrom.Size = new System.Drawing.Size(73, 13);
            this.LabelFrom.TabIndex = 0;
            this.LabelFrom.Text = "From System: ";
            // 
            // LabelTo
            // 
            this.LabelTo.AutoSize = true;
            this.LabelTo.Location = new System.Drawing.Point(42, 130);
            this.LabelTo.Name = "LabelTo";
            this.LabelTo.Size = new System.Drawing.Size(60, 13);
            this.LabelTo.TabIndex = 1;
            this.LabelTo.Text = "To System:";
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Location = new System.Drawing.Point(41, 198);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(61, 13);
            this.LabelTime.TabIndex = 3;
            this.LabelTime.Text = "Date/Time:";
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.Location = new System.Drawing.Point(234, 26);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(122, 20);
            this.LabelTitle.TabIndex = 4;
            this.LabelTitle.Text = "System Change";
            // 
            // LabelNote
            // 
            this.LabelNote.AutoSize = true;
            this.LabelNote.Location = new System.Drawing.Point(101, 163);
            this.LabelNote.Name = "LabelNote";
            this.LabelNote.Size = new System.Drawing.Size(317, 13);
            this.LabelNote.TabIndex = 5;
            this.LabelNote.Text = "*If tube is not being installed into a system at this time, leave blank";
            // 
            // textBoxTo
            // 
            this.textBoxTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxTo.Enabled = false;
            this.textBoxTo.Location = new System.Drawing.Point(104, 127);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTo.TabIndex = 10;
            this.textBoxTo.TextChanged += new System.EventHandler(this.textBoxTo_TextChanged);
            this.textBoxTo.Enter += new System.EventHandler(this.TextBoxTo_Enter);
            this.textBoxTo.Leave += new System.EventHandler(this.TextBoxTo_Leave);
            // 
            // DateTimePickerChangeTime
            // 
            this.DateTimePickerChangeTime.CustomFormat = "ddd dd MMM yyyy - h:mm tt";
            this.DateTimePickerChangeTime.Enabled = false;
            this.DateTimePickerChangeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerChangeTime.Location = new System.Drawing.Point(104, 195);
            this.DateTimePickerChangeTime.MaxDate = new System.DateTime(2018, 9, 26, 23, 59, 0, 0);
            this.DateTimePickerChangeTime.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerChangeTime.Name = "DateTimePickerChangeTime";
            this.DateTimePickerChangeTime.Size = new System.Drawing.Size(182, 20);
            this.DateTimePickerChangeTime.TabIndex = 20;
            this.DateTimePickerChangeTime.ValueChanged += new System.EventHandler(this.DateTimePickerChangeTime_ValueChanged);
            // 
            // LabelTubeNum
            // 
            this.LabelTubeNum.AutoSize = true;
            this.LabelTubeNum.Location = new System.Drawing.Point(60, 68);
            this.LabelTubeNum.Name = "LabelTubeNum";
            this.LabelTubeNum.Size = new System.Drawing.Size(45, 13);
            this.LabelTubeNum.TabIndex = 8;
            this.LabelTubeNum.Text = "Tube#: ";
            // 
            // TextBoxTubeNum
            // 
            this.TextBoxTubeNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxTubeNum.Location = new System.Drawing.Point(104, 65);
            this.TextBoxTubeNum.Name = "TextBoxTubeNum";
            this.TextBoxTubeNum.Size = new System.Drawing.Size(100, 20);
            this.TextBoxTubeNum.TabIndex = 1;
            this.TextBoxTubeNum.TextChanged += new System.EventHandler(this.TextBoxTubeNum_TextChanged);
            this.TextBoxTubeNum.Enter += new System.EventHandler(this.TextBoxTubeNum_Enter);
            this.TextBoxTubeNum.Leave += new System.EventHandler(this.TextBoxTubeNum_Leave);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.Location = new System.Drawing.Point(254, 235);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 25;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCheckTubeNum
            // 
            this.buttonCheckTubeNum.Enabled = false;
            this.buttonCheckTubeNum.Location = new System.Drawing.Point(211, 62);
            this.buttonCheckTubeNum.Name = "buttonCheckTubeNum";
            this.buttonCheckTubeNum.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckTubeNum.TabIndex = 5;
            this.buttonCheckTubeNum.Text = "check";
            this.buttonCheckTubeNum.UseVisualStyleBackColor = true;
            this.buttonCheckTubeNum.Click += new System.EventHandler(this.buttonCheckTubeNum_Click);
            // 
            // TubeNotFoundMessage
            // 
            this.TubeNotFoundMessage.AutoSize = true;
            this.TubeNotFoundMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.TubeNotFoundMessage.Location = new System.Drawing.Point(297, 68);
            this.TubeNotFoundMessage.Name = "TubeNotFoundMessage";
            this.TubeNotFoundMessage.Size = new System.Drawing.Size(85, 13);
            this.TubeNotFoundMessage.TabIndex = 13;
            this.TubeNotFoundMessage.Text = "Tube Not Found";
            this.TubeNotFoundMessage.Visible = false;
            // 
            // labelSysFrom
            // 
            this.labelSysFrom.AutoSize = true;
            this.labelSysFrom.Location = new System.Drawing.Point(108, 99);
            this.labelSysFrom.Name = "labelSysFrom";
            this.labelSysFrom.Size = new System.Drawing.Size(0, 13);
            this.labelSysFrom.TabIndex = 45;
            // 
            // buttonCheckSys
            // 
            this.buttonCheckSys.Enabled = false;
            this.buttonCheckSys.Location = new System.Drawing.Point(211, 126);
            this.buttonCheckSys.Name = "buttonCheckSys";
            this.buttonCheckSys.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckSys.TabIndex = 15;
            this.buttonCheckSys.Text = "check";
            this.buttonCheckSys.UseVisualStyleBackColor = true;
            this.buttonCheckSys.Click += new System.EventHandler(this.buttonCheckSys_Click);
            // 
            // labelSysNotFound
            // 
            this.labelSysNotFound.AutoSize = true;
            this.labelSysNotFound.ForeColor = System.Drawing.Color.DarkRed;
            this.labelSysNotFound.Location = new System.Drawing.Point(297, 130);
            this.labelSysNotFound.Name = "labelSysNotFound";
            this.labelSysNotFound.Size = new System.Drawing.Size(94, 13);
            this.labelSysNotFound.TabIndex = 47;
            this.labelSysNotFound.Text = "System Not Found";
            this.labelSysNotFound.Visible = false;
            // 
            // labelTubeTick
            // 
            this.labelTubeTick.AutoSize = true;
            this.labelTubeTick.BackColor = System.Drawing.Color.White;
            this.labelTubeTick.ForeColor = System.Drawing.Color.Green;
            this.labelTubeTick.Location = new System.Drawing.Point(186, 68);
            this.labelTubeTick.Name = "labelTubeTick";
            this.labelTubeTick.Size = new System.Drawing.Size(15, 13);
            this.labelTubeTick.TabIndex = 48;
            this.labelTubeTick.Text = "✓";
            this.labelTubeTick.Visible = false;
            // 
            // labelSysTick
            // 
            this.labelSysTick.AutoSize = true;
            this.labelSysTick.BackColor = System.Drawing.Color.White;
            this.labelSysTick.ForeColor = System.Drawing.Color.Green;
            this.labelSysTick.Location = new System.Drawing.Point(186, 130);
            this.labelSysTick.Name = "labelSysTick";
            this.labelSysTick.Size = new System.Drawing.Size(15, 13);
            this.labelSysTick.TabIndex = 49;
            this.labelSysTick.Text = "✓";
            this.labelSysTick.Visible = false;
            // 
            // SystemChange_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 275);
            this.Controls.Add(this.labelSysTick);
            this.Controls.Add(this.labelTubeTick);
            this.Controls.Add(this.labelSysNotFound);
            this.Controls.Add(this.buttonCheckSys);
            this.Controls.Add(this.labelSysFrom);
            this.Controls.Add(this.TubeNotFoundMessage);
            this.Controls.Add(this.buttonCheckTubeNum);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.TextBoxTubeNum);
            this.Controls.Add(this.LabelTubeNum);
            this.Controls.Add(this.DateTimePickerChangeTime);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.LabelNote);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.LabelTo);
            this.Controls.Add(this.LabelFrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemChange_GUI";
            this.Text = "System Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label LabelFrom;
        private System.Windows.Forms.Label LabelTo;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelNote;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.DateTimePicker DateTimePickerChangeTime;
        private System.Windows.Forms.Label LabelTubeNum;
        private System.Windows.Forms.TextBox TextBoxTubeNum;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCheckTubeNum;
        private System.Windows.Forms.Label TubeNotFoundMessage;
        private System.Windows.Forms.Label labelSysFrom;
        private System.Windows.Forms.Button buttonCheckSys;
        private System.Windows.Forms.Label labelSysNotFound;
        private System.Windows.Forms.Label labelTubeTick;
        private System.Windows.Forms.Label labelSysTick;
    }
}