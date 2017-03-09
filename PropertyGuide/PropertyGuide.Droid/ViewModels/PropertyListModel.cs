using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.Droid.ViewModels
{
    public class PropertyListModel 
    {        
        public ObservableCollection<PropertyModel> Items { get; private set; }

        public PropertyListModel(IEnumerable<Property> list)
        {
            Items = null;
            
            Items = new ObservableCollection<PropertyModel>(
                        from e in list
                        select new PropertyModel(e));
        }       
    }
}