using System;
using System.Data.Odbc;
using System.Windows;
using System.Xml.Linq;
using ISDBlab3;

namespace ISDBlab3
{
    public partial class EditModelWindow : Window
    {
        private OdbcConnection _connection;
        private bool _isNew;
        private ModelsWindow.Model _model;

        public EditModelWindow(OdbcConnection connection, bool isNew, ModelsWindow.Model model)
        {
            InitializeComponent();
            _connection = connection;
            _isNew = isNew;
            _model = model;

            if (!_isNew && _model != null)
            {
                edCode.Text = _model.model_code.ToString();
                edName.Text = _model.model_name;
                edType.Text = _model.model_type;
            }
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edName.Text) || string.IsNullOrWhiteSpace(edType.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string strSql;
            if (_isNew)
            {
                strSql = "INSERT INTO complaints_book.models (model_name, model_type) VALUES (?, ?)";
            }
            else
            {
                strSql = "UPDATE complaints_book.models SET model_name = ?, model_type = ? WHERE model_code = ?";
            }

            try
            {
                using (var command = new OdbcCommand(strSql, _connection))
                {
                    command.Parameters.AddWithValue("?", edName.Text);
                    command.Parameters.AddWithValue("?", edType.Text);
                    if (!_isNew)
                        command.Parameters.AddWithValue("?", _model.model_code);
                    command.ExecuteNonQuery();
                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}