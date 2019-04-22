using LoadingAssistanceSample.Business.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoadingAssistanceSample.UI.StartPage
{
    public class StartPageVM : BaseViewModel
    {
        #region Fields
        private LoadingAssist.LoadingAssistancePage _assistancePage;
        private INavigation _navigation;
        #endregion

        #region Propertys

        #endregion

        #region Commands
        public ICommand CmdStartLoadingAssist
        {
            get
            {
                return new Command(async () =>
                {
                    _assistancePage = new LoadingAssist.LoadingAssistancePage();
                    await _navigation.PushAsync(_assistancePage);
                });
            }
        }
        #endregion

        public StartPageVM(INavigation navigation)
        {
            _navigation = navigation;
        }

        #region Methods

        #endregion
    }
}
