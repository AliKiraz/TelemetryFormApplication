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
        public bool warning;
        int fileNumber;
        public Form1()
        {

            InitializeComponent();
             pictureBox3.Visible = false;
             pictureBox4.Visible = false;
             pictureBox7.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
            string[] ports = SerialPort.GetPortNames();  //Seri portları elementye ekleme
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
                
                    string temprature1, temprature2, voltage1,mySpeed1,fullness1;
                    int tempraturea, tempratureb,mySpeeda,voltagea,fullnessa;
                   


                    string[] element = data.Split('*');
                    //Thread.Sleep(1000);
                    temprature1 = element[0].Substring(0, 2); linearScaleComponent1.Value = Convert.ToInt32(temprature1);
                    temprature2 = element[1].Substring(0, 2); linearScaleComponent2.Value = Convert.ToInt32(temprature2);
                    voltage1 = element[2].Substring(0, 2);
                    fullness1 = element[3].Substring(0, 2); linearScaleComponent3.Value = Convert.ToInt32(fullness1);
                    mySpeed1 = element[4].Substring(0, 2);arcScaleComponent1.Value = Convert.ToInt32(mySpeed1);
                    label9.Text = element[0];//sıcaklık1 değeri    
                    label10.Text = element[1];//sıcaklık2 değeri
                    label11.Text = element[2];//pil voltage
                    label12.Text = "%" + element[3];//pil fullness
                    label13.Text = element[4];//hız
                    textBox2.Text += DateTime.Now.ToString() + " Sıcaklık1 :  " + element[0] + "\n";//Görünmez Text dosyasına değerler ekleniyor
                    textBox2.Text += DateTime.Now.ToString() + " Sıcaklık2 :  " + element[1] + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Batarya gerilim :   " + element[2] + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Batarya doluluk :   " + element[3] + "\n";//


                    tempraturea = Convert.ToInt32(temprature1); //değerler çeviriliyor
                    tempratureb = Convert.ToInt32(temprature2);//
                    voltagea = Convert.ToInt32(voltage1);
                    fullnessa = Convert.ToInt32(fullness1);
                //linearScaleComponent3.Value = Convert.ToInt32(fullnessa);
                    if (tempraturea >= 30)
                    {
                        label9.Text = ("UYARI" + tempraturea);
                        pictureBox3.Visible = true;
                    }
                    else
                    {
                        pictureBox3.Visible = false;
                    }
                    if (tempratureb >= 30)
                    {
                        label10.Text = "UYARI" + tempratureb;
                        pictureBox4.Visible = true;

                    }
                    else
                    {
                        pictureBox4.Visible = false;
                    }
                    if (fullnessa < 70)
                    {
                        pictureBox7.Visible = true;
                    }
                    else
                    {
                        pictureBox7.Visible = false;
                    }
                    
                
            }
            catch
            {
                // buraya message yazdırırsak kod bozuluyor
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
                fileNumber++;
                string filelocation = @"C:\Users\e_can\OneDrive\Masaüstü\kaydedilen_veriler\";//Dosyanın kaydedileceği konumu belirliyoruz
                string filename = ("data" + fileNumber + ".txt"); //Kaydedilecek dosyanın ismi ( dosya numarası artarak kaydediliyor)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void gaugeControl4_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }

}
