namespace GtkSharpTestMultipleRowsSelected
{
    public class MainWindowView: Gtk.Window
    {
        public MainWindowView()
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            this.SetGeometryHints( this,
                                  new Gdk.Geometry { MinWidth = 600, MinHeight = 400 },
                                  Gdk.WindowHints.MinSize );
            this.ShowAll();
        }

        Gtk.TreeView BuildTreeViewOrg()
        {
            var toret = new Gtk.TreeView();
            var artistColumn = new Gtk.TreeViewColumn { Title = "Artist" };
            var songColumn = new Gtk.TreeViewColumn { Title = "Song title" };
         
            // Add the columns to the TreeView
            toret.AppendColumn(artistColumn);
            toret.AppendColumn(songColumn);

            // Create a model that will hold two strings - Artist Name and Song Title
            var musicListStore = new Gtk.ListStore( typeof(string), typeof(string) );
            var artistNameCell = new Gtk.CellRendererText();
            var songTitleCell = new Gtk.CellRendererText();

            artistColumn.PackStart( artistNameCell, true );
            songColumn.PackStart( songTitleCell, true );

            artistColumn.AddAttribute( artistNameCell, "text", 0 );
            songColumn.AddAttribute( songTitleCell, "text", 1 );

            toret.Model = musicListStore;
            toret.Selection.Mode = Gtk.SelectionMode.Multiple;

            return toret;
        }

        Gtk.TreeView BuildTreeViewDest()
        {
            var toret = new Gtk.TreeView();
            var artistColumn = new Gtk.TreeViewColumn { Title = "Selected artist" };
            var songColumn = new Gtk.TreeViewColumn { Title = "Selected song title" };

            // Add the columns to the TreeView
            toret.AppendColumn( artistColumn );
            toret.AppendColumn( songColumn );

            // Create a model that will hold two strings - Artist Name and Song Title
            var musicListStore = new Gtk.ListStore(typeof(string), typeof(string));
            var artistNameCell = new Gtk.CellRendererText();
            var songTitleCell = new Gtk.CellRendererText();

            artistColumn.PackStart( artistNameCell, true );
            songColumn.PackStart( songTitleCell, true );

            artistColumn.AddAttribute( artistNameCell, "text", 0 );
            songColumn.AddAttribute( songTitleCell, "text", 1 );

            toret.Selection.Mode = Gtk.SelectionMode.None;
            toret.Model = musicListStore;
            toret.Selection.Mode = Gtk.SelectionMode.Multiple;

            return toret;
        }

        void Build()
        {
            var vBox = new Gtk.VBox( false, 10 );

            this.BtCopy = new Gtk.Button( "Copy" );
            this.TvSongsOrg = this.BuildTreeViewOrg();
            this.TvSongsDest = this.BuildTreeViewDest();

            vBox.PackStart( this.TvSongsOrg, true, true, 5 );
            vBox.PackStart( this.BtCopy, true, false, 5 );
            vBox.PackStart( this.TvSongsDest, true, true, 5 );

            this.Add( vBox );
        }

        public Gtk.TreeView TvSongsOrg {
            get; private set;
        }

        public Gtk.TreeView TvSongsDest {
            get; private set;
        }

        public Gtk.Button BtCopy {
            get; private set;
        }
    }
}
