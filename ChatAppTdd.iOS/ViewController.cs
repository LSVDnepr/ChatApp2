using System;

using UIKit;

namespace ChatAppTdd.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
         //   InitializeViper();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }



        //private void InitializeViper()
    //    {
            
    //    }

        /*
         RedBackGround=100,80,82 
GreyBackGround
TextColor DarkGrey = #263238  RGB=38,50,56   
TextColor DarkRed = #b71c1c RGB=138,28,28  
red textColor=#B71C1C  RGB=183,28,28

==============
Colors
android:textColorHint="#78909C"   RGBA=
android:background="#80D8FF"   RGBA=128,216,255 accent


android accent Color #00E5FF  RGBA=
andoid dark blue gray #37474F  text Color #FFFFFF   RGBA=55, 71,79
red background #FFCDD2   RGBA=255,205,210


android medium blue gray #78909C  text Color #FFFFFF RGBA=120,144,156

android lightBlueGray #B0BEC5  textColor black #000000 RGBA=176,190,197
 
          
         */


        /*
         var dest = UIStoryboard.FromName("Main", NSBundle.MainBundle).InstantiateViewController("XZViewController");
            var cell = _collectionView.CellForItem(obj) as PersonCell;
            dest.Title = cell.Text;
            NavigationController.PushViewController(dest, true);
 
         
         */



    }
}