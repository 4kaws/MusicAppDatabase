using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dbMUSICAPPsql
{
    internal class Album
    {
        public int ID { get; set; }
        public String AlbumName { get; set; }
        public String ArtistName { get; set; }
        public int Year { get; set; }
        public String ImageURL { get; set; }
        public String VideoURL { get; set; }
        public String Description { get; set; }

        //later make a List<Track> songs
        public List<Track> Tracks { get; set; }


    }
}
