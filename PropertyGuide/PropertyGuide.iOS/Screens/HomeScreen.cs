using System;
using MonoTouch.Dialog;
using PropertyGuide.BusinessLayer;
using PropertyGuide.iOS.ApplicationLayer;
using UIKit;
using PropertyGuide.BusinessLayer.Managers;
using PropertyGuide.Infrastructure;
using System.Collections.Generic;
using Foundation;

namespace PropertyGuide.iOS.Screens
{
    public class HomeScreen : DialogViewController
    {
        protected PropertyManager _propertyManager;
        private List<Property> _properties;

        public HomeScreen() : base(UITableViewStyle.Plain, null)
        {
            Initialize();
        }

        protected void Initialize()
        {
            //initilize property manager
            _propertyManager = IoCContainer.Get<PropertyManager>();

            NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Add), false);
            NavigationItem.RightBarButtonItem.Clicked += (sender, args) =>
            {
                ShowPropertyDetails(new Property());
            };
        }

        private LocalizableBindingContext _bindingContext;
        private PropertyDialog propertyDialog;
        private Property currentProperty;
        private DialogViewController detailsScreen;

        protected void ShowPropertyDetails(Property property)
        {
            currentProperty = property;
            propertyDialog = new PropertyDialog(property);

            var screenTitle = "Property Details";
            _bindingContext = new LocalizableBindingContext(this, propertyDialog, screenTitle);
            detailsScreen = new DialogViewController(_bindingContext.Root, true);

            ActivateController(detailsScreen);
        }

        public void SaveProperty()
        {
            _bindingContext.Fetch(); //re-populates the updated values

            currentProperty.Name = propertyDialog.Name;
            currentProperty.Description = propertyDialog.Description;

            if (currentProperty.ID > 0)
                currentProperty.DateModified = DateTime.Now;
            else
                currentProperty.DateAdded = DateTime.Now;

            if (currentProperty.SellerId <= 0) currentProperty.SellerId = 1; //TODO: On implementing user registration it can be updated

            _propertyManager.Save(currentProperty);

            NavigationController.PopViewController(true);
            //_bindingContext.Dispose(); //by documentation it should be disposed but appears to cause crash sometimes
        }

        public void DeleteProperty()
        {
            if (currentProperty.ID > 0)
            {
                _propertyManager.PropertyRepository.Delete(currentProperty.ID);
            }

            NavigationController.PopViewController(true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //reload/refresh
            PopulateTable();
        }

        protected void PopulateTable()
        {
            const string newPropertyDefaultName = "<new property>";

            _properties = _propertyManager.GetList();

            //Make into a list of MT.D elements to display
            //List<Section> sections = new List<Section>();
            List<Element> elements = new List<Element>();
            foreach (var property in _properties)
            {
                var name = string.IsNullOrEmpty(property.Name) ? newPropertyDefaultName : property.Name;
                elements.Add(new StringElement(name));                               
            }

            //add to section
            var s = new Section();
            s.AddAll(elements);            

            //add as root
            Root = new RootElement("Property Guide") { s };            
        }


        public override void Selected(NSIndexPath indexPath)
        {
            var property = _properties[indexPath.Row];

            ShowPropertyDetails(property);
        }

        public override Source CreateSizingSource(bool unevenRows)
        {
            return new EditingSource(this);
        }

        public void DeletePropertyRow(int rowId)
        {
            _propertyManager.PropertyRepository.Delete(_properties[rowId].ID);
        }
    }
}
