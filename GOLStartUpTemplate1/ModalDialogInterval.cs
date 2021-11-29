using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate1
{
    public partial class ModalDialogInterval : Form
    {
        // Seed Property
        public int Interval
        {
            get { return (int)IntervalNum.Value; }
            set { IntervalNum.Value = value; }
        }

        public ModalDialogInterval()
        {
            InitializeComponent();
        }
    }
}
