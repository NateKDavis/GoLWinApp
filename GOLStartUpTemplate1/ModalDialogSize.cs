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
    public partial class ModalDialogSize : Form
    {
        public int UniverseWidth
        {
            get { return (int)WidthNum.Value; }
            set { WidthNum.Value = value; }
        }

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
