using Microsoft.Win32;
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

namespace ArtBlog
{
    /// <summary>
    /// Interaction logic for AddArtPiece.xaml
    /// </summary>
    public partial class AddArtPiece : Window
    {
        //Instance of data class
        Data data = new Data();

        //Create object so we can access our other window
        MainWindow mainWindow = new MainWindow();

        public AddArtPiece()
        {
            InitializeComponent();

            //Adds years 2024-2000 to comboBoxYears
            List<int> years = new List<int>();
            for (int k = 2024; k > 1999; k--)
            {
                years.Add(k);
            }
            comboBoxYears.ItemsSource = years;
            comboBoxYears.SelectedIndex = 0;



            radioImpressionism.IsChecked = true;
        }

        private void btnAddToCollection_Click(object sender, RoutedEventArgs e)
        {
            if (CheckStatus()) //Runs if all boxes are properly filled
            {
                int date = (int)comboBoxYears.SelectedValue;
                String name = txtBoxArtName.Text;
                String artist = txtBoxArtistName.Text;
                String body = runBody.Text;
                String filepath = txtBoxImagePicker.Text;
                Style style = getRadioButton();
                data.AddArtPiece(new ArtPiece(date, name, artist, body, filepath, style));
                mainWindow.listViewDisplay.Items.Refresh();
            }
        }

        public bool CheckStatus() //Makes sure that all boxes are filled
        {
            if (String.IsNullOrWhiteSpace(txtBoxArtName.Text))
            {
                MessageBox.Show("Please enter an Art Name");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtBoxArtistName.Text))
            {
                MessageBox.Show("Please enter an Artist Name");
                return false;
            }
            if (String.IsNullOrWhiteSpace(runBody.Text))
            {
                MessageBox.Show("Please enter a body paragraph");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtBoxImagePicker.Text))
            {
                MessageBox.Show("Please select an image");
                return false;
            }
            return true;
        }

        private void btnImagePicker_Click(object sender, RoutedEventArgs e)
        {
            //Step 1
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Filter
            //What is displayed in drop down box
            String displayFilter = "Image files (*.png;*.jpeg;*.jpg;)";
            //Filter results in file explorer
            String filterBy = "*.png;*.jpeg;*.jpg;";
            //Full string which uses pipe to seperate display and filter
            String fullFilter = $"{displayFilter}|{filterBy}";

            openFileDialog.Filter = fullFilter;

            //Opens dialog and returns true if image is selected
            if (openFileDialog.ShowDialog() == true)
            {
                String returnedFiledPath = openFileDialog.FileName;
                txtBoxImagePicker.Text = returnedFiledPath;
            }
        }
        public Style getRadioButton() //Returns selected radio button
        {
            if (radioContemporary.IsChecked == true)
            {
                return ArtBlog.Style.Impressionism;
            }
            if (radioExpressionism.IsChecked == true)
            {
                return ArtBlog.Style.Expressionism;
            }
            if (radioImpressionism.IsChecked == true)
            {
                return ArtBlog.Style.Impressionism;
            }
            return ArtBlog.Style.Realism;
        }

        private void btnOpenMainWindow_Click(object sender, RoutedEventArgs e)
        {
            //Opens other window
            mainWindow.Show();
        }
    }
}
