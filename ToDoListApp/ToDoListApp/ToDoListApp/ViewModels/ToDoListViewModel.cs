using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.DAL;
using ToDoListApp.Models;

namespace ToDoListApp.ViewModels
{
    public class ToDoListViewModel : BindableBase
    {
        private readonly ToDoListData toDoListItem;
        public ToDoListViewModel(ToDoListData toDoItem)
        {
            this.toDoListItem = toDoItem;
        }
        public ToDoListData ToDoListItem => toDoListItem;
        public string Description {
            get => ToDoListItem.Description; 
            set
            {
                ToDoListItem.Description = value;
                RaisePropertyChanged();
            }
        }
        public bool Checked
        {
            get => ToDoListItem.Checked;
            set
            {
                if (ToDoListItem.Checked == value)
                    return;

                ToDoListItem.Checked = value;
                RaisePropertyChanged();
            }
        }
    }
}
