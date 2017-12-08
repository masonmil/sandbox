// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PhoneWordsIOSProj
{
    [Register ("TaskDetailController")]
    partial class TaskDetailController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton deleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch doneSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField notesText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton saveButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (deleteButton != null) {
                deleteButton.Dispose ();
                deleteButton = null;
            }

            if (doneSwitch != null) {
                doneSwitch.Dispose ();
                doneSwitch = null;
            }

            if (nameText != null) {
                nameText.Dispose ();
                nameText = null;
            }

            if (notesText != null) {
                notesText.Dispose ();
                notesText = null;
            }

            if (saveButton != null) {
                saveButton.Dispose ();
                saveButton = null;
            }
        }
    }
}