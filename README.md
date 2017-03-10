Property Guide 
--------------
WinPhone Features:
------------------
1. Register New User (including fields validations and command bindings)
2. Login registered user (including fields validations and command bindings)
3. Displaying list of saved properties
4. Adding, Editing or Deleting properties.
5. Displaying list of saved users.
6. Flickr page to display properties images using Flickr API. (User can enter new search term for searching)
7. Using progress bar indicator while searching/loading properties (e.g. from Flickr)
8. Maintaining user session
9. Displaying Loggedin user information in the application
10. User may logout via menu or logout icon in the application bar.

WinPhone Technical Implementation Details
------------------------------------------
1. Use of built-in SQLite database to save/access data
2. Use of Dependency Injection pattern to reduce coupling (Ninject portable library)
3. Use of shared project ready to be used accross Windows Phone, Xamarin.Android and Xamarin.iOS projects
4. Use of MVVM pattern for binding model and commands to the view
5. Use of device's IsolatedStorageSettings to save user settings.
6. Use of Task based asynchronous pattern (async & await) to keep the UI responsive while executing long running tasks asynchronously.
7. Use of Dispatcher to update UI from associated asynchronous thread.
7.1. Use of ApplicationBar Icons and Menus to navigate between pages.
7.2. Use of Localization (at the moment only one AppResources file, further culture based resources can be added)
8. Generating unique random numbers in very short range (e.g. 1 to 10). Used to randomly assign images to properties (or users) for testing purposes only.
9. Use of Github source control
10. Use of SOLID principles

Xamarin.Android Features:
-------------------------
1. Displaying list of saved properties
2. A new property can be added by clicking the Add button in the application bar.
3. An existing property can be edited by clicking any property item in the table rows.
4. An existing property can be deleted.

Xamarin.Android Technical Details:
----------------------------------
1. Use of built-in SQLite database to save/access data
2. Use of Dependency Injection pattern to reduce coupling (Ninject portable library)
3. Use of shared project ready to be used accross Windows Phone, Xamarin.Android and Xamarin.iOS projects
4. Use of custom property list adapter to display list of properties in the listview.
5. Custom Menu, Styles and theme.
6. Use of Github source control
7. Use of SOLID principles


Xamarin.iOS Features:
---------------------
1. Displaying list of saved properties
2. A new property can be added by clicking the Add button in the application bar.
3. An existing property can be edited by clicking any property item in the table rows.
4. An existing property can be deleted.

Xamarin.iOS Technical Details:
------------------------------
1. Use of built-in SQLite database to save/access data
2. Use of Dependency Injection pattern to reduce coupling (Ninject portable library)
3. Use of shared project ready to be used accross Windows Phone, Xamarin.Android and Xamarin.iOS projects
4. Use of MonoTouch.Dialog Reflection (/Elements) API for developing screens.
5. Use of Github source control
6. Use of SOLID principles
