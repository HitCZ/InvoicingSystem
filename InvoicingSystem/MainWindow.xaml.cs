using InvoicingSystem.Data;
using InvoicingSystem.Data.Mocks;
using InvoicingSystem.Data.Repositories;
using InvoicingSystem.Data.Repositories.Interfaces;
using InvoicingSystem.Enumerations;
using InvoicingSystem.Models;
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

namespace InvoicingSystem {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            UnitOfWork u = new UnitOfWork(new AppDbContext());

            var a = u.Addresses.GetAddressesByCity("kyšice");
            var result = u.Addresses.GetAddressesByStreet("karlovarská", a);
            
            if (result.Count() > 0)
                MessageBox.Show(result.ElementAt(0).ToString());
        }
    }
}
