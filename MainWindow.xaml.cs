using PRAKTIKA_1._2;
using System.Windows;
using PRAKTIKA_1._2.DataSet1TableAdapters;
namespace AVIACASSA2
{
    public partial class MainWindow : Window
    {
        private Window currentWindow;

        public MainWindow()
        {
            InitializeComponent();
            currentWindow = new TicketsWindow(); 
            currentWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход к предыдущему окну
            if (currentWindow is TicketsWindow)
            {
                currentWindow.Close();
                currentWindow = new PassengersWindow();
            }
            else if (currentWindow is PassengersWindow)
            {
                currentWindow.Close();
                currentWindow = new FlightsWindow();
            }
            else if (currentWindow is FlightsWindow)
            {
                currentWindow.Close();
                currentWindow = new TicketsWindow();
            }
            currentWindow.Show();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход к следующему окну
            if (currentWindow is TicketsWindow)
            {
                currentWindow.Close();
                currentWindow = new FlightsWindow();
            }
            else if (currentWindow is FlightsWindow)
            {
                currentWindow.Close();
                currentWindow = new PassengersWindow();
            }
            else if (currentWindow is PassengersWindow)
            {
                currentWindow.Close();
                currentWindow = new TicketsWindow();
            }
            currentWindow.Show();
        }
    }
}