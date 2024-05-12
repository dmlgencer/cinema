﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sinemaSalonları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen Bir Salon Seçiniz !", "SALON SEÇİMİ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listBox1.Items.Count ==0)
            {
                MessageBox.Show("Lütfen Salon Bilgilerini Görüntüleyiniz.", "SALON BİLGİSİ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBox1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Film, Şehir veya Salon Bilgilerini Seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamReader streamReader = File.OpenText(@"C:\Users\borag\OneDrive\Masaüstü\salonlar.txt");
            string metin; 
            while ((metin = streamReader.ReadLine()) != null)
            {
                listBox1.Items.Add(metin);
            }      
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
