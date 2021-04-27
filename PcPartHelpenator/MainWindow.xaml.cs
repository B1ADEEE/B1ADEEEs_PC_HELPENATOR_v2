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
using System.Media;

namespace PcPartHelpenator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /*
     * 
     * ------ GITHUB: https://github.com/B1ADEEE/B1ADEEEs_PC_HELPENATOR_v2
     * 
     */
    public partial class MainWindow : Window
    {
        PcHelpenatorEntities db;
        System.Media.SoundPlayer Player = new System.Media.SoundPlayer();
        int Rating;
        int Price;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Player.SoundLocation = "DankMusic.wav";
            Player.PlayLooping();
            
            db = new PcHelpenatorEntities();
            var query1 = from a in db.CPUs
                        select a;
            CPU_DROP.ItemsSource = query1.ToList();
 
        }
        private void CaseStealth_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            if (SelectedMobo != null)
            {
                string MoboType = SelectedMobo.MOTHERBOARDSize;
                if (MoboType == "ATX")
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "Stealth" && a.CASESize == "ATX"
                                 select a;
                    CaseStealth_DROP.ItemsSource = query8.ToList();
                }
                else
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "Stealth"
                                 select a;
                    CaseStealth_DROP.ItemsSource = query8.ToList();
                }
            }
            CaseRGB_DROP.ItemsSource = null;
            Airflow_DROP.ItemsSource = null;
        }

        private void CaseRGB_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            if (SelectedMobo != null)
            {
                string MoboType = SelectedMobo.MOTHERBOARDSize;
                if (MoboType == "ATX")
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "RGB" && a.CASESize == "ATX"
                                 select a;
                    CaseRGB_DROP.ItemsSource = query8.ToList();
                }
                else
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "RGB"
                                 select a;
                    CaseRGB_DROP.ItemsSource = query8.ToList();
                }
            }
            CaseStealth_DROP.ItemsSource = null;
            Airflow_DROP.ItemsSource = null;
        }

        private void Airflow_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            if (SelectedMobo != null)
            {
                string MoboType = SelectedMobo.MOTHERBOARDSize;
                if (MoboType == "ATX")
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "Airflow" && a.CASESize == "ATX"
                                 select a;
                    Airflow_DROP.ItemsSource = query8.ToList();
                }
                else
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "Airflow"
                                 select a;
                    Airflow_DROP.ItemsSource = query8.ToList();
                }
            }
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
                         select a;
            GPU_DROP.ItemsSource = query2.ToList();
        }

        private void MOBO_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;
            if (SelectedCPU != null)
            {
                string CpuType = SelectedCPU.CPUSocketType;
                if (CpuType == "LGA 1200")
                {
                    var query3 = from a in db.MOTHERBOARDs
                                 where a.MOTHERBOARDSocke == "LGA 1200"
                                 select a;
                    MOBO_DROP.ItemsSource = query3.ToList();
                }
                else
                {
                    var query3 = from a in db.MOTHERBOARDs
                                 where a.MOTHERBOARDSocke == "AM4"
                                 select a;
                    MOBO_DROP.ItemsSource = query3.ToList();
                }
            }
        }

        private void OptionalFans_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query9 = from a in db.OPTIONALs
                         where a.OPTIONALType.Equals("FANS")
                         select a;
            OptionalFans_DROP.ItemsSource = query9.ToList();
        }

        private void OptionalLED_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query9 = from a in db.OPTIONALs
                         where a.OPTIONALType.Equals("LED")
                         select a;
            OptionalLED_DROP.ItemsSource = query9.ToList();
        }

        private void Heatsink_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;
            if (SelectedCPU != null)
            {
                string CpuType = SelectedCPU.CPUHeatsink;
                if (CpuType == "NO")
                {
                    var query4 = from a in db.HEATSINKs
                                 where a.HEATSINKSocket == "Any"
                                 select a;
                    Heatsink_DROP.ItemsSource = query4.ToList();
                }
                else
                {
                    var query4 = from a in db.HEATSINKs
                                 select a;
                    Heatsink_DROP.ItemsSource = query4.ToList();
                }
            }
        }

        private void RAM_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            if (SelectedMobo != null)
            {
                int maxRam = SelectedMobo.MOTHERBOARDMaxRam;
                if (maxRam == 16)
                {
                    var query5 = from a in db.RAMs
                                 where a.RAMSize == 16 || a.RAMSize == 8
                                 select a;
                    RAM_DROP.ItemsSource = query5.ToList();
                }
                else
                {
                    var query5 = from a in db.RAMs
                                 select a;
                    RAM_DROP.ItemsSource = query5.ToList();
                }
            }
        }

        private void Storage1_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query6 = from a in db.STORAGEs
                         select a;
            Storage1_DROP.ItemsSource = query6.ToList();
        }

        private void Storage2_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query6 = from a in db.STORAGEs
                         select a;
            Storage2_DROP.ItemsSource = query6.ToList();
        }

        private void Storage3_DROP_DropDownOpened(object sender, EventArgs e)
        {
            db = new PcHelpenatorEntities();
            var query6 = from a in db.STORAGEs
                         select a;
            Storage3_DROP.ItemsSource = query6.ToList();
        }

        private void PSU_DROP_DropDownOpened(object sender, EventArgs e)
        {
            
            db = new PcHelpenatorEntities();
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;
            GPU SelectedGPU = GPU_DROP.SelectedItem as GPU;
            int PCWatts = SelectedCPU.CPUWatts + SelectedGPU.GPUWatts + 250;
            var query7 = from a in db.POWERSUPPLies
                         where a.POWERSUPPLYWatts >= PCWatts
                         select a;
            PSU_DROP.ItemsSource = query7.ToList();
        }

        private void CPU_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;
            if (SelectedCPU != null)
            {
                var query1v2 = from b in db.CPUs
                               where b.Id == SelectedCPU.Id
                               select b.CPURating;
                int CPURating = query1v2.First();
                Rating = Rating + CPURating;

                var query1v3 = from b in db.CPUs
                               where b.Id == SelectedCPU.Id
                               select b.CPUPrice;
                int CPUPrice = query1v3.First();
                Price = Price + CPUPrice;
            }
        }

        private void GPU_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GPU SelectedGPU = GPU_DROP.SelectedItem as GPU;
            if (SelectedGPU != null)
            {
                var query2v2 = from b in db.GPUs
                               where b.Id == SelectedGPU.Id
                               select b.GPURating;
                int GPURating = query2v2.First();
                Rating = Rating + GPURating;

                var query2v3 = from b in db.GPUs
                               where b.Id == SelectedGPU.Id
                               select b.GPUPrice;
                int GPUPrice = query2v3.First();
                Price = Price + GPUPrice;
            }
        }

        private void MOBO_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            if (SelectedMobo != null)
            {
                var query3v2 = from b in db.MOTHERBOARDs
                               where b.Id == SelectedMobo.Id
                               select b.MOTHERBOARDRating;
                int MoboRating = query3v2.First();
                Rating = Rating + MoboRating;

                var query3v3 = from b in db.MOTHERBOARDs
                               where b.Id == SelectedMobo.Id
                               select b.MOTHERBOARDPrice;
                int MoboPrice = query3v3.First();
                Price = Price + MoboPrice;
            }
        }

        private void Heatsink_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HEATSINK SelectedHeatSink = Heatsink_DROP.SelectedItem as HEATSINK;
            if (SelectedHeatSink != null)
            {
                var query4v2 = from b in db.HEATSINKs
                               where b.Id == SelectedHeatSink.Id
                               select b.HEATSINKRating;
                int HeatSinkRating = query4v2.First();
                Rating = Rating + HeatSinkRating;

                var query4v3 = from b in db.HEATSINKs
                               where b.Id == SelectedHeatSink.Id
                               select b.HEATSINKPrice;
                int HeatSinkPrice = query4v3.First();
                Price = Price + HeatSinkPrice;
            }
        }

        private void RAM_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RAM SelectedRAM = RAM_DROP.SelectedItem as RAM;
            if (SelectedRAM != null)
            {
                var query5v2 = from b in db.RAMs
                               where b.Id == SelectedRAM.Id
                               select b.RAMRating;
                int RAMRating = query5v2.First();
                Rating = Rating + RAMRating;

                var query5v3 = from b in db.RAMs
                               where b.Id == SelectedRAM.Id
                               select b.RAMPrice;
                int RAMPrice = query5v3.First();
                Price = Price + RAMPrice;
            }
        }

        private void Storage1_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            STORAGE SelectedSage1 = Storage1_DROP.SelectedItem as STORAGE;
            if (SelectedSage1 != null)
            {
                var query6v2 = from b in db.STORAGEs
                               where b.Id == SelectedSage1.Id
                               select b.STORAGERating;
                int SageRating = query6v2.First();
                Rating = Rating + SageRating;

                var query6v3 = from b in db.STORAGEs
                               where b.Id == SelectedSage1.Id
                               select b.STORAGEPrice;
                int SagePrice = query6v3.First();
                Price = Price + SagePrice;
            }
        }

        private void Storage2_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            STORAGE SelectedSage2 = Storage2_DROP.SelectedItem as STORAGE;
            if (SelectedSage2 != null)
            {
                var query6v2 = from b in db.STORAGEs
                               where b.Id == SelectedSage2.Id
                               select b.STORAGERating;
                int SageRating = query6v2.First();
                Rating = Rating + SageRating;

                var query6v3 = from b in db.STORAGEs
                               where b.Id == SelectedSage2.Id
                               select b.STORAGEPrice;
                int SagePrice = query6v3.First();
                Price = Price + SagePrice;
            }
        }

        private void Storage3_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            STORAGE SelectedSage3 = Storage3_DROP.SelectedItem as STORAGE;
            if (SelectedSage3 != null)
            {
                var query6v2 = from b in db.STORAGEs
                               where b.Id == SelectedSage3.Id
                               select b.STORAGERating;
                int SageRating = query6v2.First();
                Rating = Rating + SageRating;

                var query6v3 = from b in db.STORAGEs
                               where b.Id == SelectedSage3.Id
                               select b.STORAGEPrice;
                int SagePrice = query6v3.First();
                Price = Price + SagePrice;
            }
        }

        private void PSU_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            POWERSUPPLy SelectedPSU = PSU_DROP.SelectedItem as POWERSUPPLy;
            if (SelectedPSU != null)
            {
                var query7v2 = from b in db.POWERSUPPLies
                               where b.Id == SelectedPSU.Id
                               select b.POWERSUPPLYRating;
                int PSURating = query7v2.First();
                Rating = Rating + PSURating;

                var query7v3 = from b in db.POWERSUPPLies
                               where b.Id == SelectedPSU.Id
                               select b.POWERSUPPLYPrice;
                int PSUPrice = query7v3.First();
                Price = Price + PSUPrice;
            }
        }

        private void OptionalFans_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OPTIONAL SelectedFan = OptionalFans_DROP.SelectedItem as OPTIONAL;
            if (SelectedFan != null)
            {
                var query9v2 = from b in db.OPTIONALs
                               where b.Id == SelectedFan.Id
                               select b.OPTIONALRating;
                int FanRating = query9v2.First();
                Rating = Rating + FanRating;

                var query9v3 = from b in db.OPTIONALs
                               where b.Id == SelectedFan.Id
                               select b.OPTIONALPrice;
                int FanPrice = query9v3.First();
                Price = Price + FanPrice;
            }
        }

        private void OptionalLED_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OPTIONAL SelectedLED = OptionalLED_DROP.SelectedItem as OPTIONAL;
            if (SelectedLED != null)
            {
                var query9v2 = from b in db.OPTIONALs
                               where b.Id == SelectedLED.Id
                               select b.OPTIONALRating;
                int LEDRating = query9v2.First();
                Rating = Rating + LEDRating;

                var query9v3 = from b in db.OPTIONALs
                               where b.Id == SelectedLED.Id
                               select b.OPTIONALPrice;
                int LEDPrice = query9v3.First();
                Price = Price + LEDPrice;
            }
        }

        private void BuildRatingTBLK_Loaded(object sender, RoutedEventArgs e)
        {
            BuildRatingTBLK.Text = Convert.ToString(Rating);
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            int MaxPrice = Price + 200;
            MaxPriceTBLK.Text = Convert.ToString(MaxPrice);
        }
    }
}
