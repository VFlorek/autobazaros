using System.ComponentModel;

namespace autobazaros.Models
{
    // Tohle je jedna třída která představuje jedno auto
    // Každé auto má svoje údaje

    public class Car : INotifyPropertyChanged
    {
        // Tohle říká WPF že když se něco změní
        // má se aktualizovat obrazovka
        public event PropertyChangedEventHandler? PropertyChanged;

        // Všechny proměnné auta

        private string jmeno = "";
        public string Jmeno
        {
            get { return jmeno; }
            set
            {
                jmeno = value;
                OnPropertyChanged(nameof(Jmeno)); // řekne že se to změnilo
            }
        }

        private string prijmeni = "";
        public string Prijmeni
        {
            get { return prijmeni; }
            set
            {
                prijmeni = value;
                OnPropertyChanged(nameof(Prijmeni));
            }
        }

        private string znacka = "";
        public string Znacka
        {
            get { return znacka; }
            set
            {
                znacka = value;
                OnPropertyChanged(nameof(Znacka));
            }
        }

        private string model = "";
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private string spz = "";
        public string SPZ
        {
            get { return spz; }
            set
            {
                spz = value;
                OnPropertyChanged(nameof(SPZ));
            }
        }

        private int najeto;
        public int Najeto
        {
            get { return najeto; }
            set
            {
                najeto = value;
                OnPropertyChanged(nameof(Najeto));
            }
        }

        private string barva = "";
        public string Barva
        {
            get { return barva; }
            set
            {
                barva = value;
                OnPropertyChanged(nameof(Barva));
            }
        }

        private string typMotoru = "";
        public string TypMotoru
        {
            get { return typMotoru; }
            set
            {
                typMotoru = value;
                OnPropertyChanged(nameof(TypMotoru));
            }
        }

        private int rokVyroby;
        public int RokVyroby
        {
            get { return rokVyroby; }
            set
            {
                rokVyroby = value;
                OnPropertyChanged(nameof(RokVyroby));
            }
        }

        private string adresa = "";
        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }

        // Tohle jen řekne aplikaci že se něco změnilo
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}