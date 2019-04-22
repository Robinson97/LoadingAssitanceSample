using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace LoadingAssistanceSample.UI.LoadingAssist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingAssistancePage : ContentPage
    {
        //public LoadingAssistancePage()
        //{
        //    InitializeComponent();
        //    BindingContext = new LoadingAssistancePageVM();
        //}
        //public ICommand PlayingCommand { get; private set; }
        //public ICommand FinishedCommand { get; private set; }
        //public ICommand ClickedCommand { get; private set; }



        public ICommand PlayingCommand { get; private set; }
        public ICommand FinishedCommand { get; private set; }
        public ICommand ClickedCommand { get; private set; }

        public LoadingAssistancePage()
        {
            PlayingCommand = new Command(_ =>
                DisplayAlert($"{nameof(animationView.PlaybackStartedCommand)} executed!"));

            FinishedCommand = new Command(_ =>
                DisplayAlert($"{nameof(animationView.PlaybackFinishedCommand)} executed!"));

            ClickedCommand = new Command(_ =>
                 DisplayAlert($"{nameof(animationView.ClickedCommand)} executed!"));

            InitializeComponent();

            playButton.Clicked += (sender, e) => animationView.Play();
            playSegmentsButton.Clicked += (sender, e) => animationView.PlayProgressSegment(0.65f, 0.0f);
            playFramesButton.Clicked += (sender, e) => animationView.PlayFrameSegment(50, 1);
            pauseButton.Clicked += (sender, e) => animationView.Pause();

            BindingContext = this;
            var anime = animationView.ImageAssetsFolder;
            var b = animationView.IsVisible;
           
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            animationView.Progress = (float)e.NewValue;
        }

        private void Handle_OnFinish(object sender, System.EventArgs e)
        {
            DisplayAlert($"{nameof(animationView.OnFinish)} invoked!");
        }

        private void DisplayAlert(string message)
        {
            DisplayAlert(string.Empty, message, "OK");
        }
    }
}
