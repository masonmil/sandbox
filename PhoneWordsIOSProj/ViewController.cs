using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace PhoneWordsIOSProj
{
    public partial class ViewController : UIViewController
    {
        string translatedNumber = string.Empty;       

        public List<string> PhoneNumbers { get; set; }

        public ViewController(IntPtr handle) : base(handle)
        {
            //initialize list of phone numbers called for Call History screen
            PhoneNumbers = new List<string>();

        }
#region ViewDidLoad
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            TranslateButton.TouchUpInside += (object sender, EventArgs e) => {

                translatedNumber = PhoneTranslator.ToNumber(
                    PhoneNumberText.Text);

                PhoneNumberText.ResignFirstResponder();

                if (translatedNumber == string.Empty)
                {
                    CallButton.SetTitle("Call ", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else{
                    
                
                    CallButton.SetTitle("Call "+ translatedNumber, UIControlState.Normal);
                    CallButton.Enabled = true;
                }

            };

            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var url = new NSUrl("tel:" + translatedNumber);
                PhoneNumbers.Add(translatedNumber);

                if (!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alert = UIAlertController.Create("Not Supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);

                }
            };
        }
#endregion

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // set the View Controller that’s powering the screen we’re
            // transitioning to

            var callHistoryContoller = segue.DestinationViewController as CallHistoryController;

            //set the Table View Controller’s list of phone numbers to the
            // list of dialed phone numbers

            if (callHistoryContoller != null)
            {
                callHistoryContoller.PhoneNumbers = PhoneNumbers;
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
