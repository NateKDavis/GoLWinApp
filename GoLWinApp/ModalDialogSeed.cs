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
    public partial class ModalDialogSeed : Form
    {
        // Property for Number from user for random generation
        public int Seed
        {
            get { return (int)SeedNumBox.Value; }
            set { SeedNumBox.Value = value; }
        }

        public ModalDialogSeed()
        {
            InitializeComponent();
        }        
    }
}
