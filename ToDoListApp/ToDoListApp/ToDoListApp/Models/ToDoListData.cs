using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    public class ToDoListData
    {
        public ToDoListData()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

    }
}
