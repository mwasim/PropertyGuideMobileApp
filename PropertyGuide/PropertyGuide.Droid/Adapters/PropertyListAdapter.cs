using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.Droid.Adapters
{
    public class PropertyListAdapter : BaseAdapter<Property>
    {
        protected Activity _Context = null;
        protected IList<Property> _PropertyList = new List<Property>();

        public PropertyListAdapter(Activity context, IList<Property> properties)
        {
            _Context = context;
            _PropertyList = properties;
        }

        public override Property this[int position]
        {
            get { return _PropertyList[position]; }
        }

        public override int Count
        {
            get { return _PropertyList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //get our object for position
            var item = _PropertyList[position];
            View view = null;

            //Try to reuse convertView if its not null, otherwise inflate it from our item layout
            //gives us some performance gains by no always inflating a new view
            if (convertView == null)
            {
                view = _Context.LayoutInflater.Inflate(Resource.Layout.PropertyListItem, null);
            }
            else
            {
                view = convertView;
            }

            var tvPropertyName = view.FindViewById<TextView>(Resource.Id.tvPropertyName);
            var tvDescription = view.FindViewById<TextView>(Resource.Id.tvDescription);

            tvPropertyName.Text = item.Name;
            tvDescription.Text = item.Description;

            //Finally return the view
            return view;
        }
    }
}