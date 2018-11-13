namespace GtkSharpTestMultipleRowsSelected
{
    public class MainWindowController
    {
        public MainWindowController()
        {
            this.View = new MainWindowView();

            this.View.DeleteEvent += (o, evt) => this.OnQuit();
            this.View.BtCopy.Clicked += (o, evt) => this.OnCopy();

            this.Fill( this.View.TvSongsOrg );
        }

        void Fill(Gtk.TreeView treeView)
        {
            var list = (Gtk.ListStore)treeView.Model;

            list.AppendValues("Eagles", "Hotel California");
            list.AppendValues("AC/DC", "Highway to hell");
            list.AppendValues("Rainbow", "The man on the silver mountain");
            list.AppendValues("Ozzy Osbourne", "Miracle man");
            list.AppendValues("Guns'n'Roses", "Welcome to the jungle");
        }

        void OnQuit()
        {
            Gtk.Application.Quit();
        }

        void OnCopy()
        {
            int numColumns = this.View.TvSongsOrg.Columns.Length;
            var destList = (Gtk.ListStore) this.View.TvSongsDest.Model;
            var orgList = (Gtk.ListStore) this.View.TvSongsOrg.Model;
            Gtk.TreeSelection selected = this.View.TvSongsOrg.Selection;
            Gtk.TreePath[] rowPaths = selected.GetSelectedRows();
            string[] row = new string[ numColumns ];

            foreach(Gtk.TreePath rowPath in rowPaths) {
                for (int i = 0; i < numColumns; ++i) {
                    orgList.GetIter( out Gtk.TreeIter it, rowPath );
                    row[ i ] = (string) orgList.GetValue( it, i );
                }

                destList.AppendValues( row );
            }

            return;
        }

        public MainWindowView View {
            get; private set;
        }
    }
}
