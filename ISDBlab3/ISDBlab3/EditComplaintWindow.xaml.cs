using System;
using System.Data.Odbc;
using System.Windows;
using ISDBlab3;

namespace ISDBlab3
{
    public partial class EditComplaintWindow : Window
    {
        private OdbcConnection _connection;
        private bool _isNew;
        private ComplaintsWindow.Complaint _complaint;

        public EditComplaintWindow(OdbcConnection connection, bool isNew, ComplaintsWindow.Complaint complaint)
        {
            InitializeComponent();
            _connection = connection;
            _isNew = isNew;
            _complaint = complaint;

            if (!_isNew && _complaint != null)
            {
                edId.Text = _complaint.complaint_id.ToString();
                edYear.Text = _complaint.complaint_year.ToString();
                edMonth.Text = _complaint.complaint_month.ToString();
                edModelCode.Text = _complaint.model_code.ToString();
                edPrice.Text = _complaint.price.ToString();
                edComplaintCount.Text = _complaint.complaint_count.ToString();
                edUnitsSold.Text = _complaint.units_sold.ToString();
            }
            else
            {
                edYear.Text = "2025";
                edMonth.Text = "1";
                edPrice.Text = "0.00";
                edComplaintCount.Text = "0";
                edUnitsSold.Text = "0";
            }
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(edYear.Text, out int year) || !int.TryParse(edMonth.Text, out int month) ||
                !int.TryParse(edModelCode.Text, out int modelCode) || !decimal.TryParse(edPrice.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price)
 ||
                !int.TryParse(edComplaintCount.Text, out int complaintCount) || !int.TryParse(edUnitsSold.Text, out int unitsSold))
            {
                MessageBox.Show("Введите корректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (month < 1 || month > 12)
            {
                MessageBox.Show("Месяц должен быть от 1 до 12", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string strSql;
            if (_isNew)
            {
                strSql = "INSERT INTO complaints_book.complaints (complaint_year, complaint_month, model_code, price, complaint_count, units_sold) VALUES (?, ?, ?, ?, ?, ?)";
            }
            else
            {
                strSql = "UPDATE complaints_book.complaints SET complaint_year = ?, complaint_month = ?, model_code = ?, price = ?, complaint_count = ?, units_sold = ? WHERE complaint_id = ?";
            }

            try
            {
                using (var command = new OdbcCommand(strSql, _connection))
                {
                    command.Parameters.AddWithValue("?", year);
                    command.Parameters.AddWithValue("?", month);
                    command.Parameters.AddWithValue("?", modelCode);
                    command.Parameters.AddWithValue("?", price);
                    command.Parameters.AddWithValue("?", complaintCount);
                    command.Parameters.AddWithValue("?", unitsSold);
                    if (!_isNew)
                        command.Parameters.AddWithValue("?", _complaint.complaint_id);
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