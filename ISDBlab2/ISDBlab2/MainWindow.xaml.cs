using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ISDBlab2
{
    public partial class MainWindow : Window
    {
        private int N;
        private double A, B, C;
        private int[] x;

        public MainWindow()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            PanelInput.Visibility = Visibility.Collapsed;
            PanelResult.Visibility = Visibility.Collapsed;
            BtnCalculate.IsEnabled = false;
        }

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TxtN.Text, out N) || N <= 0)
            {
                MessageBox.Show("Введите корректное положительное N", "Ошибка");
                return;
            }
            if (!double.TryParse(TxtA.Text, out A) ||
                !double.TryParse(TxtB.Text, out B) ||
                !double.TryParse(TxtC.Text, out C))
            {
                MessageBox.Show("Введите корректные числовые параметры A, B, C", "Ошибка");
                return;
            }

            x = new int[N];
            DataGridInput.Columns.Clear();
            var row = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                DataGridInput.Columns.Add(new DataGridTextColumn
                {
                    Header = $"x[{i}]",
                    Binding = new System.Windows.Data.Binding($"[{i}]") { Mode = System.Windows.Data.BindingMode.TwoWay }
                });
                row[i.ToString()] = 0;
            }
            DataGridInput.ItemsSource = new List<Dictionary<string, int>> { row };

            PanelInput.Visibility = Visibility.Visible;
            BtnCalculate.IsEnabled = true;
            PanelResult.Visibility = Visibility.Collapsed;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var row = (Dictionary<string, int>)DataGridInput.Items[0];
            for (int i = 0; i < N; i++)
            {
                if (!row.TryGetValue(i.ToString(), out int val))
                {
                    MessageBox.Show($"Значение x[{i}] не задано", "Ошибка");
                    return;
                }
                x[i] = val;
            }

            int countGtA = x.Count(v => v > A);
            TxtResult.Text = countGtA.ToString();

            var y = x.Where(v => v > B && v < C).ToArray();
            if (y.Length == 0)
            {
                MessageBox.Show("Массив Y не сформирован: нет элементов в (B, C)", "Внимание");
                return;
            }

            DataGridOutput.Columns.Clear();
            var outRow = new Dictionary<string, int>();
            for (int i = 0; i < y.Length; i++)
            {
                DataGridOutput.Columns.Add(new DataGridTextColumn
                {
                    Header = $"y[{i}]",
                    Binding = new System.Windows.Data.Binding($"[{i}]")
                });
                outRow[i.ToString()] = y[i];
            }
            DataGridOutput.ItemsSource = new List<Dictionary<string, int>> { outRow };
            PanelResult.Visibility = Visibility.Visible;

            BtnInput.IsEnabled = false;
            BtnReset.IsEnabled = false;
            BtnCalculate.IsEnabled = false;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TxtN.Text = TxtA.Text = TxtB.Text = TxtC.Text = TxtResult.Text = "";
            DataGridInput.Columns.Clear();
            DataGridInput.ItemsSource = null;
            DataGridOutput.Columns.Clear();
            DataGridOutput.ItemsSource = null;

            BtnInput.IsEnabled = true;
            BtnReset.IsEnabled = true;

            InitializeForm();
        }
    }
}