using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFCodeFirstPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerDTO dto = new CustomerDTO();
            //Get value from ID textbox
            int id = 0;
            Int32.TryParse(txtCustomerID.Text, out id);

            dto.CustomerID = id;
            dto.Name = txtName.Text;
            dto.Address = txtAddress.Text;

            CustomerDAL dal = new CustomerDAL();
            if (id == 0) //Insert Case
            {
                dal.SaveCustomer(dto);
            }
            else //update case
            {
                dal.UpdateCustomer(dto);
            }

            MessageBox.Show("Record is saved!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = 0;
            Int32.TryParse(txtCustomerIDToSearch.Text, out id);
            if (id == 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }
            else
            {
                CustomerDAL dal = new CustomerDAL();
                var obj = dal.GetCustomerByID(id);
                if (obj != null)
                {
                    txtCustomerID.Text = obj.CustomerID.ToString();
                    txtName.Text = obj.Name;
                    txtAddress.Text = obj.Address;
                }
                else
                    MessageBox.Show("Invalid ID");
            }

        }
    }
}
