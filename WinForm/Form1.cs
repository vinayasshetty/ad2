using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFDalLib;
namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EFDal dal = new EFDal();
            var empLst = dal.GetAllEmps();
            dgv.DataSource = empLst;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //take user input for insert
            var record = new tbl_employee
            {
                Ecode = int.Parse(txtEcode.Text),
                Ename = txtEname.Text,
                salary = int.Parse(txtSalary.Text),
                deptid = int.Parse(txtDeptid.Text)
            };
            //insert using dal
            var dal = new EFDal();
            dal.AddEmployee(record);
            MessageBox.Show("record inserted");

            //referesh the data
            dgv.DataSource = dal.GetAllEmps();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            var Ecode = int.Parse(txtEcode.Text);
          
            var dal = new EFDal();
            dal.DeleteById(Ecode);
            MessageBox.Show("record deleted");
            dgv.DataSource = dal.GetAllEmps();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var record = new tbl_employee
            {
                Ecode = int.Parse(txtEcode.Text),
                salary = int.Parse(txtSalary.Text)
            
            };
            var dal = new EFDal();
            dal.UpdateEmp(record);
            MessageBox.Show("record updated");
            dgv.DataSource=dal.GetAllEmps();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //txtEname.SelectedText = string.Empty;
            //txtSalary.SelectedText = string.Empty;
            //txtDeptid.SelectedText = string.Empty;

            var Ecode = int.Parse(txtEcode.Text);
            
            var dal = new EFDal();
            var a=dal.GetEmpById(Ecode);
            txtEname.SelectedText = a.Ename;
            txtSalary.SelectedText = a.salary.ToString();
            txtDeptid.SelectedText = a.deptid.ToString();
            MessageBox.Show("record found");
            dgv.DataSource = dal.GetAllEmps();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEname.Clear();
            txtEcode.Clear();
        }
    }
}
