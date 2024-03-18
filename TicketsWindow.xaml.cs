using System.Windows;
using System.Data;
using PRAKTIKA_1._2.DataSet1TableAdapters; // Импортируйте пространство имен вашего DataSet
using System;

namespace PRAKTIKA_1._2
{
    public partial class TicketsWindow : Window
    {
        TicketsTableAdapter ticketsAdapter = new TicketsTableAdapter(); // Используйте ваш TicketsTableAdapter

        public TicketsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            TicketsDataGrid.ItemsSource = ticketsAdapter.GetData(); // Используйте метод GetData вашего TicketsTableAdapter
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new FlightsWindow();
            previousWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Реализуйте логику перехода к следующему окну, если таковое имеется
        }

        private void AddTicketButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значения из TextBox
                string seatNumber = SeatNumberTextBox.Text;
                string ticketClass = ClassTextBox.Text;
                string priceText = PriceTextBox.Text;

                // Проверяем, что введенная строка является допустимой десятичной дробью
                if (decimal.TryParse(priceText, out decimal price))
                {
                    // Добавляем новый билет
                    ticketsAdapter.Insert(seatNumber, ticketClass, price); // Используйте метод Insert вашего TicketsTableAdapter

                    // Обновляем DataGrid
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Неверный формат цены. Введите десятичную дробь.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении билета: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTicketButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TicketsDataGrid.SelectedItem != null)
                {
                    DataRowView selectedRow = TicketsDataGrid.SelectedItem as DataRowView;
                    int ticketId = (int)selectedRow.Row["TicketId"];

                    string seatNumber = SeatNumberTextBoxIzm.Text;
                    string ticketClass = ClassTextBoxIzm.Text;
                    decimal price = decimal.Parse(PriceTextBoxIzm.Text);

                    // Обновляем билет
                    ticketsAdapter.Update(seatNumber, ticketClass, price); // Используйте метод Update вашего TicketsTableAdapter

                    // Обновляем DataGrid
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Не выбран билет для обновления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении билета: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTicketButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TicketsDataGrid.SelectedItem != null)
                {
                    DataRowView selectedRow = TicketsDataGrid.SelectedItem as DataRowView;
                    int ticketId = (int)selectedRow.Row["TicketId"];

                    // Удаляем билет
                    ticketsAdapter.Delete(ticketId); // Используйте метод Delete вашего TicketsTableAdapter

                    // Обновляем DataGrid
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Не выбран билет для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении билета: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}