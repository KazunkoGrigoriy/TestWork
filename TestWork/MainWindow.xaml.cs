/*
        Тестовая задача.
        Использованы технологии ADO.Net и WPF
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWork
{
    public partial class MainWindow : Window
    {
        SqlConnection con;
        DataTable dt; //Таблица данных
        SqlDataAdapter da; //Набор SQL-запросов, используется только SELECT совместно с Inner JOIN

        public MainWindow()
        {
            //Инициализация компонентов формы WPF
            InitializeComponent();

            //создание экземпляра строки подключения к базе данных SQLDatabase
            try
            {
                SqlConnectionStringBuilder strConSQL = new SqlConnectionStringBuilder()
                {
                    DataSource = @"(localdb)\MSSQLLocalDB",
                    InitialCatalog = "SQLDatabase",
                    IntegratedSecurity = false
                };

                //создание экземпляров подключения, таблицы, набора команд
                con = new SqlConnection(strConSQL.ConnectionString);
                dt = new DataTable();
                da = new SqlDataAdapter();

                /*sql - запрос, объединяет таблицы TableClients и TableTovar, оставляя клиентов с совпадающими Email в обеих таблицах
                сортируя по Id по возрастанию.
                */
                #region select
                var sql = @"SELECT *
                            FROM DataClients
                            JOIN DataTovar ON DataClients.Email = DataTovar.Email
                            ORDER BY DataClients.Id";

                #endregion

                //выполнение SQL-запроса
                da.SelectCommand = new SqlCommand(sql, con);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }           

            //подписка на событие нажатия на кнопку
            GetDataButton.Click += GetDataButton_Click;
        }

        //заполнение таблицы на форме
        private void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            da.Fill(dt);
            grid.ItemsSource = dt.DefaultView;
        }
    }
}
