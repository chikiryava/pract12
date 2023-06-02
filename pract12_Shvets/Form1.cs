using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract12_Shvets
{
    public partial class Form1 :Form
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=PC325L15;Initial Catalog=pract12_shvets;Integrated Security=True");
        string insert_into_vehicle_table = $"INSERT INTO Транспорт ([ID транспорта], [Вид транспорта], [Средняя скорость движения],[Количество машин в парке],[Стоимость проезда]) VALUES";
        string insert_into_way_table = $"INSERT INTO Путь ([ID пути],[ID маршрута],[Начальный пункт пути],[Конечный пункт],Расстояние) VALUES";
        
        public Form1 ()
        {
            InitializeComponent( );
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pract12_shvetsDataSet.Транспорт". При необходимости она может быть перемещена или удалена.
            this.транспортTableAdapter.Fill(this.pract12_shvetsDataSet.Транспорт);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pract12_shvetsDataSet.Путь". При необходимости она может быть перемещена или удалена.
            this.путьTableAdapter.Fill(this.pract12_shvetsDataSet.Путь);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pract12_shvetsDataSet.Маршрут". При необходимости она может быть перемещена или удалена.
            this.маршрутTableAdapter.Fill(this.pract12_shvetsDataSet.Маршрут);

        }

        private void button1_Click_1 (object sender, EventArgs e)
        {
            try
            {
                connect.Open( );
                string insert_into_vehicle_table = $"INSERT INTO Транспорт ([ID транспорта], [Вид транспорта], [Средняя скорость движения],[Количество машин в парке],[Стоимость проезда]) VALUES({int.Parse(textBox1.Text)}, '{textBox2.Text}', '{textBox3.Text}', {int.Parse(textBox4.Text)}, '{textBox5.Text}')";
                SqlCommand command = new SqlCommand(insert_into_vehicle_table, connect);
                command.ExecuteNonQuery( );
                connect.Close( );
                this.транспортTableAdapter.Fill(this.pract12_shvetsDataSet.Транспорт);
            }
            catch
            {
                MessageBox.Show("Поле с таким ключем уже существует");
            }
        }

        private void button2_Click (object sender, EventArgs e)
        {
            try
            {
                string insert_into_rout_table = $"INSERT INTO Маршрут ([ID маршрута],[ID транспорта],[Номер маршрута],[Количество остановок в пути],[Количество машин в маршруте],[Количество пассажиров в день]) VALUES ({int.Parse(textBox10.Text)},{int.Parse(textBox9.Text)},{int.Parse(textBox8.Text)},{int.Parse(textBox7.Text)},{int.Parse(textBox6.Text)},{int.Parse(textBox11.Text)})";
                connect.Open( );
                SqlCommand command = new SqlCommand(insert_into_rout_table, connect);
                command.ExecuteNonQuery( );
                connect.Close( );
                this.маршрутTableAdapter.Fill(this.pract12_shvetsDataSet.Маршрут);
            }
            catch
            {
                MessageBox.Show("Значение в поле ID транспорта должно соответствовать значению из таблицы Транспорт");
            }
        }

        private void button3_Click (object sender, EventArgs e)
        {
            try
            {
                string insert_into_way_table = $"INSERT INTO Путь ([ID пути],[ID маршрута],[Начальный пункт пути],[Конечный пункт],Расстояние) VALUES ({int.Parse(textBox16.Text)},{int.Parse(textBox15.Text)},'{textBox14.Text}','{textBox13.Text}',{int.Parse(textBox12.Text)})";
                connect.Open( );
                SqlCommand command = new SqlCommand(insert_into_way_table, connect);
                command.ExecuteNonQuery( );
                connect.Close( );
                this.путьTableAdapter.Fill(this.pract12_shvetsDataSet.Путь);
            }
            catch
            {
                MessageBox.Show("Значение в поле ID маршрута должно соответствовать значению из таблицы Маршрут или значение в ключевом поле уже существует");
            }
        }

        private void button4_Click (object sender, EventArgs e)
        {
            string field = string.Empty;
            string zapros = string.Empty;
            if (radioButton1.Checked)
            {
                field = radioButton1.Tag.ToString();
                zapros = $"SELECT * FROM Транспорт WHERE {field} = {textBox17.Text}";
            }
            else if (radioButton2.Checked)
            {
                field = radioButton2.Tag.ToString();
                zapros = $"SELECT * FROM Транспорт WHERE {field} = '{textBox17.Text}'";
            }
            else if (radioButton3.Checked)
            {
                field = radioButton3.Tag.ToString();
                zapros = $"SELECT * FROM Транспорт WHERE {field} = '{textBox17.Text}'";
            }
            else if (radioButton4.Checked)
            {
                field = radioButton4.Tag.ToString();
                zapros = $"SELECT * FROM Транспорт WHERE {field} = {textBox17.Text}";
            }
            else if (radioButton5.Checked)
            {
                field = radioButton5.Tag.ToString();
                zapros = $"SELECT * FROM Транспорт WHERE {field} = '{textBox17.Text}'";
            }
            connect.Open();
            SqlCommand command = new SqlCommand(zapros, connect);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show($"ID: {reader.GetInt32(0)}\n Вид транспорта :{reader.GetString(1)}\nСредняя скорость движения: {reader.GetString(2)}\nКоличество машин в парке: {reader.GetInt32(3)}\nСтоимость проезда:{reader.GetString(4)}");
                }
            }
            reader.Close();
            connect.Close();

        }

        private void radioButton1_CheckedChanged (object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged (object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged (object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged (object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged (object sender, EventArgs e)
        {

        }

        private void radioButton5_Enter (object sender, EventArgs e)
        {

        }

        private void button5_Click (object sender, EventArgs e)
        {
            string zapros = string.Empty;
            foreach(RadioButton rb in groupBox1.Controls)
            {
                if (rb.Checked)
                {
                    if(rb.Tag.ToString() == "int")
                    {
                        zapros = $"SELECT * FROM Путь WHERE {rb.Text} = {textBox18.Text}";
                    }
                    else
                        zapros = $"SELECT * FROM Путь WHERE {rb.Text} = '{textBox18.Text}'";
                }
            }
            connect.Open();
            SqlCommand command = new SqlCommand(zapros, connect);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show($"ID пути: {reader.GetInt32(0)}\nID маршрута :{reader.GetInt32(1)}\nНачальный пункт пути: {reader.GetString(2)}\nКонечный пункт: {reader.GetString(3)}\nРасстояние:{reader.GetInt32(4)}");
                }
            } 
            else
            {
                MessageBox.Show("Совпадений не найдено");
            }
            reader.Close();
            connect.Close();
        }

        private void contextMenuStrip1_Opening (object sender, CancelEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click (object sender, EventArgs e)
        {
            connect.Open();
            if (dataGridView3.SelectedRows.Count > 0)
            {
                string field = dataGridView1.SelectedRows[0].Cells["ID Транспорта"].Value.ToString();
                try
                {
                    string query = $"DELETE FROM ТРАНСПОРТ WHERE [ID транспорта] = {field}";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "pract12_shvetsDataSet.Транспорт". При необходимости она может быть перемещена или удалена.
                    this.транспортTableAdapter.Fill(this.pract12_shvetsDataSet.Транспорт);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "pract12_shvetsDataSet.Путь". При необходимости она может быть перемещена или удалена.
                    this.путьTableAdapter.Fill(this.pract12_shvetsDataSet.Путь);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "pract12_shvetsDataSet.Маршрут". При необходимости она может быть перемещена или удалена.
                    this.маршрутTableAdapter.Fill(this.pract12_shvetsDataSet.Маршрут);


                } catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        MessageBox.Show("Ключевое поле используется");
                    connect.Close();
                }
            }
        }

        private void tabPage2_Click (object sender, EventArgs e)
        {

        }
    }
}
