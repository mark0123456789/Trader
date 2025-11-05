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
    public partial class loginpage : Page
    {
        private readonly DatabaseStatemantes _databaseStatements = new DatabaseStatemantes();
        private readonly MainWindow _mainWindow;
        public loginpage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new
            {
                Name = userNameTextBox.Text,
                Pass = userPasswordTextBox1.Password
            };
            if (_databaseStatements.LoginUser(user))
                _mainWindow.StartWindow.Navigate(new AdminPage(_mainWindow));
            else
                MessageBox.Show("Még nem regisztrált");
        }

        private void regLink_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.StartWindow.Navigate(new Page1(_mainWindow));
        }
    }
}
