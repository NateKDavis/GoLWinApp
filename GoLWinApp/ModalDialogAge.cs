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
    public partial class ModalDialogAge : Form
    {
        //Property for number of generations a cell can live
        public int deathAge
        {
            get { return (int)DeathAgeNum.Value; }
            set { DeathAgeNum.Value = value; }
        }

        public ModalDialogAge()
        {
            InitializeComponent();
        }
    }
}
