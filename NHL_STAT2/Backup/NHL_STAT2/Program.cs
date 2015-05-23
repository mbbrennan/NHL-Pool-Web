using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHL_Stat2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static int _poolid;
        public static string _poolname;
        public static int _seasonid;

        public  static int PoolID
        {
            get { return _poolid; }
            set { _poolid = value; }
        }

        public static string PoolName
        {
            get { return _poolname; }
            set { _poolname = value; }
        }

        public static int SeasonID
        {
            get { return _seasonid; }
            set { _seasonid = value; }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Form2());
            Application.Run(new frmStartup());
        }
    }
}
