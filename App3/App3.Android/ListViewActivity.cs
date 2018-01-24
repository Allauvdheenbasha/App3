using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android;

namespace App3.Droid
{
    
    [Activity(Label = "ListViewActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class ListViewActivity : Activity
    {
        List<modelboclass> listdetails = new List<modelboclass>();
        public InventoryDB invdb1;
        public LVaDAPTER adpaterforlist;

        ListView listVw;
        ArrayAdapter AAlv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ListLAyout);
            showlist();
        }

        private void showlist()
        {
            listVw = FindViewById<ListView>(Resource.Id.listVw);
            invdb1 = new InventoryDB();
            listdetails = invdb1.GetEmployeelist();
            adpaterforlist = new LVaDAPTER(this, listdetails);
            
            //AAlv = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1 , listdetails);
            listVw.Adapter = adpaterforlist;
            listVw.ItemClick += ListVw_ItemClick;
            
            
        }

        private void ListVw_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           Toast.MakeText(this, "You Clicked at "+(e.Position+1), ToastLength.Long).Show();
            //Intent nxtpage1 = new Intent(this, typeof(FinalOne));
            //int itemno = e.Position + 1;
            
            //nxtpage1.PutExtra("itemidd", itemno);
            //StartActivity(nxtpage1);
            
            


        }
    }
}