

using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;

namespace MauiApp2;

public partial class NewPage1 : ContentPage
{
    async void SaveMauiAsset()
    {
        try
        {
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

            File.WriteAllLines($"{docsDirectory.AbsoluteFile.Path}/adat.txt", list);
        }
        catch (Exception ex)
        {
            DisplayAlert("Title", ex.Message, "Cancel");
        }
    }
    async void LoadMauiAsset()
    {
        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

        string[] data = File.ReadAllLines($"{docsDirectory.AbsoluteFile.Path}/adat.txt");
        for (int i = 0; i < data.Length; i++)
        {
            list.Add(data[i]);
        }
    }
    ObservableCollection<string> list = new ObservableCollection<string>();

    public NewPage1()
    {
        InitializeComponent();
        LSzam.Text = MainPage.Count.ToString();
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    private async void BtnFelvitel_Clicked(object sender, EventArgs e)
    {
        list.Add(EtrBe.Text);
        LwAdatok.ItemsSource = list;

    }
    private async void BtnMent_Clicked(object sender, EventArgs e)
    {
        SaveMauiAsset();
    }
    private async void BtnBetolt_Clicked(object sender, EventArgs e)
    {
        LoadMauiAsset();
        LwAdatok.ItemsSource = list;
    }
    private async void BtnKijeloltTorol_Clicked(object sender, EventArgs e)
    {
        string torolhetoitem = LwAdatok.SelectedItem.ToString();
        list.Remove(torolhetoitem);
        LwAdatok.ItemsSource = list;
    }
    private async void BtnTeljesTorol_Clicked(object sender, EventArgs e)
    {
        list.Clear();
        LwAdatok.ItemsSource = list;
    }
    private async void BtnBeszur_Clicked(object sender, EventArgs e)
    {
        string kivalitem = LwAdatok.SelectedItem.ToString();
        int poz = list.IndexOf(kivalitem);
        list.Insert(poz, EtrBe.Text);
        LwAdatok.ItemsSource = list;
    }
    private async void BtnRendez_Clicked(object sender, EventArgs e)
    {
        list.OrderDescending();
        LwAdatok.ItemsSource = list;
    }
}