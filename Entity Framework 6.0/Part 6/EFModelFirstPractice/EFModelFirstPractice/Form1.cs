using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFModelFirstPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cust = new CustomerDTO();
            cust.Name = "Bilal";

            using (var ctx = new MyModelContainer())
            {
                ctx.Customers.Add(cust);
                ctx.SaveChanges();



                var list = ctx.Customers.ToList();
            }
        }
    }
}
