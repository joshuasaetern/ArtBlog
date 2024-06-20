using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArtBlog
{
    //Joshua Saetern
    //Computer Programming II
    //06.12.2024
    //Final - Art Blog - S24
    public partial class MainWindow : Window
    {
        //Instance of data class
        Data data = new Data();

        public MainWindow()
        {
            InitializeComponent();

            listViewDisplay.ItemsSource = Data.ArtPieces;
        }
        private void listViewDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //turn listbox into a object we can use
            ArtPiece piece = listViewDisplay.SelectedItem as ArtPiece;

            //change values to paragraph
            Paragraph date =  new Paragraph(new Run(piece.Date.ToString()));
            Paragraph name = new Paragraph(new Run(piece.Name));
            Paragraph artist = new Paragraph(new Run(piece.Artist));
            Paragraph body = new Paragraph(new Run(piece.Body));

            //display values using FormattedPost
            richTextBoxDisplay.Document = piece.FormattedPost(date, name, artist, body);

            imageDisplay.Source = piece.GenerateBitMap(piece.FilePath);
        }

        private void btnOpenAddArtPiece_Click(object sender, RoutedEventArgs e)
        {
            //Create object so we can access our other window
            AddArtPiece addArtPiece = new AddArtPiece();

            //Opens other window
            addArtPiece.Show();
        }
    }
}