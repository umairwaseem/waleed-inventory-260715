using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmServerItemMatching : Form
    {
        CoreClass ObjCore;
        private int LocalItemId = -1;
        public frmServerItemMatching()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmServerItemMatching_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxOptioni(this.cmbServerItems, "Select Id, Code + ' ' + Name from ItemList", this.ObjCore.getHBCConnectionString());

                this.loadGV();   
            }
            catch (Exception ex)
            {

            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure to change the item", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.No) return;

                string command = "Update Items set Server_Id = " + this.cmbServerItems.SelectedValue.ToString() + " where ItemId = " + this.LocalItemId;

                this.ObjCore.executeQuery(command, this.ObjCore.getClientConnectionString());

                this.loadGV();

            }
            catch (Exception ex)
            {

            }
        }

        private void loadGV()
        {
            try
            {
                this.dsServerItemMatching1.Clear();
                this.dsServerItemMatching1.EnforceConstraints = false;
                this.daServerItemMatching.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daServerItemMatching.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.ToString();
                this.daServerItemMatching.Fill(this.dsServerItemMatching1);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    this.LocalItemId = Convert.ToInt32(this.dgv["ItemId", e.RowIndex].Value);
                    string LocalName = this.dgv["Code", e.RowIndex].Value.ToString() + " " + this.dgv["Title", e.RowIndex].Value.ToString();
                    this.lbLocalItem.Text = LocalName;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadGV();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
