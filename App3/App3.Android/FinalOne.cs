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
    [Activity(Label = "FinalOne")]
    public class FinalOne : Activity
    {
        EditText txtAge, txtName;
        TextView textView1;
        Button button1, button2;
        public modelboclass boobj = new modelboclass();
        public InventoryDB invdb;
        List<modelboclass> lstbomodel = new List<modelboclass>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.EdtDetails);

            int itemid = Intent.Extras.GetInt("itemidd");
            ////string name = Intent.GetStringExtra("ItemId");
            //int Itemidd = itemid;
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            bindEditDetails(itemid);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button1.Click += Button1_Click; button2.Click += Button2_Click;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            boobj.ID = Convert.ToInt32(textView1.Text);
            invdb.DeleteEmp(boobj);
            var mainpage = new Intent(this, typeof(ListViewActivity));
            StartActivity(mainpage);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            boobj.name = txtName.Text;
            boobj.age = Convert.ToInt32( txtAge.Text);
            boobj.ID = Convert.ToInt32(textView1.Text);
            invdb.UpdateEmp(boobj);
            var mainpage = new Intent(this, typeof(ListViewActivity));
            StartActivity(mainpage);
        }

        private void bindEditDetails(int itemidd)
        {
            invdb = new InventoryDB();
            
            lstbomodel = invdb.GetEmployee(itemidd);
            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtAge = FindViewById<EditText>(Resource.Id.txtAge);
            int count = lstbomodel.Count;
            var getItem = lstbomodel[count-1];
            txtName.Text = getItem.name;
            txtAge.Text = getItem.age.ToString();
            textView1.Text = getItem.ID.ToString();
        }
    }
}