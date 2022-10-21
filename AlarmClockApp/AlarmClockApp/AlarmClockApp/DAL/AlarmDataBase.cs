using AlarmClockApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClockApp.DAL
{
    public class AlarmDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<AlarmDataBase> Instance = new AsyncLazy<AlarmDataBase>(async () =>
        {
            var instance = new AlarmDataBase();
            CreateTableResult result = await Database.CreateTableAsync<AlarmData>();

            return instance;
        });

        public AlarmDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<AlarmData>> GetAlarmsAsync()
        {
            return Database.Table<AlarmData>().ToListAsync();
        }

        public Task<AlarmData> GetAlarmAsync(int id)
        {
            return Database.Table<AlarmData>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAlarmAsync(AlarmData item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteAlarmAsync(AlarmData item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
