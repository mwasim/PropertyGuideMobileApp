using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using PropertyGuide.BusinessLayer;
using PropertyGuide.BusinessLayer.Managers;
using PropertyGuide.Infrastructure;

namespace PropertyGuide.Droid
{
    [Activity(Label = "Property Guide", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected Adapters.PropertyListAdapter _PropertyListAdapter;
        protected IList<Property> _Properties;
        protected ListView _PropertyListView;
        protected PropertyManager _PropertyManager;   

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //initilize property manager
            _PropertyManager = IoCContainer.Get<PropertyManager>();

            //Enable the Action Bar
            RequestWindowFeature(WindowFeatures.ActionBar);

            //Set our layout to be the Main screen
            SetContentView(Resource.Layout.Main);

            //Find our controls
            _PropertyListView = FindViewById<ListView>(Resource.Id.listViewProperties);

            //wire up the click handler
            if (_PropertyListView != null)
            {
                _PropertyListView.ItemClick += OnPropertyItemClick;
            }            
        }

        private void OnPropertyItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var propertyDetails = new Intent(this, typeof(PropertyDetails));
            propertyDetails.PutExtra("PropertyID", _Properties[e.Position].ID);

            StartActivity(propertyDetails);
        }

        protected override void OnResume()
        {
            base.OnResume();

            //Load properties
            _Properties = _PropertyManager.GetList();

            //create our adapter
            _PropertyListAdapter = new Adapters.PropertyListAdapter(this, _Properties);

            //hookup our adapter to the listview
            _PropertyListView.Adapter = _PropertyListAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //Create the actions in the actions bar
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //TODO: case to load property details screen
                case Resource.Id.menu_add_property:
                    StartActivity(typeof(PropertyDetails));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}


