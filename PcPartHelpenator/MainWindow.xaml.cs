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

namespace PcPartHelpenator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /*
     * 
     * ------ GITHUB: https://github.com/B1ADEEE/B1ADEEEs_PC_HELPENATOR
     * 
     */
    public partial class MainWindow : Window
    {
        PcHelpenatorEntities db;
        int Rating;
        int Price;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query1 = from a in db.CPUs
                        select a.CPUName;
            CPU_DROP.ItemsSource = query1.ToList();

            var query2 = from a in db.GPUs
                        select a.GPUName;
            GPU_DROP.ItemsSource = query2.ToList();

            var query3 = from a in db.MOTHERBOARDs
                         select a.MOTHERBOARDName;
            MOBO_DROP.ItemsSource = query3.ToList();

            var query4 = from a in db.HEATSINKs
                         select a.HEATSINKName;
            Heatsink_DROP.ItemsSource = query4.ToList();

            var query5 = from a in db.RAMs
                         select a.RAMSize;
            RAM_DROP.ItemsSource = query5.ToList();

            var query6 = from a in db.STORAGEs
                         select a.STORAGESize;
            Storage1_DROP.ItemsSource = query6.ToList();
            Storage2_DROP.ItemsSource = query6.ToList();
            Storage3_DROP.ItemsSource = query6.ToList();

            var query7 = from a in db.POWERSUPPLies
                         select a.POWERSUPPLYBrand;
            PSU_DROP.ItemsSource = query7.ToList();

            var query8 = from a in db.Cases
                         select a.CASEName;

            if (CaseStealth_DROP.IsDropDownOpen)
            {
                CaseStealth_DROP.ItemsSource = query8.ToList();
            }
            if (CaseRGB_DROP.IsDropDownOpen)
            {
                CaseRGB_DROP.ItemsSource = query8.ToList();
            }
            if (Airflow_DROP.IsDropDownOpen)
            {
                Airflow_DROP.ItemsSource = query8.ToList();
            }

            var query9 = from a in db.OPTIONALs
                         select a.OPTIONALType;
            OptionalFans_DROP.ItemsSource = query9.ToList();
            OptionalLED_DROP.ItemsSource = query9.ToList(); 
        }
    }
}
