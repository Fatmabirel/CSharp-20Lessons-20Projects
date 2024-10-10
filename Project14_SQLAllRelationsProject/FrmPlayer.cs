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
    public partial class FrmPlayer : Form
    {
        public FrmPlayer()
        {
            InitializeComponent();
        }

        private void FrmPlayer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbRelationDataSet2.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.dbRelationDataSet2.Players);

        }
    }
}
