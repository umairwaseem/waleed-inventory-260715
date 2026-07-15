using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace Ncsln.Forms
{
    public partial class frmGetKey : Form
    {
        public frmGetKey()
        {
            InitializeComponent();
            this.objCore = new Classes.CoreClass();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            try
            {
                string getId = string.Empty, enCry = string.Empty;
                if (this.txtKey.Text.Trim() == "9195202inst")
                {
                    getId = Classes.Encry.GetProcessorID();
                    enCry = Classes.Encry.Encrypt(getId);

                    XmlTextWriter x = new XmlTextWriter("system.xml", null);
                    x.Formatting = Formatting.Indented;
                    x.WriteStartDocument();
                    x.WriteStartElement("system");
                    x.WriteElementString("log", enCry);
                    x.WriteEndElement();
                    x.WriteEndDocument();
                    x.Flush();
                    x.Close();

                    //objCore.funVoidWildCardRD("Update tbl_GlobleSetting Set LogKey = '" + enCry + "'");
                    this.Close();
                }
                else
                    MessageBox.Show("Wrong code. contect administrator.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
            }
        }

        private void frmGetKey_Load(object sender, EventArgs e)
        {

        }

       
    }
}