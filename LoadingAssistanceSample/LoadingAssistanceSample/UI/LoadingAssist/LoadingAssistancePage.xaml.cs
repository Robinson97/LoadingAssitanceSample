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
        public LoadingAssistancePage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = new LoadingAssistancePageVM();    
        }
    }
}
