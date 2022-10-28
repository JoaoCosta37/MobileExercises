using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoListApp.DAL;
using ToDoListApp.Models;
using Xamarin.Forms;
using System.Linq;

namespace ToDoListApp.ViewModels
{
    public class ToDoListPageViewModel : BindableBase
    {
        ObservableCollection<ToDoListViewModel> toDoListItems;
        ObservableCollection<ToDoListViewModel> toDoListItemsClosed;
        private string description;
        private bool inserting;
        
        public ToDoListPageViewModel()
        {
            loadData();
            AddCommand = new Command(() => add());
            DeleteCommand = new Command((x) => delete(x));
        }
        public string Description
        {
            get => description; set
            {
                description = value;
                if (description == "" || description == null) Inserting = false;
                else Inserting = true;
                RaisePropertyChanged();
            }
        }
        public bool Inserting
        {
            get => inserting;
            set
            {
                inserting = value;
                RaisePropertyChanged();
            }
        }
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }
        public ObservableCollection<ToDoListViewModel> ToDoListItems
        {
            get => toDoListItems;
            set
            {
                toDoListItems = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ToDoListViewModel> ToDoListItemsClosed
        {
            get => toDoListItemsClosed;
            set
            {
                toDoListItemsClosed = value;
                RaisePropertyChanged();
            }
        }

        async void loadData()
        {
            ToDoListDataBase database = await ToDoListDataBase.Instance;
            var toDoListItemsVm = (await database.GetToDoListAsync()).Select(x => new ToDoListViewModel(x)).ToList();
            foreach (var toDoListItem in toDoListItemsVm)
            {
                toDoListItem.PropertyChanged += ToDoListItem_PropertyChanged;
            }

            this.ToDoListItems = new ObservableCollection<ToDoListViewModel>(toDoListItemsVm.Where(x => !x.Checked));
            this.ToDoListItemsClosed = new ObservableCollection<ToDoListViewModel>(toDoListItemsVm.Where(x => x.Checked));
        }

        private async void ToDoListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToDoListViewModel.Checked))
            {
                var toDoListItem = (ToDoListViewModel)sender;
                ToDoListDataBase database = await ToDoListDataBase.Instance;
                await database.SaveToDoListAsync(toDoListItem.ToDoListItem);
                // loadData();

                if (toDoListItem.Checked)
                {
                    this.ToDoListItems.Remove(toDoListItem);
                    this.ToDoListItemsClosed.Add(toDoListItem);
                }
                else
                {
                    this.ToDoListItems.Add(toDoListItem);
                    this.ToDoListItemsClosed.Remove(toDoListItem);
                }
            }
        }

        async void add()
        {
            var item = new ToDoListData() { Description = this.Description, Checked = false };
            ToDoListDataBase database = await ToDoListDataBase.Instance;
            await database.SaveToDoListAsync(item);
            this.Description = "";
            loadData();
        }
        async void delete(object toDoListVm)
        {
            var action = await Application.Current.MainPage.DisplayAlert("Delete Task", "Are you sure you want to delete this Task?", "YES", "NO");
            if (action)
            {
                var toDoList = (ToDoListViewModel)toDoListVm;
                ToDoListDataBase database = await ToDoListDataBase.Instance;
                await database.DeleteToDoListAsync(toDoList.ToDoListItem);
                loadData();
            }
        }
    }
}
