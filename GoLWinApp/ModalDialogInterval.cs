using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoLWinApp
{
    public partial class ModalDialogInterval : Form
    {
        // Property for Time between each generation
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
