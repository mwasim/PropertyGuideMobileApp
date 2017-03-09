using System;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.Droid.ViewModels
{
    public class PropertyModel 
    {
        public int ID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public string PhotoURL { get; set; }
        public bool Sold { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public int SellerId { get; set; }
        public int? BuyerId { get; set; }


        public PropertyModel()
        {

        }

        public PropertyModel(Property item)
        {
            Update(item);
        }

        public void Update(Property item)
        {
            ID = item.ID;
            PropertyName = item.Name;
            PropertyDescription = item.Description;
            Sold = item.Sold;
            DateAdded = item.DateAdded;
            DateModified = item.DateModified;
            SellerId = item.SellerId;
            BuyerId = item.BuyerId;
            //PhotoURL = GetPropertyPhotoUrl();
        }
    }
}