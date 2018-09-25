using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;

namespace MicroX_database
{
    /**
     * for entering or editing data from the XinRay 
     * Manufacturing End of Line Report
     * and saving it to the database
     */
     
    public partial class EOLReportGUI: Form
    {
        //fields
        #region
        private List<tester> allTesters; // ALL testers in a list (not just testers for current tube)
        private BindingList<tester> thisTesters = new BindingList<tester>(); //testers for current tube (bindingList tells objectsThatUseIt when it is updated)
        private tube_data Tube;
        MicroXEntities ctx;
        private bool NewTube;
        private string TubeNum;
        private float? Ia;
        private float? Ic;
        private float? T;
        private int? V0;
        private int? Rgrid;
        private int? Vf;
        private int? Vgrid;
        private string StationID;
        private string FocalSpotStand;
        private string SlitDiaphragm;
        private string CarestreamHPX;
        private string Film1;
        private string Film2;
        private float? Ifs09;
        private float? Ifs19;
        private string RaySafeBU;
        private string RaySafeSensor;
        private int? DM55Init;
        private int? DM55Limit;
        private float? DM55Va;
        private float? DM55mas;
        private float? DM55T;
        private float? DM55Dose;
        private int? DM70Init;
        private int? DM70Limit;
        private float? DM70Va;
        private float? DM70mas;
        private float? DM70T;
        private float? DM70Dose;
        private int? DM80Init;
        private int? DM80Limit;
        private float? DM80Va;
        private float? DM80mas;
        private float? DM80T;
        private float? DM80Dose;
        private int? DM100Init;
        private int? DM100Limit;
        private float? DM100Va;
        private float? DM100mas;
        private float? DM100T;
        private float? DM100Dose;
        private int? DM110Init;
        private int? DM110Limit;
        private float? DM110Va;
        private float? DM110mas;
        private float? DM110T;
        private float? DM110Dose;
        private float? Ia55;
        private string CathodeNum;
        private int? AlumIclimit;
        private int? AlumIcInit;
        private float? EqAlumHalf;
        #endregion

        //Constructor
        public EOLReportGUI()
        { 
            Console.WriteLine("Loading EOL Report Interface...");
            InitializeComponent();
            ExtraInit();
        }

        //aditional initialisation
        private void ExtraInit()
        {
            ctx = new MicroXEntities();
            InitCBAllTesters();
            thisTesters = new BindingList<tester>(); //testers for current tube (bindingList tells objects that use it when it is updated)
            this.listBoxTesters.DataSource = thisTesters;
            ClearFields();
        }

        //initaialising the testers combobox with data from database
        private void InitCBAllTesters()
        {
            allTesters = new List<tester>();
            tester addNew = new tester();
            addNew.first_name = "Add new...";
            tester selectPH = new tester();
            selectPH.first_name = "--Select--";
            foreach(tester t in ctx.testers)
            {
                allTesters.Add(t);
            }
            allTesters.Sort();
            allTesters.Insert(0, selectPH); //top of list
            allTesters.Add(addNew);         //bot of list
            this.comboBoxTesters.DataSource = allTesters;
        }

