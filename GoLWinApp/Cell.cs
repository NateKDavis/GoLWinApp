using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLWinApp
{
    public class Cell
    {
        private bool m_isAlive = false; // Defaults cells to be dead
        private int m_age = 0;

        // Property for cell being alive or dead
        public bool isAlive
        {
            get { return m_isAlive; }
            set { m_isAlive = value;  }
        }

        // Property for how many generations a cell has been alive
        public int age
        {
            get { return m_age; }
            set { m_age = value; }
        }
    }
}
