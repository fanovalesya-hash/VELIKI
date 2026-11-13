using Microsoft.EntityFrameworkCore;
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
using VELIKI.Data;

namespace VELIKI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _userFio;
        private int _userRoleId;
        public MainWindow(string fio, int roleId)
        {
            InitializeComponent();
            _userFio = fio;
            _userRoleId = roleId;

            TbFio.Text = _userFio;
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (VelikiDbContext db = new VelikiDbContext())
            {
                // Загружаем товары вместе с связанными таблицами
                var products = db.Товарыs
                    .Include(t => t.КатегорияТовараNavigation)  // Загружаем категорию
                    .Include(t => t.ПоставщикNavigation)         // Загружаем поставщика
                    .Include(t => t.ПроизводительNavigation)     // Загружаем производителя
                    .ToList();

                LbProducts.ItemsSource = products;
            }
        }

    }
}