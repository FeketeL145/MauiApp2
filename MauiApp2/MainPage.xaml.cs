namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        static int count = 0;

        public static int Count { get => count; set => count = value; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)

        {
            Count++;

            if (Count == 1)
                CounterBtn.Text = $"Clicked {Count} timer";
            else
                CounterBtn.Text = $"Clicked {Count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void NewPageBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("P123");
        }
        private async void GoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("P123");
        }
    }

}
