using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartShopProject.Commands

{
    public class ViewModel
    {
        public ICommand MyCommand { get; private set; }

        public ViewModel()
        {
            MyCommand = new RelayCommand(ExecuteMyCommand, CanExecuteMyCommand);
        }

        private void ExecuteMyCommand(object parameter)
        {
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            return true; 
        }
    }

}
