using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace haberlesme_0._2_
{

    public partial class Form1 : Form

    {
        string data;
        public bool uyarı;
        int dosyanumarasi;
        public Form1()
        {

            InitializeComponent();
             pictureBox3.Visible = false;
             pictureBox4.Visible = false;
             pictureBox7.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            datas.ReadOnly = true;
            string[] ports = SerialPort.GetPortNames();  //Seri portları diziye ekleme
            foreach (string port in ports)
                comboBox1.Items.Add(port);               //Seri portları comboBox1'e ekleme
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived); //DataReceived eventini oluşturma
            //bu event ile seri portu dinleyerek porta veri geldiğinde gelen veriyi alarak data değişkenine eşitleyeceğiz.
        }
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();                      //Veriyi al

            this.Invoke(new EventHandler(displayData_event)); // displayData_event fonksiyonunu çalıştır
            //invoke kullanılmazsa hata veriyor

        }
       
        private void displayData_event(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
            try
            {
                string sicaklik1, sicaklik2, doluluk1;
                int sicaklika, sicaklikb, doluluka;
                
                string[] dizi = data.Split('*');
                //Thread.Sleep(1000);
                sicaklik1 = dizi[0].Substring(0, 2); linearScaleComponent1.Value = Convert.ToInt32(sicaklik1);
                sicaklik2 = dizi[1].Substring(0, 2); linearScaleComponent2.Value = Convert.ToInt32(sicaklik2);
                doluluk1 = dizi[2].Substring(0); linearScaleComponent3.Value = Convert.ToInt32(sicaklik2);

                datas.Text = dizi[0];
                textBox1.Text = dizi[1];
                textBox3.Text = dizi[2];
                textBox4.Text = "%" + dizi[3];
                textBox2.Text += DateTime.Now.ToString() + "   sıcaklık1 :     " + dizi[0] + "\n";
                textBox2.Text += DateTime.Now.ToString() + "   sıcaklık2 :     " + dizi[1] + "\n";
                textBox2.Text += DateTime.Now.ToString() + "   batarya gerilim :     " + dizi[2] + "\n";
                textBox2.Text += DateTime.Now.ToString() + "   batarya doluluk :     " + dizi[3] + "\n";
               
                sicaklika = Convert.ToInt32(sicaklik1); 
                sicaklikb = Convert.ToInt32(sicaklik2);
                doluluka = Convert.ToInt32(doluluk1);

                if (sicaklika >= 25)
                {
                    datas.Text = ("UYARI" + sicaklika);
                    pictureBox3.Visible = true;
                }
                else if (sicaklikb >= 25)
                {
                    textBox1.Text = "UYARI" + sicaklikb;
                    pictureBox4.Visible = true;

                }   
                
            }
            catch
            {
                
            }

        }
      
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();    //Seri port açıksa kapat
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            try//try-catch hata oluşabilecek durumlarda kullanılır dener hata olmazsa çalışır olursa catch de yazan olaylar oluşur
            {
                dosyanumarasi++;
                string filelocation = @"C:\Users\e_can\OneDrive\Masaüstü\kaydedilen_veriler\";//Dosyanın kaydedileceği konumu belirliyoruz
                string filename = ("data" + dosyanumarasi + ".txt"); //Kaydedilecek dosyanın ismi ( dosya numarası artarak kaydediliyor)
                System.IO.File.WriteAllText(filelocation + filename, "Zaman\t\t\tDeğer\n" + textBox2.Text); //Dosya konumuna textBox1 üstündeki verilerden oluşan text dosyamızı kaydediyoruz
                MessageBox.Show("Başarıyla Kaydedildi.");

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Hata!");//Hata mesajı
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                serialPort1.PortName = comboBox1.Text;  //ComboBox1'de seçili nesneyi port ismine ata
                serialPort1.BaudRate = 9600;            //BaudRate 9600 olarak ayarla
                serialPort1.Open();                     //Seri portu aç
                button1.Enabled = true;                  //Durdurma butonunu aktif hale getir
                button2.Enabled = false;                 //Başlatma butonunu pasif hale getir
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");    //Hata mesajı göster
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();        //Seri Portu kapa
                button1.Enabled = false;     //Durdurma butonunu pasif hale getir
                button2.Enabled = true;      //Başlatma butonunu aktif hale getir
            }
            catch
            {

            }
        }

        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
