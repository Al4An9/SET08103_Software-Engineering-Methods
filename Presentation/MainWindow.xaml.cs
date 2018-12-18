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

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBoxColor.Items.Add("Blue £20");
            ComboBoxColor.Items.Add("Black £20");
            ComboBoxColor.Items.Add("Red £20");
            ComboBoxColor.Items.Add("Silver £20");
            ComboBoxColor.Items.Add("Yellow £20");
            ComboBoxColor.Items.Add("Green £20");
        }

        private int _specialStockCounter;
        private int _standardStockCounter;
        private int _totalCost;
        private int _totalDeliveryTime;
        private int _brakes;
        private int _saddle;
        private int _wheels;
        private int _gears;
        private int _framesize;
        private int _handlebars;
        private int _bikeStyle;
        private int _color;
        private int _errorCounter = 0;

        private void BtnSubmitPreference_Click(object sender, RoutedEventArgs e)
        {
            //call totalcost method and parsing to string to assign it to the text box
            TotalCost();
            TotalDeliveryTime();
            if (_errorCounter > 0)
            {
                MessageBox.Show("fix the errors within the form to proceed");
            }
            else
            {
                LblCost.Content = "£" + _totalCost.ToString();
                LblTime.Content = "up to " + _totalDeliveryTime.ToString() + " days";

                MessageBox.Show("Does the customer agrees with the total cost"
                    + " £" + _totalCost + " and up to "
                    + _totalDeliveryTime
                    + " days for the completion?", "Confirmation", MessageBoxButton.YesNo);
            }
        }

        private int TotalCost()
        {
            Frame();
            Wheels();
            Gears();
            Brakes();
            Saddle();
            BikeStyle();
            Handlebards();
            Color();

            int _buildingAndtesting = 100;
            int _warranty = 50;

            _totalCost = _color + _bikeStyle + _brakes + _framesize + _gears + _saddle + _wheels + _handlebars + _buildingAndtesting;

            if (ChkBoxWarranty.IsChecked == true)
            {
                _totalCost += _warranty;
            }

            return _totalCost;
        }

        private int TotalDeliveryTime()
        {
            int _buldingAndTesting = 1;
            int daysForRestock = 0;

            if (_specialStockCounter > 0)
            {
                daysForRestock = 14;
            }
            else if (_standardStockCounter > 0)
            {
                daysForRestock = 7;
            }

            _totalDeliveryTime = _buldingAndTesting + daysForRestock;

            return _totalDeliveryTime;
        }

        public int BikeStyle()
        {
            int roadBike = 20;
            int mountainBike = 50;

            if (RdBtnRoadBike.IsChecked == true)
            {
                _bikeStyle = roadBike;
            }
            else if (RdBtnMountainBike.IsChecked == true)
            {
                _bikeStyle = mountainBike;
            }
            else if ((RdBtnRoadBike.IsChecked == false) && (RdBtnMountainBike.IsChecked == false))
            {
                MessageBox.Show("Select Bike Frame style to proceed");
                _errorCounter++;
            }
            return _bikeStyle;
        }

        public int Color()
        {
            int color = 20;

            if (ComboBoxColor.SelectedItem != null)
            {
                _color = color;
            }
            else if (ComboBoxColor.SelectedItem == null)
            {
                MessageBox.Show("Select frame color to proceed");
                _errorCounter++;
            }

            return _color;
        }

        public int Wheels()
        {
            int roadWheels = 30;
            int offRoadWheels = 50;

            if (ChkBoxRoadWheels.IsChecked == true)
            {
                _wheels = roadWheels;
            }
            else if (ChkBoxOffRoad.IsChecked == true)
            {
                _wheels = offRoadWheels;
            }
            else if ((ChkBoxRoadWheels.IsChecked == false) && (ChkBoxOffRoad.IsChecked == false))
            {
                MessageBox.Show("Select Wheels to proceed");
                _errorCounter++;
            }
            return _wheels;
        }

        public int Gears()
        {
            int singleSpeed = 20;
            int twentyoneSpeed = 50;
            int twentyfourSpeed = 150;

            if (ChkBoxSingleSpeed.IsChecked == true)
            {
                _gears = singleSpeed;
            }
            else if (ChkBox21Speed.IsChecked == true)
            {
                _gears = twentyoneSpeed;
            }
            else if (ChkBox24Speed.IsChecked == true)
            {
                _gears = twentyfourSpeed;
                _specialStockCounter++;
            }
            else if ((ChkBoxSingleSpeed.IsChecked == false) && (ChkBox21Speed.IsChecked == false) && (ChkBox24Speed.IsChecked == false))
            {
                MessageBox.Show("Select Gears to proceed");
                _errorCounter++;
            }
            return _gears;
        }

        public int Frame()
        {
            int smallFrame = 100;
            int mediumFrame = 120;
            int largeFrame = 150;

            if (ChkBoxSmall.IsChecked == true)
            {
                _framesize = smallFrame;
            }
            else if (ChkBoxMedium.IsChecked == true)
            {
                _framesize = mediumFrame;
            }
            else if (ChkBoxLarge.IsChecked == true)
            {
                _framesize = largeFrame;
            }
            else if ((ChkBoxSmall.IsChecked == false) && (ChkBoxMedium.IsChecked == false) && (ChkBoxLarge.IsChecked == false))
            {
                MessageBox.Show("Select Frame size to proceed");
                _errorCounter++;
            }
            return _framesize;
        }

        public int Brakes()
        {
            int rimBrakes = 20;
            int discBrakes = 50;

            if (ChkBoxRimBrakes.IsChecked == true)
            {
                _standardStockCounter++;
                _brakes = rimBrakes;
            }
            else if (ChkBoxDiscBrakes.IsChecked == true)
            {
                _brakes = discBrakes;
            }
            else if ((ChkBoxRimBrakes.IsChecked == false) && (ChkBoxDiscBrakes.IsChecked == false))
            {
                MessageBox.Show("Select Brakes to proceed");
                _errorCounter++;
            }
            return _brakes;
        }

        public int Saddle()
        {
            int carbonSaddle = 20;
            int gelSaddle = 30;

            if (ChkBoxCarbonSaddle.IsChecked == true)
            {
                _saddle = carbonSaddle;
            }
            else if (ChkBoxGelSaddle.IsChecked == true)
            {
                _saddle = gelSaddle;
            }
            else if ((ChkBoxGelSaddle.IsChecked == false) && (ChkBoxCarbonSaddle.IsChecked == false))
            {
                MessageBox.Show("Select Saddle to proceed");
                _errorCounter++;
            }
            return _saddle;
        }

        public int Handlebards()
        {
            int bullhorn = 20;
            int riser = 30;
            int flat = 15;

            if (ChkBoxBullhorn.IsChecked == true)
            {
                _handlebars = bullhorn;
            }
            else if (ChkBoxRiser.IsChecked == true)
            {
                _handlebars = riser;
            }
            else if (ChkBoxFlat.IsChecked == true)
            {
                _handlebars = flat;
            }
            else if ((ChkBoxRiser.IsChecked == false) && (ChkBoxBullhorn.IsChecked == false) && (ChkBoxFlat.IsChecked == false))
            {
                MessageBox.Show("Select Handlebars to proceed");
                _errorCounter++;
            }
            return _handlebars;
        }

        public void Clear()
        {
            LblCost.Content = "";
            LblTime.Content = "";
            _errorCounter = 0;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void ChkBoxRoadWheels_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxRoadWheels.IsChecked == true)
                ChkBoxOffRoad.IsEnabled = false;
        }
        private void ChkBoxRoadWheels_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxRoadWheels.IsChecked == false)
                ChkBoxOffRoad.IsEnabled = true;
        }

        private void ChkBoxOffRoad_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxOffRoad.IsChecked == true)
                ChkBoxRoadWheels.IsEnabled = false;
        }
        private void ChkBoxOffRoad_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxOffRoad.IsChecked == false)
                ChkBoxRoadWheels.IsEnabled = true;
        }

        private void ChkBoxRimBrakes_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxRimBrakes.IsChecked == true)

                ChkBoxDiscBrakes.IsEnabled = false;
        }
        private void ChkBoxRimBrakes_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxRimBrakes.IsChecked == false)
                _standardStockCounter = 0;
            ChkBoxDiscBrakes.IsEnabled = true;
        }

        private void ChkBoxDiscBrakes_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxDiscBrakes.IsChecked == true)
                ChkBoxRimBrakes.IsEnabled = false;
        }
        private void ChkBoxDiscBrakes_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxDiscBrakes.IsChecked == false)
                ChkBoxRimBrakes.IsEnabled = true;
        }

        private void ChkBoxCarbonSaddle_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxCarbonSaddle.IsChecked == true)
                ChkBoxGelSaddle.IsEnabled = false;
        }
        private void ChkBoxCarbonSaddle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxCarbonSaddle.IsChecked == false)
                ChkBoxGelSaddle.IsEnabled = true;
        }

        private void ChkBoxGelSaddle_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxGelSaddle.IsChecked == true)
                ChkBoxCarbonSaddle.IsEnabled = false;
        }

        private void ChkBoxGelSaddle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxGelSaddle.IsChecked == false)
                ChkBoxCarbonSaddle.IsEnabled = true;
        }


        private void ChkBoxSmall_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxSmall.IsChecked == true)
            {
                ChkBoxMedium.IsEnabled = false;
                ChkBoxLarge.IsEnabled = false;
            }
        }
        private void ChkBoxSmall_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxSmall.IsChecked == false)
            {
                ChkBoxMedium.IsEnabled = true;
                ChkBoxLarge.IsEnabled = true;
            }
        }

        private void ChkBoxMedium_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxMedium.IsChecked == true)
            {
                ChkBoxSmall.IsEnabled = false;
                ChkBoxLarge.IsEnabled = false;
            }
        }
        private void ChkBoxMedium_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxMedium.IsChecked == false)
            {
                ChkBoxSmall.IsEnabled = true;
                ChkBoxLarge.IsEnabled = true;
            }
        }

        private void ChkBoxLarge_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxLarge.IsChecked == true)
            {
                ChkBoxSmall.IsEnabled = false;
                ChkBoxMedium.IsEnabled = false;
            }
        }
        private void ChkBoxLarge_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxLarge.IsChecked == false)
            {
                ChkBoxMedium.IsEnabled = true;
                ChkBoxSmall.IsEnabled = true;
            }
        }

        private void ChkBoxBullhorn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxBullhorn.IsChecked == true)
            {
                ChkBoxRiser.IsEnabled = false;
                ChkBoxFlat.IsEnabled = false;
            }
        }
        private void ChkBoxBullhorn_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxBullhorn.IsChecked == false)
            {
                ChkBoxRiser.IsEnabled = true;
                ChkBoxFlat.IsEnabled = true;
            }
        }


        private void ChkBoxRiser_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxRiser.IsChecked == true)
            {
                ChkBoxBullhorn.IsEnabled = false;
                ChkBoxFlat.IsEnabled = false;
            }
        }
        private void ChkBoxRiser_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxRiser.IsChecked == false)
            {
                ChkBoxBullhorn.IsEnabled = true;
                ChkBoxFlat.IsEnabled = true;
            }
        }

        private void ChkBoxFlat_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxFlat.IsChecked == true)
            {
                ChkBoxBullhorn.IsEnabled = false;
                ChkBoxRiser.IsEnabled = false;
            }
        }
        private void ChkBoxFlat_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxFlat.IsChecked == false)
            {
                ChkBoxBullhorn.IsEnabled = true;
                ChkBoxRiser.IsEnabled = true;
            }
        }


        private void ChkBoxSingleSpeed_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxSingleSpeed.IsChecked == true)
            {
                ChkBox21Speed.IsEnabled = false;
                ChkBox24Speed.IsEnabled = false;
            }
        }
        private void ChkBoxSingleSpeed_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBoxSingleSpeed.IsChecked == false)
            {
                ChkBox21Speed.IsEnabled = true;
                ChkBox24Speed.IsEnabled = true;
            }
        }

        private void ChkBox21Speed_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBox21Speed.IsChecked == true)
            {
                ChkBoxSingleSpeed.IsEnabled = false;
                ChkBox24Speed.IsEnabled = false;
            }
        }
        private void ChkBox21Speed_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBox21Speed.IsChecked == false)
            {
                ChkBoxSingleSpeed.IsEnabled = true;
                ChkBox24Speed.IsEnabled = true;
            }
        }

        private void ChkBox24Speed_Checked(object sender, RoutedEventArgs e)
        {
            if (ChkBox24Speed.IsChecked == true)
            {
                ChkBoxSingleSpeed.IsEnabled = false;
                ChkBox21Speed.IsEnabled = false;
            }
        }
        private void ChkBox24Speed_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ChkBox24Speed.IsChecked == false)
            {
                _specialStockCounter = 0;
                ChkBoxSingleSpeed.IsEnabled = true;
                ChkBox21Speed.IsEnabled = true;
            }
        }
    }
}
