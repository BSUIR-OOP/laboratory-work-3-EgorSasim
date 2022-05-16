using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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
            ,VEH_END
        };


        public string[] vehNames = new string[5]; /*{ "lb3.Vehicles.Boat", "lb3.Vehicles.BUS", "lb3.Vehicles.CAR", "lb3.Vehicles.PLANE", "lb3.Vehicles.TRAIN" };*/


        List<Transport> vehicles = new List<Transport>();

        
        public void showVehicles()
        {
            lstBoxVehicles.Items.Clear();
            foreach(var item in vehicles)
            {
                lstBoxVehicles.Items.Add($"{item} {item.speed} {item.name} {item.id} {item.power} {item.places}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Create the class " + cmbBoxSelectVehicle.SelectedValue);

            int id, places;
            double power, speed;
            string name;
            if(Logic.checkEmpty(vehSpeed.Text, vehName.Text, vehId.Text, vehPower.Text, vehPlaces.Text))
            {
                if (Logic.ValidSpec(vehSpeed.Text, vehName.Text, vehId.Text, vehPower.Text, vehPlaces.Text))
                {
                    id      = Convert.ToInt32(vehId.Text);
                    places  = Convert.ToInt32(vehPlaces.Text);
                    power   = Convert.ToDouble(vehPower.Text);
                    speed   = Convert.ToDouble(vehSpeed.Text);
                    name    = vehName.Text;
                    

                    

                    switch (cmbBoxSelectVehicle.SelectedIndex)
                    {
                        case (int)vehType.NOT_CHOOSEN:
                            MessageBox.Show("Please, choose the class to create");
                            break;
                        case (int)vehType.BOAT:
                            vehicles.Add(new Vehicles.Boat(speed, name, id, power, places));
                            break;
                        case (int)vehType.BUS:
                            vehicles.Add(new Vehicles.Bus(speed, name, id, power, places));
                            break;
                        case (int)vehType.CAR:
                            vehicles.Add(new Vehicles.Car(speed, name, id, power, places));
                            break;
                        case (int)vehType.PLANE:
                            vehicles.Add(new Vehicles.Plane(speed, name, id, power, places));
                            break;
                        case (int)vehType.TRAIN:
                            vehicles.Add(new Vehicles.Train(speed, name, id, power, places));
                            break;
                        default:
                            MessageBox.Show("Smth goes wrong, please try again");
                            break;
                    }

                    

                    showVehicles();
                }
                else
                {
                    MessageBox.Show("Not valid values, please do smth about it)");
                }
            } else
            {
                MessageBox.Show("An empty fields detected!!!");
            }
            

            

        }

        private void btnSearchSerializeFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog1.FileName;
                txtBoxSerFile.Text = selectedFileName;
            }
        }


        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (System.IO.StreamWriter writer = new StreamWriter(txtBoxSerFile.Text))
                {
                    foreach(var item in vehicles)
                    {
                        writer.Write($"{item.ToString()} {item.speed} {item.name} {item.id} {item.power} {item.places}\n");
                    }

                    MessageBox.Show("Successfully write");
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }


        
        public void createObjFromString(string type, string speed, string name, string id, string power, string places)
        {

            
            //if( String.IsNullOrEmpty(type) || Logic.checkEmpty(speed, name, id, power, places) )
            //{
            //    return;
            //}


            double _speed = Convert.ToDouble(speed);
            int _id        = Convert.ToInt32(id);
            double _power = Convert.ToDouble(power);
            int _places    = Convert.ToInt32(places);


            switch (type)
            {
                case "lb3.Vehicles.Boat":
                    vehicles.Add(new Vehicles.Boat(_speed, name, _id, _power, _places));
                    break;
                case "lb3.Vehicles.Bus":
                    vehicles.Add(new Vehicles.Bus(_speed, name, _id, _power, _places));
                    break;
                case "lb3.Vehicles.Car":
                    vehicles.Add(new Vehicles.Car(_speed, name, _id, _power, _places));
                    break;
                case "lb3.Vehicles.Plane":
                    vehicles.Add(new Vehicles.Plane(_speed, name, _id, _power, _places));
                    break;
                case "lb3.Vehicles.Train":
                    vehicles.Add(new Vehicles.Train(_speed, name, _id, _power, _places));
                    break;
                default:
                    MessageBox.Show("Oops, smth out of order...");
                    break;
            }
        }

        private void btnSearchDeserializeFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog1.FileName;
                txtBoxDeserFile.Text = selectedFileName;
            }


            
        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //using (System.IO.StreamReader reader = new StreamReader(txtBoxDeserFile.Text))
                //{

                    string content = File.ReadAllText(txtBoxDeserFile.Text);
                    string[] objs = content.Split("\n");
                    
                    vehicles.Clear();

                    foreach (string obj in objs)
                    {
                        if (obj == "") continue;
                        string[] objSpec = obj.Split(" ");
                        createObjFromString(objSpec[0], objSpec[1], objSpec[2], objSpec[3], objSpec[4], objSpec[5]);
                    }


                    MessageBox.Show("Successfully read");
                    showVehicles();
                //}
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
    }
}
