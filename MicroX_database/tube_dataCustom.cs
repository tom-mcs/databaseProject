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
            for(int i = this.tube_system.Count-1; i >= 0; i--)
            {
                if (tube_system.ElementAt(i).start < dateTime)
                {
                    if(tube_system.ElementAt(i).finish == null)
                    {
                        return tube_system.ElementAt(i);
                    }
                }
            }
            return null;
        }


    }
}
