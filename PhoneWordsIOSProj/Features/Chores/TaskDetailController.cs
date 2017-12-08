using Foundation;
using System;
using UIKit;
using PhoneWordsIOSProj.model;

namespace PhoneWordsIOSProj
{
    public partial class TaskDetailController : UITableViewController
    {
        public ChoresController Delegate { get; set; }
        Chore currentTask { get; set; }

        public TaskDetailController(IntPtr handle) : base(handle)
        {
        }

        public void SetTask(ChoresController d, Chore task)
        {
            Delegate = d;
            currentTask = task;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            nameText.Text = currentTask.Name;
            notesText.Text = currentTask.Notes;
            doneSwitch.On = currentTask.Done;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            saveButton.TouchUpInside += (sender, e) =>
            {
                currentTask.Name = nameText.Text;
                currentTask.Notes = notesText.Text;
                currentTask.Done = doneSwitch.On;
                Delegate.SaveTask(currentTask);
            };

            deleteButton.TouchUpInside += (sender, e) => Delegate.DeleteTask(currentTask);
        }
    }

}