        //saves data to database informs user of empty and invalid fields
        //allows user to continue without saving those fields(OK)
        //or to return to the interface and make any changes(CANCEL)
        private void Save()
        {
            bool emptyOrInvalidFields = false;
            Object[] fields = new Object[]
            { 
                Ia,
                Ic,
                T,
                V0,
                Rgrid,
                Vf,
                Vgrid,
                StationID,
                FocalSpotStand,
                SlitDiaphragm,
                CarestreamHPX,
                Film1,
                Film2,
                Ifs09,
                Ifs19,
                RaySafeBU,
                RaySafeSensor,
                DM55Init,
                DM55Limit,
                DM55Va,
                DM55mas,
                DM55T,
                DM55Dose,
                DM70Init,
                DM70Limit,
                DM70Va,
                DM70mas,
                DM70T,
                DM70Dose,
                DM80Init,
                DM80Limit,
                DM80Va,
                DM80mas,
                DM80T,
                DM80Dose,
                DM100Init,
                DM100Limit,
                DM100Va,
                DM100mas,
                DM100T,
                DM100Dose,
                DM110Init,
                DM110Limit,
                DM110Va,
                DM110mas,
                DM110T,
                DM110Dose,
                Ia55,
                CathodeNum,
                AlumIclimit,
                AlumIcInit,
                EqAlumHalf
            };
            int x = 0;
            foreach (Object o in fields)
            {
                x = x + 1;
                if (o == null || (o is string && o == ""))
                {
                    Console.WriteLine(x);
                    if(MessageBox.Show("There are empty or invalid fields, those fields will not be saved. Click OK to continue or Cancel to Abort", 
                        "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        break;
                    }
                    else
                    {
                        MessageBox.Show("No Data was saved");
                        return;
                    }
                }
            }
            if (Tube == null)
            {
                Tube = new tube_data();
                ctx.tube_data.Add(Tube);
                Tube.tube_nr = TubeNum;
            }

            Tube.eol_ia = Ia;
            Tube.eol_ic = Ic;
            Tube.eol_t = T;
            Tube.eol_vz = V0;
            Tube.eol_r_grid = Rgrid;
            Tube.eol_focus_corr = Vf;
            Tube.eol_v_grid_peak = Vgrid;
            Tube.station_id = StationID;
            Tube.focal_spot_stand = FocalSpotStand;
            Tube.slit_diaphragm = SlitDiaphragm;
            Tube.carestream_hpx = CarestreamHPX;
            Tube.film1 = Film1;
            Tube.film2 = Film2;
            Tube.eol_ifs_09mm = Ifs09;
            Tube.eol_ifs_19mm = Ifs19;
            Tube.raysafe_base_unit = RaySafeBU;
            Tube.raysafe_sensor = RaySafeSensor;
            Tube.eol_ia_55kv_09mm = Ia55;
            Tube.cathode_nr = CathodeNum;
            Tube.eq_alum_ic_limit = AlumIclimit;
            Tube.eq_alum_ic_init = AlumIcInit;
            Tube.eq_alum_half = EqAlumHalf;

            dose_measurements DM55 = Tube.dose_measurements.FirstOrDefault(
                                dose_measurements => (dose_measurements.fromeol == true &&
                                dose_measurements.kv == 55));
            if (DM55 == null)
            {
                DM55 = new dose_measurements(55);
                Tube.dose_measurements.Add(DM55);
            }
            DM55.ic_init = DM55Init;
            DM55.ic_limit = DM55Limit;
            DM55.kvp_a = DM55Va;
            DM55.mas = DM55mas;
            DM55.ms = DM55T;
            DM55.dose = DM55Dose;
            DM55.fromeol = true;

            dose_measurements DM70 = Tube.dose_measurements.FirstOrDefault(
                              dose_measurements => (dose_measurements.fromeol == true &&
                              dose_measurements.kv == 70));
            if (DM70 == null)
            {
                DM70 = new dose_measurements(70);
                Tube.dose_measurements.Add(DM70);
            }
            DM70.ic_init = DM70Init;
            DM70.ic_limit = DM70Limit;
            DM70.kvp_a = DM70Va;
            DM70.mas = DM70mas;
            DM70.ms = DM70T;
            DM70.dose = DM70Dose;
            DM70.fromeol = true;

            dose_measurements DM80 = Tube.dose_measurements.FirstOrDefault(
                              dose_measurements => (dose_measurements.fromeol == true &&
                              dose_measurements.kv == 80));
            if (DM80 == null)
            {
                DM80 = new dose_measurements(80);
                Tube.dose_measurements.Add(DM80);
            }
            DM80.ic_init = DM80Init;
            DM80.ic_limit = DM80Limit;
            DM80.kvp_a = DM80Va;
            DM80.mas = DM80mas;
            DM80.ms = DM80T;
            DM80.dose = DM80Dose;
            DM80.fromeol = true;

            dose_measurements DM100 = Tube.dose_measurements.FirstOrDefault(
                              dose_measurements => (dose_measurements.fromeol == true &&
                              dose_measurements.kv == 100));
            if (DM100 == null)
            {
                DM100 = new dose_measurements(100);
                Tube.dose_measurements.Add(DM100);
            }
            DM100.ic_init = DM100Init;
            DM100.ic_limit = DM100Limit;
            DM100.kvp_a = DM100Va;
            DM100.mas = DM100mas;
            DM100.ms = DM100T;
            DM100.dose = DM100Dose;
            DM100.fromeol = true;

            dose_measurements DM110 = Tube.dose_measurements.FirstOrDefault(
                              dose_measurements => (dose_measurements.fromeol == true &&
                              dose_measurements.kv == 110));
            if (DM110 == null)
            {
                DM110 = new dose_measurements(110);
                Tube.dose_measurements.Add(DM110);
            }
            DM110.ic_init = DM110Init;
            DM110.ic_limit = DM110Limit;
            DM110.kvp_a = DM110Va;
            DM110.mas = DM110mas;
            DM110.ms = DM110T;
            DM110.dose = DM110Dose;
            DM110.fromeol = true;

         
            try
            {
                ctx.SaveChanges();
                ctx.Dispose();
                MessageBox.Show("Tube saved to database", "Tube Saved", MessageBoxButtons.OK);
                ExtraInit();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
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
            //string fields
            TextBoxTubeNum.Text = RemoveWhitespace(tube.tube_nr);
            TextBoxCathodeNum.Text = RemoveWhitespace(tube.cathode_nr);
            TextBoxStationID.Text = RemoveWhitespace(tube.station_id);
            TextBoxFocalSpotStand.Text = RemoveWhitespace(tube.focal_spot_stand);
            TextBoxSlitDiaphragm.Text = RemoveWhitespace(tube.slit_diaphragm);
            TextBoxCarestreamHPX.Text = RemoveWhitespace(tube.carestream_hpx);
            TextBoxRaySafeBU.Text = RemoveWhitespace(tube.raysafe_base_unit);
            TextBoxRaySafeSensor.Text = RemoveWhitespace(tube.raysafe_sensor);
            TextBoxFilm1.Text = RemoveWhitespace(tube.film1);
            TextBoxFilm2.Text = RemoveWhitespace(tube.film2);

            //number fields
            TextBoxRgrid.Text = tube.eol_r_grid.ToString();
            TextBoxIa.Text = tube.eol_ia.ToString();
            TextBoxIc.Text = tube.eol_ic.ToString();
            TextBoxV0.Text = tube.eol_vz.ToString();
            TextBoxVf.Text = tube.eol_focus_corr.ToString();
            TextBoxVgrid.Text = tube.eol_v_grid_peak.ToString();
            TextBoxIa55.Text = tube.eol_ia_55kv_09mm.ToString();
            TextBoxIfs09.Text = tube.eol_ifs_09mm.ToString();
            TextBoxIfs19.Text = tube.eol_ifs_19mm.ToString();
            TextBoxEqAlumHalf.Text = tube.eq_alum_half.ToString();
            TextBox75kVIcInit.Text = tube.eq_alum_ic_init.ToString();
            TextBox75kVIcLimit.Text = tube.eq_alum_ic_limit.ToString();

            //referenced fields using foreign 
            foreach (tester t in tube.testers)
            {
                thisTesters.Add(t);
            }
            //this line takes the first dose measurement that satisfies (fromeol == true && kV == 55) 
            //or returns NULL if no such dose measurement exists.
            dose_measurements dm55 = tube.dose_measurements.FirstOrDefault(dose_measurements => 
            (dose_measurements.fromeol == true && dose_measurements.kv == 55));
            if (dm55 != null)
            {
                TextBoxDM55Init.Text = dm55.ic_init.ToString();
                TextBoxDM55Limit.Text = dm55.ic_limit.ToString();
                TextBoxDM55mas.Text = dm55.mas.ToString();
                TextBoxDM55T.Text = dm55.ms.ToString();
                TextBoxDM55Va.Text = dm55.kvp_a.ToString();
                TextBoxDM55Dose.Text = dm55.dose.ToString();
            }
            dose_measurements dm70 = tube.dose_measurements.FirstOrDefault(dose_measurements => 
            (dose_measurements.fromeol == true && dose_measurements.kv == 70));
            if (dm70 != null)
            {
                TextBoxDM70Init.Text = dm70.ic_init.ToString();
                TextBoxDM70Limit.Text = dm70.ic_limit.ToString();
                TextBoxDM70mas.Text = dm70.mas.ToString();
                TextBoxDM70T.Text = dm70.ms.ToString();
                TextBoxDM70Va.Text = dm70.kvp_a.ToString();
                TextBoxDM70Dose.Text = dm70.dose.ToString();
            }
            dose_measurements dm80 = tube.dose_measurements.FirstOrDefault(dose_measurements => 
            (dose_measurements.fromeol == true && dose_measurements.kv == 80));
            if (dm80 != null)
            {
                TextBoxDM80Init.Text = dm80.ic_init.ToString();
                TextBoxDM80Limit.Text = dm80.ic_limit.ToString();
                TextBoxDM80mas.Text = dm80.mas.ToString();
                TextBoxDM80T.Text = dm80.ms.ToString();
                TextBoxDM80Va.Text = dm80.kvp_a.ToString();
                TextBoxDM80Dose.Text = dm80.dose.ToString();
            }
            dose_measurements dm100 = tube.dose_measurements.FirstOrDefault(dose_measurements => 
            (dose_measurements.fromeol == true && dose_measurements.kv == 100));
            if (dm100 != null)
            {
                TextBoxDM100Init.Text = dm100.ic_init.ToString();
                TextBoxDM100Limit.Text = dm100.ic_limit.ToString();
                TextBoxDM100mas.Text = dm100.mas.ToString();
                TextBoxDM100T.Text = dm100.ms.ToString();
                TextBoxDM100Va.Text = dm100.kvp_a.ToString();
                TextBoxDM100Dose.Text = dm100.dose.ToString();
            }
            dose_measurements dm110 = tube.dose_measurements.FirstOrDefault(dose_measurements => 
            (dose_measurements.fromeol == true && dose_measurements.kv == 110));
            if (dm110 != null)
            {
                TextBoxDM110Init.Text = dm110.ic_init.ToString();
                TextBoxDM110Limit.Text = dm110.ic_limit.ToString();
                TextBoxDM110mas.Text = dm110.mas.ToString();
                TextBoxDM110T.Text = dm110.ms.ToString();
                TextBoxDM110Va.Text = dm110.kvp_a.ToString();
                TextBoxDM110Dose.Text = dm110.dose.ToString();
            }
        }

        //clear fields
        private void ClearFields()
        {
            thisTesters.Clear();
            TextBoxTubeNum.Clear();
            LabelTxR.Text = "Transmission Rate:";
            TextBoxIa.Clear();
            TextBoxIc.Clear();
            TextBoxRgrid.Clear();
            TextBoxV0.Clear();
            TextBoxVf.Clear();
            TextBoxCathodeNum.Clear();
            TextBoxVgrid.Clear();
            TextBoxStationID.Clear();
            TextBoxFocalSpotStand.Clear();
            TextBoxSlitDiaphragm.Clear();
            TextBoxCarestreamHPX.Clear();
            TextBoxFilm1.Clear();
            TextBoxFilm2.Clear();
            TextBoxIa55.Clear();
            TextBoxIfs09.Clear();
            TextBoxIfs19.Clear();
            TextBoxRaySafeBU.Clear();
            TextBoxRaySafeSensor.Clear();
            TextBoxDM55Init.Clear();
            TextBoxDM55Limit.Clear();
            TextBoxDM70Init.Clear();
            TextBoxDM70Limit.Clear();
            TextBoxDM80Init.Clear();
            TextBoxDM80Limit.Clear();
            TextBoxDM100Init.Clear();
            TextBoxDM100Limit.Clear();
            TextBoxDM110Init.Clear();
            TextBoxDM110Limit.Clear();
            TextBoxDM55Va.Clear();
            TextBoxDM55mas.Clear();
            TextBoxDM55T.Clear();
            TextBoxDM55Dose.Clear();
            TextBoxDM70Va.Clear();
            TextBoxDM70mas.Clear();
            TextBoxDM70T.Clear();
            TextBoxDM70Dose.Clear();
            TextBoxDM80Va.Clear();
            TextBoxDM80mas.Clear();
            TextBoxDM80T.Clear();
            TextBoxDM80Dose.Clear();
            TextBoxDM100Va.Clear();
            TextBoxDM100mas.Clear();
            TextBoxDM100T.Clear();
            TextBoxDM100Dose.Clear();
            TextBoxDM110Va.Clear();
            TextBoxDM110mas.Clear();
            TextBoxDM110T.Clear();
            TextBoxDM110Dose.Clear();
            TextBoxEqAlumHalf.Clear();
            TextBox75kVIcInit.Clear();
            TextBox75kVIcLimit.Clear();
        }

        //clear fields except tube number
        private void ClearFieldsNotTubeNum()
        {
            thisTesters.Clear();
            LabelTxR.Text = "Transmission Rate:";
            TextBoxIa.Clear();
            TextBoxIc.Clear();
            TextBoxRgrid.Clear();
            TextBoxV0.Clear();
            TextBoxVf.Clear();
            TextBoxCathodeNum.Clear();
            TextBoxVgrid.Clear();
            TextBoxStationID.Clear();
            TextBoxFocalSpotStand.Clear();
            TextBoxSlitDiaphragm.Clear();
            TextBoxCarestreamHPX.Clear();
            TextBoxFilm1.Clear();
            TextBoxFilm2.Clear();
            TextBoxIa55.Clear();
            TextBoxIfs09.Clear();
            TextBoxIfs19.Clear();
            TextBoxRaySafeBU.Clear();
            TextBoxRaySafeSensor.Clear();
            TextBoxDM55Init.Clear();
            TextBoxDM55Limit.Clear();
            TextBoxDM70Init.Clear();
            TextBoxDM70Limit.Clear();
            TextBoxDM80Init.Clear();
            TextBoxDM80Limit.Clear();
            TextBoxDM100Init.Clear();
            TextBoxDM100Limit.Clear();
            TextBoxDM110Init.Clear();
            TextBoxDM110Limit.Clear();
            TextBoxDM55Va.Clear();
            TextBoxDM55mas.Clear();
            TextBoxDM55T.Clear();
            TextBoxDM55Dose.Clear();
            TextBoxDM70Va.Clear();
            TextBoxDM70mas.Clear();
            TextBoxDM70T.Clear();
            TextBoxDM70Dose.Clear();
            TextBoxDM80Va.Clear();
            TextBoxDM80mas.Clear();
            TextBoxDM80T.Clear();
            TextBoxDM80Dose.Clear();
            TextBoxDM100Va.Clear();
            TextBoxDM100mas.Clear();
            TextBoxDM100T.Clear();
            TextBoxDM100Dose.Clear();
            TextBoxDM110Va.Clear();
            TextBoxDM110mas.Clear();
            TextBoxDM110T.Clear();
            TextBoxDM110Dose.Clear();
            TextBoxEqAlumHalf.Clear();
            TextBox75kVIcInit.Clear();
            TextBox75kVIcLimit.Clear();
        }

        //disable fields except Tube Number
        private void DisableFieldsNotTubeNum()
        {
            TextBoxIa.Enabled = false;
            TextBoxIc.Enabled = false;
            TextBoxRgrid.Enabled = false;
            TextBoxV0.Enabled = false;
            TextBoxVf.Enabled = false;
            buttonSubmit.Enabled = false;
            TextBoxTubeNum.TextChanged += null;
            buttonAddTester.Enabled = false;
            TextBoxCathodeNum.Enabled = false;
            buttonRemoveTester.Enabled = false;
            comboBoxTesters.Enabled = false;
            listBoxTesters.Enabled = false;
            TextBoxVgrid.Enabled = false;
            TextBoxStationID.Enabled = false;
            TextBoxFocalSpotStand.Enabled = false;
            TextBoxSlitDiaphragm.Enabled = false;
            TextBoxCarestreamHPX.Enabled = false;
            TextBoxFilm1.Enabled = false;
            TextBoxFilm2.Enabled = false;
            TextBoxIa55.Enabled = false;
            TextBoxIfs09.Enabled = false;
            TextBoxIfs19.Enabled = false;
            TextBoxRaySafeBU.Enabled = false;
            TextBoxRaySafeSensor.Enabled = false;
            TextBoxDM55Init.Enabled = false;
            TextBoxDM55Limit.Enabled = false;
            TextBoxDM70Init.Enabled = false;
            TextBoxDM70Limit.Enabled = false;
            TextBoxDM80Init.Enabled = false;
            TextBoxDM80Limit.Enabled = false;
            TextBoxDM100Init.Enabled = false;
            TextBoxDM100Limit.Enabled = false;
            TextBoxDM110Init.Enabled = false;
            TextBoxDM110Limit.Enabled = false;
            TextBoxDM55Va.Enabled = false;
            TextBoxDM55mas.Enabled = false;
            TextBoxDM55T.Enabled = false;
            TextBoxDM55Dose.Enabled = false;
            TextBoxDM70Va.Enabled = false;
            TextBoxDM70mas.Enabled = false;
            TextBoxDM70T.Enabled = false;
            TextBoxDM70Dose.Enabled = false;
            TextBoxDM80Va.Enabled = false;
            TextBoxDM80mas.Enabled = false;
            TextBoxDM80T.Enabled = false;
            TextBoxDM80Dose.Enabled = false;
            TextBoxDM100Va.Enabled = false;
            TextBoxDM100mas.Enabled = false;
            TextBoxDM100T.Enabled = false;
            TextBoxDM100Dose.Enabled = false;
            TextBoxDM110Va.Enabled = false;
            TextBoxDM110mas.Enabled = false;
            TextBoxDM110T.Enabled = false;
            TextBoxDM110Dose.Enabled = false;
            TextBoxEqAlumHalf.Enabled = false;
            TextBox75kVIcInit.Enabled = false;
            TextBox75kVIcLimit.Enabled = false;
        }

        //enable fields
        private void EnableFields()
        {
            TextBoxIa.Enabled = true;
            TextBoxIc.Enabled = true;
            TextBoxRgrid.Enabled = true;
            TextBoxV0.Enabled = true;
            TextBoxVf.Enabled = true;
            buttonSubmit.Enabled = true;
            TextBoxTubeNum.TextChanged += new System.EventHandler(this.TextBoxTubeNum_TextChanged);
            buttonAddTester.Enabled = true;
            TextBoxCathodeNum.Enabled = true;
            buttonRemoveTester.Enabled = true;
            comboBoxTesters.Enabled = true;
            listBoxTesters.Enabled = true;
            TextBoxVgrid.Enabled = true;
            TextBoxStationID.Enabled = true;
            TextBoxFocalSpotStand.Enabled = true;
            TextBoxSlitDiaphragm.Enabled = true;
            TextBoxCarestreamHPX.Enabled = true;
            TextBoxFilm1.Enabled = true;
            TextBoxFilm2.Enabled = true;
            TextBoxIa55.Enabled = true;
            TextBoxIfs09.Enabled = true;
            TextBoxIfs19.Enabled = true; 
            TextBoxRaySafeBU.Enabled = true;
            TextBoxRaySafeSensor.Enabled = true;
            TextBoxDM55Init.Enabled = true;
            TextBoxDM55Limit.Enabled = true;
            TextBoxDM70Init.Enabled = true;
            TextBoxDM70Limit.Enabled = true;
            TextBoxDM80Init.Enabled = true;
            TextBoxDM80Limit.Enabled = true;
            TextBoxDM100Init.Enabled = true;
            TextBoxDM100Limit.Enabled = true;
            TextBoxDM110Init.Enabled = true;
            TextBoxDM110Limit.Enabled = true;
            TextBoxDM55Va.Enabled = true;
            TextBoxDM55mas.Enabled = true;
            TextBoxDM55T.Enabled = true;
            TextBoxDM55Dose.Enabled = true;
            TextBoxDM70Va.Enabled = true;
            TextBoxDM70mas.Enabled = true;
            TextBoxDM70T.Enabled = true;
            TextBoxDM70Dose.Enabled = true;
            TextBoxDM80Va.Enabled = true;
            TextBoxDM80mas.Enabled = true;
            TextBoxDM80T.Enabled = true;
            TextBoxDM80Dose.Enabled = true;
            TextBoxDM100Va.Enabled = true;
            TextBoxDM100mas.Enabled = true;
            TextBoxDM100T.Enabled = true;
            TextBoxDM100Dose.Enabled = true;
            TextBoxDM110Va.Enabled = true;
            TextBoxDM110mas.Enabled = true;
            TextBoxDM110T.Enabled = true;
            TextBoxDM110Dose.Enabled = true;
            TextBoxEqAlumHalf.Enabled = true;
            TextBox75kVIcInit.Enabled = true;
            TextBox75kVIcLimit.Enabled = true;
        }

        //update Transmission rate and display
        private void updateTx()
        {
            if(Ia.HasValue && Ic.HasValue && Ic != 0)
            {
                T = (float)Math.Round((double)(100 * Ia / Ic), 2);
            }
            else
            {
                T = null;
            }
            LabelTxR.Text = "Transmission Rate: " + T + @"%";
            TxValid();
        }
        
        /// <summary>
        /// Checks database for cathode number
        /// returns tube with same cathode number if exists (it shouldn't)
        /// otherwise returns null (it should)
        /// </summary>
        /// <param name="cathodeNum"></param>
        /// <returns></returns>
        private tube_data checkCathodeNumUnique(string cathodeNum)
        {
            tube_data tube = ctx.tube_data.FirstOrDefault(tube_data => tube_data.cathode_nr == cathodeNum);
            return tube;
        }
        
        //Check database for Tube data with primary key tubeNum
        private tube_data checkDBForExistingTube(string tubeNum)
        {
            tube_data tube = ctx.tube_data.Find(new string[] { tubeNum });
            return tube;
        }

        /**
         * --------------------------------------------------------------
         *                  EVENT HANDLERS         
         *  -------------------------------------------------------------
         */
        //called when submit button is clicked
        //check tube number valid and save
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (TubeNumValid())
            {
                Save();
                return;
            }
            else
            {
                MessageBox.Show("Tube Number is invalid", "Invalid Fields");
            }
        }

        //called when "check" button is clicked 
        //OR ENTER is hit from within tube number field
        //checks for existing tube in DB, informs user of result (if positive)
        //performs autofill and allows access to other fields
        private void ButtonCheckNumClick(object sender, EventArgs e)
        {
            NewTube = false;
            if (!TubeNumValid())
            {
                MessageBox.Show("Tube number must be of format: MXTnnnnn \n eg. MXT00123", "Invalid Tube number");
                return;
            }
            
            Tube = checkDBForExistingTube(TubeNum);
            if (Tube == null) //unique&valid TubeNum implies new Tube
            {
                NewTube = true;
                EnableFields();
            }
            else
            {
                if (MessageBox.Show("Some data already exists for that tube. If you continue, you will be editing existing data", "Tube data Exists",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AutoFill(Tube);
                    EnableFields();
                }
                else
                {
                    ClearFields();
                }
            }
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
            ActiveForm.AcceptButton = null;
        }

        private void ComboBoxTesters_SelectedItemChanged(object sender, EventArgs e)
        {
            tester tester = (tester)comboBoxTesters.SelectedItem;
            if (tester.first_name == "Add new...")
            {
                Form_Add_new_tester form = new Form_Add_new_tester();
                form.ShowDialog();
                InitCBAllTesters();
                return;
            }

        }

        private void ButtonAddTester_Click(object sender, EventArgs e)
        {
            tester tester = (tester)comboBoxTesters.SelectedItem;
            if (tester.first_name == "--Select--" || tester.first_name == "Add new...")
            {
                MessageBox.Show("Select a tester or select \"Add new\" from the dropdown list", "Select a tester");
                return;
            }
            foreach(tester t in thisTesters)
            {
                if (t.tester_nr == tester.tester_nr)
                {
                    MessageBox.Show("Only add each tester once.", "Tester Already Added");
                    return;
                }
            }
            thisTesters.Add(tester);
        }

        private void ButtonRemoveTester_Click(object sender, EventArgs e)
        {
            tester tester = (tester)listBoxTesters.SelectedItem;
            thisTesters.Remove(tester);
        }

        /**
         *  TEXT CHANGED EVENT HANDLERS
         *  Largely just call validity checkers
         */

        //tube number altered
        private void TextBoxTubeNum_TextChanged(object sender, EventArgs e)
        {
            ClearFieldsNotTubeNum();
            DisableFieldsNotTubeNum();
        }

        //Other fields text changed EventHandlers
        //simply call the validity checker, with certain parameters
        #region
        private void TextBoxIa_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIa, LabelIaError, ref Ia, 0, null);     
            updateTx();
        }   
        private void TextBoxIc_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIc, LabelIcError, ref Ic, 0, null);
            updateTx();
        }        
        private void TextBoxV0_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxV0, LabelV0Error, ref V0, 0, null);
        }
        private void TextBoxGridR_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxRgrid, LabelRgridError, ref Rgrid, 0, null);
        }
        private void TextBoxVf_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxVf, LabelVfError, ref Vf, -250, 250);
        }
        private void TextBoxVgrid_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxVgrid, LabelVgridError, ref Vgrid, 0, null);
            
        }
        private void TextBoxStationID_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxStationID, LabelStationIDError, ref StationID);
        }
        private void TextBoxFocalSpotStand_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxFocalSpotStand, LabelFocalSpotStandError, ref FocalSpotStand);
        }
        private void TextBoxSlitDiaphragm_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxSlitDiaphragm, LabelSlitDiaphragmError, ref SlitDiaphragm);
        }
        private void TextBoxCarestreamHPX_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxCarestreamHPX, LabelCarestreamHPXError, ref CarestreamHPX);
        }
        private void TextBoxFilm1_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxFilm1, LabelFilm1Error, ref Film1);
        }
        private void TextBoxFilm2_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxFilm2, LabelFilm2Error, ref Film2);
        }
        private void TextBoxIfs09_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIfs09, LabelIfs09Error, ref Ifs09, -10, 10);
        }
        private void TextBoxIfs19_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIfs19, LabelIfs19Error, ref Ifs19, -10, 10);
        }
        private void TextBoxRaySafeBU_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxRaySafeBU, LabelRaySafeBUError, ref RaySafeBU);
        }
        private void TextBoxRaySafeSensor_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxRaySafeSensor, LabelRaySafeSensorError, ref RaySafeSensor);
        }
        private void TextBoxDM55Init_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM55Init, LabelDM55InitError, ref DM55Init, 0, null);
        }
        private void TextBoxDM55Limit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM55Limit, LabelDM55LimitError, ref DM55Limit, 0, null);
        }
        private void TextBoxDM55Va_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM55Va, LabelDM55VaError, ref DM55Va, 0, null);
        }
        private void TextBoxDM55mas_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM55mas, LabelDM55masError, ref DM55mas, 0, null);
        }
        private void TextBoxDM55T_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM55T, LabelDM55TError, ref DM55T, 0, null);
        }
        private void TextBoxDM55Dose_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM55Dose, LabelDM55DoseError, ref DM55Dose, 0, null);
        }
        private void TextBoxDM70Init_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM70Init, LabelDM70InitError, ref DM70Init, 0, null);
        }
        private void TextBoxDM70Limit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM70Limit, LabelDM70LimitError, ref DM70Limit, 0, null);
        }
        private void TextBoxDM70Va_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM70Va, LabelDM70VaError, ref DM70Va, 0, null);
        }
        private void TextBoxDM70mas_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM70mas, LabelDM70masError, ref DM70mas, 0, null);
        }
        private void TextBoxDM70T_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM70T, LabelDM70TError, ref DM70T, 0, null);
        }
        private void TextBoxDM70Dose_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM70Dose, LabelDM70DoseError, ref DM70Dose, 0, null);
        }
        private void TextBoxDM80Init_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM80Init, LabelDM80InitError, ref DM80Init, 0, null);
        }
        private void TextBoxDM80Limit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM80Limit, LabelDM80LimitError, ref DM80Limit, 0, null);
        }
        private void TextBoxDM80Va_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM80Va, LabelDM80VaError, ref DM80Va, 0, null);
        }
        private void TextBoxDM80mas_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM80mas, LabelDM80masError, ref DM80mas, 0, null);
        }
        private void TextBoxDM80T_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM80T, LabelDM80TError, ref DM80T, 0, null);
        }
        private void TextBoxDM80Dose_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM80Dose, LabelDM80DoseError, ref DM80Dose, 0, null);
        }
        private void TextBoxDM100Init_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM100Init, LabelDM100InitError, ref DM100Init, 0, null);
        }
        private void TextBoxDM100Limit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM100Limit, LabelDM100LimitError, ref DM100Limit, 0, null);
        }
        private void TextBoxDM100Va_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM100Va, LabelDM100VaError, ref DM100Va, 0, null);
        }
        private void TextBoxDM100mas_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM100mas, LabelDM100masError, ref DM100mas, 0, null);
        }
        private void TextBoxDM100T_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM100T, LabelDM100TError, ref DM100T, 0, null);
        }
        private void TextBoxDM100Dose_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM100Dose, LabelDM100DoseError, ref DM100Dose, 0, null);
        }
        private void TextBoxDM110Init_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM110Init, LabelDM110InitError, ref DM110Init, 0, null);
        }
        private void TextBoxDM110Limit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBoxDM110Limit, LabelDM110LimitError, ref DM110Limit, 0, null);
        }
        private void TextBoxDM110Va_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM110Va, LabelDM110VaError, ref DM110Va, 0, null);
        }
        private void TextBoxDM110mas_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM110mas, LabelDM110masError, ref DM110mas, 0, null);
        }
        private void TextBoxDM110T_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM110T, LabelDM110TError, ref DM110T, 0, null);
        }
        private void TextBoxDM110Dose_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxDM110Dose, LabelDM110DoseError, ref DM110Dose, 0, null);
        }
        private void TextBoxEqAlumHalf_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxEqAlumHalf, LabelEqAlumHalfError, ref EqAlumHalf, 0, null);
        }
        private void TextBox75kVIcInit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBox75kVIcInit, Label75kVIcInitError, ref AlumIcInit, 0, null);
        }
        private void TextBox75kVIcLimit_TextChanged(object sender, EventArgs e)
        {
            IntValid(TextBox75kVIcLimit, Label75kVIcLimitError, ref AlumIclimit, 0, null);
        }
        private void TextBoxCathodeNum_TextChanged(object sender, EventArgs e)
        {
            Char8Valid(TextBoxCathodeNum, LabelCathodeNumError, ref CathodeNum);
        }
        private void TextBoxIa55_TextChanged(object sender, EventArgs e)
        {
            FloatValid(TextBoxIa55, LabelIa55Error, ref Ia55, 0, null);
        }
        #endregion

        private void TextBoxCathodeNum_Leave(object sender, EventArgs e)
        {
            tube_data t = checkCathodeNumUnique(CathodeNum);
            if (t != null && t.tube_nr != TubeNum)
            {
                MessageBox.Show("Tube " + t.tube_nr + " already has Cathode Number: " + CathodeNum + ". Cathode Number must be unique", "Cathode Number Not Unique");
                TextBoxCathodeNum.Clear();
                TextBoxCathodeNum.Focus();
            }
        }

        //TextBox Leave method removes whitespace
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = RemoveWhitespace(((TextBox)sender).Text);
        }

        //validity checkers
        //check the text in the text boxes
        //if invalid return false
        //if valid return true
        private bool TubeNumValid()
        {
            string text = TextBoxTubeNum.Text;
            int number;
            if (text.StartsWith("MXT") && text.Length == 8
                && Int32.TryParse(text.Substring(3), out number) && number > 0)
            {
                TubeNum = text;
                LabelTubeNumError.Visible = false;
                return true;
            }
            else
            {
                TubeNum = null;
                LabelTubeNumError.Visible = true;
                return false;
            }
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
