using PropertyGuide.BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#if NETFX_CORE || WINDOWS_PHONE
using Windows.Storage;
#endif

namespace PropertyGuide.CommonUtils
{
    public static class Utils
    {
        public static List<User> GetDefaultUserList()
        {
            return new List<User>
            {
                new User {Name = "Hector McHector", Email = "hector@gmail.com", UserTypeId = (int)UserTypeEnum.Seller},
                new User {Name = "Max Colorado", Email = "max@gmail.com", UserTypeId = (int)UserTypeEnum.Buyer},
                new User {Name = "Carlos Waterslide", Email = "carlos@gmail.com", UserTypeId = (int)UserTypeEnum.Seller},
                new User {Name = "Hank Fracas",Email = "hank@gmail.com", UserTypeId = (int)UserTypeEnum.Buyer},
                new User {Name = "Paul Corduroy", Email = "paul@gmail.com", UserTypeId = (int)UserTypeEnum.Seller},

                new User {Name = "Emma Stout", Email = "emma@gmail.com", UserTypeId = (int)UserTypeEnum.Seller},
                new User {Name = "Alicia Purple", Email = "alicia@gmail.com", UserTypeId = (int)UserTypeEnum.Buyer},
                new User {Name = "Molly Popper", Email = "molly@gmail.com", UserTypeId = (int)UserTypeEnum.Seller},
                new User {Name = "Dina Negroni", Email = "dina@gmail.com", UserTypeId = (int)UserTypeEnum.Buyer},
                new User {Name = "Helen Porter", Email = "helen@gmail.com", UserTypeId = (int)UserTypeEnum.Seller}
            };
        }

        public static List<Property> GetDefaultPropertyList()
        {
            return new List<Property>
            {
                new Property {Name = "Property 1", Description = "Description here.", SellerId = 1, DateAdded = DateTime.Now},
                new Property {Name = "Property 2", Description = "Description here.", SellerId = 1, DateAdded = DateTime.Now, BuyerId = 2, Sold = true},
                new Property {Name = "Property 3", Description = "Description here.", SellerId = 1, DateAdded = DateTime.Now},

                new Property {Name = "Property 4", Description = "Description here.", SellerId = 3, DateAdded = DateTime.Now},
                new Property {Name = "Property 5", Description = "Description here.", SellerId = 3, DateAdded = DateTime.Now, BuyerId = 7, Sold = true},
                new Property {Name = "Property 6", Description = "Description here.", SellerId = 3, DateAdded = DateTime.Now},

                new Property {Name = "Property 7", Description = "Description here.", SellerId = 5, DateAdded = DateTime.Now},
                new Property {Name = "Property 8", Description = "Description here.", SellerId = 5, DateAdded = DateTime.Now, BuyerId = 2, Sold = true},
                new Property {Name = "Property 9", Description = "Description here.", SellerId = 5, DateAdded = DateTime.Now},

                new Property {Name = "Property 10", Description = "Description here.", SellerId = 6, DateAdded = DateTime.Now},
                new Property {Name = "Property 11", Description = "Description here.", SellerId = 6, DateAdded = DateTime.Now, BuyerId = 7, Sold = true},
                new Property {Name = "Property 12", Description = "Description here.", SellerId = 6, DateAdded = DateTime.Now},

            };
        }

        public static List<UserType> GetDefaultUserTypeList()
        {
            return new List<UserType>
            {
                new UserType {ID = (int) UserTypeEnum.Seller, Name = $"{UserTypeEnum.Seller}"},
                new UserType {ID = (int) UserTypeEnum.Buyer, Name = $"{UserTypeEnum.Buyer}"}
            };            
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
              @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3}))$");
        }

        public static IEnumerable<int> GetUniqueRandomNumbers(int minInclusive, int maxInclusive)
        {
            List<int> candidates = new List<int>();
            for (int i = minInclusive; i <= maxInclusive; i++)
            {
                candidates.Add(i);
            }
            Random rnd = new Random();
            while (candidates.Count > 0)
            {
                int index = rnd.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }

        private static List<int> numberUsedList = new List<int>();
        public static int GetUniqueRandomNumber(int minInclusive, int maxInclusive)
        {
            var numberList = GetUniqueRandomNumbers(minInclusive, maxInclusive).ToList();
            var number = 1;
            while (numberUsedList.Contains(number))
            {
                number++;
                if (number >= maxInclusive)
                    numberUsedList.Clear();
            }

            numberUsedList.Add(number);
            return number;
        }

        public static UserTypeEnum GetTypeName(bool isSeller)
        {
            return isSeller ? UserTypeEnum.Seller : UserTypeEnum.Buyer;
        }

        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "PropertyGuideDB.sqlite";

#if NETFX_CORE || WINDOWS_PHONE
                var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
#else

#if __ANDROID__
				//Just use whatever SpecialFolder.Personal returns
				var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documen
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Documents Folder
				string libraryPath = Path.Combine(documentsPath, "../Library/"); //Library folder

#endif
				var path = Path.Combine(libraryPath, sqliteFilename);
#endif

#endif
                return path;
            }
        }
    }
}
