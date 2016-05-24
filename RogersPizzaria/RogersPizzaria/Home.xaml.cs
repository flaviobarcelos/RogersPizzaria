using Plugin.Connectivity;
using System;
using Xamarin.Forms;

namespace RogersPizzaria
{
    public partial class Home : ContentPage
    {

        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //chama o plugin do xamarin que verifica se tem internet
            bool isConnected = CrossConnectivity.Current.IsConnected;

            //se nao tiver conexao exibe mensagem avisando que nao tem internet
            if (!isConnected)
            {
                var beachImage = new Image { Aspect = Aspect.AspectFit };
                beachImage.Source = Device.OnPlatform(
                    iOS: ImageSource.FromFile("Images/sem_internet.jpg"),
                    Android: ImageSource.FromFile("sem_internet.jpg"),
                    WinPhone: ImageSource.FromFile("Images/sem_internet.jpg")
                );
                                
                Button button = new Button
                {
                    Text = "Atualizar",
                    Font = Font.SystemFontOfSize(NamedSize.Large),
                    BorderWidth = 1,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                button.Clicked += Refresh;
                
                this.Content = new StackLayout
                {
                    Children =
                    {
                        beachImage,
                        button
                    },
                    //BackgroundColor = Color.FromHex("#FFFFFF")
                    BackgroundColor = Color.FromRgb(239,240,242)
                };
            }
            //se tiver internet carrega a pagina
            else
            {
                WebView MywebView = new WebView();
                MywebView.Source = "http://www.rogerspizzaria.com.br/app";
                Content = MywebView;
            }
        }

        public async void Refresh(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}
