using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BookingHotel.Models
{
    public class BookingDatabase
    {
        private readonly SQLiteConnection db;
        public BookingDatabase()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            db = new SQLiteConnection(System.IO.Path.Combine(folder, "BookingDatabase.db3"));
            db.CreateTable<User>();
            db.CreateTable<Token>();
            db.CreateTable<Home_save_filter>();
        }

        //User
        //check xem đã có tài khoản nào đăng nhập vào thiết bị này chưa
        public bool CheckLoginResponse()
        {
            try 
            {
                if(db.Table<User>().Count()>0)
                    return true;
                else
                    return false;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        //lấy thông tin từ loginResponse lưu vào bảng User và Token
        public bool CreateLoginResponse(LoginResponse loginResponse)
        {
            try
            {
                User user = new User();
                user._id = loginResponse.user._id;
                user.mauser = loginResponse.user.mauser;
                user.name = loginResponse.user.name;
                user.email = loginResponse.user.email;
                user.password = loginResponse.user.password;
                user.sdt = loginResponse.user.sdt;
                user.verifyCode = loginResponse.user.verifyCode;

                Token token = new Token();
                token.mauser = user.mauser;
                token.token = loginResponse.token;

                db.Insert(user);
                db.Insert(token);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                db.Update(user);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        //xóa thông tin trong bảng user và token khi người dùng đăng xuất
        public bool DeleteLoginResponse()
        {
            try
            {
                User user = db.Table<User>().First();
                db.Delete(user);
                Token token = db.Table<Token>().First();
                db.Delete(token);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }

        //Lấy tất cả thông tin về user
        public User GetUser()
        {
            try
            {
                return db.Table<User>().First();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return null;
                throw;
            }
        }
        public string GetUserLastName()
        {
            try
            {
                User user = db.Table<User>().First();
                var names = user.name.Split(' ');
                string lastName = names.Last();
                return lastName;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return null;
                throw;
            }
        }
        //filter của Home
        //lưu thông tin khi người dùng nhấn nút Tìm kiếm ở trang Home
        public bool CreateHome_save_filter(Home_save_filter home_Save_Filter)
        {
            try
            {
                db.Insert(home_Save_Filter);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public List<Home_save_filter> ReadHome_save_filter()
        {
            try
            {
                return db.Table<Home_save_filter>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return null;
                throw;
            }
        }
        public bool UpdateHome_save_filter(Home_save_filter home_Save_Filter)
        {
            try
            {
                db.Update(home_Save_Filter);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public bool DeleteHome_save_filter(Home_save_filter home_Save_Filter)
        {
            try
            {
                db.Delete(home_Save_Filter);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        
    }
}

