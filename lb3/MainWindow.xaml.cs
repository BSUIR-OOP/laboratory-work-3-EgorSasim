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

using lb3.Vehicles;

namespace lb3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public enum vehType
        {
            NOT_CHOOSEN = -1
            ,BOAT = 0
            ,BUS
            ,CAR
            ,PLANE
            ,TRAIN
        };


        List<Transport> vehicles = new List<Transport>();


        //public string msgCreatedClass()
        //{

            
        //    switch (cmbBoxSelectVehicle.SelectedIndex)
        //    {
        //        case (int)vehType.NOT_CHOOSEN:
        //            return "Unknown";
        //        case (int)vehType.BOAT:
        //            return "Boat";
        //        case (int)vehType.BUS:
        //            return "Bus";
        //        case (int)vehType.CAR:
        //            return "Car";
        //        case (int)vehType.PLANE:
        //            return "Plane";
        //        case (int)vehType.TRAIN:
        //            return "Train";
        //        default:
        //            return "Error occured";
        //    }
        //}

        public void showVehicles()
        {
            foreach(var item in vehicles)
            {
                lstBoxVehicles.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Create the class " + cmbBoxSelectVehicle.SelectedValue);

            switch(cmbBoxSelectVehicle.SelectedIndex)
            {
                case (int)vehType.NOT_CHOOSEN:
                    MessageBox.Show("Please, choose the class to create");
                    break;
                case (int)vehType.BOAT:
                    vehicles.Add(new Vehicles.Boat(0,"boat",0,0,0));
                    break;
                case (int)vehType.BUS:
                    vehicles.Add(new Vehicles.Boat(0, "BUS", 0, 0, 0));
                    break;
                case (int)vehType.CAR:
                    vehicles.Add(new Vehicles.Boat(0, "CAR", 0, 0, 0));
                    break;
                case (int)vehType.PLANE:
                    vehicles.Add(new Vehicles.Boat(0, "PLANE", 0, 0, 0));
                    break;
                case (int)vehType.TRAIN:
                    vehicles.Add(new Vehicles.Boat(0, "TRAIN", 0, 0, 0));
                    break;
                default:
                    MessageBox.Show("Smth goes wrong, please try again");
                    break;
            }

            showVehicles();

        }
    }
}
