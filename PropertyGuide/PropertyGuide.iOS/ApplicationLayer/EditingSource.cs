using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using MonoTouch.Dialog;
using PropertyGuide.iOS.Screens;
using UIKit;

namespace PropertyGuide.iOS.ApplicationLayer
{
    //Sub class that allows editing
    public class EditingSource : DialogViewController.Source
    {
        public EditingSource(DialogViewController container) : base(container)
        {
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            //we let all rows be editable regardless of section or row
            return true;
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            //tirivial implementation: show a delete button always
            return UITableViewCellEditingStyle.Delete;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            //actually carry out the delete request
            var section = Container.Root[indexPath.Section];
            var element = section[indexPath.Row] as StringElement;
            section.Remove(element);

            var dvc = Container as HomeScreen;
            dvc.DeletePropertyRow(indexPath.Row);
        }
    }
}
