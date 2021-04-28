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
        PcHelpenatorEntities db;                                                            //Getting the Database
        System.Media.SoundPlayer Player = new System.Media.SoundPlayer();                   //Getting the media player to work in the code
        int Rating;                                                                         //int Variable that will keep track of the Rating
        int Price;                                                                          //int Variable that will keep track of the price
        int SelectionChangeCounterCase = 0;                                                 //int Variable that will keep track of the times the case drop downs were used
        int oldCasePrice = 0;                                                               //int Variable that will keep track of the Case Price before it was changed
        int oldCaseRating = 0;                                                              //int Variable that will keep track of the Case Rating before it was changed
        int SelectionChangeCounterCPU = 0;                                                  //int Variable that will keep track of the times the CPU drop downs were used
        int oldCPUPrice = 0;                                                                //int Variable that will keep track of the CPU Price before it was changed
        int oldCPURating = 0;                                                               //int Variable that will keep track of the CPU Rating before it was changed
        int SelectionChangeCounterGPU = 0;                                                  //int Variable that will keep track of the times the GPU drop downs were used
        int oldGPUPrice = 0;                                                                //int Variable that will keep track of the GPU price before it was changed
        int oldGPURating = 0;                                                               //int Variable that will keep track of the GPU Rating before it was changed
        int SelectionChangeCounterMOBO = 0;                                                 //int Variable that will keep track of the times the MOTHERBOARD drop downs were used
        int oldMOBOPrice = 0;                                                               //int Variable that will keep track of the MotherBoard Price before it was changed
        int oldMOBORating = 0;                                                              //int Variable that will keep track of the MotherBoard Rating before it was changed
        int SelectionChangeCounterHEAT = 0;                                                 //int Variable that will keep track of the times the HEATSINK drop downs were used
        int oldHEATPrice = 0;                                                               //int Variable that will keep track of the HeatSink Price before it was changed
        int oldHEATRating = 0;                                                              //int Variable that will keep track of the HeatSink Rating before it was changed
        int SelectionChangeCounterRAM = 0;                                                  //int Variable that will keep track of the times the RAM drop downs were used
        int oldRAMPrice = 0;                                                                //int Variable that will keep track of the RAM Price before it was changed
        int oldRAMRating = 0;                                                               //int Variable that will keep track of the RAM Rating before it was changed
        int SelectionChangeCounterSTORAGE1 = 0;                                             //int Variable that will keep track of the times the STROAGE1 drop downs were used
        int SelectionChangeCounterSTORAGE2 = 0;                                             //int Variable that will keep track of the times the STORAGE2 drop downs were used
        int SelectionChangeCounterSTORAGE3 = 0;                                             //int Variable that will keep track of the times the STORAGE3 drop downs were used
        int oldSTO1Price = 0;                                                               //int Variable that will keep track of the Storage 1 Price before it was changed
        int oldSTO1Rating = 0;                                                              //int Variable that will keep track of the Storage 1 Rating before it was changed
        int oldSTO2Price = 0;                                                               //int Variable that will keep track of the Storage 2 Price before it was changed
        int oldSTO2Rating = 0;                                                              //int Variable that will keep track of the Storage 2 Rating before it was changed
        int oldSTO3Price = 0;                                                               //int Variable that will keep track of the Storage 3 Price before it was changed
        int oldSTO3Rating = 0;                                                              //int Variable that will keep track of the Storage 3 Rating before it was changed
        int SelectionChangeCounterPSU = 0;                                                  //int Variable that will keep track of the times the POWERSUPPLY drop downs were used
        int oldPSUPrice = 0;                                                                //int Variable that will keep track of the PSU Price before it was changed
        int oldPSURating = 0;                                                               //int Variable that will keep track of the PSU Rating before it was changed
        int SelectionChangeCounterOPTIONALFAN = 0;                                          //int Variable that will keep track of the times the FANS drop downs were used
        int oldOP1Price = 0;                                                                //int Variable that will keep track of the FANS Price before it was changed
        int oldOP1Rating = 0;                                                               //int Variable that will keep track of the FANS Rating before it was changed
        int SelectionChangeCounterOPTIONALLED = 0;                                          //int Variable that will keep track of the times the LEDs drop downs were used
        int oldOP2Price = 0;                                                                //int Variable that will keep track of the LEDs Price before it was changed
        int oldOP2Rating = 0;                                                               //int Variable that will keep track of the LEDs Rating before it was changed
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Player.SoundLocation = "DankMusic.wav";                                         //When the WPF is loaded it will play the song that i put in the debug folder of the project
            Player.PlayLooping();                                                           //This will keep the song looping for as long as your in the app
            
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            var query1 = from a in db.CPUs                                                  //When loaded the CPU drop down will be instantly loaded as its the first one you need to use for the rest to work
                        select a;
            CPU_DROP.ItemsSource = query1.ToList();
 
        }
        private void CaseStealth_DROP_DropDownOpened(object sender, EventArgs e)            //When the Drop Down for the Stealth Case Selection is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;               //Compatible is key when building a pc so the motherboard has to fit in the case so this will only be ran after a motherboard is picked otherwise it will be null
            if (SelectedMobo != null)                                                       //As long as Motherboard has been picked
            {
                string MoboType = SelectedMobo.MOTHERBOARDSize;                             //Setting the MotherboardSize data from the Database to a string
                if (MoboType == "ATX")                                                      //If the MotherboardSize data is equal to "ATX" it will run this code
                {
                    var query8 = from a in db.Cases                                         //Query to get the list of cases that are both "Stealth" and "ATX" to fit in with Compatiblity
                                 where a.CASELooks == "Stealth" && a.CASESize == "ATX"
                                 select a;
                    CaseStealth_DROP.ItemsSource = query8.ToList();                         //Setting the Data acuired as the item source of the drop down menu
                }
                else                                                                        //If its not equal to "ATX" it will run this code
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "Stealth"                             //Query to get the list of cases that are "Stealth" to fit in with Compatiblity
                                 select a;
                    CaseStealth_DROP.ItemsSource = query8.ToList();                         //Setting the Data acuired as the item source of the drop down menu
                }
            }
            CaseRGB_DROP.ItemsSource = null;                                                //When this drop down menu is opened the other two drop down menus will be cleared as you can only have one case
            Airflow_DROP.ItemsSource = null;
        }

        private void CaseRGB_DROP_DropDownOpened(object sender, EventArgs e)                //When the Drop Down for the RGB Case Selection is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;               //Compatible is key when building a pc so the motherboard has to fit in the case so this will only be ran after a motherboard is picked otherwise it will be null
            if (SelectedMobo != null)                                                       //As long as Motherboard has been picked
            {
                string MoboType = SelectedMobo.MOTHERBOARDSize;                             //Setting the MotherboardSize data from the Database to a string
                if (MoboType == "ATX")                                                      //If the MotherboardSize data is equal to "ATX" it will run this code
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "RGB" && a.CASESize == "ATX"          //Query to get the list of cases that are both "RGB" and "ATX" to fit in with Compatiblity
                                 select a;
                    CaseRGB_DROP.ItemsSource = query8.ToList();                             //Setting the Data acuired as the item source of the drop down menu
                }
                else                                                                        //If its not equal to "ATX" it will run this code
                {
                    var query8 = from a in db.Cases                                         //Query to get the list of cases that are "RGB" to fit in with Compatiblity
                                 where a.CASELooks == "RGB"
                                 select a;
                    CaseRGB_DROP.ItemsSource = query8.ToList();                             //Setting the Data acuired as the item source of the drop down menu
                }
            }
            CaseStealth_DROP.ItemsSource = null;                                            //When this drop down menu is opened the other two drop down menus will be cleared as you can only have one case
            Airflow_DROP.ItemsSource = null;
        }

        private void Airflow_DROP_DropDownOpened(object sender, EventArgs e)                //When the Drop Down for the Airflow Case Selection is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;               //Compatible is key when building a pc so the motherboard has to fit in the case so this will only be ran after a motherboard is picked otherwise it will be null
            if (SelectedMobo != null)                                                       //As long as Motherboard has been picked
            {
                string MoboType = SelectedMobo.MOTHERBOARDSize;                             //Setting the MotherboardSize data from the Database to a string
                if (MoboType == "ATX")                                                      //If the MotherboardSize data is equal to "ATX" it will run this code
                {
                    var query8 = from a in db.Cases
                                 where a.CASELooks == "Airflow" && a.CASESize == "ATX"      //Query to get the list of cases that are both "Airflow" and "ATX" to fit in with Compatiblity
                                 select a;
                    Airflow_DROP.ItemsSource = query8.ToList();                             //Setting the Data acuired as the item source of the drop down menu
                }
                else                                                                        //If its not equal to "ATX" it will run this code
                {
                    var query8 = from a in db.Cases                                         //Query to get the list of cases that are "Airflow" to fit in with Compatiblity
                                 where a.CASELooks == "Airflow"
                                 select a;
                    Airflow_DROP.ItemsSource = query8.ToList();                             //Setting the Data acuired as the item source of the drop down menu
                }
            }
            CaseRGB_DROP.ItemsSource = null;                                                //When this drop down menu is opened the other two drop down menus will be cleared as you can only have one case
            CaseStealth_DROP.ItemsSource = null;
        }

        private void Airflow_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)      //When the item in the Drop box is selected initiate this code
        {
            Case SelectedCase = Airflow_DROP.SelectedItem as Case;                          //Selecting the items that was selected in the drop box
            int CaseRating;                                                                 //Current Case Rating
            int CasePrice;                                                                  //Current Case Price
            if (SelectedCase != null)                                                       //Do the following code when there is a case selected
            {
                if (SelectionChangeCounterCase == 1)                                        //If the Counter that i declared at the top of the code is equal to 1 then do the following
                {
                    Rating = Rating - oldCaseRating;                                        //Take the Rating of the item that was prevousily selected and take it from the rating 
                    Price = Price - oldCasePrice;                                           //Take the Price of the item that was prevousily selected and take it from the Price
                }
                SelectionChangeCounterCase = 1;                                             //Setting the Counter too 1 so that any change to the case you select will not effect the rating or price 
                var query8v2 = from b in db.Cases                                           //This is a query to get the matching image of the case selected in the drop down menu
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();                                 //Assigning that image to list box

                var query8v3 = from b in db.Cases                                           //Getting the Rating of the selected Case
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                CaseRating = query8v3.First();
                Rating = Rating + CaseRating;                                               //Adding the rating to the overall rating
                oldCaseRating = CaseRating;                                                 //Keeping a copy of that rating incase the user changes there mind about the case
                CaseRating = 0;                                                             //Setting the case rating back to 0 after all the rating code has been ran

                var query8v4 = from b in db.Cases                                           //Getting the price of the selected case
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                CasePrice = query8v4.First();
                Price = Price + CasePrice;                                                  //Adding the price to the overall price
                oldCasePrice = CasePrice;                                                   //Keeping a copy of the Price incase user changes their mind
                CasePrice = 0;                                                              //Setting the price back to 0 so it can be run again if user changes their mind
            }
        }

        private void CaseStealth_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)  //When the item in the Drop box is selected initiate this code
        {
            Case SelectedCase = CaseStealth_DROP.SelectedItem as Case;                      //Selecting the items that was selected in the drop box
            int CaseRating;                                                                 //Current Case Rating
            int CasePrice;                                                                  //Current Case Price
            if (SelectedCase != null)                                                       //Do the following code when there is a case selected
            {
                if (SelectionChangeCounterCase == 1)                                        //If the Counter that i declared at the top of the code is equal to 1 then do the following
                {
                    Rating = Rating - oldCaseRating;                                        //Take the Rating of the item that was prevousily selected and take it from hte rating 
                    Price = Price - oldCasePrice;                                           //Take the Price of the item that was prevousily selected and take it from the Price
                }
                SelectionChangeCounterCase = 1;                                             //Setting the Counter too 1 so that any change to the case you select will not effect the rating or price 
                var query8v2 = from b in db.Cases                                           //This is a query to get the matching image of the case selected in the drop down menu
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();                                 //Assigning that image to list box

                var query8v3 = from b in db.Cases                                           //Getting the Rating of the selected Case
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                CaseRating = query8v3.First();                                                  
                Rating = Rating + CaseRating;                                               //Adding the rating to the overall rating
                oldCaseRating = CaseRating;                                                 //Keeping a copy of that rating incase the user changes there mind about the case
                CaseRating = 0;                                                             //Setting the case rating back to 0 after all the rating code has been ran

                var query8v4 = from b in db.Cases                                           //Getting the price of the selected case
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                CasePrice = query8v4.First();
                Price = Price + CasePrice;                                                  //Adding the price to the overall price
                oldCasePrice = CasePrice;                                                   //Keeping a copy of the Price incase user changes their mind
                CasePrice = 0;                                                              //Setting the price back to 0 so it can be run again if user changes their mind
            }
        }

        private void CaseRGB_DROP_SelectionChanged(object sender, SelectionChangedEventArgs e)  //When the item in the Drop box is selected initiate this code
        {
            Case SelectedCase = CaseRGB_DROP.SelectedItem as Case;                          //Selecting the items that was selected in the drop box
            int CaseRating;                                                                 //Current Case Rating
            int CasePrice;                                                                  //Current Case Price
            if (SelectedCase != null)                                                       //Do the following code when there is a case selected
            {
                if (SelectionChangeCounterCase == 1)                                        //If the Counter that i declared at the top of the code is equal to 1 then do the following
                {
                    Rating = Rating - oldCaseRating;                                        //Take the Rating of the item that was prevousily selected and take it from hte rating 
                    Price = Price - oldCasePrice;                                           //Take the Price of the item that was prevousily selected and take it from the Price
                }
                SelectionChangeCounterCase = 1;                                             //Setting the Counter too 1 so that any change to the case you select will not effect the rating or price 
                var query8v2 = from b in db.Cases                                           //This is a query to get the matching image of the case selected in the drop down menu
                               where b.Id == SelectedCase.Id
                               select b;
                PCImageLBX.ItemsSource = query8v2.ToList();                                 //Assigning that image to list box

                var query8v3 = from b in db.Cases                                           //Getting the Rating of the selected Case
                               where b.Id == SelectedCase.Id
                               select b.CASERating;
                CaseRating = query8v3.First();
                Rating = Rating + CaseRating;                                               //Adding the rating to the overall rating
                oldCaseRating = CaseRating;                                                 //Keeping a copy of that rating incase the user changes there mind about the case
                CaseRating = 0;                                                             //Setting the case rating back to 0 after all the rating code has been ran

                var query8v4 = from b in db.Cases                                           //Getting the price of the selected case
                               where b.Id == SelectedCase.Id
                               select b.CASEPrice;
                CasePrice = query8v4.First();
                Price = Price + CasePrice;                                                  //Adding the price to the overall price
                oldCasePrice = CasePrice;                                                   //Keeping a copy of the Price incase user changes their mind
                CasePrice = 0;                                                              //Setting the price back to 0 so it can be run again if user changes their mind
            }
        }

        private void RecPriceTBLK_Loaded(object sender, RoutedEventArgs e)                  //When the text box is loaded do the following
        {
            if (Price == 420)                                                               //if the price is equal to 420 do the following
            {
                Random rnd = new Random();                                                  //Creats list of random numbers
                int randomNum = rnd.Next(421);                                              //Getting a random Number bettween 0 and 420
                string RandomNumberS = Convert.ToString(randomNum);                         //Converting the number to a string
                RANDOEASTEREGG.Text = " " + RandomNumberS + " NOICEE!!!";                   //Filling in the textbox with a random number and text (EASTER EGG)
            }
            RecPriceTBLK.Text = Convert.ToString(Price);                                    //The price of the PC into the text box
        }

        private void GPU_DROP_DropDownOpened(object sender, EventArgs e)                    //When the Drop Down for the GPU is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            var query2 = from a in db.GPUs
                         select a;
            GPU_DROP.ItemsSource = query2.ToList();                                         //Getting all the GPUs and putting them in the drop down box as they are all compatible 
        }

        private void MOBO_DROP_DropDownOpened(object sender, EventArgs e)                   //When the Drop Down for the MotherBoard is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;                                 //Compatible is key when building a pc so the right CPU has to be with the right Motherboard so only compatible motherboards will show for the CPU selected
            if (SelectedCPU != null)                                                        //Do the following code when there is a CPU selected
            {
                string CpuType = SelectedCPU.CPUSocketType;                                 //Getting the socket type of the selected CPU
                if (CpuType == "LGA 1200")                                                  //If CPUType is equal to LGA 1200 do the following
                {
                    var query3 = from a in db.MOTHERBOARDs                                  //Query to get the right motherboards from the database
                                 where a.MOTHERBOARDSocke == "LGA 1200"
                                 select a;
                    MOBO_DROP.ItemsSource = query3.ToList();                                //Putting those motherboards in the drop down box
                }
                else                                                                        //If its anything other than LGA 1200 do the following code
                {
                    var query3 = from a in db.MOTHERBOARDs                                  //Query to get the right motherboards from the database
                                 where a.MOTHERBOARDSocke == "AM4"
                                 select a;
                    MOBO_DROP.ItemsSource = query3.ToList();                                //Putting those motherboards in the drop down box
                }
            }
        }

        private void OptionalFans_DROP_DropDownOpened(object sender, EventArgs e)           //When the Drop Down for the Fans is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            var query9 = from a in db.OPTIONALs                                             //Query to get the right Items from the database
                         where a.OPTIONALType.Equals("FANS")
                         select a;
            OptionalFans_DROP.ItemsSource = query9.ToList();                                //Putting the FANs in the drop down box
        }

        private void OptionalLED_DROP_DropDownOpened(object sender, EventArgs e)            //When the Drop Down for the LEDs is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            var query9 = from a in db.OPTIONALs                                             //Query to get the right Items from the database
                         where a.OPTIONALType.Equals("LED")
                         select a;
            OptionalLED_DROP.ItemsSource = query9.ToList();                                 //Putting the LEDs in the drop down box
        }

        private void Heatsink_DROP_DropDownOpened(object sender, EventArgs e)               //When the Drop Down for the HeatSink is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;
            if (SelectedCPU != null)                                                        //Do the following code when there is a CPU selected
            {
                string CpuType = SelectedCPU.CPUHeatsink;                                   //Getting the Heatsink type of the selected CPU
                if (CpuType == "NO")                                                        //If CPU heatSink equals NO do the following code
                {
                    var query4 = from a in db.HEATSINKs                                     //Query to get the Heatsinks that equal Any
                                 where a.HEATSINKSocket == "Any"
                                 select a;
                    Heatsink_DROP.ItemsSource = query4.ToList();                            //Putting the HeatSink in the drop down box
                }
                else                                                                        //if its anything other than Any do the following
                {
                    var query4 = from a in db.HEATSINKs                                     //Getting all the heatsinks as the rest are all compatible
                                 select a;
                    Heatsink_DROP.ItemsSource = query4.ToList();                            //Putting the HeatSink in the drop down box
                }
            }
        }

        private void RAM_DROP_DropDownOpened(object sender, EventArgs e)                    //When the Drop Down for the RAM is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                                //Declaring db as the database
            MOTHERBOARD SelectedMobo = MOBO_DROP.SelectedItem as MOTHERBOARD;
            if (SelectedMobo != null)                                                       //Do the following code when there is a Motherboard is selected
            {
                int maxRam = SelectedMobo.MOTHERBOARDMaxRam;                                //Getting the MaxRam of the selected Motherboard 
                if (maxRam == 16)                                                           //if MaxRam is equal to 16 do the following code
                {
                    var query5 = from a in db.RAMs                                          //Get the RamSize that is equal to both 16 and 8
                                 where a.RAMSize == 16 || a.RAMSize == 8
                                 select a;
                    RAM_DROP.ItemsSource = query5.ToList();                                 //Putting the RAM in the drop down box
                }
                else                                                                        //If its anything other than 16 do the following
                {
                    var query5 = from a in db.RAMs                                          //Gets all the ram as it is all compatible then.
                                 select a;
                    RAM_DROP.ItemsSource = query5.ToList();                                 //Putting the RAM in the drop down box
                }
            }
        }

        private void Storage1_DROP_DropDownOpened(object sender, EventArgs e)           //When the Drop Down for the Storage 1 is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                            //Declaring db as the database
            var query6 = from a in db.STORAGEs                                          //Query to get the right Items from the database
                         select a;
            Storage1_DROP.ItemsSource = query6.ToList();                                //Putting Storage in the drop down box
        }

        private void Storage2_DROP_DropDownOpened(object sender, EventArgs e)           //When the Drop Down for the Storage 2 is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                            //Declaring db as the database
            var query6 = from a in db.STORAGEs                                          //Query to get the right Items from the database
                         select a;
            Storage2_DROP.ItemsSource = query6.ToList();                                //Putting Storage in the drop down box
        }

        private void Storage3_DROP_DropDownOpened(object sender, EventArgs e)           //When the Drop Down for the Storage 3 is opened it will run this code
        {
            db = new PcHelpenatorEntities();                                            //Declaring db as the database
            var query6 = from a in db.STORAGEs                                          //Query to get the right Items from the database
                         select a;
            Storage3_DROP.ItemsSource = query6.ToList();                                //Putting Storage in the drop down box
        }

        private void PSU_DROP_DropDownOpened(object sender, EventArgs e)                //When the Drop Down for the PSU is opened it will run this code
        {
            
            db = new PcHelpenatorEntities();                                            //Declaring db as the database
            CPU SelectedCPU = CPU_DROP.SelectedItem as CPU;                             //Getting the Selected CPU from the selection box
            GPU SelectedGPU = GPU_DROP.SelectedItem as GPU;                             //Getting the Selected GPU from the selection box
            int PCWatts = SelectedCPU.CPUWatts + SelectedGPU.GPUWatts + 250;            //Adding the Watts of the GPU and CPU and adding 200 to give a safe overhead
            var query7 = from a in db.POWERSUPPLies                                     //Query to get power supplies that are more then the PCWatts
                         where a.POWERSUPPLYWatts >= PCWatts
                         select a;
            PSU_DROP.ItemsSource = query7.ToList();                                     //Putting those PSUs in the drop down box
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
