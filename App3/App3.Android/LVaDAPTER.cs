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

namespace App3.Droid
{
    public class LVaDAPTER : BaseAdapter<modelboclass>
    {
        private List<modelboclass> listItems;
        private Activity _listActivity;

        public LVaDAPTER(Activity acti, List<modelboclass> moboobj)
        {
            this.listItems = moboobj;
            this._listActivity = acti;
        }
        public override modelboclass this[int position]
        {
            get
            {
               return this.listItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return this.listItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this.listItems[position];
            View view = convertView;
            //If there is nothing to reuse, then create view from your row layout
            if (view == null)
                view = this._listActivity.LayoutInflater.Inflate(Resource.Layout.list_single, null);

            view.FindViewById<TextView>(Resource.Id.txt).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.txtage).Text = item.age.ToString();
            view.FindViewById<TextView>(Resource.Id.txtid).Text = item.ID.ToString();
            
            return view;
        }

      
    }
}