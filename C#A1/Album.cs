using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A1
{
    internal class Album(string albumName, string artistName, int numOfTracks) //---Works very much like the Pet-class.
    {
        private readonly string AlbumName = albumName;
        private readonly string ArtistName = artistName;
        private readonly int NumOfTracks = numOfTracks;

        public string GetPrintFormatAlbum() //---Returns a formatted string of data associated with the specific instance of Album
        {
            return $"Album Title: {AlbumName}\nArtist Name: {ArtistName}\nNumber of Tracks: {NumOfTracks}";
        }

        public string GetAlbumTitle() //---Returns AlbumName for the specific instance of Album
        {
            return AlbumName;
        }
    }
}
