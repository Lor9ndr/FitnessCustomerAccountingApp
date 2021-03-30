using Ninject;

namespace FitnessCustomerAccountingApp.Core
{
    public static class IoC
    {
        #region Public properties
        public static IKernel Kernel { get; private set; } = new StandardKernel();
        /// <summary>
        /// Sets up the IoC container,binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all services can be find
        /// </summary>
        #endregion



        #region Construction
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        private static void BindViewModels()
        {
            // Bind to a single instance of ApplicationViewModel
            Kernel.Bind<MainViewModel>().ToConstant(new MainViewModel()); 
        }
        #endregion

        /// <summary>
        /// Get's a service from the Ioc, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

    }
}
