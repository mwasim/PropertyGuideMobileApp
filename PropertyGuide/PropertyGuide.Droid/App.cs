using System;

using Android.App;
using Android.Runtime;
using PropertyGuide.Infrastructure;
using PropertyGuide.BusinessLayer.Managers;

namespace PropertyGuide.Droid
{
    //Application attribute can be used only once t
    [Application]
    public class App : Application
    {
        public App(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)

        {
        }

        public override void OnCreate()
        {
            //Initialize DI
            IoCContainer.Initialize();

            //Load default data
            var appManager = IoCContainer.Get<AppManager>();

            if (!appManager.IsDataLoaded)
            {
                appManager.LoadAppData();
            }

            base.OnCreate();
        }
    }
}