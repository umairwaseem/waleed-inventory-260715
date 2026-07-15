using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Classes
{
    internal class CommonTask
    {
        public static Boolean Question(int id, bool delete = false)
        {

            string QuestionText = (delete) ? "Are you sure to delete?" : ((id == -1) ? "Are you sure to save?" : "Are you sure to update?");
            DialogResult result = MessageBox.Show(QuestionText, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.No) ? false : true;
        }
    }
}
