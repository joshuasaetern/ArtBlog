using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Printing;
using System.Windows.Media;
using System.Windows.Controls;

namespace ArtBlog
{
    //Enumerable for different styles
    public enum Style { Impressionism, Expressionism, Contemporary, Realism }
    internal class ArtPiece
    {
        //Fields
        int date;
        String name;
        String artist;
        String body;
        String filePath;
        BitmapImage art;
        Style artStyle;

        //Constructors
        public ArtPiece(int date, String name, String artist, String body, String filepath, Style artStyle)
        {
            this.date = date;
            this.name = name;
            this.artist = artist;
            this.body = body;
            this.filePath = filepath;
            this.art = GenerateBitMap(filepath);
            this.artStyle = artStyle;
        }
        //Properties
        public int Date { get => date; set => date = value; }
        public string Name { get => name; set => name = value; }
        public string Artist { get => artist; set => artist = value; }
        public string Body { get => body; set => body = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public BitmapImage Art { get => art; set => art = value; }
        public Style ArtStyle { get => artStyle; set => artStyle = value; }

        //Methods
        public BitmapImage GenerateBitMap(String filePath) //Generates Bitmap Image
        {
            String imgPath = @filePath;

            //Uniform Resource Identifier
            Uri convertPath = new Uri(imgPath);
            BitmapImage bitmap = new BitmapImage(convertPath);

            return bitmap;
        }
        public FlowDocument FormattedPost(Paragraph date, Paragraph header, Paragraph artist, Paragraph body) //Displays fully formatted post to RichTextBox
        {
            FlowDocument post = new FlowDocument(); 

            //Changes all FontFamilies
            post.FontFamily = new FontFamily("Cascadia Code");

            //Adds all blocks to post
            post.Blocks.Add(DateFormatted(date));
            post.Blocks.Add(HeaderFormatted(header));
            post.Blocks.Add(ArtistFormatted(artist));
            post.Blocks.Add(BodyFormatted(body));

            //Returns finished post
            return post;
        }
        private Paragraph DateFormatted(Paragraph date) //Formats Date Year
        {
            date.FontSize = 10;
            date.FontWeight = FontWeights.Bold;
            return date;
        }
        private Paragraph HeaderFormatted(Paragraph header) //Format Header
        {
            header.FontSize = 18;
            header.FontWeight = FontWeights.Bold;
            return header;
        }
        private Paragraph ArtistFormatted(Paragraph artist) //Format Artist
        {
            artist.FontSize = 14;
            artist.FontStyle = FontStyles.Italic;
            return artist;
        }
        private Paragraph BodyFormatted(Paragraph body) //Format Body
        {
            body.FontSize = 12;
            return body;
        }
    }
}
