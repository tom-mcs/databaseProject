using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MicroX_database
{
    //
    // For entering bare essential data from XinRay EOL Report
    // when a new tube is recieved.
    //
    public partial class new_tube_GUI: Form
    {
        //data points
        private MicroXEntities ctx;
        private tube_data Tube;
        private string TubeNum;
        private string StartingSystemNumber;
        private int? Rgrid;
        private int? V0;
        private float? Ic;
        private float? Ia;
        private float? T;
        private int? Vf;
        private DateTime? StartingDateTime;

        //Constructor
        public new_tube_GUI()
        {
            Console.WriteLine("Loading New Tube Interface...");
            InitializeComponent();
            ExtraInit();
        }

        private void ExtraInit()
        {
            TubeNum = null;
            Tube = null;
            StartingSystemNumber = null;
            Rgrid = null;
            V0 = null;
            Ic = null;
            Ia = null;
            T = null;
            Vf = null;
            ctx = new MicroXEntities();
            ClearFields();
        }

        //validity checkers
        //check the text in the text boxes and if valid,
        //if invalid return false
        //if valid
        //assign the the relevant variable
        //return true
        private bool TubeNumValid()
        {
            string text = TextBoxTubeNum.Text.ToUpper();
            int number;
            if (text.StartsWith("MXT") && text.Length == 8 
                && Int32.TryParse(text.Substring(3), out number) && number > 0)
            {
                TubeNum = text;
                LabelTubeNumError.Visible = false;
                TextBoxTubeNum.Text = text;
                return true;
            }
            LabelTubeNumError.Visible = false;
            return false;
        }


        //check
        private bool TxValid()
        {
            if (T <= 100 && T >= 0)
            {
                LabelTxError.Visible = false;
                return true;
            }
            LabelTxError.Visible = true;
            return false;
        }

        /// <summary>
        /// returns true if the text in sender can be parsed as a float between min and max
        /// or if the TextBox is empty.
        /// stores the value in dest.
        /// otherwise returns false
        /// if min or max are null, there is no minimum/maximum value respectively
        /// also makes the errorLabel visible or invisible depending on the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="errorLabel"></param>
        /// <returns></returns>
        private bool FloatValid(TextBox TextBox, Label ErrorLabel, ref float? dest, float? min, float? max)
        {
            bool valid = true;
            string text = TextBox.Text;
            dest = null;
            if (text.Length != 0)
            {
                float number;
                if (float.TryParse(text, out number))
                {
                    if (min.HasValue && number < min)
                    {
                        valid = false;
                    }
                    else if (max.HasValue && number > max)
                    {
                        valid = false;
                    }
                    else
                    {
                        dest = number;
                    }
                }
                else
                {
                    valid = false;
                }
            }
            ErrorLabel.Visible = !valid;
            return valid;
        }

        /// <summary>
        /// returns true if the text in sender can be parsed as an integer between min and max
        /// or if the TextBox is empty.
        /// stores the value in dest.
        /// otherwise returns false
        /// if min or max are null, there is no minimum/maximum value respectively
        /// also makes the errorLabel visible or invisible depending on the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="errorLabel"></param>
        /// <returns></returns>
        private bool IntValid(TextBox TextBox, Label ErrorLabel, ref int? dest, int? min, int? max)
        {
            bool valid = true;
            string text = TextBox.Text;
            dest = null;
            if (text.Length != 0)
            {
                int number;
                if (Int32.TryParse(text, out number))
                {
                    if (min.HasValue && number < min)
                    {
                        valid = false;
                    }
                    else if (max.HasValue && number > max)
                    {
                        valid = false;
                    }
                    else
                    {
                        dest = number;
                    }
                }
                else
                {
                    valid = false;
                }
            }
            ErrorLabel.Visible = !valid;
            return valid;
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


        //update Tube number 
        private void TextBoxTubeNum_TextChanged(object sender, EventArgs e)
        {
            ClearFieldsNotTubeNum();
            DisableFields();
        }

        //Check validity, update Ia and call updateTx()
        private void TextBoxIa_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIa, LabelIaError, ref Ia, 0, null);
            UpdateTx();
        }

        //Check validity, update Ic and call updateTx()
        private void TextBoxIc_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIc, LabelIcError, ref Ic, 0, null);
            UpdateTx();
        }

        //Check validity, update V0
        private void TextBoxV0_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxV0, LabelV0Error, ref V0, 0, null);
        }

        //Check validity, update Rgrid
        private void TextBoxGridR_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxRgrid, LabelRgridError, ref Rgrid, 0, null);
        }

        //check validity, update Vf
        private void TextBoxVf_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxVf, LabelVfError, ref Vf, -250, 250);
        }

        private void TextBoxStartingSystem_TextChanged(object sender, EventArgs e)
        {
            if(Char8Valid(TextBoxStartingSystem, LabelStartingSystemError, ref StartingSystemNumber) && StartingSystemNumber.Length > 0){
                EnableDateTimePicker(true);
            }
            else
            {
                EnableDateTimePicker(false);
            }

        }

        private void EnableDateTimePicker(bool b)
        {
            DateTimePickerStartingDate.Enabled = b;
        }

        //Check database for Tube data with primary key tubeNum
        private ref tube_data CheckDBForExistingTube(string tubeNum)
        {
            Tube = ctx.tube_data.Find(new string[] { tubeNum });
            return ref Tube;
        }

        //update Transmission rate and display
        private void UpdateTx()
        {
            if (!Ia.HasValue || !Ic.HasValue)
            {
                LabelTxR.Text = "Transmission Rate: ";
                return;
            }
            T = (float)Math.Round((double)(100 * Ia / Ic), 2);
            LabelTxR.Text = "Transmission Rate: " + T + @"%";
            TxValid();
        }

        //called when submit button is clicked
        //check validity and call save()
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (TubeNumValid())
            {
                Save();
                return;
            }
            MessageBox.Show("TubeNumber is Invalid", "Invalid Fields");
        }  

        //called when "check" button is clicked 
        //OR ENTER is hit from within tube number field
        //checks for existing tube in DB, informs user of result (if positive)
        //performs autofill and allows access to other fields
        private void ButtonCheckNumClick(object sender, EventArgs e)
        {
            if (!TubeNumValid())
            {
                MessageBox.Show("Tube number must be of format: MXTnnnnn \n eg. MXT00123", "Invalid Tube number");
                return;
            }
            tube_data tube = CheckDBForExistingTube(TubeNum);
            if (tube == null)
            {
                LabelTubeNumError.Text = "";
                EnableFields();
                return;
            }
            else
            {
                if (MessageBox.Show("AutoFill data? If you continue, you will be editing existing tube data.", "Tube already Exists",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AutoFill(tube);
                    EnableFields();
                }
                else
                {
                    ClearFields();
                }
            }
        }

        //saves data to database
        private void Save()
        {
            if (Tube == null)//dealing with a new tube
            {
                Tube = new tube_data();
                Tube.tube_nr = TubeNum;
                ctx.tube_data.Add(Tube);
            }

            //save properties
            Tube.eol_r_grid = Rgrid;
            Tube.eol_ia = Ia;
            Tube.eol_ic = Ic;
            Tube.eol_vz = V0;
            Tube.eol_focus_corr = Vf;
            Tube.eol_t = T;

            //save navigation properties
            tube_system tube_sys0 = Tube.tube_system.OrderBy(tube_sys => tube_sys.start).FirstOrDefault();
            if (tube_sys0 == null)//no tube_system accociations exist
            {
                tube_sys0 = new tube_system();
                tube_sys0.tube_data = Tube;
                Tube.tube_system.Add(tube_sys0);
            }
            if (StartingSystemNumber.Length > 0)
            {
                system StartingSystem = ctx.systems.Find(StartingSystemNumber);
                if (StartingSystem == null)//system does not exist on database
                {
                    StartingSystem = new system();
                    StartingSystem.sys_nr = StartingSystemNumber;
                    ctx.systems.Add(StartingSystem);
                }
                tube_sys0.start = DateTimePickerStartingDate.Value;
                tube_sys0.system = StartingSystem;
            }

            try
            {
                ctx.SaveChanges();
                ctx.Dispose();
                MessageBox.Show("Tube saved to database", "Tube Saved", MessageBoxButtons.OK);
                ExtraInit();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                        string message = string.Format("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                        MessageBox.Show(message);
                    }
                }
            }
        }

        //fills out fields with data from database
        private void AutoFill(tube_data tube)
        {
            TextBoxTubeNum.Text = RemoveWhitespace(tube.tube_nr);
            TextBoxRgrid.Text = RemoveWhitespace(tube.eol_r_grid.ToString());
            TextBoxIa.Text = RemoveWhitespace(tube.eol_ia.ToString());
            TextBoxIc.Text = RemoveWhitespace(tube.eol_ic.ToString());
            TextBoxV0.Text = RemoveWhitespace(tube.eol_vz.ToString());
            TextBoxVf.Text = RemoveWhitespace(tube.eol_focus_corr.ToString());
            tube_system tube_sys0 = tube.tube_system.OrderBy(tube_sys => tube_sys.start).FirstOrDefault();
            if (tube_sys0 != null)
            {

                DateTimePickerStartingDate.Value = tube_sys0.start ?? DateTime.Now;
                TextBoxStartingSystem.Text = tube_sys0.sys_nr;
            }
        }

        //clear fields
        private void ClearFields()
        {
            LabelTxR.Text = "Transmission Rate:";
            TextBoxTubeNum.Clear();
            TextBoxRgrid.Clear();
            TextBoxIa.Clear();
            TextBoxIc.Clear();
            TextBoxV0.Clear();
            TextBoxVf.Clear();
            TextBoxStartingSystem.Clear();
        }

        //clear fields except tube number
        private void ClearFieldsNotTubeNum()
        {
            LabelTxR.Text = "Transmission Rate:";
            TextBoxRgrid.Clear();
            TextBoxIa.Clear();
            TextBoxIc.Clear();
            TextBoxV0.Clear();
            TextBoxVf.Clear();
            TextBoxStartingSystem.Clear();
        }

        //disable fields (except Tube Number)
        private void DisableFields()
        {
            TextBoxIa.Enabled = false;
            TextBoxIc.Enabled = false;
            TextBoxRgrid.Enabled = false;
            TextBoxV0.Enabled = false;
            TextBoxVf.Enabled = false;
            buttonSubmit.Enabled = false;
            TextBoxStartingSystem.Enabled = false;
            TextBoxTubeNum.TextChanged += null;
        }
        //enable fields
        private void EnableFields()
        {
            TextBoxIa.Enabled = true;
            TextBoxIc.Enabled = true;
            TextBoxRgrid.Enabled = true;
            TextBoxV0.Enabled = true;
            TextBoxVf.Enabled = true;
            TextBoxStartingSystem.Enabled = true;
            buttonSubmit.Enabled = true;
            TextBoxTubeNum.TextChanged += new System.EventHandler(this.TextBoxTubeNum_TextChanged);
        }


        //called when cursor enters tube num text box
        //sets ENTER as clicking check tube number button
        private void TextBoxTubeNum_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = buttonCheckNum; // ButtonCheckNum will be 'clicked' when user presses return
        }

        //called when cursor leaves the tube num text box
        //sets ENTER as doing nothing.
        private void TextBoxTubeNum_Leave(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = null; // remove "return" button behavior
        }

        private void TextBoxStartingSystem_Leave(object sender, EventArgs e)
        {
            system startingSystem = ctx.systems.FirstOrDefault(system => system.sys_nr == StartingSystemNumber);
            if(startingSystem == null)//this system does not exist on the database
            {
                MessageBox.Show(StartingSystemNumber + " does not exist on the database. " +
                    "\n If you submit this New Tube Form, a new system named \n" + StartingSystemNumber + "\nwill be added to the database", "System not found");
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

    }
}
