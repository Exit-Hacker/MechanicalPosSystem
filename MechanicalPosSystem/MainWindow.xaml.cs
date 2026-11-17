using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace MechanicalPosSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Real-time search functionality
            StartClock();
        }

        //Method for real-time search functionality

        private DispatcherTimer clockTimer;

        private void ClockTimer_Tick(object sender, EventArgs e)
        {        // Date and time display
            DateText.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TimeText.Text = DateTime.Now.ToString("HH: mm: ss");
        }
        private void StartClock()
        {
            clockTimer = new DispatcherTimer();
            clockTimer.Interval = TimeSpan.FromSeconds(1);
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            // XAML TextBlock elements for displaying date and time
            DateText.Text = $"Date: {DateTime.Now:yyy-MM-dd}";
            TimeText.Text = $"Time: {DateTime.Now:hh:mm:ss tt}";
        }

        private void LoadDefaultCatalog()
        {
            CatalogItems.Add(new PartItem { PartCode = "KUB-001", Name = "Kubota Piston Ring Set", Category = "Kubota Parts", Price = 35.00m });
            CatalogItems.Add(new PartItem { PartCode = "KUB-002", Name = "Kubota Head Gasket", Category = "Kubota Parts", Pirce = 22.50m });
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string category = button.Content.ToString() ?? "";
                MessageBox.Show($"Showing parts for category: {category}", "Category Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}