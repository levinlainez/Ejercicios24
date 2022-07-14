using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio24.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarVideo : ContentPage
    {
        models.VideoModel video;
        public MostrarVideo()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaVideos.ItemsSource = await App.BaseDatosObject.ObtenerVideos();
        }

        private async void listaVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            video = (models.VideoModel)e.Item;

            await Navigation.PushAsync(new PlayVideo(this.video));
        }
    }
}