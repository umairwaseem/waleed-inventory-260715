using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ncsln.Classes;

namespace Ncsln.Manufacturing
{
    public partial class ucItemSearch : UserControl
    {
        CoreClass ObjCore;
        public ucItemSearch()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void ucItemSearch_Load(object sender, EventArgs e)
        {
            this.SearchItems();
        }

        private void SearchItems()
        {
            try
            {
                this.dsItemSearch1.Clear();
                this.daItemSearch.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daItemSearch.SelectCommand.Parameters["@key"].Value = this.txtSearchKey.Text.Trim();
                this.daItemSearch.Fill(this.dsItemSearch1);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            this.SearchItems();
        }
    }
}
