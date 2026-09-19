using Ncsln.Classes;
using Ncsln.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Control
{
    public partial class frmUserGroupRights : Form
    {

        CoreClass objCore;
        private int ControlStartPosition = 0;
        private int ControlStartPositionV = 10;
        public int GroupId { get; set; }
        public bool UseHbcDatabase { get; set; }

        private struct AllRights
        {
            public bool CanView;
            public bool CanAdd;
            public bool CanUpdate;
            public bool CanDelete;
        }

        public frmUserGroupRights()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }
        private void frmtest_Load(object sender, EventArgs e)
        {

            using (InventoryEntities db = new InventoryEntities(this.GetConnectionName()))
            {
                var UserRight = db.UserForms.ToList();
                foreach (var item in UserRight)
                {
                    var RightData = db.vUserGroupRights.Where(x => x.Group_Id == this.GroupId && x.Id == item.Id).FirstOrDefault();

                    UCTextBox NewControl = new UCTextBox();
                    NewControl.Location = new System.Drawing.Point(ControlStartPosition, ControlStartPositionV);
                    NewControl.Size = new System.Drawing.Size(500, 81);
                    NewControl.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    NewControl.name = item.FromName;
                    NewControl.Text = item.FromName;
                    NewControl.CanView = (Boolean)this.VerifyRight(RightData).CanView;
                    NewControl.CanAdd = (Boolean)this.VerifyRight(RightData).CanAdd;
                    NewControl.CanUpdate = (Boolean)this.VerifyRight(RightData).CanUpdate;
                    NewControl.CanDelete = (Boolean)this.VerifyRight(RightData).CanDelete;
                    NewControl.Group_Id = GroupId;
                    NewControl.Form_Id = item.Id;
                    NewControl.IsReport = item.Report ?? false;
                    NewControl.UseHbcDatabase = this.UseHbcDatabase;

                    plControl.Controls.Add(NewControl);
                    ControlStartPositionV += 90;
                }
            }
        }

        private string GetConnectionName()
        {
            return this.UseHbcDatabase
                ? this.objCore.getHBCConnectionStringName()
                : this.objCore.getClientConnectionStringName();
        }

        private vUserGroupRight VerifyRight(vUserGroupRight value)
        {
            vUserGroupRight _localRight = new vUserGroupRight();

            if (value == null)
            {
                _localRight.CanView = false;
                _localRight.CanAdd = false;
                _localRight.CanUpdate = false;
                _localRight.CanDelete = false;
            }
            else
            {
                _localRight.CanView = (value.CanView == null) ? false : Convert.ToBoolean(value.CanView);
                _localRight.CanAdd = (value.CanAdd == null) ? false : Convert.ToBoolean(value.CanAdd);
                _localRight.CanUpdate = (value.CanUpdate == null) ? false : Convert.ToBoolean(value.CanUpdate);
                _localRight.CanDelete = (value.CanDelete == null) ? false : Convert.ToBoolean(value.CanDelete);
            }

            return _localRight;
        }
    }
}
