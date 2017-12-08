using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using PhoneWordsIOSProj.model;


namespace PhoneWordsIOSProj
{
    public partial class ChoresController : UITableViewController
    {
        public List<Chore> Chores { get; set; }
        static NSString cellIdentifier = new NSString("taskcell");

        public ChoresController(IntPtr handle) : base(handle)
        {
            Chores = new List<Chore> {
                new Chore {Id=0, Name="Groceries", Notes="Buy bread, cheese, apples", Done=false},
                new Chore {Id=1, Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=2, Name="Devices2", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=3, Name="Devices3", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=4, Name="Devices4", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=5, Name="Devices5", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=6, Name="Devices6", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=7, Name="Devices7", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=8, Name="Devices8", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=9, Name="Devices9", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=10, Name="Devices10", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=11, Name="Devices11", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=12, Name="Devices12", Notes="Buy Nexus, Galaxy, Droid", Done=false},
                new Chore {Id=13, Name="Devices13", Notes="Buy Nexus, Galaxy, Droid", Done=false},
            };



        }

        public override void ViewDidLoad()
        {
            AddButton.Clicked += (sender, e) => CreateTask();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            TableView.Source = new ChoresTableSource(this);
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "TaskSegue")
            {
                var navctlr = segue.DestinationViewController as TaskDetailController;
                if (navctlr != null)
                {
                    var source = TableView.Source as ChoresTableSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = source.GetItem(rowPath.Row);
                    navctlr.SetTask(this, item); // to be defined on the TaskDetailController
                }
            }
        }

        public void SaveTask(Chore chore)
        {
            var oldTask = Chores.Find(t => t.Id == chore.Id);
            if (TableView.IndexPathForSelectedRow != null)
            {
                NSIndexPath[] ns = { TableView.IndexPathForSelectedRow };
                TableView.ReloadRows(ns, UITableViewRowAnimation.Automatic);
            }
            else
            {
                TableView.ReloadData();
            }

            NavigationController.PopViewController(true);
        }

        public void DeleteTask(Chore chore)
        {
            var oldTask = Chores.Find(t => t.Id == chore.Id);
            Chores.Remove(oldTask);
            TableView.ReloadData();
            NavigationController.PopViewController(true);
        }

        public void CreateTask()
        {
            // first, add the task to the underlying data
            var newId = Chores[Chores.Count - 1].Id + 1;
            var newChore = new Chore { Id = newId, Name = "new chore" };
            Chores.Add(newChore);

            // then open the detail view to edit it
            var detail = Storyboard.InstantiateViewController("detail") as TaskDetailController;
            detail.SetTask(this, newChore);
            NavigationController.PushViewController(detail, true);
        }


        class ChoresTableSource : UITableViewSource
        {

            ChoresController controller;

            public ChoresTableSource(ChoresController c)
            {
                this.controller = c;
            }
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(ChoresController.cellIdentifier);
                var item = controller.Chores[indexPath.Row];
                cell.TextLabel.Text = item.Name;

                if (item.Done)
                {
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                }
                else
                {
                    cell.Accessory = UITableViewCellAccessory.None;
                }
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return controller.Chores.Count;
            }

            public Chore GetItem(int id)
            {
                return controller.Chores[id];
            }

        }
    }




}