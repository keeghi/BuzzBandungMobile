using System;
using System.Collections.Generic;
using Autofac;
using BuzzBandung.Common.Base;
using Xamarin.Forms;

namespace BuzzBandung
{
    public sealed class Locator
    {
        private static readonly Lazy<Locator> instance = new Lazy<Locator>(() => new Locator());
        public static Locator Instance => instance.Value;

        private IContainer container;
        private readonly ContainerBuilder containerBuilder = new ContainerBuilder();
        private readonly Dictionary<Type, Type> mappings = new Dictionary<Type, Type>();

        private Locator()
        {
        }

        public void Build() => container = containerBuilder.Build();

        public void RegisterService<TInterface, TImplementation>() where TImplementation : TInterface
        {
            containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        public void RegisterView<TView, TViewModel>() where TView : Page where TViewModel : ViewModelBase
        {
            containerBuilder.RegisterType<TViewModel>();
            mappings.Add(typeof(TViewModel), typeof(TView));
        }

        public Page CreatePage<TViewModel>() where TViewModel : ViewModelBase
        {
            return CreatePage(typeof(TViewModel));
        }

        public Page CreatePage(Type viewModelType)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"Mapping type for {viewModelType} is not a page");

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        public T Resolve<T>() => container.Resolve<T>();
        public object Resolve(Type type) => container.Resolve(type);

        Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on mappings");

            return mappings[viewModelType];
        }

        Type GetPageTypeForViewModel<TViewModel>() where TViewModel : ViewModelBase
        {
            return GetPageTypeForViewModel(typeof(TViewModel));
        }
    }
}
