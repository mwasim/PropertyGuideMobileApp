using Foundation;
using PropertyGuide.BusinessLayer.Managers;
using PropertyGuide.Infrastructure;
using PropertyGuide.iOS.Screens;
using UIKit;

namespace PropertyGuide.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        private UINavigationController navController;
        private UITableViewController homeViewController;
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            //Load application data
            LoadAppData();

            //create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            //make the window visible
            Window.MakeKeyAndVisible();

            //create our nave controller
            navController = new UINavigationController();

            //create our home controller based on the device
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                homeViewController = new HomeScreen();
            }
            else
            {
                homeViewController = new HomeScreen(); //TODO: replace it with iPad screen if we implement for iPad
            }


            //Styling
            UINavigationBar.Appearance.TintColor = UIColor.FromRGB(38, 117, 255); //blue shade
            UITextAttributes ta = new UITextAttributes();
            ta.Font = UIFont.FromName("AmericanTypewriter-Bold", 0f);
            UINavigationBar.Appearance.SetTitleTextAttributes(ta);
            ta.Font = UIFont.FromName("AmericanTypewriter", 0f);
            UIBarButtonItem.Appearance.SetTitleTextAttributes(ta, UIControlState.Normal);

            //push the view controller on the nav controller and show the window
            navController.PushViewController(homeViewController, false);
            Window.RootViewController = navController;
            Window.MakeKeyAndVisible();

            return true;
        }

        private void LoadAppData()
        {
            //Initialize DI
            IoCContainer.Initialize();

            //Load default data
            var appManager = IoCContainer.Get<AppManager>();

            if (!appManager.IsDataLoaded)
            {
                appManager.LoadAppData();
            }
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}


