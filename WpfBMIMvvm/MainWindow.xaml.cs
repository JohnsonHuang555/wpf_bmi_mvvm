using System.Windows;

namespace WpfBMIMvvm
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new CalcViewModel();
        }
    }
}
