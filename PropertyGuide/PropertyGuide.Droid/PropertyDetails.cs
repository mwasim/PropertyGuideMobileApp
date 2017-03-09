using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using PropertyGuide.BusinessLayer;
using PropertyGuide.BusinessLayer.Managers;
using PropertyGuide.Infrastructure;

namespace PropertyGuide.Droid
{
    [Activity(Label = "Property Details")]
    public class PropertyDetails : Activity
    {
        protected Property _Property = new Property();
        protected EditText _txtName;
        protected EditText _txtDescription;
        protected PropertyManager _PropertyManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //initilize property manager
            _PropertyManager = IoCContainer.Get<PropertyManager>();

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            //Load property details
            LoadProperty();

            //set our layout to be the property details screen
            SetContentView(Resource.Layout.PropertyDetails);

            //Populate Fields
            PopulateFields();
        }

        private void PopulateFields()
        {
            _txtName = FindViewById<EditText>(Resource.Id.txtName);
            _txtDescription = FindViewById<EditText>(Resource.Id.txtDesc);

            if (_txtName != null) _txtName.Text = _Property.Name;

            if (_txtDescription != null) _txtDescription.Text = _Property.Description;
        }

        private void LoadProperty()
        {
            var propertyId = Intent.GetIntExtra("PropertyID", 0);
            if (propertyId <= 0) return;

            _Property = _PropertyManager.Get(propertyId);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_propertydetails, menu);

            IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete_property);
            menuItem.SetTitle(_Property.ID > 0 ? "Delete" : "Cancel");

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_save_property:
                    Save();
                    return true;
                case Resource.Id.menu_delete_property:
                    CancelDelete();
                    return true;

                default:
                    Finish();
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected void Save()
        {
            _Property.Name = _txtName.Text.Trim();
            _Property.Description = _txtDescription.Text.Trim();

            if (_Property.ID > 0)
                _Property.DateModified = DateTime.Now;
            else
                _Property.DateAdded = DateTime.Now;

            if (_Property.SellerId <= 0)
                _Property.SellerId = 1; //TODO: After users login/registration implementation, this should be changed

            _PropertyManager.Save(_Property);

            Finish();
        }

        protected void CancelDelete()
        {
            if (_Property.ID > 0)
            {
                _PropertyManager.Delete(_Property.ID);
            }
            Finish();
        }
    }
}