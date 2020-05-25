using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        protected Form1 UseForm;

        public Form2(Form1 form)
        {
            InitializeComponent();
            this.UseForm = form;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dateCreated = textBox1.Text;
            string eve = textBox2.Text;
            string people = textBox3.Text;
            string landscapes = textBox4.Text;
            string photoPlace = textBox5.Text;

            /*Apelam serviciul din api pentru a adauga o fotografie*/
            InterfaceServiceClient client = new InterfaceServiceClient();

            client.AddFile(UseForm.FilePath, dateCreated, eve, people, landscapes, photoPlace);

            client.Close();

            MessageBox.Show("Fotografia " + " " + UseForm.FilePath + " a fost adaugata cu succes");

            this.Hide();
        }
    }
}
