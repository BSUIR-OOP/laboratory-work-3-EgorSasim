using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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
            cmbBoxSelectVehicle.Items.Add(new Boat());
            cmbBoxSelectVehicle.Items.Add(new Bus());
            cmbBoxSelectVehicle.Items.Add(new Car());
            cmbBoxSelectVehicle.Items.Add(new Plane());
            cmbBoxSelectVehicle.Items.Add(new Train());
        }



        /*public enum vehType
        {
            NOT_CHOOSEN = -1
            ,BOAT = 0
            ,BUS
            ,CAR
            ,PLANE
            ,TRAIN
            ,VEH_END
        };
        */



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

                    Type t = Type.GetType(cmbBoxSelectVehicle.SelectedItem.ToString());
                    Transport transport = (Transport)Activator.CreateInstance(t, speed, name, id, power, places);
                    vehicles.Add(transport);


                    /* switch (cmbBoxSelectVehicle.SelectedIndex)
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
                     } */



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
            double _speed, _power;
            int _id, _places;
            
            _speed = Convert.ToDouble(speed);
            _id = Convert.ToInt32(id);
            _power = Convert.ToDouble(power);
            _places = Convert.ToInt32(places);

            Type t = Type.GetType(type);
            Transport transport = (Transport)Activator.CreateInstance(t, _speed, name, _id, _power, _places);
            vehicles.Add(transport);

          /*  switch (type)
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
            } */
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

        private void btnRmSelected_Click(object sender, RoutedEventArgs e)
        {
            int selected_index = lstBoxVehicles.SelectedIndex;
            if(selected_index == -1)
            {
                MessageBox.Show("Please, choose the element to remove");
                return;
            }
            vehicles.RemoveAt(selected_index);
            showVehicles();
        }

        private void btnChngSelected_Click(object sender, RoutedEventArgs e)
        {

            int selected_index = lstBoxVehicles.SelectedIndex;
            if (selected_index == -1)
            {
                MessageBox.Show("Please, choose the element to change");
                return;
            }

            

            var el = vehicles.ElementAt(selected_index);
            foreach (var t in cmbBoxSelectVehicle.Items)
                if (t.ToString().Equals(el.ToString()))
                {
                    cmbBoxSelectVehicle.SelectedItem = t;
                    break;
                }
          /*  switch (el.ToString())
            {
                case "lb3.Vehicles.Boat":
                    cmbBoxSelectVehicle.SelectedIndex = (int)vehType.BOAT;
                    break;
                case "lb3.Vehicles.Bus":
                    cmbBoxSelectVehicle.SelectedIndex = (int)vehType.BUS;
                    break;
                case "lb3.Vehicles.Car":
                    cmbBoxSelectVehicle.SelectedIndex = (int)vehType.CAR;
                    break;
                case "lb3.Vehicles.Plane":
                    cmbBoxSelectVehicle.SelectedIndex = (int)vehType.PLANE;
                    break;
                case "lb3.Vehicles.Train":
                    cmbBoxSelectVehicle.SelectedIndex = (int)vehType.TRAIN;
                    break;
                default:
                    MessageBox.Show("Oops, smth out of order...");
                    break;
            } */
            vehSpeed.Text = el.speed.ToString();
            vehName.Text  = el.name;
            vehId.Text    = el.id.ToString();
            vehPower.Text = el.power.ToString();
            vehPlaces.Text = el.places.ToString();

            vehicles.RemoveAt(selected_index);
        }
    }
}
