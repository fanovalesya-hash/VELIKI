using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VELIKI.Data;
using VELIKI;

namespace VELIKI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TbLogin.Text;
            string password = PbPassword.Password;
            using (VelikiDbContext db = new VelikiDbContext())
            {
                // Ищем пользователя, у которого совпадают и логин, и пароль
                // p => это условие (лямбда-выражение): "для каждого пользователя p проверить..."
                var user = db.Пользователиs.FirstOrDefault(p => p.Логин == login && p.Пароль == password);

                // 3. Проверяем результат
                if (user != null)
                {
                    MainWindow mainWindow = new MainWindow(user.Фио, user.РольСотрудника);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    // Пользователь не найден. Выводим ошибку.
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
         }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow("Гость", 0);
            mainWindow.Show();
            this.Close();
        }
    }
}
