using System.Windows;
using System.Data;
using PRAKTIKA_1._2.DataSet1TableAdapters; // Импортируйте пространство имен вашего DataSet
using System;

namespace PRAKTIKA_1._2
{
    public partial class FlightsWindow : Window
    {
        FlightsTableAdapter flightsAdapter = new FlightsTableAdapter(); // Используйте ваш FlightsTableAdapter

        public FlightsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            FlightsDataGrid.ItemsSource = flightsAdapter.GetData(); // Используйте метод GetData вашего FlightsTableAdapter
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new PassengersWindow();
            previousWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var nextWindow = new TicketsWindow();
            nextWindow.Show();
            this.Close();
        }

        private void AddFlightButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения из TextBox
            string flightNumber = FlightNumberTextBox.Text;
            string departureAirport = DepartureAirportTextBox.Text;
            string arrivalAirport = ArrivalAirportTextBox.Text;
            DateTime departureTime = DateTime.Parse(DepartureTimeTextBox.Text);
            DateTime arrivalTime = DateTime.Parse(ArrivalTimeTextBox.Text);

            // Добавляем новый рейс
            flightsAdapter.Insert(flightNumber, departureAirport, arrivalAirport, departureTime, arrivalTime); // Используйте метод Insert вашего FlightsTableAdapter

            // Обновляем DataGrid
            RefreshDataGrid();
        }

        private void UpdateFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = FlightsDataGrid.SelectedItem as DataRowView;
                int flightId = (int)selectedRow.Row["FlightId"];

                string flightNumber = FlightNumberTextBoxIzm.Text;
                string departureAirport = DepartureAirportTextBoxIzm.Text;
                string arrivalAirport = ArrivalAirportTextBoxIzm.Text;
                DateTime departureTime = DateTime.Parse(DepartureTimeTextBoxIzm.Text);
                DateTime arrivalTime = DateTime.Parse(ArrivalTimeTextBoxIzm.Text);

                // Обновляем рейс
                flightsAdapter.UpdateQuery(flightNumber, departureAirport, arrivalAirport, departureTime, arrivalTime, flightId); // Используйте метод Update вашего FlightsTableAdapter

                // Обновляем DataGrid
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Не выбран рейс для обновления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = FlightsDataGrid.SelectedItem as DataRowView;
                int flightId = (int)selectedRow.Row["FlightId"];

                // Удаляем рейс
                flightsAdapter.DeleteQuery(flightId); // Используйте метод Delete вашего FlightsTableAdapter

                // Обновляем DataGrid
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Не выбран рейс для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}