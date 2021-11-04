using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyPersonal
{
    public class StaffManRepository
    {
        SQLiteConnection database;
        public StaffManRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<StaffMan>();
        }
        public IEnumerable<StaffMan> GetItems()
        {
            return database.Table<StaffMan>().ToList();
        }
        public StaffMan GetItem(int id)
        {
            return database.Get<StaffMan>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<StaffMan>(id);
        }
        public int SaveItem(StaffMan item)
        {
            if (item.IndexMan != 0)
            {
                database.Update(item);
                return item.IndexMan;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
