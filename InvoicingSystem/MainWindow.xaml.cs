using InvoicingSystem.Logic;
using System.Linq;
using System.Windows;

namespace InvoicingSystem
{
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
