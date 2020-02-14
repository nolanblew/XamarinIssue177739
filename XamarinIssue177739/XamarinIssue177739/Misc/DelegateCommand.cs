using System;
using System.Windows.Input;

namespace XamarinIssue177739.Misc
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action action)
            : this(action, () => true) { }

        public DelegateCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        private Action _action;
        private Func<bool> _canExecute;

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
    public class DelegateCommand<T> : ICommand
    {
        public DelegateCommand(Action<T> action)
            : this(action, _ => true) { }

        public DelegateCommand(Action<T> action, Func<T, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        private Action<T> _action;
        private Func<T, bool> _canExecute;

        bool ICommand.CanExecute(object parameter)
        {
            if (Equals(parameter, default(T)))
            {
                return CanExecute(default(T));
            }
            else if (parameter is T t)
            {
                return CanExecute(t);
            }
            else
            {
                throw new InvalidCastException("Cannot cast parameter to type T");
            }
        }

        void ICommand.Execute(object parameter)
        {
            if (Equals(parameter, default(T)))
            {
                Execute(default(T));
            }
            else if (parameter is T t)
            {
                Execute(t);
            }
            else
            {
                throw new InvalidCastException("Cannot cast parameter to type T");
            }
        }

        public void Execute(T parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(T parameter)
        {
            return _canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
