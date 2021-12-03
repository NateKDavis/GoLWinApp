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
    public partial class ModalDialogSize : Form
    {
        // Property for Number of cells row
        public int UniverseWidth
        {
            get { return (int)WidthNum.Value; }
            set { WidthNum.Value = value; }
        }

        // Property for Number of cells per column
        public int UniverseHeight
        {
            get { return (int)HeightNum.Value; }
            set { HeightNum.Value = value; }
        }

        public ModalDialogSize()
        {
            InitializeComponent();
        }
    }
}
