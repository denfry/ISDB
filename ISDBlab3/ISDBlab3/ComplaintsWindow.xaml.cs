using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows;

namespace ISDBlab3
{
    public partial class ComplaintsWindow : Window
    {
        private OdbcConnection _connection;
        private List<Complaint> _complaints;

        public class Complaint
        {
            public int complaint_id { get; set; }
            public int complaint_year { get; set; }
            public int complaint_month { get; set; }
            public int model_code { get; set; }
            public decimal price { get; set; }
            public int complaint_count { get; set; }
            public int units_sold { get; set; }
        }

        public ComplaintsWindow(OdbcConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            LoadComplaints();
        }

        private void LoadComplaints()
        {
            _complaints = new List<Complaint>();
            string query = "SELECT * FROM complaints_book.complaints WHERE 1=1";

            if (!string.IsNullOrEmpty(YearFilter1.Text) && int.TryParse(YearFilter1.Text, out int year1))
                query += $" AND complaint_year >= {year1}";
            if (!string.IsNullOrEmpty(YearFilter2.Text) && int.TryParse(YearFilter2.Text, out int year2))
                query += $" AND complaint_year <= {year2}";

            if (!string.IsNullOrEmpty(MonthFilter1.Text) && int.TryParse(MonthFilter1.Text, out int month1))
            {
                if (month1 < 1 || month1 > 12)
                {
                    MessageBox.Show("Месяц должен быть от 1 до 12", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                query += $" AND complaint_month >= {month1}";
            }
            if (!string.IsNullOrEmpty(MonthFilter2.Text) && int.TryParse(MonthFilter2.Text, out int month2))
            {
                if (month2 < 1 || month2 > 12)
                {
                    MessageBox.Show("Месяц должен быть от 1 до 12", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                query += $" AND complaint_month <= {month2}";
            }

            if (!string.IsNullOrEmpty(ModelCodeFilter.Text) && int.TryParse(ModelCodeFilter.Text, out int modelCode))
                query += $" AND model_code = {modelCode}";

            if (!string.IsNullOrEmpty(PriceFilter1.Text) && decimal.TryParse(PriceFilter1.Text, out decimal price1))
                query += $" AND price >= {price1}";
            if (!string.IsNullOrEmpty(PriceFilter2.Text) && decimal.TryParse(PriceFilter2.Text, out decimal price2))
                query += $" AND price <= {price2}";

            if (!string.IsNullOrEmpty(ComplaintCountFilter1.Text) && int.TryParse(ComplaintCountFilter1.Text, out int complaintCount1))
                query += $" AND complaint_count >= {complaintCount1}";
            if (!string.IsNullOrEmpty(ComplaintCountFilter2.Text) && int.TryParse(ComplaintCountFilter2.Text, out int complaintCount2))
                query += $" AND complaint_count <= {complaintCount2}";

            if (!string.IsNullOrEmpty(UnitsSoldFilter1.Text) && int.TryParse(UnitsSoldFilter1.Text, out int unitsSold1))
                query += $" AND units_sold >= {unitsSold1}";
            if (!string.IsNullOrEmpty(UnitsSoldFilter2.Text) && int.TryParse(UnitsSoldFilter2.Text, out int unitsSold2))
                query += $" AND units_sold <= {unitsSold2}";

            try
            {
                using (var command = new OdbcCommand(query, _connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _complaints.Add(new Complaint
                        {
                            complaint_id = reader.GetInt32(0),
                            complaint_year = reader.GetInt32(1),
                            complaint_month = reader.GetInt32(2),
                            model_code = reader.GetInt32(3),
                            price = reader.GetDecimal(4),
                            complaint_count = reader.GetInt32(5),
                            units_sold = reader.GetInt32(6)
                        });
                    }
                }
                ComplaintsDataGrid.ItemsSource = _complaints;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditComplaintWindow(_connection, true, null);
            editWindow.Title = "Добавление жалобы";
            if (editWindow.ShowDialog() == true)
            {
                LoadComplaints();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsDataGrid.SelectedItem is Complaint selectedComplaint)
            {
                var editWindow = new EditComplaintWindow(_connection, false, selectedComplaint);
                editWindow.Title = "Редактирование жалобы";
                if (editWindow.ShowDialog() == true)
                {
                    LoadComplaints();
                    ComplaintsDataGrid.SelectedItem = _complaints.Find(c => c.complaint_id == selectedComplaint.complaint_id);
                }
            }
            else
            {
                MessageBox.Show("Выберите жалобу для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsDataGrid.SelectedItem is Complaint selectedComplaint)
            {
                var result = MessageBox.Show("Удалить жалобу?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result != MessageBoxResult.OK) return;

                try
                {
                    using (var command = new OdbcCommand("DELETE FROM complaints_book.complaints WHERE complaint_id = ?", _connection))
                    {
                        command.Parameters.AddWithValue("?", selectedComplaint.complaint_id);
                        command.ExecuteNonQuery();
                    }
                    LoadComplaints();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите жалобу для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            LoadComplaints();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            YearFilter1.Text = string.Empty;
            YearFilter2.Text = string.Empty;
            MonthFilter1.Text = string.Empty;
            MonthFilter2.Text = string.Empty;
            ModelCodeFilter.Text = string.Empty;
            PriceFilter1.Text = string.Empty;
            PriceFilter2.Text = string.Empty;
            ComplaintCountFilter1.Text = string.Empty;
            ComplaintCountFilter2.Text = string.Empty;
            UnitsSoldFilter1.Text = string.Empty;
            UnitsSoldFilter2.Text = string.Empty;
            LoadComplaints();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}