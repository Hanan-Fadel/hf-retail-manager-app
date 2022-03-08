using Caliburn.Micro;
using HFRetailManagerDesktopUI.Helpers;
using HFRetailManagerDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HFRetailManagerDesktopUI
{
    //We will use this class to setup Caliburn.Micro
    public class BootStrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public BootStrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");

        }

        protected override void Configure()
        {
            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                //here's where we can pass event message through our application
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>();

            //Get all types in our all, of type class and their names ends with ViewModel

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType=> _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //On the startup Launch the ShellViewModel as our base view
            DisplayRootViewFor<ShellViewModel>();
        }

        //here we pass the type and the name and we get an instance of that type.
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        //We get all instances of something
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
