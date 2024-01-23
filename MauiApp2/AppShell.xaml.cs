namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("P123", typeof(NewPage1));
            Routing.RegisterRoute("Home", typeof(MainPage));
        }
    }
}
