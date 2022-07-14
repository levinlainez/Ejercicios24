using System;
using System.IO;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio24.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoView : ContentPage
    {

        public string RutaVideo;
        public PhotoView()
        {
            InitializeComponent();
        }

        private async void btnGrabar_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                return; 
            }

            GuardarVideos();

        }
        public async void GuardarVideos()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {RutaVideo}");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = RutaVideo
                };

                videoPlayer.Source = uriVideoSurce;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

      
        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(descripcion.Text))
            {
                await DisplayAlert("Alerta", "Falta agregar una descripcion", "OK");
                descripcion.Focus();
            }
            else
            {
                var videos = new models.VideoModel
                {
                    ruta = RutaVideo,
                    descripcion = descripcion.Text
                };

                var resultado = await App.BaseDatosObject.GuardarVideos(videos);

                if (resultado == 1)
                {
                    await DisplayAlert("", "Se guardo exitosomente.", "OK");
                    limpiar();
                }
                else
                {
                    await DisplayAlert("Error", "Error al guardar", "OK");
                }
            }

        }

        public void limpiar()
        {
            descripcion.Text = "";
            videoPlayer.Source = null;

        }

        private async void btnlistarvideo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarVideo());
        }
    }
}