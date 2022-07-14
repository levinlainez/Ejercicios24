using Ejercicio24.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio24.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayVideo : ContentPage
    {
        public PlayVideo(VideoModel video)
        {
            InitializeComponent();
             reproducirVideo(video);
    }
        private void reproducirVideo(VideoModel video)
        {
            lbldescripcion.Text = video.descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = video.ruta
            };
            videoPlayer2.Source = uriVideoSurce;
        }
    }
}