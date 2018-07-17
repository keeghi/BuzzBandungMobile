using System.Threading.Tasks;

namespace BuzzBandung.Common.Base
{
    public abstract class ViewModelBase : BindableActionObject
    {
        bool _isBusy = true;
        string _title;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }
    }
}
