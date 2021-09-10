using System;
using System.Windows.Input;

namespace WPF_MVVM_Exam.Core
{
    class Command : ICommand
    {
        private readonly Action<object> commanExecute;
        private readonly Func<object, bool> commandCanExcute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Command(Action<object> excute, Func<object, bool> canExcute = null)
        {
            commanExecute = excute;
            commandCanExcute = canExcute;
        }

        public bool CanExecute(object parameter)
        {
            return commandCanExcute == null || commandCanExcute(parameter);
        }

        public void Execute(object parameter)
        {
            commanExecute(parameter);
        }
    }
}
