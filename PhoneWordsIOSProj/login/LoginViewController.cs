using Foundation;
using System;
using UIKit;

namespace PhoneWordsIOSProj
{
    public partial class LoginViewController : UIViewController
    {


        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            //Validate our Username & Password.
            //This is usually a web service call.
            if (IsUserNameValid() && IsPasswordValid())
            {
                //We have successfully authenticated a the user,
                //Now fire our OnLoginSuccess Event.
                if (OnLoginSuccess != null)
                {
                    OnLoginSuccess(sender, new EventArgs());
                }
            }
            else
            {
                UIAlertController okAlertController = UIAlertController.Create("Login Error", "Bad username or password.", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
        }

        //Create an event when a authentication is successful
        public event EventHandler OnLoginSuccess;

        public LoginViewController(IntPtr handle) : base(handle)
        {
        }



        private bool IsUserNameValid()
        {
            return !String.IsNullOrEmpty(userNameText.Text.Trim());
        }

        private bool IsPasswordValid()
        {
            return !String.IsNullOrEmpty(passwordText.Text.Trim());
        }
    }



}