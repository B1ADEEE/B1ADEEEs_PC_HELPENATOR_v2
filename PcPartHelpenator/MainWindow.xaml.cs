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

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query1 = from a in db.CPUs
                        select a.CPUName;
            CPU_DROP.ItemsSource = query1.ToList();

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

            var query9 = from a in db.OPTIONALs
                         select a.OPTIONALType;
            OptionalFans_DROP.ItemsSource = query9.ToList();
            OptionalLED_DROP.ItemsSource = query9.ToList(); 
        }
        private void CaseStealth_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();

            var query8 = from a in db.Cases
                         where a.CASELooks == "Stealth"
                         select a;
            CaseStealth_DROP.ItemsSource = query8.ToList();

            CaseRGB_DROP.ItemsSource = null;
            Airflow_DROP.ItemsSource = null;
        }

        private void CaseRGB_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();

            var query8 = from a in db.Cases
                         where a.CASELooks == "RGB"
                         select a;
            CaseRGB_DROP.ItemsSource = query8.ToList();

            CaseStealth_DROP.ItemsSource = null;
            Airflow_DROP.ItemsSource = null;
        }

        private void Airflow_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();

            var query8 = from a in db.Cases
                         where a.CASELooks == "Airflow"
                         select a;
            Airflow_DROP.ItemsSource = query8.ToList();

            CaseRGB_DROP.ItemsSource = null;
            CaseStealth_DROP.ItemsSource = null;
        }

        private void Airflow_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Case SelectedCase = Airflow_DROP.SelectedItem as Case;
            if (SelectedCase != null)
            {
                var query8v2 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();

                var query8v3 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                int CaseRating = query8v3.First();
                Rating = Rating + CaseRating;

                var query8v4 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                int CasePrice = query8v4.First();
                Price = Price + CasePrice;
            }
        }

        private void CaseStealth_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Case SelectedCase = CaseStealth_DROP.SelectedItem as Case;
            if (SelectedCase != null)
            {
                var query8v2 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();

                var query8v3 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                int CaseRating = query8v3.First();
                Rating = Rating + CaseRating;

                var query8v4 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                int CasePrice = query8v4.First();
                Price = Price + CasePrice;
            }
        }

        private void CaseRGB_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Case SelectedCase = CaseRGB_DROP.SelectedItem as Case;
            if (SelectedCase != null)
            {
                var query8v2 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();

                var query8v3 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                int CaseRating = query8v3.First();
                Rating = Rating + CaseRating;

                var query8v4 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                int CasePrice = query8v4.First();
                Price = Price + CasePrice;
            }
        }

        private void RecPriceTBLK_Loaded(object sender, RoutedEventArgs e)
        {
            RecPriceTBLK.Text = Convert.ToString(Price);
        }

        private void GPU_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query2 = from a in db.GPUs
                         select a.GPUName;
            GPU_DROP.ItemsSource = query2.ToList();
        }

        private void MOBO_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            //CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;
            //if (SelectedCPU != null)
            //{

                var query3 = from a in db.MOTHERBOARDs
                             select a;
                MOBO_DROP.ItemsSource = query3.ToList();
            //}
        }

        private void OptionalFans_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query9 = from a in db.OPTIONALs
                         where a.OPTIONALType.Equals("FANS")
                         select a.Property1;
            OptionalFans_DROP.ItemsSource = query9.ToList();
        }

        private void OptionalLED_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query9 = from a in db.OPTIONALs
                         where a.OPTIONALType.Equals("LED")
                         select a.Property1;
            OptionalLED_DROP.ItemsSource = query9.ToList();
        }
    }
}
