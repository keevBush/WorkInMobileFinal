using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;

namespace WorkInMobileFinal.StorageHelpers
{
    public class LiteDbHelper
    {
        private static DemandeurIdentite _currentUser;
        public static DemandeurIdentite CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db");
                    LiteDatabase db = new LiteDatabase(path);
                    var exist = db.CollectionExists("user");
                    if (!exist)
                        _currentUser = null;
                    else
                        _currentUser = db.GetCollection<DemandeurIdentite>("user").Find(d => d.Id == SecureStorageHelper.AuthKey).FirstOrDefault();
                }
                return _currentUser;
            }
        }
        public static void SaveDataUser(DemandeurIdentite demandeurIdentite)
        {
            LiteDatabase db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db"));
            db.GetCollection<DemandeurIdentite>("user").Insert(demandeurIdentite);
        }
        public static void UpdateDataUser(DemandeurIdentite demandeurIdentite)
        {
            LiteDatabase db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db"));
            db.GetCollection<DemandeurIdentite>("user").Update(demandeurIdentite);
        }
    }
}
