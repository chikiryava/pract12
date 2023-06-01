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
    }
}
