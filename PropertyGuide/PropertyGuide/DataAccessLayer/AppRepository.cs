using System;
using System.Collections.Generic;
using System.IO;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer;

namespace PropertyGuide.DataAccessLayer
{
    public class AppRepository
    {
        protected static string dbLocation;
        static AppRepository()
        {
            //set the db location
            dbLocation = CommonUtils.Utils.DatabaseFilePath;
        }

        /*
        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "PropertyGuideDB.db3";

#if NETFX_CORE || WINDOWS_PHONE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
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
        */

    }
}
