using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Пятерочка
{
    public partial class Form1 : Form
    {
        MySqlConnection Baza = new MySqlConnection("host = localhost; user = root; password = 12345; database = пятерочка");
        public Form1()
        {
            InitializeComponent();
            tabControl1.Visible = false;
            panel1.Visible = false;
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.сотрудник", Baza);
            Baza.Open();
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                NSbox.Items.Add(rdr1[1]);
            }
            Baza.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            DELbox.Visible = false;
            Baza.Open();
            obnova5();
            Random rnd = new Random();
            S = rnd.Next(1, 3);
            obnova6();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM пятерочка.метод_доставки", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                METbox3.Items.Add(rdr1[1]);
            }
            rdr1.Close();
            Baza.Close();
        }
        void obnova1()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM пятерочка.товары_view", Baza);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM пятерочка.поставщик;", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                Pbox1.Items.Add(rdr1[1]);
            }
            rdr1.Close();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM пятерочка.тип_товара;", Baza);
            MySqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                Tbox1.Items.Add(rdr2[1]);
            }
            rdr2.Close();
        }
        void obnova2()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM пятерочка.склад_view;", Baza);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM пятерочка.поставщик;", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                Pbox1.Items.Add(rdr1[1]);
            }
            rdr1.Close();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM пятерочка.тип_товара;", Baza);
            MySqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                Tbox2.Items.Add(rdr2[1]);
            }
            rdr2.Close();
        }
        void obnova3()
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Сотрудник = '{NSbox.Text}'", Baza);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Сотрудник = '{NSbox.Text}' group by Клиент", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                Klbox.Items.Add(rdr1[5]);
            }
            rdr1.Close();
        }
        void obnova4()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM пятерочка.история_заказов;", Baza);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView4.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
            }
            rdr.Close();
        }
        void obnova5()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM пятерочка.товары_view", Baza);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView5.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            rdr.Close();
            
        }
        void obnova6()
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Клиент = '{FIObox3.Text}';", Baza);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView4.Rows.Add(rdr[0], rdr[1], rdr[5], rdr[4], rdr[3], rdr[6], rdr[8], rdr[9]);
            }
            rdr.Close();
        }
        string name;
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button cl = (Button)sender;
            string postav1 = ""; string tip1 = "";
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.поставщик where Наименование_пс = '{Pbox1.Text}';", Baza);
            Baza.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                postav1 = rdr[0].ToString();
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.тип_товара where Название = '{Tbox1.Text}';", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                tip1 = rdr1[0].ToString();
            }
            rdr1.Close();
            switch (cl.Text)
            {
                case "Добавить Товар":
                    MySqlCommand D = new MySqlCommand($"INSERT INTO `пятерочка`.`товары` (`Наименование_П`, `Код_поставщика`, `Тип_П`, `Цена`, `Статус`) VALUES ('{Nbox1.Text}', '{postav1}', '{tip1}', '{Cbox1.Text}', '{Sbox1.Text}')", Baza);
                    D.ExecuteNonQuery();
                    dataGridView1.Rows.Clear();
                    obnova1();
                    IDbox1.Text = Nbox1.Text = Pbox1.Text = Tbox1.Text = Cbox1.Text = Sbox1.Text = "";
                    break;
                case "Изменить информацию":
                    MySqlCommand I = new MySqlCommand($"UPDATE `пятерочка`.`товары` SET `idТовары` = '{IDbox1.Text}', `Наименование_П` = '{Nbox1.Text}', `Код_поставщика` = '{postav1}', `Тип_П` = '{tip1}', `Цена` = '{Cbox1.Text}', `Статус` = '{Sbox1.Text}' WHERE (`idТовары` = '{IDbox1.Text}')", Baza);
                    I.ExecuteNonQuery();
                    dataGridView1.Rows.Clear();
                    obnova1();
                    IDbox1.Text = Nbox1.Text = Pbox1.Text = Tbox1.Text = Cbox1.Text = Sbox1.Text = "";
                    break;
                case "Удалить товар":
                    DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить этот объект?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MySqlCommand Y = new MySqlCommand($"DELETE FROM `пятерочка`.`товары` WHERE (`idТовары` = '{IDbox1.Text}')", Baza);
                        Y.ExecuteNonQuery();
                        MessageBox.Show("Вы удалили объект");
                        dataGridView1.Rows.Clear();
                        obnova1();
                        IDbox1.Text = Nbox1.Text = Pbox1.Text = Tbox1.Text = Cbox1.Text = Sbox1.Text = "";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        
                    }
                    break;

            }
            Baza.Close();
        }
        string postav, tip;

        private void button11_Click(object sender, EventArgs e)
        {
            Button cl = (Button)sender;
            string postav1 = ""; string tip1 = "";
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.поставщик where Наименование_пс = '{Pbox2.Text}';", Baza);
            Baza.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                postav1 = rdr[0].ToString();
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.тип_товара where Название = '{Tbox2.Text}';", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                tip1 = rdr1[0].ToString();
            }
            rdr1.Close();
            switch (cl.Text)
            {
                case "Добавить Товар":
                    MySqlCommand D = new MySqlCommand($"INSERT INTO `пятерочка`.`товары_на_складе` (`Наименование_С`, `Поставщик_С`, `Тип_товара_С`, `Цена`, `Статус`) VALUES ('{IDbox2.Text}', '{postav1}', '{tip}', '{Cbox2.Text}', '{Tbox2.Text}')", Baza);
                    D.ExecuteNonQuery();
                    dataGridView2.Rows.Clear();
                    obnova2();
                    IDbox2.Text = Nbox2.Text = Pbox2.Text = Tbox2.Text = Cbox2.Text = Sbox2.Text = "";
                    break;
                case "Изменить информацию":
                    MySqlCommand I = new MySqlCommand($"UPDATE `пятерочка`.`товары_на_складе` SET `idтовары_на_складе` = '{IDbox2.Text}', `Наименование_С` = '{Nbox2.Text}', `Поставщик_С` = '{postav1}', `Тип_товара_С` = '{tip1}', `Цена` = '{Cbox2.Text}', `Статус` = '{Sbox2.Text}' WHERE (`idтовары_на_складе` = '{IDbox2.Text}')", Baza);
                    I.ExecuteNonQuery();
                    dataGridView2.Rows.Clear();
                    obnova2();
                    IDbox2.Text = Nbox2.Text = Pbox2.Text = Tbox2.Text = Cbox2.Text = Sbox2.Text = "";
                    break;
                case "Удалить товар":
                    DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить этот объект?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MySqlCommand Y = new MySqlCommand($"DELETE FROM `пятерочка`.`товары_на_складе` WHERE (`idтовары_на_складе` = '{IDbox2.Text}')", Baza);
                        Y.ExecuteNonQuery();
                        MessageBox.Show("Вы удалили объект");
                        dataGridView2.Rows.Clear();
                        obnova2();
                        IDbox2.Text = Nbox2.Text = Pbox2.Text = Tbox2.Text = Cbox2.Text = Sbox2.Text = "";
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                    break;

            }
            Baza.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDbox2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nbox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            Pbox2.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            Tbox2.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            Cbox2.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            Sbox2.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.поставщик where Наименование_пс = '{Pbox2.Text}';", Baza);
            Baza.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                postav = rdr[0].ToString();
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.тип_товара where Название = '{Tbox2.Text}';", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                tip = rdr1[0].ToString();
            }
            rdr1.Close();
            Baza.Close();
        }
        string kl;
        private void Klbox_TextChanged(object sender, EventArgs e)
        {
            if (Klbox.Text != "")
            {
                Baza.Open();
                dataGridView3.Rows.Clear();
                SPbox.Text = "";
                string dost = "";
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Клиент = '{Klbox.Text}'", Baza);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SPbox.Text += $"{rdr[3]} - {rdr[8]}(сумма) - {rdr[7]}(количество);\n";
                    dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    SUMbox.Text = rdr[10].ToString();
                    
                }
                rdr.Close();
                MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Клиент = '{Klbox.Text}' group by Цена_доставки; ", Baza);
                MySqlDataReader rdr1 = cmd1.ExecuteReader();
                while (rdr1.Read())
                {
                    dost = rdr1[9].ToString();
                }
                rdr1.Close();
                MySqlCommand cmd3 = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Клиент = '{Klbox.Text}';", Baza);
                MySqlDataReader rdr3 = cmd3.ExecuteReader();
                while (rdr3.Read())
                {
                    kl = rdr3[1].ToString();
                }
                rdr3.Close();
                Baza.Close();
            }
           
        }
        private void button13_Click(object sender, EventArgs e)
        {
            string data = ""; string klient = ""; string sodrudnik = ""; string tovar = ""; string metod_d = ""; string cena = ""; string sum = ""; string kl = "";
            DateTime dat = DateTime.Today;
            DialogResult dialogResult = MessageBox.Show("Провертье все ли собрано верно\nЕсли все готово, нажмите OK", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Baza.Open();
                MessageBox.Show("Заказ получил Статус собран и готов к получение или отправке");
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.заказ_view where Клиент = '{Klbox.Text}'", Baza);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    kl = rdr[0].ToString();
                    data = dat.ToString("dd/MM/yyyy");
                    klient = rdr[5].ToString();
                    sodrudnik = STbox.Text;
                    tovar = SPbox.Text;
                    metod_d = rdr[6].ToString();
                    cena = rdr[9].ToString();
                    sum = SUMbox.Text;
                }
                rdr.Close();
                MySqlCommand Dob = new MySqlCommand($"INSERT INTO `пятерочка`.`история_заказов` (`Дата`, `Клиент`, `Сотрудник`, `Товар`, `Метод_доставки`, `Цена_доставки`, `Сумма_заказа`) VALUES ('{data}', '{klient}', '{sodrudnik}', '{tovar}', '{metod_d}', '{cena}', '{sum}')", Baza);
                Dob.ExecuteNonQuery();
                MySqlCommand Del = new MySqlCommand($"DELETE FROM пятерочка.заказ Where Код_клиента = '{kl}';", Baza);
                Del.ExecuteNonQuery();
                string text = $"000 'Биоконтроль - К'\n115478 Москва Каширское ш.24 стр.10 06.05.19 18:34\nPH KKТ: 0001132713048398 ЗН ККТ 0490330012051075 СНЕНА 278 ЧЕК: 75\nКАССОВЫЙ ЧЕК/ ПРИХОД ИНН: 7724548394 ФН: 9252440300024055 Кассир: Московчук Наталия Михайловна #4126 Сайт ФНС: www. nalog.ru\n{SPbox.Text}\nСумма заказа: {SUMbox.Text}";
                File.WriteAllText(@"C:\Users\stepa\OneDrive\Рабочий стол\Дистант\check.txt", text);
                Klbox.Text = SUMbox.Text = SPbox.Text = "";
                Baza.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void NSbox_TextChanged(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.Visible = true;
            panel1.Visible = false;
            Baza.Open();
            obnova1();
            obnova2();
            obnova3();
            obnova4();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.сотрудник where ФИО = '{NSbox.Text}';", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                STbox.Text = rdr1[1].ToString();
            }
            Baza.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void DELbox_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите очистить историю заказов ?!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Baza.Open();
                MySqlCommand Del_T = new MySqlCommand($"Delete FROM пятерочка.история_заказов;", Baza);
                Del_T.ExecuteNonQuery();
                MessageBox.Show("Очистка завершена");
                dataGridView4.Rows.Clear();
                obnova4();
                Baza.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Label katalog = (Label)sender;
            Baza.Open();
            if(katalog.Text != "Все товары\r\n")
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.товары_view where Тип_товара = '{katalog.Text}'", Baza);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dataGridView5.Rows.Clear();
                    dataGridView5.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                rdr.Close();
            }
            else if(katalog.Text == "Все товары\r\n")
            {
                dataGridView5.Rows.Clear();
                obnova5();
            }
            Baza.Close();
        }
        string tovar1 = "";
        string cena1 = "";
        int id = 0;
        int N = 0;
        double sum = 0;
        string SQL = "";
        string kod_t = "";
        string Kod_S = "";
        string Kod_Klient = "";
        string Kod_metod = "";
        int S = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            double c = 0;
            double d = 0;
            if (tovar1 != "")
            {
                N += 1;
                Nproduct.Text = $"{N}";
                dataGridView6.Rows.Add(N, tovar1, kol, cena1);
                c = Convert.ToDouble(cena1);
                sum += (c * kol);
                if (sum < 500)
                    d = 249;
                else if (sum < 1000 && sum >= 500)
                    d = 189;
                else if (sum < 2000 && sum >= 1000)
                    d = 129;
                else if (sum >= 2000)
                    d = 89;
                sum += d;
                SUMbox3.Text = sum.ToString();
                CDbox3.Text = $"{d:0.00}";
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }
        }
        double kol = 1;
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kol = 1;
            tovar1 = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            cena1 = dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString();
            KOLbox.Text = $"{kol}";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage6"];
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button cl = (Button)sender;
            switch (cl.Text)
            {
                case "+":
                    kol += 1;
                    KOLbox.Text = $"{kol}";
                    break;
                case "-":
                    kol -= 1;
                    if (kol < 1)
                        kol = 1;
                    KOLbox.Text = $"{kol}";
                    
                    break;
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KOLbox1.Text = dataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
            id = dataGridView6.CurrentCell.RowIndex;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button cl = (Button)sender;
            switch (cl.Text)
            {
                case "Сохранить":
                    dataGridView6.CurrentRow.Cells[2].Value = KOLbox1.Text.ToString();
                    break;
                case "Удалить":
                    dataGridView6.Rows.Remove(dataGridView6.Rows[id]);
                    KOLbox1.Text = "";
                    break;
            }
        }
        string klient = "";
        private void button5_Click(object sender, EventArgs e)
        {
            Baza.Open();
            if (FIObox3.Text != "" && METbox3.Text != "" && Tbox3.Text != "")
            {
                DateTime date_today = DateTime.Today;
                string DATE = date_today.ToString("dd/MM/yyyy");
                for (int i = 0; i < N; i++)
                {
                    string CENA = dataGridView6.Rows[i].Cells[3].Value.ToString();
                    string KOL = dataGridView6.Rows[i].Cells[2].Value.ToString();
                    string TOVAR = dataGridView6.Rows[i].Cells[1].Value.ToString();
                    if (klient == "")
                    {
                        MySqlCommand Klient = new MySqlCommand($"INSERT INTO `пятерочка`.`клиент` (`ФИО`, `Адрес`, `Телефон`, `Примечание`) VALUES ('{FIObox3.Text}', '{Abox3.Text}', '{Tbox3.Text}', '{PRIMbox.Text}')", Baza);
                        Klient.ExecuteNonQuery();
                    }
                    ///////////////////
                    MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.товары where Наименование_П = '{TOVAR}';", Baza);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        kod_t = rdr[0].ToString();
                    }
                    rdr.Close();
                    MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.клиент where ФИО = '{FIObox3.Text}';", Baza);
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    while (rdr1.Read())
                    {
                        Kod_Klient = rdr1[0].ToString();
                    }
                    rdr1.Close();
                    MySqlCommand cmd2 = new MySqlCommand($"SELECT * FROM пятерочка.метод_доставки where Наименование_М = '{METbox3.Text}';", Baza);
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        Kod_metod = rdr2[0].ToString();
                    }
                    rdr2.Close();
                    SQL += $"('{DATE}', '1', '{kod_t}', '{S}', '{Kod_Klient}', '{Kod_metod}', '{KOL}', '{CENA}', '{CDbox3.Text}', '{SUMbox3.Text}'),";
                }
                SQL = SQL.TrimEnd(',');
                MySqlCommand zakaz = new MySqlCommand($"INSERT INTO `пятерочка`.`заказ` (`Дата`, `Код_организации`, `Код_товара`, `Код_сотрудника`, `Код_клиента`, `Код_метода_заказа`, `Количество`, `Цена`, `Цена_доставки`, `Сумма_заказа`) VALUES {SQL}", Baza);
                zakaz.ExecuteNonQuery();
                if (METbox3.Text == "Доставка по адресу")
                {
                    MessageBox.Show("Заказ был оформлен!\nОжидайте его в течении 30 минут");

                }
                else if (METbox3.Text == "Самовывоз")
                {
                    MessageBox.Show("Заказ был оформлен!\nВы можете забарать его чер 10-20 минут :)");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }

            Baza.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDbox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nbox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Pbox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Tbox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Cbox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Sbox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM пятерочка.поставщик where Наименование_пс = '{Pbox1.Text}';", Baza);
            Baza.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                postav = rdr[0].ToString();
            }
            rdr.Close();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM пятерочка.тип_товара where Название = '{Tbox1.Text}';", Baza);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                tip = rdr1[0].ToString();
            }
            rdr1.Close();
            Baza.Close();
        }
    }
}
