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
using System.Windows.Shapes;

// Olio-ohjelmointi
// Tehtävät 8.2. - 8.3.2022 (notepad)
// Jarkko Niemi - INTIP21A6
// 07.03.2022
// Kiitos Saku Karttunen joka auttoi tämän FontWindowin tekemisessä

namespace JarkonNotepad
{
    public partial class FontWindow : Window
    {
        private string? SelectedFont { get; set; }
        public FontWindow()
        {
            InitializeComponent();
            Title = "Font formatting";

            int[] ArrayItems =
            {
                12, 14, 16, 18, 20, 24, 28, 32, 36, 40, 45, 50, 60
            };

            SampleList.ItemsSource = ArrayItems;
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            // Access pääikkunaan
            MainApp win = (MainApp)Application.Current.MainWindow;

            if (SampleList.SelectedValue != null)
            {
                SelectedFont = SampleList.SelectedValue.ToString();
                FontBox.Text = SelectedFont;
                SampleList.UnselectAll();
            }

            try
            {
                win.txtBoxContent.FontSize = Convert.ToDouble(FontBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n-Give the size in numbers");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
