using ReactiveUI;
using Splat;
using System;

namespace FitnessCustomerAccountingApp.Core

{
    public class BaseRoutableViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; set; }

        public BaseRoutableViewModel() => HostScreen = Locator.Current.GetService<IScreen>();

        public void GoToPage(BaseRoutableViewModel pagevm) => IoC.Get<MainViewModel>().GoToPage(pagevm);
    }
}