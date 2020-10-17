using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_Mask
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the open button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                // ...
            }

            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Error after click open button", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>
        /// Event handler for the save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // ...
            }

            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Error after click save button", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
