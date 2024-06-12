using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArtBlog
{
    internal class Data
    {
        //Fields
        static ObservableCollection<ArtPiece> artPieces;

        //Constructors
        static Data()
        {
            artPieces = new ObservableCollection<ArtPiece>();
        }

        //Properties
        internal static ObservableCollection<ArtPiece> ArtPieces { get => artPieces; }

        //Methods
        public void AddArtPiece(ArtPiece artPiece)
        {
            artPieces.Add(artPiece);
        }
    }
}
