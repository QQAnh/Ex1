using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exc1.Entity;

namespace Exc1.Servies
{
    class UserServies
    {
        public static ObservableCollection<User> Users = null;
        public static void LoadStatic()
        {
            if (Users == null)
            {
                Users = new ObservableCollection<User>();
            }
            if (Users.Count == 0)
            {
                Users.Add(new User
                {
                    Name = "Giấc mơ chỉ là giấc mơ",
                    Phone = "12345678",
                    Email = "anh123@gmail.com",
                    Address = "HA NOI",
                    Avatar = "https://c1-ex-swe.nixcdn.com/NhacCuaTui945/GiacMoChiLaGiacMoSeeSingShare2-HaAnhTuan-5082049.mp3",
                });

            }
        }

        public static ObservableCollection<User> GetSongs(int page, int limit)
        {
            LoadStatic();
            //if (MetaData == null)
            //{
            //    MetaData = new MetaData();
            //}
            //// tao moi meta data tu api hoac fix tai local.
            //MetaData.Page = page;
            //MetaData.Limit = limit;
            //MetaData.TotalPage = 1;
            //MetaData.From = 1;
            //MetaData.To = 6;
            //MetaData.Total = 6;
            return Users;
        }
    }
}
