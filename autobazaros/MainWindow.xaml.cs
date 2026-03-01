using System.Collections.ObjectModel;
using System.Windows;
using autobazaros.Models;
using autobazaros.Data;

namespace autobazaros
{
    public partial class MainWindow : Window
    {
        // Seznam všech aut
        private ObservableCollection<Car> auta;

        // Třída co ukládá data
        private DataService dataService = new DataService();

        public MainWindow()
        {
            InitializeComponent();

            // Načteme auta ze souboru
            auta = new ObservableCollection<Car>(dataService.LoadCars());

            // Napojíme seznam na ListBox
            CarsGrid.ItemsSource = auta;
        }

        // Přidání auta
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditCarWindow okno = new AddEditCarWindow();

            if (okno.ShowDialog() == true)
            {
                auta.Add(okno.Car);

                // Uložíme změny
                dataService.SaveCars(new System.Collections.Generic.List<Car>(auta));
            }
        }

        // Úprava auta
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CarsGrid.SelectedItem is Car vybraneAuto)
            {
                AddEditCarWindow okno = new AddEditCarWindow(vybraneAuto);

                if (okno.ShowDialog() == true)
                {
                    dataService.SaveCars(new System.Collections.Generic.List<Car>(auta));
                }
            }
        }

        // Smazání auta
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CarsGrid.SelectedItem is Car vybraneAuto)
            {
                var odpoved = MessageBox.Show(
                    "Opravdu chceš smazat toto auto?",
                    "Potvrzení",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (odpoved == MessageBoxResult.Yes)
                {
                    auta.Remove(vybraneAuto);

                    dataService.SaveCars(new System.Collections.Generic.List<Car>(auta));
                }
            }
        }
    }
}