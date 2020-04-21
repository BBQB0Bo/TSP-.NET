using DataBaseLibrary;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InterfaceServiceClient client = new InterfaceServiceClient();

            Propriety prop = client.returnPropriety(textBox6.Text);

            DateTime parsedDate = DateTime.Parse(textBox1.Text);
            if (prop.DataCreated != parsedDate)
                client.updateDateTime(textBox6.Text, parsedDate.ToString());

            if (prop.Event != textBox2.Text)
                client.updateEvent(textBox6.Text, textBox2.Text);

            if (prop.People != textBox3.Text)
                client.updatePeople(textBox6.Text, textBox3.Text);

            if (prop.Landscapes != textBox4.Text)
                client.updateLandscapes(textBox6.Text, textBox4.Text);

            if (prop.Photoplace != textBox5.Text)
                client.updateLandscapes(textBox6.Text, textBox5.Text);

            MessageBox.Show("S-au efectuat modificarile pentru fotografia selectata");

            client.Close();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string propName = textBox7.Text;
            string propValue = textBox8.Text;

            InterfaceServiceClient client = new InterfaceServiceClient();

            client.AddDynamicProp(textBox6.Text, propName, propValue);

            MessageBox.Show("S-a adaugat proprietatea dinamica " + propName +
                " cu valoarea " + propValue + " pentru fotografia curenta");

            client.Close();

            this.Hide();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string propName = textBox9.Text;
            string oldPropValue = textBox10.Text;
            string newPropValue = textBox11.Text;

            InterfaceServiceClient client = new InterfaceServiceClient();

            client.UpdateDynamicProp(textBox6.Text, propName, oldPropValue, newPropValue);

            MessageBox.Show("S-a updatat proprietatea dinamica " + propName +
                " cu valoarea " + newPropValue + " pentru fotografia curenta");

            client.Close();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InterfaceServiceClient client = new InterfaceServiceClient();

            client.DeleteFile(textBox6.Text);

            MessageBox.Show("Fotografia curenta a fost stearsa din aplicatie");

            client.Close();

            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            InterfaceServiceClient client = new InterfaceServiceClient();

            string propName = textBox12.Text;

            client.DeleteDynamicProp(textBox6.Text, propName);

            MessageBox.Show("Proprietatea cu numele " + propName + " a fost stearsa.");

            client.Close();
        }
    }
}
