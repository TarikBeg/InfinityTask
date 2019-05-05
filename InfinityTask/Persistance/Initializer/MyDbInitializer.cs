using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using InfinityTask.Core.EntityModel;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using  Microsoft.CodeAnalysis;
namespace InfinityTask.Persistance.Initializer
{
    public class MyDbInitializer
    {
        static List<AppUser> Users = new List<AppUser>();
        static List<Blog> Blogs = new List<Blog>();
        public static List<AppUser> AddUsers(MyContext context)
        {
            // Look for any User.
            if (context.User.Any()) return new List<AppUser>(); // DB has been seeded

            var maxUser = 14;
           

           
          
            Users.Add(new AppUser()
            {
                FirstName = "admin",
                LastName = "",
                Age = 20,
                PasswordHash = "admin"
            });
          
            for (var i = 1; i <= maxUser; i++)
            {
                string Password = MyRandomExtensions.MyRandomStringWithNmb(4);  
                Users.Add(new AppUser()
                {
                    FirstName  = MyRandomExtensions.MyRandomString(4),LastName = MyRandomExtensions.MyRandomString(6), Age = MyRandomExtensions.GiveAge(),
                    PasswordHash = Password
                });

            }

            foreach (var u in Users)
            {
                u.Email = u.FirstName+u.LastName + "@gmail.com";
                u.UserName = u.FirstName + u.LastName;
            }


            return Users;

        }

        public static List<Blog> AddBlogs(MyContext context)
        {
            if (context.Blog.Any()) return new List<Blog>(); 

            var maxBlog = 50;

            for (int i = 1; i <= maxBlog; i++)
            {
                int userPosition = MyRandomExtensions.RandomId();


                Blogs.Add(new Blog()
                {
                    Id = Users[userPosition].Id,
                    Content = MyRandomExtensions.MyRandomString(50),
                    Title = MyRandomExtensions.MyRandomString(10),
                    PublishDate = MyRandomExtensions.RandomDay(),
                    Summary=MyRandomExtensions.MyRandomString(20)
                });
            }


           
            return Blogs;
        }
        public static class MyRandomExtensions
        {
            public static readonly Random random = new Random();

            public static string MyRandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            public static string MyRandomStringWithNmb(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ12345";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            public static T MyRandom<T>(List<T> lista)
            {
                var r = random.Next(0, lista.Count);
                return lista[r];
            }

            public static int GiveAge()
            {
               return random.Next(20, 40);
                
            }

            public static int RandomId()
            {
                return random.Next(1,15);
                
            }

            public static string RadnomIdString()
            {
                return MyRandomStringWithNmb(4);
            }

            public static DateTime RandomDay()
            {
                DateTime start = new DateTime(2010, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(random.Next(range));
            }
        }
    }
}