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
        int SelectionChangeCounterCase = 0;
        int oldCasePrice = 0;
        int oldCaseRating = 0;
        int SelectionChangeCounterCPU = 0;
        int oldCPUPrice = 0;
        int oldCPURating = 0;
        int SelectionChangeCounterGPU = 0;
        int oldGPUPrice = 0;
        int oldGPURating = 0;
        int SelectionChangeCounterMOBO = 0;
        int oldMOBOPrice = 0;
        int oldMOBORating = 0;
        int SelectionChangeCounterHEAT = 0;
        int oldHEATPrice = 0;
        int oldHEATRating = 0;
        int SelectionChangeCounterRAM = 0;
        int oldRAMPrice = 0;
        int oldRAMRating = 0;
        int SelectionChangeCounterSTORAGE1 = 0;
        int SelectionChangeCounterSTORAGE2 = 0;
        int SelectionChangeCounterSTORAGE3 = 0;
        int oldSTO1Price = 0;
        int oldSTO1Rating = 0;
        int oldSTO2Price = 0;
        int oldSTO2Rating = 0;
        int oldSTO3Price = 0;
        int oldSTO3Rating = 0;
        int SelectionChangeCounterPSU = 0;
        int oldPSUPrice = 0;
        int oldPSURating = 0;
        int SelectionChangeCounterOPTIONALFAN = 0;
        int oldOP1Price = 0;
        int oldOP1Rating = 0;
        int SelectionChangeCounterOPTIONALLED = 0;
        int oldOP2Price = 0;
        int oldOP2Rating = 0;
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
            int CaseRating;
            int CasePrice;
            if (SelectedCase != null)
            {
                if (SelectionChangeCounterCase == 1)
                {
                    Rating = Rating - oldCaseRating;
                    Price = Price - oldCasePrice;
                }
                SelectionChangeCounterCase = 1;
                var query8v2 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();

                var query8v3 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                CaseRating = query8v3.First();
                Rating = Rating + CaseRating;
                oldCaseRating = CaseRating;
                CaseRating = 0;

                var query8v4 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                CasePrice = query8v4.First();
                Price = Price + CasePrice;
                oldCasePrice = CasePrice;
                CasePrice = 0;
            }
        }

        private void CaseStealth_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Case SelectedCase = CaseStealth_DROP.SelectedItem as Case;
            int CaseRating;
            int CasePrice;
            if (SelectedCase != null)
            {
                if (SelectionChangeCounterCase == 1)
                {
                    Rating = Rating - oldCaseRating;
                    Price = Price - oldCasePrice;
                }
                SelectionChangeCounterCase = 1;
                var query8v2 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();

                var query8v3 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                CaseRating = query8v3.First();
                Rating = Rating + CaseRating;
                oldCaseRating = CaseRating;
                CaseRating = 0;

                var query8v4 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                CasePrice = query8v4.First();
                Price = Price + CasePrice;
                oldCasePrice = CasePrice;
                CasePrice = 0;
            }
        }

        private void CaseRGB_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Case SelectedCase = CaseRGB_DROP.SelectedItem as Case;
            int CaseRating;
            int CasePrice;
            if (SelectedCase != null)
            {
                if (SelectionChangeCounterCase == 1)
                {
                    Rating = Rating - oldCaseRating;
                    Price = Price - oldCasePrice;
                }
                SelectionChangeCounterCase = 1;
                var query8v2 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();

                var query8v3 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                CaseRating = query8v3.First();
                Rating = Rating + CaseRating;
                oldCaseRating = CaseRating;
                CaseRating = 0;

                var query8v4 = from b in db.Cases
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                CasePrice = query8v4.First();
                Price = Price + CasePrice;
                oldCasePrice = CasePrice;
                CasePrice = 0;
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
            int CPURating;
            int CPUPrice;
            if (SelectedCPU != null)
            {
                if (SelectionChangeCounterCPU == 1)
                {
                    Rating = Rating - oldCPURating;
                    Price = Price - oldCPUPrice;
                }
                SelectionChangeCounterCPU = 1;
                var query1v2 = from b in db.CPUs
                               where b.Id == SelectedCPU.Id
                               select b.CPURating;
                CPURating = query1v2.First();
                Rating = Rating + CPURating;
                oldCPURating = CPURating;
                CPURating = 0;

                var query1v3 = from b in db.CPUs
                               where b.Id == SelectedCPU.Id
                               select b.CPUPrice;
                CPUPrice = query1v3.First();
                Price = Price + CPUPrice;
                oldCPUPrice = CPUPrice;
                CPUPrice = 0;
            }
        }

        private void GPU_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GPU SelectedGPU = GPU_DROP.SelectedItem as GPU;
            int GPURating;
            int GPUPrice;
            if (SelectedGPU != null)
            {
                if (SelectionChangeCounterGPU == 1)
                {
                    Price = Price - oldGPUPrice;
                    Rating = Rating - oldGPURating;
                }
                SelectionChangeCounterGPU = 1;
                var query2v2 = from b in db.GPUs
                               where b.Id == SelectedGPU.Id
                               select b.GPURating;
                GPURating = query2v2.First();
                Rating = Rating + GPURating;
                oldGPURating = GPURating;
                GPURating = 0;

                var query2v3 = from b in db.GPUs
                               where b.Id == SelectedGPU.Id
                               select b.GPUPrice;
                GPUPrice = query2v3.First();
                Price = Price + GPUPrice;
                oldGPUPrice = GPUPrice;
                GPUPrice = 0;
            }
        }

        private void MOBO_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            int MoboRating;
            int MoboPrice;
            if (SelectedMobo != null)
            {
                if (SelectionChangeCounterMOBO == 1)
                {
                    Rating = Rating - oldMOBORating;
                    Price = Price - oldMOBOPrice;
                }
                SelectionChangeCounterMOBO = 1;
                var query3v2 = from b in db.MOTHERBOARDs
                               where b.Id == SelectedMobo.Id
                               select b.MOTHERBOARDRating;
                MoboRating = query3v2.First();
                Rating = Rating + MoboRating;
                oldMOBORating = MoboRating;
                MoboRating = 0;

                var query3v3 = from b in db.MOTHERBOARDs
                               where b.Id == SelectedMobo.Id
                               select b.MOTHERBOARDPrice;
                MoboPrice = query3v3.First();
                Price = Price + MoboPrice;
                oldMOBOPrice = MoboPrice;
                MoboPrice = 0;
            }
        }

        private void Heatsink_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HEATSINK SelectedHeatSink = Heatsink_DROP.SelectedItem as HEATSINK;
            int HeatSinkPrice;
            int HeatSinkRating;
            if (SelectedHeatSink != null)
            {
                if (SelectionChangeCounterHEAT == 1)
                {
                    Price = Price - oldHEATPrice;
                    Rating = Rating - oldHEATRating;
                }
                SelectionChangeCounterHEAT = 1;
                var query4v2 = from b in db.HEATSINKs
                               where b.Id == SelectedHeatSink.Id
                               select b.HEATSINKRating;
                HeatSinkRating = query4v2.First();
                Rating = Rating + HeatSinkRating;
                oldHEATRating = HeatSinkRating;
                HeatSinkRating = 0;

                var query4v3 = from b in db.HEATSINKs
                               where b.Id == SelectedHeatSink.Id
                               select b.HEATSINKPrice;
                HeatSinkPrice = query4v3.First();
                Price = Price + HeatSinkPrice;
                oldHEATPrice = HeatSinkPrice;
                HeatSinkPrice = 0;
            }
        }

        private void RAM_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RAM SelectedRAM = RAM_DROP.SelectedItem as RAM;
            int RAMRating;
            int RAMPrice;
            if (SelectedRAM != null)
            {
                if (SelectionChangeCounterRAM == 1)
                {
                    Price = Price - oldRAMPrice;
                    Rating = Rating - oldRAMRating;
                }
                SelectionChangeCounterRAM = 1;
                var query5v2 = from b in db.RAMs
                               where b.Id == SelectedRAM.Id
                               select b.RAMRating;
                RAMRating = query5v2.First();
                Rating = Rating + RAMRating;
                oldRAMRating = RAMRating;
                RAMRating = 0;

                var query5v3 = from b in db.RAMs
                               where b.Id == SelectedRAM.Id
                               select b.RAMPrice;
                RAMPrice = query5v3.First();
                Price = Price + RAMPrice;
                oldRAMPrice = RAMPrice;
                RAMPrice = 0;
            }
        }

        private void Storage1_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            STORAGE SelectedSage1 = Storage1_DROP.SelectedItem as STORAGE;
            int SagePrice;
            int SageRating;
            if (SelectedSage1 != null)
            {
                if (SelectionChangeCounterSTORAGE1 == 1)
                {
                    Price = Price - oldSTO1Price;
                    Rating = Rating - oldSTO1Rating;
                }
                SelectionChangeCounterSTORAGE1 = 1;
                var query6v2 = from b in db.STORAGEs
                               where b.Id == SelectedSage1.Id
                               select b.STORAGERating;
                SageRating = query6v2.First();
                Rating = Rating + SageRating;
                oldSTO1Rating = SageRating;
                SageRating = 0;

                var query6v3 = from b in db.STORAGEs
                               where b.Id == SelectedSage1.Id
                               select b.STORAGEPrice;
                SagePrice = query6v3.First();
                Price = Price + SagePrice;
                oldSTO1Price = SagePrice;
                SagePrice = 0;
            }
        }

        private void Storage2_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            STORAGE SelectedSage2 = Storage2_DROP.SelectedItem as STORAGE;
            int SagePrice;
            int SageRating;
            if (SelectedSage2 != null)
            {
                if (SelectionChangeCounterSTORAGE2 == 1)
                {
                    Price = Price - oldSTO2Price;
                    Rating = Rating - oldSTO2Rating;
                }
                SelectionChangeCounterSTORAGE2 = 1;
                var query6v2 = from b in db.STORAGEs
                               where b.Id == SelectedSage2.Id
                               select b.STORAGERating;
                SageRating = query6v2.First();
                Rating = Rating + SageRating;
                oldSTO2Rating = SageRating;
                SageRating = 0;

                var query6v3 = from b in db.STORAGEs
                               where b.Id == SelectedSage2.Id
                               select b.STORAGEPrice;
                SagePrice = query6v3.First();
                Price = Price + SagePrice;
                oldSTO2Price = SagePrice;
                SagePrice = 0;
            }
        }

        private void Storage3_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            STORAGE SelectedSage3 = Storage3_DROP.SelectedItem as STORAGE;
            int SageRating;
            int SagePrice;
            if (SelectedSage3 != null)
            {
                if (SelectionChangeCounterSTORAGE3 == 1)
                {
                    Price = Price - oldSTO3Price;
                    Rating = Rating - oldSTO3Rating;
                }
                SelectionChangeCounterSTORAGE3 = 1;
                var query6v2 = from b in db.STORAGEs
                               where b.Id == SelectedSage3.Id
                               select b.STORAGERating;
                SageRating = query6v2.First();
                Rating = Rating + SageRating;
                oldSTO3Rating = SageRating;
                SageRating = 0;

                var query6v3 = from b in db.STORAGEs
                               where b.Id == SelectedSage3.Id
                               select b.STORAGEPrice;
                SagePrice = query6v3.First();
                Price = Price + SagePrice;
                oldSTO3Price = SagePrice;
                SagePrice = 0;
            }
        }

        private void PSU_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            POWERSUPPLy SelectedPSU = PSU_DROP.SelectedItem as POWERSUPPLy;
            int PSUPrice;
            int PSURating;
            if (SelectedPSU != null)
            {
                if (SelectionChangeCounterPSU == 1)
                {
                    Price = Price - oldPSUPrice;
                    Rating = Rating - oldPSURating;
                }
                SelectionChangeCounterPSU = 1;
                var query7v2 = from b in db.POWERSUPPLies
                               where b.Id == SelectedPSU.Id
                               select b.POWERSUPPLYRating;
                PSURating = query7v2.First();
                Rating = Rating + PSURating;
                oldPSURating = PSURating;
                PSURating = 0;

                var query7v3 = from b in db.POWERSUPPLies
                               where b.Id == SelectedPSU.Id
                               select b.POWERSUPPLYPrice;
                PSUPrice = query7v3.First();
                Price = Price + PSUPrice;
                oldPSUPrice = PSUPrice;
                PSUPrice = 0;
            }
        }

        private void OptionalFans_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OPTIONAL SelectedFan = OptionalFans_DROP.SelectedItem as OPTIONAL;
            int FanRating;
            int FanPrice;
            if (SelectedFan != null)
            {
                if (SelectionChangeCounterOPTIONALFAN == 1)
                {
                    Price = Price - oldOP1Price;
                    Rating = Rating - oldOP1Rating;
                }
                SelectionChangeCounterOPTIONALFAN = 1;
                var query9v2 = from b in db.OPTIONALs
                               where b.Id == SelectedFan.Id
                               select b.OPTIONALRating;
                FanRating = query9v2.First();
                Rating = Rating + FanRating;
                oldOP1Rating = FanRating;
                FanRating = 0;

                var query9v3 = from b in db.OPTIONALs
                               where b.Id == SelectedFan.Id
                               select b.OPTIONALPrice;
                FanPrice = query9v3.First();
                Price = Price + FanPrice;
                oldOP1Price = FanPrice;
                FanPrice = 0;
            }
        }

        private void OptionalLED_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OPTIONAL SelectedLED = OptionalLED_DROP.SelectedItem as OPTIONAL;
            int LEDPrice;
            int LEDRating;
            if (SelectedLED != null)
            {
                if (SelectionChangeCounterOPTIONALLED == 1)
                {
                    Price = Price - oldOP2Price;
                    Rating = Rating - oldOP2Rating;
                }
                SelectionChangeCounterOPTIONALLED = 1;
                var query9v2 = from b in db.OPTIONALs
                               where b.Id == SelectedLED.Id
                               select b.OPTIONALRating;
                LEDRating = query9v2.First();
                Rating = Rating + LEDRating;
                oldOP2Rating = LEDRating;
                LEDRating = 0;

                var query9v3 = from b in db.OPTIONALs
                               where b.Id == SelectedLED.Id
                               select b.OPTIONALPrice;
                LEDPrice = query9v3.First();
                Price = Price + LEDPrice;
                oldOP2Price = LEDPrice;
                LEDPrice = 0;
            }
        }

        private void BuildRatingTBLK_Loaded(object sender, RoutedEventArgs e)
        {
            double FinalRating = ((double)Rating / 115) * 100;
            double TrimmedRating = Math.Round(FinalRating);
            string RatingS = Convert.ToString(TrimmedRating);
            BuildRatingTBLK.Text = " " + RatingS + "/100";
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            int MaxPrice = Price + 200;
            MaxPriceTBLK.Text = Convert.ToString(MaxPrice);
        }
    }
}
