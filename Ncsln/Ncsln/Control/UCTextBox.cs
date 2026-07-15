using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ncsln.DBModel;
using Ncsln.Classes;

namespace Ncsln.Control
{
    public partial class UCTextBox : UserControl
    {
        CoreClass ObjCore;

        public int Group_Id { get; set; }
        public int Form_Id { get; set; }
        public string name { get; set; }

        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool IsReport { get; set; }

        private UserGroupRight UGR = new UserGroupRight();

        public UCTextBox()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void UCTextBox_Load(object sender, EventArgs e)
        {
            this.lbTitle.Text = this.name;
            this.chkView.Checked = this.CanView;
            this.chkAdd.Checked = this.CanAdd;
            this.chkUpdate.Checked = this.CanUpdate;
            this.chkDelete.Checked = this.CanDelete;

            this.chkAdd.Visible = this.chkUpdate.Visible = this.chkDelete.Visible = !this.IsReport;
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            this.CanView = this.chkView.Checked;
            this.ChangeSave();
        }

        private void chkAdd_CheckedChanged(object sender, EventArgs e)
        {
            this.CanAdd = this.chkAdd.Checked;
            this.ChangeSave();
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            this.CanUpdate = this.chkUpdate.Checked;
            this.ChangeSave();
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.CanDelete = this.chkDelete.Checked;
            this.ChangeSave();
        }

        private void UCTextBox_MouseHover(object sender, EventArgs e)
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void UCTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void ChangeSave()
        {
            using (InventoryEntities db = new InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                
                var CheckData = db.UserGroupRights.Where(x => x.Group_Id == this.Group_Id && x.Form_Id == this.Form_Id).FirstOrDefault();


                if (CheckData != null)
                {
                    this.UGR = CheckData;
                    this.UGR.CanView = this.chkView.Checked;
                    this.UGR.CanAdd = this.chkAdd.Checked;
                    this.UGR.CanUpdate = this.chkUpdate.Checked;
                    this.UGR.CanDelete = this.chkDelete.Checked;
                    db.Entry(this.UGR).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    this.UGR.Group_Id = this.Group_Id;
                    this.UGR.Form_Id = this.Form_Id;
                    this.UGR.CanView = this.chkView.Checked;
                    this.UGR.CanAdd = this.chkAdd.Checked;
                    this.UGR.CanUpdate = this.chkUpdate.Checked;
                    this.UGR.CanDelete = this.chkDelete.Checked;
                    db.UserGroupRights.Add(this.UGR);
                    db.SaveChanges();
                }
                //MessageBox.Show("Done!");
            }
        }

        private void chkView_CheckStateChanged(object sender, EventArgs e)
        {
            //this.ChangeSave();
        }

        
    }
}
