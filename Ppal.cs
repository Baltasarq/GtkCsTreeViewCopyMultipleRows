namespace GtkSharpTestMultipleRowsSelected
{
    public class Ppal
    {
        [System.STAThread]
        public static void Main()
        {
            Gtk.Application.Init();
            new MainWindowController();
            Gtk.Application.Run();
        }
    }
}
