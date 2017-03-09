using System;
using System.Collections.Generic;
using System.Text;
using MonoTouch.Dialog;
using PropertyGuide.BusinessLayer;
using UIKit;

namespace PropertyGuide.iOS.ApplicationLayer
{
    //https://developer.xamarin.com/guides/ios/user_interface/monotouch.dialog/
    /*
     1. A DialogViewController, or DVC for short, inherits from UITableViewController and therefore represents a screen with a table. DVCs can be pushed onto a navigation controller just like a regular UITableViewController.
     2. A RootElement is the top-level container for the items that go into a DVC. It contains Sections, which can then contain Elements. RootElements are not rendered; instead they’re simply containers for what actually gets rendered. A RootElement is assigned to a DVC, and then the DVC renders its children.
     3. A section is a group of cells in a table. As with a normal table section, it can optionally have a header and footer that can either be text, or even custom views    
     4. An Element represents an actual cell in the table. MT.D comes packed with a wide variety of Elements that represent different data types or different inputs. 
         */
    public class PropertyDialog
    {
        public PropertyDialog(Property property)
        {
            Name = property.Name;
            Description = property.Description;
        }

        //Use of Reflection API
        //https://developer.xamarin.com/guides/ios/user_interface/monotouch.dialog/reflection_api_walkthrough/
        /*
         In addition to the Elements API, MonoTouch.Dialog (MT.D) also includes an attribute-based Reflection API. 
         The Reflection API makes creating screens with MT.D as easy as decorating classes with attributes.
         
            Using the Reflection API is as simple as:
            Step-1: Creating a class decorated with MT.D attributes.
            Step-2: Creating a BindingContext (here it's LocalizableBindingContext) instance, passing it an instance of the above class.[Passing instance of PropertyDialog to the BindingContext class]
            Step-3: Creating a DialogViewController, passing it the BindingContext’s RootElement              
             */

        [Entry("Property Name")]
        public string Name { get; set; }

        [Entry("Description")]
        public string Description { get; set; }

        [Section("")]
        [OnTap("SaveProperty")]
        [Alignment(UITextAlignment.Center)]
        public string Save;

        [Section("")]
        [OnTap("DeleteProperty")]
        [Alignment(UITextAlignment.Center)]
        public string Delete;
    }
}
