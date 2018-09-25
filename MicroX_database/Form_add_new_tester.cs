using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroX_database
{
    public partial class Form_Add_new_tester : Form
    {

        private String firstName;
        private String lastName;

        public Form_Add_new_tester()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckFirstNameValid()
        {
            string text = textBoxFirstName.Text.ToUpper();
            if (text.Length < 1 || !text.All(Char.IsUpper))
            {
                return false;
            }
            firstName = text;
            return true;
        }

        private bool CheckLastNameValid()
        {
            string text = textBoxLastName.Text.ToUpper();
            if (text.Length < 1 || !text.All(Char.IsUpper))
            {
                return false;
            }
            lastName = text;
            return true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (CheckFirstNameValid() && CheckLastNameValid())
            {
                MicroXEntities ctx = new MicroXEntities();
                tester tester = new tester();
                tester.first_name = firstName;
                tester.last_name = lastName;
                ctx.testers.Add(tester);
                ctx.SaveChanges();
                this.Close();
            }

        }
    }
}
