using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Task_19.Models;

namespace WPF_Task_19.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double length;
        public double Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }

        private void OnAddCommandExecute(object p)
        {
            Length = Circle.CalcLength(radius);
        }
        private bool CanAddCommandExecut(object p)
        {
            if (Radius != 0)
                return true;
            else
                return false;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecut);
        }
    }
}
