using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.DAL
{
    public class ToDoListDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ToDoListDataBase> Instance = new AsyncLazy<ToDoListDataBase>(async () =>
        {
            var instance = new ToDoListDataBase();
            CreateTableResult result = await Database.CreateTableAsync<ToDoListData>();

            return instance;
        });

        public ToDoListDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<ToDoListData>> GetToDoListAsync()
        {
            return Database.Table<ToDoListData>().ToListAsync();
        }

        public Task<ToDoListData> GetToDoListAsync(int id)
        {
            return Database.Table<ToDoListData>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveToDoListAsync(ToDoListData item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteToDoListAsync(ToDoListData item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
