using Caliburn.Micro;
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
        private string _username = "";
        private string _password;
        private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
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
                var result = await _apiHelper.Authenticate(userName, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
