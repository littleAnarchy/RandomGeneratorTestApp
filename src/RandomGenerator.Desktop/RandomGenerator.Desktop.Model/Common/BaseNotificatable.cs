using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomGenerator.Desktop.Model.Common
{
    public class BaseNotificatable : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Hadler for creating notification chains. For hadler correct work, propeties (in Model and ViewModel) must have the same names/
        /// </summary>
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            RaisePropertyChanged(args.PropertyName);
        }
    }
}
