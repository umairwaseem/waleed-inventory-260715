using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmPicture : Form
    {
        public string Id;
        CoreClass ObjCore;

        public frmPicture()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmPicture_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("Select * from Employee where Id = " + Id, this.ObjCore.getHBCConnectionString()).Tables[0];

                System.IO.MemoryStream photoStream = new System.IO.MemoryStream((byte[])dt.Rows[0]["Photo"]);
                this.pBxPhoto.Image = Image.FromStream(photoStream, true, true);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
