using LoadingAssistanceSample.Business.Base;
using LoadingAssistanceSample.Business.TaskManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoadingAssistanceSample.UI.LoadingAssist
{
    public class LoadingAssistancePageVM : BaseViewModel
    {
        #region Fields
        private string _loadingTextValue;
        private string _animationSource;   
        #endregion


        #region Propertys
        /// <summary>
        /// Zielseite
        /// </summary>
        public ContentPage TargetPage { get; set; }


        /// <summary>
        /// Text, which will shown during the loading session
        /// </summary>
        public string LoadingTextValue
        {
            get => _loadingTextValue;
            set
            {
                _loadingTextValue = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Asset Source for the Animation JSON File
        /// </summary>
        public string AnimationSource
        {
            get => _animationSource;          
            set
            {
                _animationSource = value;
                NotifyPropertyChanged();
            }
        }

        public List<TaskResult> TaskResults { get; set; }

        public TaskCollection<Task<object>> TaskCollection { get; set; }
        #endregion

        #region Command
        /// <summary>
        /// 
        /// </summary>
        public ICommand PageAppearingCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (TaskCollection.Count > 0)
                    {
                        TaskCollection.Clear();
                    }

                    CreateTmpData();
                    RunParamTasksAsync(TaskCollection);
                });

            }
        }

        public ICommand PageDisappearingCommand
        {
            get
            {
                return new Command(() =>
                {
                    
                });
            }
        }
        #endregion

        public LoadingAssistancePageVM()
        {
            LoadingTextValue = "Bitte warten...";
            AnimationSource = "data.json";
            TaskCollection = new Collection<Task<object>>();
            TaskResults = new List<TaskResult>();
        }

        public async void RunParamTasksAsync(IEnumerable<Task<object>> paramTaks)
        {
            //Zwei Möglichkeiten
            // -> Nur Tasks die einen Rückgabewert haben
            // -> Zwei Listen für Tasks mit und ohne eine ohne Rückgabewert
            TaskManager taskManager = new TaskManager();
            await taskManager.RunTaskAsync(paramTaks);
            TaskResults = taskManager.TaskResults;
            await Application.Current.MainPage.Navigation.PopAsync();
            List<Task<object>> objList = new List<Task<object>>(paramTaks);
            objList.ForEach(x => Console.WriteLine(x.Result));
        }

       

        /// <summary>
        /// Erstellt Testdaten
        /// </summary>
        private void CreateTmpData()
        {
            Task<object> calc = CalculateASimpleTaskAsync();
            Task<object> webHTML = GetHTMLFromWebside();
            Task<bool> refferentError = ThrowAnError();
            TaskCollection.Add(calc);
            TaskCollection.Add(webHTML);
            TaskCollection.Add(refferentError);
        }

        #region testTasks
        public async Task<object> CalculateASimpleTaskAsync()
        {
            int answer = 5 + 5;
            await Task.Delay(5000);
            return answer;
        }

        /// <summary>
        /// Gibt den HTMLCode von einer Webseite zurück
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetHTMLFromWebside()
        {
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.google.com/");
            }
            return htmlCode;
        }

        public async Task<bool> ThrowAnError()
        {
            throw new NullReferenceException();
            return false;
        }
        #endregion
    }
}
