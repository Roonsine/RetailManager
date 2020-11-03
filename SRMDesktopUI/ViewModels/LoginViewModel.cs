using Caliburn.Micro;
using SRMDesktopUi.Library.Api;
using SRMDesktopUI.EventModels;
using SRMDesktopUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username = "test@test.ca";
        private string _password = "Pwd12345.";
        private IAPIHelper _apiHelper;
        IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }
        public string userName
        {
            get { return _username; }
            set 
            {
                _username = value;
                NotifyOfPropertyChange(() => userName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }


        public bool isErrorVisible
        {
            get 
            {
                bool output = false;
                if(ErrorMessage?.Length > 0)
                {
                    output = true;
                    return output;
                }
                return output;
            }

        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => isErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);

            }
        }



        public bool CanLogin
        {
            get
            {
                bool output = false;
                if (userName?.Length > 0 && password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task Login()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(userName, password);

                await _apiHelper.GetLoggedInUserInfo(result.access_Token);

                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }


    }
}
