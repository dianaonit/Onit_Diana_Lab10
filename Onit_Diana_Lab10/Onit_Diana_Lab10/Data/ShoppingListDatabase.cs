﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Onit_Diana_Lab10.Models;
using System.Threading.Tasks;

namespace Onit_Diana_Lab10.Data
{
     public class ShoppingListDatabase
    {
        readonly SQLiteAsyncConnection _database; 
        public ShoppingListDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopList>().Wait(); 
        }
        public Task<List<ShopList>> GetShopListsAsync()
        {
            return _database.Table<ShopList>().ToListAsync();
        }
        public Task<ShopList> GetShopListAsync(int id) { 
            return _database.Table<ShopList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync(); 
        }
        public Task<int> SaveShopListAsync(ShopList slist) { 
            if (slist.ID != 0) 
            { 
                return _database.UpdateAsync(slist); 
            } 
            else 
            { 
                return _database.InsertAsync(slist); 
            } 
        }
        public Task<int> DeleteShopListAsync(ShopList slist) { 
            return _database.DeleteAsync(slist); 
        }

    }
}
