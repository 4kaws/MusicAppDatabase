using System.Windows.Forms;

namespace dbMUSICAPPsql
{
    public partial class Form1 : Form
    {

        BindingSource albumBindingSource = new BindingSource();
        BindingSource tracksBindingSource = new BindingSource();

        List<Album> albums = new List<Album>();
        List<Track> tracks = new List<Track>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AlbumsDAO albumsDAO = new AlbumsDAO();
            

            //connect the list to the grid view control

            albums = albumsDAO.GetAllAlbums();
            albumBindingSource.DataSource = albums;
            tracksBindingSource.DataSource = tracks;

            dataGridView1.DataSource = albumBindingSource;
            dataGridView2.DataSource = tracksBindingSource;

            pictureBox1.Load("https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Dark_Side_of_the_Moon.png/220px-Dark_Side_of_the_Moon.png");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();

            //connect the list to the grid view control
            albumBindingSource.DataSource = albumsDAO.searchTitles(textBox1.Text);

            dataGridView1.DataSource = albumBindingSource;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            //get the row number clicked

            int rowClicked = dataGridView.CurrentRow.Index;
            //MessageBox.Show("You clicked row " + rowClicked);

            String imageURL = dataGridView.Rows[rowClicked].Cells[4].Value.ToString();
            //MessageBox.Show("URL= " + imageURL);
            pictureBox1.Load(imageURL);



            tracksBindingSource.DataSource = albums[rowClicked].Tracks;

            dataGridView2.DataSource = tracksBindingSource;

        }


        private void Add_Click(object sender, EventArgs e)
        {
            //add a new item to database
            Album album = new Album
            {
                AlbumName = txt_albumName.Text,
                ArtistName = txt_albumArtist.Text,
                Year = Int32.Parse(txt_year.Text),
                ImageURL = txt_imageURL.Text,
                Description = txt_description.Text,
            };

            AlbumsDAO albumsDAO = new AlbumsDAO();
            int result = albumsDAO.addOneAlbum(album);
            MessageBox.Show(result + "new row(s) inserted");

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            //get the row number clicked

            int rowClicked = dataGridView.CurrentRow.Index;
            //MessageBox.Show("You clicked row " + rowClicked);

            String videoURL = dataGridView.Rows[rowClicked].Cells[3].Value.ToString();
            //MessageBox.Show("URL= " + imageURL);
            webView21.Source = new Uri(videoURL);

        }



        private void button3_Click(object sender, EventArgs e)
        {
            //get the row number clicked

            int rowClicked = dataGridView2.CurrentRow.Index;
            //MessageBox.Show("You clicked row " + rowClicked);
            int trackID = (int) dataGridView2.Rows[rowClicked].Cells[0].Value;

            AlbumsDAO albumsDao = new AlbumsDAO();

            int result = albumsDao.deleteTrack(trackID);

            MessageBox.Show("Result" + result);

            dataGridView2.DataSource = null;
            albums = albumsDao.GetAllAlbums();
        }

    }
}