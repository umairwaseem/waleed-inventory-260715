using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory.Reports
{
    public partial class frmRptBranchesDailyCash : Form
    {
        private Classes.CoreClass ObjCore;

        public frmRptBranchesDailyCash()
        {
            InitializeComponent();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmRptBranchesDailyCash_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsBranchesDailyCash.Clear();
                this.daBranchesDailyCash.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daBranchesDailyCash.Fill(this.dsBranchesDailyCash);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
