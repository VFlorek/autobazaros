using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using autobazaros.Models;

namespace autobazaros.Data
{
    // Tahle třída se stará o ukládání do JSON souboru

    public class DataService
    {
        private string cestaKSlozce;
        private string cestaKSouboru;

        public DataService()
        {
            // Najdeme složku AppData
            cestaKSlozce = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Autobazaros");

            // Když složka neexistuje, vytvoří se
            Directory.CreateDirectory(cestaKSlozce);

            // Vytvoříme cestu k souboru
            cestaKSouboru = Path.Combine(cestaKSlozce, "cars.json");
        }

        // Načte auta ze souboru
        public List<Car> LoadCars()
        {
            // Když soubor neexistuje, vrátíme prázdný seznam
            if (!File.Exists(cestaKSouboru))
                return new List<Car>();

            string json = File.ReadAllText(cestaKSouboru);

            // Převede JSON zpět na objekty
            List<Car>? auta = JsonSerializer.Deserialize<List<Car>>(json);

            return auta ?? new List<Car>();
        }

        // Uloží auta do souboru
        public void SaveCars(List<Car> auta)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Převede objekty na JSON text
            string json = JsonSerializer.Serialize(auta, options);

            File.WriteAllText(cestaKSouboru, json);
        }
    }
}