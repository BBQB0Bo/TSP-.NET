using DataBaseLibrary;
using DataBaseLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public string FilePath { get; set; }

        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            InterfaceServiceClient client = new InterfaceServiceClient();


            FileDTO[] dbFiles;

            List<FileDTO> filesDTO = new List<FileDTO>();

            dbFiles = client.GetFiles();

            client.Close();

            var bindingList = new BindingList<FileDTO>(dbFiles);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

            this.dataGridView1.Columns[0].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = openFileDialog1.FileName;

                MessageBox.Show(FilePath);

                Form2 f2 = new Form2(this);

                f2.Size = new System.Drawing.Size(500, 500);

                f2.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    MessageBox.Show("File-urile gasite sunt in numar de  " + files.Length.ToString());
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form3 f3 = new Form3();
            string fullPath = "";

            fullPath = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            InterfaceServiceClient client = new InterfaceServiceClient();

            Propriety prop = client.returnPropriety(fullPath);

            client.Close();

            f3.textBox1.Text = prop.DataCreated.ToString();
            f3.textBox2.Text = prop.Event;
            f3.textBox3.Text = prop.People;
            f3.textBox4.Text = prop.Landscapes;
            f3.textBox5.Text = prop.Photoplace;
            f3.textBox6.Text = fullPath;


            f3.ShowDialog();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string fullPath = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();

            Process.Start(fullPath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();

            InterfaceServiceClient client = new InterfaceServiceClient();

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByDate(this.textBox1.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<DataBaseLibrary.File>(listFile);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByEvent(this.textBox2.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<FileDTO>(filesDTOs);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByPeople(this.textBox3.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<FileDTO>(filesDTOs);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByLandscapes(this.textBox4.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<FileDTO>(filesDTOs);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }
            if (!string.IsNullOrWhiteSpace(textBox5.Text))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByPhotoPlace(this.textBox5.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<FileDTO>(filesDTOs);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }
            if (!string.IsNullOrWhiteSpace(textBox6.Text))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByDynamicPropName(this.textBox6.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<FileDTO>(filesDTOs);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }
            if (!(string.IsNullOrWhiteSpace(textBox7.Text)) && !(string.IsNullOrWhiteSpace(textBox8.Text)))
            {
                DataBaseLibrary.File[] listFile;

                listFile = client.searchByDynamicProp(this.textBox7.Text, this.textBox8.Text);

                List<FileDTO> filesDTOs = new List<FileDTO>();

                foreach (DataBaseLibrary.File file in listFile)
                {
                    string photo = "";
                    if (file.IsPhoto == true)
                        photo = "Poza";
                    else photo = "Video";
                    FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                    filesDTOs.Add(fileDTO);
                }

                var bindingList = new BindingList<FileDTO>(filesDTOs);
                var source = new BindingSource(bindingList, null);
                dataGridView2.DataSource = source;
            }

            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[3].Visible = false;

            client.Close();
        }
    }
}
