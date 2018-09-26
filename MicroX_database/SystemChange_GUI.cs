using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroX_database
{
    public partial class SystemChange_GUI : Form
    {
        MicroXEntities ctx;
        private tube_data Tube;
        private string TubeNum;
        private string SysToNum;
        private system SysTo;
        private tube_system tube_sysCurrent;
        private DateTime ChangeTime;
        private string note = "If tube is not being installed into a system at this time, leave blank";



        public SystemChange_GUI()
        {
            InitializeComponent();
            ExtraInit();
        }

        private void ExtraInit()
        {
            ctx = new MicroXEntities();
            ClearFieldsNotTubeNum();
            TextBoxTubeNum.Clear();
            Tube = null;
            TubeNum = null;
            SysToNum = null;
            SysTo = null;
            tube_sysCurrent = null;
            textBoxTo.Enabled = false;
            buttonSubmit.Enabled = false;
            buttonCheckSys.Enabled = false;
            buttonCheckTubeNum.Enabled = false;
            DateTimePickerChangeTime.Enabled = false;
            DateTimePickerChangeTime.MinDate = new DateTime(1993,03,05);
            labelSysTick.Visible = false;
            labelTubeTick.Visible = false;
            LabelNote.Text = note;
        }

        private void ClearFieldsNotTubeNum()
        {
            Tube = null;
            TubeNum = null;
            tube_sysCurrent = null;
            SysToNum = null;
            ChangeTime = DateTime.Now;
            DateTimePickerChangeTime.Value = ChangeTime;
            textBoxTo.Clear();
            labelSysFrom.Text = "";
        }

        private void TextBoxTubeNum_TextChanged(object sender, EventArgs e)
        {
            textBoxTo.Enabled = false;
            DateTimePickerChangeTime.Enabled = false;
            buttonCheckSys.Enabled = false;
            buttonSubmit.Enabled = false;
            ClearFieldsNotTubeNum();
            buttonCheckTubeNum.Enabled = true;
            buttonCheckSys.Enabled = false;
            labelSysTick.Visible = false;
            labelTubeTick.Visible = false;
        }




        private system checkDBForSystem(string systemNumber)
        {
            system sys = ctx.systems.Find(systemNumber);
            return sys;
        }
        
                
        private void buttonCheckTubeNum_Click(object sender, EventArgs e)
        {
            TubeNum = TextBoxTubeNum.Text;
            Tube = checkDBForExistingTube(TubeNum);
            if (Tube == null)
            {
                labelTubeTick.Visible = false;
                TubeNotFoundMessage.Visible = true;
            }
            else
            {
                TubeNotFoundMessage.Visible = false;
                labelTubeTick.Visible = true;
                tube_sysCurrent = Tube.getSystemAssociationAtTime(DateTime.Now);
                if (tube_sysCurrent == null)
                {
                    labelSysFrom.Text = "No System";
                }
                else
                {
                    DateTimePickerChangeTime.MinDate = tube_sysCurrent.start ?? new DateTime(1993,03,05);
                    labelSysFrom.Text = tube_sysCurrent.sys_nr;
                }
                textBoxTo.Enabled = true;
                buttonCheckSys.Enabled = true;
                textBoxTo.Focus();
            }
            buttonCheckTubeNum.Enabled = false;
        }


        //Check database for Tube data with primary key tubeNum
        private tube_data checkDBForExistingTube(string tubeNum)
        {
            tube_data tube = ctx.tube_data.Find(new string[] { tubeNum });
            return tube;
        }
         
        //called when submit button is clicked
        //check tube number valid and save
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Save();
            return;
        }

        private void Save()
        {
            if (tube_sysCurrent != null)
            {
                tube_sysCurrent.finish = ChangeTime;
            }
            if(SysTo != null)
            {
                tube_system tube_sysNew = new tube_system();
                tube_sysNew.start = ChangeTime;
                tube_sysNew.tube_data = Tube;
                tube_sysNew.system = SysTo;
                Tube.tube_system.Add(tube_sysNew);
            }
            ctx.SaveChanges();
            ctx.Dispose();
            ExtraInit();
        }




        /// <summary>
        /// returns true if the text in sender can be stored as char(8)
        /// or if the TextBox is empty.
        /// stores the value in dest
        /// otherwise returns false
        /// also makes the errorLabel visible or invisible depending on the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="errorLabel"></param>
        /// <returns></returns>
        private bool Char8Valid(TextBox TextBox, Label ErrorLabel, ref string dest)
        {
            if (TextBox.TextLength <= 8)
            {
                dest = RemoveWhitespace(TextBox.Text);
                TextBox.Text = dest;
                ErrorLabel.Visible = false;
                return true;
            }
            else
            {
                dest = null;
                ErrorLabel.Visible = true;
                return false;
            }
        }

        //method to remove whitespace
        public static readonly Regex sWhitespace = new Regex(@"\s+");
        private string RemoveWhitespace(string s)
        {
            if (s != null)
            {
                return sWhitespace.Replace(s, "").ToUpper();
            }
            return s;
        }

        private void buttonCheckSys_Click(object sender, EventArgs e)
        {
            SysToNum = textBoxTo.Text;
            if (SysToNum.Length > 0)
            {
                SysTo = checkDBForSystem(SysToNum);
                if (SysTo == null)
                {
                    labelSysTick.Visible = false;
                    labelSysNotFound.Visible = true;
                }
                else
                {
                    labelSysTick.Visible = true;
                    labelSysNotFound.Visible = false;
                    buttonSubmit.Enabled = true;
                    DateTimePickerChangeTime.Enabled = true;
                    DateTimePickerChangeTime.Value = DateTime.Now;
                    LabelNote.Text = note;
                }
            }
            else
            {
                LabelNote.Text = "(No System)";
                labelSysTick.Visible = true;
                labelSysNotFound.Visible = false;
                buttonSubmit.Enabled = true;
                DateTimePickerChangeTime.Enabled = true;
                DateTimePickerChangeTime.Value = DateTime.Now;
            }
            buttonCheckSys.Enabled = false;
        }

        private void DateTimePickerChangeTime_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime = DateTimePickerChangeTime.Value;
        }

        private void textBoxTo_TextChanged(object sender, EventArgs e)
        {
            buttonCheckSys.Enabled = true;
            DateTimePickerChangeTime.Enabled = false;
            buttonSubmit.Enabled = false;
            labelSysTick.Visible = false;
        }

        private void TextBoxTo_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = buttonCheckSys;
        }

        private void TextBoxTo_Leave(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = null;
        }

        private void TextBoxTubeNum_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = buttonCheckTubeNum;
        }

        private void TextBoxTubeNum_Leave(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = null;
        }

    }
}
