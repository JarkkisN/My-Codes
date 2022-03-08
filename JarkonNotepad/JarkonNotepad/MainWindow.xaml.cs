using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;

// Olio-ohjelmointi
// Tehtävät 8.2. - 8.3.2022 (notepad)
// Jarkko Niemi - INTIP21A6
// 07.03.2022

namespace JarkonNotepad
{
    public partial class MainApp
    {
        private bool dataChanged = false;
        private string filePath = null;
        public MainApp()
        {
            this.InitializeComponent();
        }
        //
        // Kun "New" on valittu menusta
        //
        private void NewItem(object sender, RoutedEventArgs e)
        {
            ProcessNewCommand();
        }
        //
        // Kun "Open" on valittu menusta
        //
        private void OpenItem(object sender, RoutedEventArgs e)
        {
            ProcessOpenCommand();
        }
        //
        // Kun "Save" on valittu menusta
        //
        private void SaveItem(object sender, RoutedEventArgs e)
        {
            ProcessSaveCommand();
        }
        //
        // Kun "Save As" on valittu menusta
        //
        private void SaveAsItem(object sender, RoutedEventArgs e)
        {
            ShowSaveDialog();
        }
        //
        // Kun "Print" on valittu menusta
        //
        private void PrintItem(object sender, RoutedEventArgs e)
        {
            ProcessPrintCommand();
        }
        //
        // Kun "Exit" on valittu menusta
        //
        private void ExitItem(object sender, RoutedEventArgs e)
        {
            if (dataChanged)
            {
                SaveFirst();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        //
        // Kun "Font" on valittu menusta
        //
        private void FontItem(object sender, RoutedEventArgs e)
        {
            ProcessFontCommand();
        }
        //
        // Näytä "Open File" valintaikkuna
        //
        private void ShowOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All|*.*";
            //
            // Jos käyttäjä valitsee tiedoston ja painaa "OK"
            //
            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
                ReadFile(filePath);
                SetTitle(ofd.SafeFileName);
                dataChanged = false;
            }
        }
        //
        // Kun annetaan tiedostopolku, lue tiedot ja lataa ne tekstikenttään
        //
        private void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            StringBuilder sb = new StringBuilder();
            string r = reader.ReadLine();
            while (r != null)
            {
                sb.Append(r);
                sb.Append(Environment.NewLine);
                r = reader.ReadLine();
            }
            reader.Close();
            //
            // Tekstin lähettäminen tekstilaatikkoon
            //
            txtBoxContent.Text = sb.ToString();
        }
        //
        // Anna polku tiedostoon, kirjoita tekstilaatikon sisältö siihen
        //
        private void SaveFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.Write(txtBoxContent.Text);
            writer.Close();
            dataChanged = false;
        }
        //
        // Näytä "Save"-valintaikkuna määrittääksesi tiedoston tallennuspaikan
        //
        private void ShowSaveDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Document (.txt)|*.txt";
            bool? saveResult = sfd.ShowDialog();
            if (saveResult == true)
            {
                string s = sfd.FileName;
                filePath = s;
                SaveFile(s);
                SetTitle(sfd.SafeFileName);
            }
        }
        //
        // Varmista, että tallennat muutokset ennen kuin teet mitään, mikä saattaa muuttaa tekstilaatikon sisältöä tai sulkea ohjelman
        //
        private string SaveFirst()
        {
            MessageBoxResult mbr = MessageBox.Show("Do you want to save your changes first?", "Save File?", MessageBoxButton.YesNoCancel);
            if (mbr == MessageBoxResult.Yes)
            {
                if (filePath != null)
                {
                    SaveFile(filePath);
                }
                else
                {
                    ProcessSaveCommand();
                }
            }
            else if (mbr == MessageBoxResult.Cancel)
            {
                return "Cancel";
            }
            return "Nothing";
        }
        //
        // Poistaa kaikki tiedot näytöltä
        //
        private void ClearState()
        {
            filePath = null;
            dataChanged = false;
            txtBoxContent.Text = "";
            ResetTitle();
        }
        //
        // Selvitetään paras tapa tallentaa asiakirja
        //
        private void ProcessSaveCommand()
        {
            if (filePath == null)
            {
                ShowSaveDialog();
            }
            else
            {
                SaveFile(filePath);
            }
        }
        //
        // Selvitetään paras tapa luoda uusi asiakirja
        //
        private void ProcessNewCommand()
        {
            if (dataChanged)
            {
                string sf = SaveFirst();
                if (sf != "Cancel")
                {
                    ClearState();
                }
            }
            else
            {
                ClearState();
            }
        }
        //
        // Selvitetään paras tapa avata asiakirja
        //
        private void ProcessOpenCommand()
        {
            if (dataChanged)
            {
                SaveFirst();
                ShowOpenDialog();
            }
            else
            {
                ShowOpenDialog();
            }
        }
        //
        // Printataan asiakirja
        //
        private void ProcessPrintCommand()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(txtBoxContent, "This is working");
            }
        }
        //
        // Fontin muokkaaminen TODO
        //
        private void ProcessFontCommand()
        {
            FontWindow fontWindow = new FontWindow();
            fontWindow.Show();
        }
        public void ChangeFont(int scale)
        {
            txtBoxContent.FontSize = scale;
        }
        //
        // Tallennetaan asiakirja ennen sovelluksen sulkemista
        //
        private void AppClosing(object sender, CancelEventArgs e)
        {
            if (dataChanged)
            {
                SaveFirst();
            }
        }
        //
        // Aina kun näppäintä painetaan tekstikentän sisällä, se huomataan
        //
        private void ContentChanged(object sender, KeyEventArgs e)
        {
            dataChanged = true;
        }
        //
        // Tarkistetaan, onko sisältö muuttunut
        //
        private void FocusChanged(object sender, RoutedEventArgs e)
        {
            dataChanged = true;
        }
        //
        // Pikavalinnat Save, New, Open ja print
        //
        private void KeyCombinations(object sender, KeyEventArgs e)
        {
            // Ctrl + S
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S))
            {
                ProcessSaveCommand();
            }
            // Ctrl + N
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
            {
                ProcessNewCommand();
            }
            // Ctrl + O
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
            {
                ProcessOpenCommand();
            }
            // Ctrl + P
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.P))
            {
                ProcessPrintCommand();
            }
        }
        //
        // Muutetaan ikkunan otsikkoa niin, että se sisältää tiedoston nimen, kun se avataan tai tallennetaan
        //
        private void SetTitle(string newTitle)
        {
            Window.Title = "JarkonNotepad - " + newTitle;
        }
        //
        // Nollataan ikkunan otsikko
        //
        private void ResetTitle()
        {
            Window.Title = "JarkonNotepad";
        }
    }
}