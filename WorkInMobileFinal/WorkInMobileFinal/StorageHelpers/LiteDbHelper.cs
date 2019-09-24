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
        //private static DemandeurIdentite _currentUser;
        public static DemandeurIdentite CurrentUser
        {
            get
            {
                
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db");
                LiteDatabase db = new LiteDatabase(path);
                var exist = db.CollectionExists("user");
                if (!exist)
                    return null;
                else
                    return db.GetCollection<DemandeurIdentite>("user").Find(d => d.Id == SecureStorageHelper.AuthKey).FirstOrDefault();
            }
        }

        public static IEnumerable<Notification> Notifications
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db");
                LiteDatabase db = new LiteDatabase(path);
                var exist = db.CollectionExists("notifications");
                if (!exist)
                    return new List<Notification>();
                else
                    return db.GetCollection<Notification>("user").FindAll();

            }
        }

        public static void NewNotification(params Notification[] notification)
        {
            LiteDatabase db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db"));
            db.GetCollection<Notification>("notifications").InsertBulk(notification);
        }

        public static void SaveDataUser(DemandeurIdentite demandeurIdentite)
        {
            LiteDatabase db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db"));
            db.GetCollection<DemandeurIdentite>("user").Insert(demandeurIdentite);
        }
        public static void DeleteUser()
        {
            LiteDatabase db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db"));
            db.DropCollection("user");
            SecureStorageHelper.DeleteKey();

        }
        public static void UpdateDataUser(DemandeurIdentite demandeurIdentite)
        {
            LiteDatabase db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local_workin.db"));
            db.GetCollection<DemandeurIdentite>("user").Update(demandeurIdentite);
        }
    }
}
