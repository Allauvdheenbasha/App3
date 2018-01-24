
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;


    public abstract class DataAccess<T> 
    {
        public SQLiteConnection sqlconn;
        private string type;
        public bool IsExits;

        public DataAccess()
        {

        }
        protected DataAccess(string tabletype, string tblName)
        {
            //Xamarin.Forms.DependencyService.Register<ISQLiteCrudd>();
            sqlconn = DependencyService.Get<ISQLiteCrudd>().getConnection();

            IsExits = DoesTableExist(tabletype, tblName);

            if (!IsExits)
            {
                sqlconn.CreateTable<T>();
            }
        }

        private bool DoesTableExist(string tabletype, string tblName)
        {
            bool exists = DoesTypeExist(tabletype, tblName);
            return exists;
        }

        private bool DoesTypeExist(string tabletype, string tblName)
        {
            SQLiteCommand command = sqlconn.CreateCommand("SELECT COUNT(*) FROM SQLITE_MASTER WHERE TYPE = @TYPE AND NAME = @NAME");
            command.Bind("@TYPE", tabletype);
            command.Bind("@NAME", tblName);

            int result = command.ExecuteScalar<int>();

            return (result > 0);
        }

        public virtual bool CreateOperation(object Modelobj)
        {
            //var types = Modelobj.GetType().GetRuntimeProperties();
            
            sqlconn.Insert(Modelobj);
            return true;
        }
        public virtual List<T> ReadOperation(string tblname)
        {
            //var _returnVal = (from i in sqlconn.Table<T>() select i).ToList();
            //return _returnVal;
            List<T> lst = new List<T>();
            SQLiteCommand command = sqlconn.CreateCommand("SELECT * FROM " + tblname);
            lst = command.ExecuteQuery<T>();
            return lst;
            
        }

        public virtual List<T> GetSpecificDetail(string tblname,int id)
        {
            List<T> lst = new List<T>();
            SQLiteCommand command = sqlconn.CreateCommand("SELECT * FROM " + tblname + " where ID="+id);
            lst = command.ExecuteQuery<T>();
            return lst;
        }

        public virtual void UpdateOperation(object obj)
        {
            sqlconn.Update(obj);
        }

        public virtual void DeleteOperation(int id)
        {
            sqlconn.Delete<T>(id);

        }
    }

