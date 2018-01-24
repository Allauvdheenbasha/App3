using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android;

namespace App3.Droid
{
    [Activity(Label = "App3.Android", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        //Button button1;
        Button Get;
        EditText txtAge, txtName, txtid;
        public modelboclass boobj = new modelboclass();
        public InventoryDB invdb;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            Button Get = FindViewById<Button>(Resource.Id.Get);
            Get.Click += Get_Click;
        }

        private void Get_Click(object sender, EventArgs e)
        {
            txtid = FindViewById<EditText>(Resource.Id.txtid);
            getdetails(txtid.Text);
           

        }

        private void getdetails(string itemid)
        {
            var nxtpage1 = new Intent(this, typeof(FinalOne));
            nxtpage1.PutExtra("itemidd", Convert.ToInt32( itemid));
            StartActivity(nxtpage1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtAge = FindViewById<EditText>(Resource.Id.txtAge);
            txtName = FindViewById<EditText>(Resource.Id.txtName);
            string name = txtName.Text;
            int age = Convert.ToInt32(txtAge.Text);
            AddDetails(age, name);
        }

        private void AddDetails(int age, string name)
        {
             invdb= new InventoryDB();
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Message");
            alert.SetButton("ok", (cv, EventArgs) =>
            {

            });

            boobj.name = name;
            boobj.age = age;

            
            if (invdb.CreateEmployee(boobj))
            {
                var nxtpage = new Intent(this, typeof(ListViewActivity));
                StartActivity(nxtpage);
            }
            else
            {
                alert.SetMessage("row not added ");
                alert.Show();
            }

        }
    }
}



