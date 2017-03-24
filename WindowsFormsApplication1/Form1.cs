using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BO;
using BL;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BindingSource bs;

        private async void Form1_Load(object sender, EventArgs e)
        {
           
            KategoriBL myKategori = new KategoriBL();
            var results = await myKategori.GetAllKategori();

            bs = new BindingSource();
            bs.DataSource = results;

            textBox1.DataBindings.Add("Text", bs, "NamaKategori");

            dataGridView1.DataSource = bs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
    }
}
