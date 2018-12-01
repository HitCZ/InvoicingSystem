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
using InvoicingSystem.Logic;
using InvoicingSystem.Logic.ExcelCreation;

namespace InvoicingSystem.Views {
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window {
        public MainView() {
            InitializeComponent();
            // testing
            ExcelCreator c = new ExcelCreator();
            UnitOfWork u = new UnitOfWork(new AppDbContext());
            var invoices = u.Invoices.GetAll();
            c.CreateExcel(invoices.ElementAt(0));
        }
    }
}
