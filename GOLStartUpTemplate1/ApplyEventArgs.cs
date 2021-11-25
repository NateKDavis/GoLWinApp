using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLStartUpTemplate1
{
    public class ApplyEventArgs : EventArgs
    {
        int seed;
        string seedString;

        public int Seed
        {
            get { return seed; }
            set { seed = value; }
        }

        public string SeedString
        {
            get { return seedString; }
            set { seedString = value; }
        }

        public ApplyEventArgs(int seed, string seedString)
        {
            this.seed = seed;
            this.seedString = seedString;
        }

    }
}
