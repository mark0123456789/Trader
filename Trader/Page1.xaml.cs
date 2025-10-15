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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trader
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private readonly DatabaseStatemantes _databaseStatements = new DatabaseStatemantes();
        private readonly MainWindow _mainWindow;
        public Page1(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (userPasswordTextBox1.Password == userPasswordTextBox2.Password)
            {
                var user = new
                {
                    UserName = userNameTextBox.Text,
                    FullName = userFullNameTextBox.Text,
                    UserPassword = userPasswordTextBox1.Password,
                    Salt = "",
                    Email = userEmailTextBox.Text

                };

                MessageBox.Show(_databaseStatements.AddNewUser(user).ToString());
                _mainWindow.StartWindow.Navigate(new LoginPage(_mainWindow));
            }
            else
            {
                MessageBox.Show("Eltérő jelszavak.");
            }

        }
    }
}
