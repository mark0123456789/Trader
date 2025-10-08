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
        private readonly DatabaseStatemantes db = new DatabaseStatemantes();
        public Page1()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserPassworTextbox1.Password == userPassordTextbox2.Password)
            {
                var user = new
                {
                    username = UsernameTextbox.Text,
                    password = userPassordTextbox2.Password,
                    fullname = userFullnameTextbox.Text,
                    salt = "",
                    Email = UserEmailTextbox.Text
                };

                MessageBox.Show(db.addNewUser(user).ToString());
            }
            else
            {
                MessageBox.Show("eltérő jelszavak");
            }
        }
    }
}
