using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroX_database
{
    public partial class tube_data
    {
        /// <summary>
        /// returns the system at the given dateTime, 
        /// if no system association exists, returns null.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public tube_system getSystemAssociationAtTime(DateTime dateTime)
        {
            IEnumerable<tube_system> tube_Systems = tube_system.OrderByDescending(tube_system => tube_system.start);
            foreach(tube_system ts in tube_Systems)
            {
                if(ts.finish < dateTime)
                {
                    return null;
                }
                else if(ts.start < dateTime)
                {
                    return ts;
                }
            }
            return null;
        }


    }
}
