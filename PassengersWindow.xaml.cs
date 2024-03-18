using System.Windows;
using System.Data;
using PRAKTIKA_1._2.DataSet1TableAdapters; // Импортируйте пространство имен вашего DataSet
using System;
using AVIACASSA2;

namespace PRAKTIKA_1._2
{
    public partial class PassengersWindow : Window
    {
        PassengersTableAdapter passengersAdapter = new PassengersTableAdapter(); // Используйте ваш PassengersTableAdapter

        public PassengersWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            PassengersDataGrid.ItemsSource = passengersAdapter.GetData(); // Используйте метод GetData вашего PassengersTableAdapter
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new FlightsWindow();
            previousWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var nextWindow = new TicketsWindow();
            nextWindow.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения из TextBox
            string firstName = NameTextBox.Text;
            string lastName = SurnameTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;

            // Добавляем нового пассажира
            passengersAdapter.Insert(firstName, lastName, email, phone); // Используйте метод Insert вашего PassengersTableAdapter

            // Обновляем DataGrid
            RefreshDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassengersDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = PassengersDataGrid.SelectedItem as DataRowView;
                int passengerId = (int)selectedRow.Row["PassengerId"]; // Или другое имя столбца, который используется для идентификатора

                string firstName = NameTextBoxIzm.Text;
                string lastName = SurnameTextBoxIzm.Text;
                string phone = PhoneTextBoxIzm.Text;
                string email = EmailTextBoxIzm.Text;

                // Передаем исходные значения для всех столбцов в метод Update
                string originalFirstName = (string)selectedRow.Row["FirstName"];
                string originalLastName = (string)selectedRow.Row["LastName"];
                string originalEmail = (string)selectedRow.Row["Email"];
                string originalPhone = (string)selectedRow.Row["Phone"];

                passengersAdapter.Update(firstName, lastName, email, phone, passengerId, originalFirstName, originalLastName, originalEmail, originalPhone);
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для изменения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassengersDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = PassengersDataGrid.SelectedItem as DataRowView;
                int passengerId = (int)selectedRow.Row["PassengerId"]; // Или другое имя столбца, который используется для идентификатора

                // Передаем исходные значения для всех столбцов в метод Delete
                string originalFirstName = (string)selectedRow.Row["FirstName"];
                string originalLastName = (string)selectedRow.Row["LastName"];
                string originalEmail = (string)selectedRow.Row["Email"];
                string originalPhone = (string)selectedRow.Row["Phone"];

                passengersAdapter.Delete(passengerId, originalFirstName, originalLastName, originalEmail, originalPhone);
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}