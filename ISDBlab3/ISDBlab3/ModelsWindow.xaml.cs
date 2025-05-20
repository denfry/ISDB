using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;
using ISDBlab3;

namespace ISDBlab3
{
    public partial class ModelsWindow : Window
    {
        private OdbcConnection _connection;
        private List<Model> _models;

        public class Model
        {
            public int model_code { get; set; }
            public string model_name { get; set; }
            public string model_type { get; set; }
        }

        public ModelsWindow(OdbcConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            LoadModels();
        }

        private void LoadModels()
        {
            _models = new List<Model>();
            using (var command = new OdbcCommand("SELECT * FROM complaints_book.models", _connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    _models.Add(new Model
                    {
                        model_code = reader.GetInt32(0),
                        model_name = reader.GetString(1),
                        model_type = reader.GetString(2)
                    });
                }
            }
            ModelsDataGrid.ItemsSource = _models;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditModelWindow(_connection, true, null);
            editWindow.Title = "Добавление модели";
            if (editWindow.ShowDialog() == true)
            {
                LoadModels();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsDataGrid.SelectedItem is Model selectedModel)
            {
                var editWindow = new EditModelWindow(_connection, false, selectedModel);
                editWindow.Title = "Редактирование модели";
                if (editWindow.ShowDialog() == true)
                {
                    LoadModels();
                    // Восстановление выделения
                    ModelsDataGrid.SelectedItem = _models.Find(m => m.model_code == selectedModel.model_code);
                }
            }
            else
            {
                MessageBox.Show("Выберите модель для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsDataGrid.SelectedItem is Model selectedModel)
            {
                var result = MessageBox.Show("Удалить модель?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result != MessageBoxResult.OK) return;

                try
                {
                    using (var command = new OdbcCommand("DELETE FROM complaints_book.models WHERE model_code = ?", _connection))
                    {
                        command.Parameters.AddWithValue("?", selectedModel.model_code);
                        command.ExecuteNonQuery();
                    }
                    LoadModels();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите модель для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}