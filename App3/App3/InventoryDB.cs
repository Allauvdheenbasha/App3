using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace App3
{
    public class InventoryDB : DataAccess<modelboclass>
    {
        public SQLiteConnection SQLCONN;
        public const string tblname = "tblList";
        public InventoryDB(string type ="table", string tblname= "tblList") : base(type, tblname)
        {
            
        }
     
        public bool CreateEmployee(modelboclass _emp)
        {
           
            CreateOperation(_emp);
            return true;
        }

        public List<modelboclass> GetEmployeelist()
        {
            List<modelboclass> list1 = ReadOperation(tblname);
            return list1;

        }
        public void UpdateEmp(modelboclass EmpUpdate)
        {
            UpdateOperation(EmpUpdate);

        }
        
        public void DeleteEmp(modelboclass EmpUpdate)
        {
            DeleteOperation(EmpUpdate.ID);
        }

        public List<modelboclass> GetEmployee(int id)
        {
            List<modelboclass> list1 = GetSpecificDetail(tblname,id);
            return list1;

        }
    }

   
}
