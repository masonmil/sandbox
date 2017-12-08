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
    [Register ("RegisterViewController")]
    partial class RegisterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField confirmPasswordText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField firstNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lastNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton registerButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (confirmPasswordText != null) {
                confirmPasswordText.Dispose ();
                confirmPasswordText = null;
            }

            if (emailText != null) {
                emailText.Dispose ();
                emailText = null;
            }

            if (firstNameText != null) {
                firstNameText.Dispose ();
                firstNameText = null;
            }

            if (lastNameText != null) {
                lastNameText.Dispose ();
                lastNameText = null;
            }

            if (passwordText != null) {
                passwordText.Dispose ();
                passwordText = null;
            }

            if (registerButton != null) {
                registerButton.Dispose ();
                registerButton = null;
            }
        }
    }
}