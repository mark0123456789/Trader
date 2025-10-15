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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private readonly DatabaseStatemantes _databaseStatements = new DatabaseStatemantes();
        private readonly MainWindow _mainWindow;
        public AdminPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            userDataGrid.ItemsSource = _databaseStatements.userlist();
        }
    }
}
