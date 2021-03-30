using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using Splat;
using System;

namespace FitnessCustomerAccountingApp
{
    public class ConventionalViewLocator : IViewLocator, IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View").Replace(".Core", "");
            var type = Type.GetType(name);

            if (type != null)
                return (Control)Activator.CreateInstance(type)!;
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data)
        {
            return data is ReactiveObject;
        }

        public IViewFor? ResolveView<T>(T viewModel, string? contract = null)
        {
            // Find view's by chopping of the 'Model' on the view model name
            // MyApp.ShellViewModel => MyApp.ShellView
            string? viewModelName = viewModel?.GetType().FullName;
            string? viewTypeName = viewModelName?.TrimEnd("Model".ToCharArray())
                                            .Replace(".Core", "");

            try
            {
                var viewType = Type.GetType(viewTypeName);
                if (viewType == null)
                {
                    this.Log().Error($"Could not find the view {viewTypeName} for view model {viewModelName}.");
                    return null;
                }
                return Activator.CreateInstance(viewType) as IViewFor;
            }
            catch (Exception)
            {
                this.Log().Error($"Could not instantiate view {viewTypeName}.");
                throw;
            }
        }
    }
}