namespace MicroX_database
{
    using System;
    using System.Collections.Generic;

    public partial class dose_measurements
    {
        [Obsolete("use constructor with target voltage")]
        public dose_measurements()
        {

        }
        public dose_measurements(int kv)
        {
            this.kv = kv;
        }
        
    }
}