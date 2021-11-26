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

    public partial class ModalDialog : Form
    {
        // Seed Property
        public int Seed
        {
            get { return (int)SeedNumBox.Value; }
            set { SeedNumBox.Value = value; }
        }

        public ModalDialog()
        {
            InitializeComponent();
        }        
    }
}
