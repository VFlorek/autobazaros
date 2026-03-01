using System.Windows;
using autobazaros.Models;

namespace autobazaros
{
    public partial class AddEditCarWindow : Window
    {
        // Tohle je auto které budeme upravovat
        public Car Car { get; set; }

        public AddEditCarWindow(Car? auto = null)
        {
            InitializeComponent();

            // Když je to nové auto, vytvoří se nové
            Car = auto ?? new Car();

            // Když upravujeme existující auto,
            // naplníme formulář hodnotama
            if (auto != null)
            {
                JmenoBox.Text = Car.Jmeno;
                PrijmeniBox.Text = Car.Prijmeni;
                ZnackaBox.Text = Car.Znacka;
                ModelBox.Text = Car.Model;
                SPZBox.Text = Car.SPZ;
                NajetoBox.Text = Car.Najeto.ToString();
                BarvaBox.Text = Car.Barva;
                MotorBox.Text = Car.TypMotoru;
                RokBox.Text = Car.RokVyroby.ToString();
                AdresaBox.Text = Car.Adresa;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Zkontrolujeme že čísla jsou opravdu čísla
            if (!int.TryParse(NajetoBox.Text, out int najeto) ||
                !int.TryParse(RokBox.Text, out int rok))
            {
                MessageBox.Show("Najeto a rok musí být číslo!");
                return;
            }

            // Uložíme hodnoty z formuláře do objektu
            Car.Jmeno = JmenoBox.Text;
            Car.Prijmeni = PrijmeniBox.Text;
            Car.Znacka = ZnackaBox.Text;
            Car.Model = ModelBox.Text;
            Car.SPZ = SPZBox.Text;
            Car.Najeto = najeto;
            Car.Barva = BarvaBox.Text;
            Car.TypMotoru = MotorBox.Text;
            Car.RokVyroby = rok;
            Car.Adresa = AdresaBox.Text;

            DialogResult = true;
            Close();
        }
    }
}