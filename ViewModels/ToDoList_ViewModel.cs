
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class ToDoList_ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoListModel> Tasks { get; set; } = new ObservableCollection<ToDoListModel>();

        private string _newTask;
        public string NewTask
        {
            get => _newTask;
            set { _newTask = value; OnPropertyChanged(nameof(NewTask)); }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ToDoList_ViewModel()
        {
            AddCommand = new RelayCommand(_ => AddTask(), _ => !string.IsNullOrWhiteSpace(NewTask));
            DeleteCommand = new RelayCommand(DeleteTask);
        }

        private void AddTask()
        {
            Tasks.Add(new ToDoListModel { Task = NewTask, IsCompleted = false });
            NewTask = string.Empty;
        }

        private void DeleteTask(object parameter)
        {
            if (parameter is ToDoListModel item)
                Tasks.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
