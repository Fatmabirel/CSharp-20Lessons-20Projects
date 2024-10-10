using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project14_SQLAllRelationsProject
{
    public partial class FrmSponsor : Form
    {
        public FrmSponsor()
        {
            InitializeComponent();
        }

        private void FrmSponsor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbRelationDataSet1.Sponsors' table. You can move, or remove it, as needed.
            this.sponsorsTableAdapter.Fill(this.dbRelationDataSet1.Sponsors);

        }
    }
}
