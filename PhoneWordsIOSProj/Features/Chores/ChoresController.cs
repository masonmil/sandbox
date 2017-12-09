using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using PhoneWordsIOSProj.model;
using PhoneWordsIOSProj.Features.Chores;
using PhoneWordsIOSProj.Services.Rest;

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
                new Chore {Id=1, Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}

            };



        }

        public override async void ViewDidLoad()
        {
            AddButton.Clicked += (sender, e) => CreateTask();

            var mgr = new TodoItemManager(new RestService());
            var items = await mgr.GetTasksAsync();
            foreach (var item in items)
            {
                Chores.Add(new Chore() { Id = Chores.Count, Name = item });
            }
            TableView.ReloadData();
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