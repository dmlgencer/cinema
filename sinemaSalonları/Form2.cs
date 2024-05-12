using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using  static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace sinemaSalonları
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Random random = new Random();
            //50 tane hem ikili hem tekli koltuk ekledik
            Button b = new Button();

            for (int i = 109; i > 0; i--)
            {
                    Button buton = new Button
                    {
                        Name = "button" + i,
                        Text = (i).ToString(),
                        Height = 50,
                        Width = 50,
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat

                    };
                    buton.Click += koltuk;
                    flowLayoutPanel1.Controls.Add(buton);


                // 50'den sonra bir satır boşluk bırak
                if (i == 55)
                {
                    Panel bosluk = new Panel
                    {
                        Width = 1000,
                        Height = 50, 
                        BackColor = Color.Transparent 
                    };
                    flowLayoutPanel1.Controls.Add(bosluk);
                }


            }

            Random random1 = new Random();

            // Rastgele 5 koltuk seçip onların rengini kırmızı yap
            List<Button> redButtons = new List<Button>();
            while (redButtons.Count < 10)
            {
                int randomIndex = random1.Next(flowLayoutPanel1.Controls.Count);
                if (flowLayoutPanel1.Controls[randomIndex] is Button button && button.BackColor != Color.Red)
                {
                    button.BackColor = Color.Red;
                    redButtons.Add(button);
                }
            }

        }

        int yesilTekli = 0;
   
        private void koltuk(object sender, EventArgs e)
        {

            Button buton2 = (Button)sender;
            if (buton2.BackColor == Color.LightGray)
            {
                buton2.BackColor = Color.Green;
                yesilTekli++;
            }

            if (buton2.BackColor == Color.Red)
            {
                MessageBox.Show("Bu koltuk zaten alınmış. Başka koltuk seçiniz.", "KOLTUK SEÇİMİ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buton2.BackColor = Color.Red;
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            // kolturkların renk değişimi
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Button button && button.BackColor == Color.Green)
                {
                    button.BackColor = Color.LightGray;
                    
                }
            }

            textBox1.Clear();
            textBox3.Clear();
            textBox9.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox10.Clear();

            comboBox1.SelectedIndex = -1;
            yesilTekli = 0;          
                     
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        int fiyat, fiyat2, fiyat3, fiyat4;
        int ödenecekTutar;
        private void button1_Click(object sender, EventArgs e)
        {

            int tekliKoltukTam = 100;
           
            int tekliÖğrenci = 70;
            

            //tam
            if (textBox3.Text != "" && yesilTekli!=0)
            {
                 fiyat = 100* Convert.ToInt32 (textBox3.Text);
   
            }
           
            //öğrenci
            if (textBox4.Text != "" && yesilTekli != 0)
            {
                 fiyat3 = 70 * Convert.ToInt32(textBox4.Text);
            }

            
            int ödenecekTutar = fiyat + fiyat2 + fiyat3 + fiyat4;
            string menuFiyat = comboBox1.SelectedItem.ToString();

            
            string[] parcalar = menuFiyat.Split(' ');
          
            string a = "";
            
            foreach (string parca in parcalar)
            {              
                foreach (char c in parca)
                { 
                    if (char.IsDigit(c))
                    {      
                        int index = parca.IndexOf(c); 
                        a = parca.Substring(index); 
                        break; 
                    }

                    if (!char.IsDigit(c))
                    {
                        
                        int p = 0;
                        int total2 = ödenecekTutar + Convert.ToInt32(p);    
                        textBox1.Text = "Seçilen Koltuk Adedi: " + yesilTekli + "\r\n" + "Ödenecek Tutar: " + ödenecekTutar.ToString();
                        textBox2.Text = total2.ToString();
                    }
                }
            }
                 
            int total = ödenecekTutar + Convert.ToInt32(a);
            textBox1.Text = 0.ToString();
        
           textBox1.Text = "Seçilen Koltuk Adedi: " + yesilTekli + "\r\n" +  comboBox1.Text + "\r\n" + "Ödenecek Tutar: " + total.ToString();
               
            textBox2.Text = total.ToString();

        }

        int a = 0;
        int b = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            a++;
            textBox3.Text = a.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a--;
            textBox3.Text = a.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            b++;
            textBox4.Text = b.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            b--;
            textBox4.Text = b.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text!="" || textBox6.Text != "" || textBox7.Text != "" || textBox8.Text != "")
            {
                MessageBox.Show("BİLGİLERİNİZ ALINMIŞTIR. İYİ SEYİRLER DİLERİZ.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 form2 = new Form2();
                form2.Close();
            }
           
        }

        private bool metinKontrol(string metin)
        {
            foreach (char karakter in metin)
            {
                if (!char.IsLetter(karakter) && karakter != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool sayiKontrol(string metin)
        {
            foreach (char karakter in metin)
            {
                if (!char.IsDigit(karakter))
                {
                    return false;
                }
            }
            return true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Menü Dosyası Seçiniz.";
            openFileDialog1.Filter = "Text dosyalar|.txt|Tüm dosyalar|.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox9.Text = File.ReadAllText(openFileDialog1.FileName);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Bilgilerinizi Eksiksiz Giriniz !", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return;
            }

            string metin = textBox5.Text;
            bool sadeceHarfVeKelime = metinKontrol(metin);

            if (!sadeceHarfVeKelime)
            {
                MessageBox.Show("Ad Soyad Kısmına lütfen sadece harf veya kelime giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }
            string sayi = textBox6.Text;
            int size2 = sayi.Length;
            bool sadeceSayi = sayiKontrol(sayi); // Kredi kartı numarası için kontrol yapılıyor

            if (!sadeceSayi)
            {
                MessageBox.Show("Kredi kartı numarası kısmına lütfen sadece sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox6.Focus();
                return;
            }

            if (size2 != 16)
            {
                MessageBox.Show("Kredi kartı numarası 16 karakter olmalıdır. Aralarında Boşluk Bırakmadan Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
                return;
            }

            string guvenlikNo = textBox8.Text;
            int size = guvenlikNo.Length;
            bool guvenlikNoSayi = sayiKontrol(guvenlikNo); // Güvenlik numarası için kontrol yapılıyor

            if (!guvenlikNoSayi)
            {
                MessageBox.Show("Güvenlik numarası kısmına lütfen sadece sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox8.Focus();
                return;
            }

            if (size != 3)
            {
                MessageBox.Show("Güvenlik numarası 3 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox8.Focus();
                return;
            }
            int ay = Convert.ToInt32(textBox7.Text);
            if (ay>13 || ay<2)
            {
                MessageBox.Show("Lütfen geçerli bir ay değeri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox7.Focus();
                return;
            }
            int yıl = Convert.ToInt32(textBox10.Text);

            if (yıl<=24 || yıl>=99)
            {
                MessageBox.Show("Lütfen geçerli bir yıl değeri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox10.Focus();
                return;
            }
            /*
            openFileDialog1.Title = "Referans dosyası seçiniz.";
            openFileDialog1.Filter = "Text dosyalar|.txt|Tüm dosyalar|.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string referansNo;

            string  r = openFileDialog1.FileName;

            string[] referansArr = File.ReadAllLines(r);

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, referansArr.Length); // Rastgele bir index seç

            for (int i = 0; i < referansArr.Length; i++)    
            { 
                string r1 = referansArr[i].Substring(0,4);
                   
                MessageBox.Show("Referans Nuamranız: " +  r1 +  "\r\n" + "Onayla butonuna basarak bilgilerini onaylamayı unutmayın.", "REFERANS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button8.Focus();
                return;    

            }
            */
            openFileDialog1.Title = "Referans dosyası seçiniz.";
            openFileDialog1.Filter = "Text dosyalar|.txt|Tüm dosyalar|.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string r = openFileDialog1.FileName;

            string[] referansArr = File.ReadAllLines(r);

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, referansArr.Length); // Rastgele bir index seç

            string r1 = referansArr[randomIndex].Substring(0, 4);

            MessageBox.Show("Referans Numaranız: " + r1 + "\r\n" + "Onayla butonuna basarak bilgilerini onaylamayı unutmayın.", "REFERANS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button8.Focus();

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



