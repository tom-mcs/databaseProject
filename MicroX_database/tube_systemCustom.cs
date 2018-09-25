using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroX_database
{
    public partial class tube_system
    {
        public tube_system()
        {

        }

        public tube_system(tube_data tube_data, system system, DateTime start)
        {
            this.tube_data = tube_data;
            this.system = system;
            this.start = start;
        }

        public void End(DateTime endTime)
        {
            this.finish = endTime;
        }
    }
}
