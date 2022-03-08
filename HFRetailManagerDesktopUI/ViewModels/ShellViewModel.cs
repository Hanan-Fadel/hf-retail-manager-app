using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HFRetailManagerDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginVM;

        //Constructor injection to pass in a new instance of loginVM
        public ShellViewModel(LoginViewModel loginVM)
        {
            //Give me a new LoginViewModel instance
            _loginVM = loginVM;

            //Showme the View corresponsing to this LoginViewModel which is LoginView
            ActivateItemAsync(_loginVM);
        }

    }
}
