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
        string seedString;

        public int Seed
        {
            get { return (int)SeedNumBox.Value; }
            set { SeedNumBox.Value = value; }
        }

        public string SeedString
        {
            get { return seedString; }
            set { seedString = value; }
        }

        public ModalDialog()
        {
            InitializeComponent();
        }        
    }
}
