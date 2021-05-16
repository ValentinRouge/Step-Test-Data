using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Step_Test_Data
{
    public partial class showForm : Form
    {
        private DBManager DBM = new DBManager();
        int cellID = 0;
        public showForm()
        {
            InitializeComponent();
        }

        private void showForm_Load(object sender, EventArgs e)
        {
            PopulateGrid(DBM.getAll());
            ///inset the data from all the database in the grid
        }

        private void PopulateGrid(List<TestsHistory> list)
        {
            GRIDVIEW_DisplayTest.DataSource = list;
            GRIDVIEW_DisplayTest.Columns["Id"].Visible = false;
            ///mask the ID comlumn
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            PopulateGrid(DBM.Search(txt_search.Text));
            /// change the list in the grid, if search is null all we be displayed
        }

        private void GRIDVIEW_DisplayTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (cellID != 0)
            {
                DBM.Delete(cellID);
                //delete the correct test
                MessageBox.Show("Record Deleted Successfully!");
                PopulateGrid(DBM.getAll());
                //update the grid
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void GRIDVIEW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            cellID = Convert.ToInt32(GRIDVIEW_DisplayTest.Rows[e.RowIndex].Cells[0].Value.ToString());
            // the id of the test to delete is get the fist cell of the selected row 
        }
    }
}
