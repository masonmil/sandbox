using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PhoneWordsIOSProj
{
    public partial class CallHistoryController : UITableViewController
    {

        public List<string> PhoneNumbers { get; set; }

        static NSString callHistoryCellId = new NSString("CallHistoryCell");

        public CallHistoryController(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), callHistoryCellId);
            TableView.Source = new CallHistoryDataSource(this);
            PhoneNumbers = new List<string>();

        }

        class CallHistoryDataSource : UITableViewSource
        {
            CallHistoryController controller;
            public CallHistoryDataSource(CallHistoryController controller)
            {
                this.controller = controller;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                UIAlertController okAlertController = UIAlertController.Create("Row Selected", controller.PhoneNumbers[indexPath.Row], UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                controller.PresentViewController(okAlertController, true, null);

            }
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CallHistoryController.callHistoryCellId);
                var row = indexPath.Row;
                cell.TextLabel.Text = controller.PhoneNumbers[row];
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return controller.PhoneNumbers.Count;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
            {
                switch (editingStyle)
                {
                    case UITableViewCellEditingStyle.Delete:
                        controller.PhoneNumbers.RemoveAt(indexPath.Row);
                        tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                        break;
                    case UITableViewCellEditingStyle.None:
                        Console.WriteLine("CommitEditingStyle.None called");
                        break;
                }
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath) => true;



        }

    }
}