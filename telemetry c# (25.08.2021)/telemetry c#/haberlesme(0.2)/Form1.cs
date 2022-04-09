using System;
using System.Windows.Forms;
using System.IO.Ports;

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
                comboBox1.Items.Add(port);               //Seri portları comboBox1'es ekleme
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
                string temprature1, temprature2, voltage1, mySpeed1, fullness1, mySpeed2, fullness2, voltage2;
                int tempraturea, tempratureb, voltagea, fullnessa, mySpeeda, mySpeedb;
                if (data.StartsWith("$"))
                {
                    string[] element = data.Split('*');//Veriyi '*' karakterine göre elemanlara ayırıyoruz
                                                       //Thread.Sleep(1000);

                    temprature1 = element[1]; linearScaleComponent1.Value = Convert.ToInt32(temprature1);//Char'ı string e çevirip Gauge'ye değer atıyoruz
                    temprature2 = element[2]; linearScaleComponent2.Value = Convert.ToInt32(temprature2);//
                    voltage1 = element[3];
                    fullness1 = element[4]; linearScaleComponent3.Value = Convert.ToInt32(fullness1);//
                    mySpeed1 = element[5];
                    mySpeeda = Convert.ToInt32(mySpeed1);
                    mySpeedb = mySpeeda; arcScaleComponent1.Value = mySpeedb;
                    mySpeed2 = Convert.ToString(mySpeedb);
                    label9.Text = element[2];//sıcaklık1 değeri    motor
                    fullnessa = Convert.ToInt32(fullness1);
                    // fullnessa = fullnessa ;
                    fullness2 = Convert.ToString(fullnessa);
                    voltagea = Convert.ToInt32(voltage1);
                    voltage2 = Convert.ToString(voltagea);
                    int voltageb = voltagea;

                    voltagea = voltagea - 1;
                    if (mySpeeda <= 0)
                    {
                        voltagea = 0;
                    }
                    String motorvoltage = Convert.ToString(voltagea);
                    label63.Text = motorvoltage;//gerilim







                    label10.Text = temprature1;//sıcaklık2 değeri batarya
                    label11.Text = voltage2;//pil voltage
                    label12.Text = fullness2;//pil fullness
                    label13.Text = mySpeed2;//hız


                  
                    double b1 = Convert.ToDouble(element[6]);
                    double b2 = Convert.ToDouble(element[7]);
                    double b3 = Convert.ToDouble(element[8]);
                    double b4 = Convert.ToDouble(element[9]);
                    double b5 = Convert.ToDouble(element[10]);
                    double b6 = Convert.ToDouble(element[11]);
                    double b7 = Convert.ToDouble(element[12]);
                    double b8 = Convert.ToDouble(element[13]);
                    double b9 = Convert.ToDouble(element[14]);
                    double b10 = Convert.ToDouble(element[15]);
                    double b11 = Convert.ToDouble(element[16]);
                    double b12 = Convert.ToDouble(element[17]);
                    double b13 = Convert.ToDouble(element[18]);
                    double b14 = Convert.ToDouble(element[19]);
                    double b15 = Convert.ToDouble(element[20]);
                    double b16 = Convert.ToDouble(element[21]);
                    double b17 = Convert.ToDouble(element[22]);
                    double b18 = Convert.ToDouble(element[23]);
                    double b19 = Convert.ToDouble(element[24]);
                    double b20 = Convert.ToDouble(element[25]);

                    double bb1 = b1 / 50;
                    double bb2 = b2 / 50;
                    double bb3 = b3 / 50;
                    double bb4 = b4 / 50;
                    double bb5 = b5 / 50;
                    double bb6 = b6 / 50;
                    double bb7 = b7 / 50;
                    double bb8 = b8 / 50;
                    double bb9 = b9 / 50;
                    double bb10 = b10 / 50;
                    double bb11 = b11 / 50;
                    double bb12 = b12 / 50;
                    double bb13 = b13 / 50;
                    double bb14 = b14 / 50;
                    double bb15 = b15 / 50;
                    double bb16 = b16 / 50;
                    double bb17 = b17 / 50;
                    double bb18 = b18 / 50;
                    double bb19 = b19 / 50;
                    double bb20 = b20 / 50;




                    label43.Text = bb1.ToString();
                    label42.Text = bb2.ToString();
                    label41.Text = bb3.ToString();
                    label40.Text = bb4.ToString();
                    label39.Text = bb5.ToString();
                    label38.Text = bb6.ToString();
                    label37.Text = bb7.ToString();
                    label36.Text = bb8.ToString();
                    label35.Text = bb9.ToString();
                    label34.Text = bb10.ToString();
                    label53.Text = bb11.ToString();
                    label52.Text = bb12.ToString();
                    label51.Text = bb13.ToString();
                    label50.Text = bb14.ToString();
                    label49.Text = bb15.ToString();
                    label48.Text = bb16.ToString();
                    label47.Text = bb17.ToString();
                    label46.Text = bb18.ToString();
                    label45.Text = bb19.ToString();
                    label44.Text = bb20.ToString();

                    String pil1 = bb1.ToString();
                    String pil2 = bb2.ToString();
                    String pil3 = bb3.ToString();
                    String pil4 = bb4.ToString();
                    String pil5 = bb5.ToString();
                    String pil6 = bb6.ToString();
                    String pil7 = bb7.ToString();
                    String pil8 = bb8.ToString();
                    String pil9 = bb9.ToString();
                    String pil10 = bb10.ToString();
                    String pil11 = bb11.ToString();
                    String pil12 = bb12.ToString();
                    String pil13 = bb13.ToString();
                    String pil14 = bb14.ToString();
                    String pil15 = bb15.ToString();
                    String pil16 = bb16.ToString();
                    String pil17 = bb17.ToString();
                    String pil18 = bb18.ToString();
                    String pil19 = bb19.ToString();
                    String pil20 = bb20.ToString();

                    label60.Text = element[26];//batarya sağşığı
                    label62.Text = element[27];//en büyük batarya sıcaklığı
                    int enyukseksicaklik = Convert.ToInt32(element[27]);
                    label63.Text = motorvoltage;//gerilim
                    //sicakliklar
                    label65.Text = element[29];
                    label66.Text = element[30];
                    label67.Text = element[31];
                    label68.Text = element[32];
                    label69.Text = temprature2;








                    textBox2.Text += DateTime.Now.ToString() + " Sıcaklık1       :   " + element[1] + "\n";//Görünmez Text dosyasına değerler ekleniyor
                    textBox2.Text += DateTime.Now.ToString() + " Sıcaklık2       :   " + element[2] + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Batarya gerilim :   " + element[3] + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Batarya doluluk :   " + element[4] + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Hız             :   " + mySpeed2 + "\n";//

                    textBox2.Text += DateTime.Now.ToString() + " Pil1            :   " + pil1 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil2            :   " + pil2 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil3            :   " + pil3 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil4            :   " + pil4 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil5            :   " + pil5 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil6            :   " + pil6 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil7            :   " + pil7 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil8            :   " + pil8 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil9            :   " + pil9 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil10           :   " + pil10 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil11           :   " + pil11 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil12           :   " + pil12 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil13           :   " + pil13 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil14           :   " + pil14 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil15           :   " + pil15 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil16           :   " + pil16 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Pil17           :   " + pil17 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " pil18           :   " + pil18 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil19           :   " + pil19 + "\n";//
                    textBox2.Text += DateTime.Now.ToString() + " Pil20           :   " + pil20 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Batarya Sağlığı :   " + element[26] + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Max batarya sıcaklığı :   " + element[27] + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Batarya Sıcaklığı1 :   " + element[29] + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Batarya Sıcaklığı2 :   " + element[30] + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Batarya Sıcaklığı3 :   " + element[31] + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Batarya Sıcaklığı4 :   " + element[32] + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Batarya Sıcaklığı5 :   " + temprature2 + "\n";
                    textBox2.Text += DateTime.Now.ToString() + " Motor Voltaj :   " + motorvoltage + "\n";


                    //label54.Text = data;
                    textBox2.Text += "------------------------------------------" + "\n";//
                    tempraturea = Convert.ToInt32(temprature1); //değerler çeviriliyor
                    tempratureb = Convert.ToInt32(temprature2);//
                    voltagea = Convert.ToInt32(voltage1);
                    fullnessa = Convert.ToInt32(fullness1);
                    //linearScaleComponent3.Value = Convert.ToInt32(fullnessa);
                    if (enyukseksicaklik >= 70)//Uyarı kodu
                    {
                        label56.Text = ("UYARI BATARYA ORTALAMA SICAKLIK= " + element[27] + "°C");
                        pictureBox3.Visible = true;
                    }
                    else
                    {
                        pictureBox3.Visible = false;

                    }
                    if (tempraturea >= 70)//Uyarı kodu
                    {
                        label56.Text = "UYARI BATARYA SICAKLIK= " + temprature1 + "°C";
                        pictureBox3.Visible = true;
                    }
                    else
                    {
                        pictureBox3.Visible = false;

                    }
                    if (tempratureb >= 70)//Uyarı kodu
                    {
                        label57.Text = ("UYARI MOTOR SICAKLIK= " + temprature2 + "°C");
                        pictureBox4.Visible = true;

                    }
                    else
                    {
                        pictureBox4.Visible = false;

                    }
                    if (fullnessa < 20)
                    {
                        pictureBox7.Visible = true;
                    }
                    else
                    {
                        pictureBox7.Visible = false;
                    }
                    if (data.EndsWith("END"))
                    {

                        return;
                    }
                }
            }
            catch
            {
                // Buraya message yazdırınca kod bozuluyor
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
                string filelocation = @"C:\Users\Ayvaz\Desktop\kaydedilen_veriler\";//Dosyanın kaydedileceği konumu belirliyoruz
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

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}
