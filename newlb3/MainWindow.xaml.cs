using lb3;
using lb3.Vehicles;
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

namespace newlb3
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

        List<Transport> vehicles = new List<Transport>();


        public void showVehicles()
        {
            lstBoxVehicles.Items.Clear();
            foreach (var item in vehicles)
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
            if (Checks.checkEmpty(vehSpeed.Text, vehName.Text, vehId.Text, vehPower.Text, vehPlaces.Text))
            {
                if (Checks.ValidSpec(vehSpeed.Text, vehName.Text, vehId.Text, vehPower.Text, vehPlaces.Text))
                {
                    id = Convert.ToInt32(vehId.Text);
                    places = Convert.ToInt32(vehPlaces.Text);
                    power = Convert.ToDouble(vehPower.Text);
                    speed = Convert.ToDouble(vehSpeed.Text);
                    name = vehName.Text;

                    Type t = Type.GetType(cmbBoxSelectVehicle.SelectedItem.ToString());
                    Transport transport = (Transport)Activator.CreateInstance(t, speed, name, id, power, places);
                    vehicles.Add(transport);


                    showVehicles();
                }
                else
                {
                    MessageBox.Show("Not valid values, please do smth about it)");
                }
            }
            else
            {
                MessageBox.Show("An empty fields detected!!!");
            }

        }
    }
}
