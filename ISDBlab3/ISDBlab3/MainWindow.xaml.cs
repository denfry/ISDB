using System;
using System.Data.Odbc;
using System.Windows;
using ISDBlab3;

namespace ISDBlab3
{
    public partial class MainWindow : Window
    {
        private OdbcConnection odbcCon;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool isCon = false;
            int attempts = 1;

            while (attempts <= 3)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.edUser.Text = Properties.Settings.Default.Login;
                loginWindow.edPwd.Password = Properties.Settings.Default.Pwd;

                bool? result = loginWindow.ShowDialog();

                if (result != true)
                {
                    break;
                }

                try
                {
                    string connectionString = $"DSN=MyDSN;Uid={loginWindow.edUser.Text};Pwd={loginWindow.edPwd.Password};";
                    odbcCon = new OdbcConnection(connectionString);
                    odbcCon.Open();
                    isCon = true;
                    loginWindow.Close();
                    break;
                }
                catch (OdbcException ex)
                {
                    if (ex.Message.Contains("authentication"))
                    {
                        MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                attempts++;
            }

            if (!isCon)
            {
                this.Close();
            }
        }

        private void ModelsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (odbcCon != null && odbcCon.State == System.Data.ConnectionState.Open)
            {
                var modelsWindow = new ModelsWindow(odbcCon);
                modelsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Соединение с базой данных не установлено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComplaintsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (odbcCon != null && odbcCon.State == System.Data.ConnectionState.Open)
            {
                var complaintsWindow = new ComplaintsWindow(odbcCon);
                complaintsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Соединение с базой данных не установлено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            odbcCon?.Close();
            this.Close();
        }
    }
}