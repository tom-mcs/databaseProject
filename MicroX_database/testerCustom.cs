using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroX_database
{
    public partial class tester: IComparable
    {
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }

        public override String ToString()
        {
            return first_name + " " + last_name;
        }

    }
}
