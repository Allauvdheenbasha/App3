using System;
using SQLite.Net.Attributes;

namespace App3
{
    [Table("tblList")]
    public class modelboclass
    {
        [PrimaryKey,AutoIncrement]
        public virtual int ID { get; set; }
        public string name { get; set; }
        public int age { get; set; }
      
        public modelboclass()
        {

        }


    }
}

