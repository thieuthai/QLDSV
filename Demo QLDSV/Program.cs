﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data;
using System.Data.SqlClient;

namespace Demo_QLDSV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static String serverName = "";
        public static String userName = "";
        public static String password = "1";
        public static String loginName = "";

        public static String currentID = "";
        public static String currentPass = "";
        public static String currentLoginName = "";
        public static String currentUserName = "";
        public static String currentServer = "";
        public static String currentRole = "";
        public static int currentBranch = 0;
        public static String classSelected = "";
        public static String className = "";

        public static String databaseName = "QLDSV";
        public static String remoteLogin = "HTKN";
        public static String remotePass = "1";

        public static String connectStr;
        public static SqlDataReader myReader;
        public static SqlConnection connect = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static Boolean isLogin = false;

        public static BindingSource bds = new BindingSource();
        public static BindingSource currentBidingSource = new BindingSource();

        public static String insertDepID = "";
        public static String insertSubjectID = "";
        public static String insertClassID = "";
        public static String insertLevel = "";
        public static String insertTeacherID = "";
        public static String insertCountdown = "";
        public static String insertTime = "";
        public static String insertDate = "";
        public static String insertNumberQuest = "";

        public struct Method
        {
            public const string Update = "U";
            public const string New = "N";
            public const string Delete = "D";
        }


        public static int Connection()
        {
            if (Program.connect != null && Program.connect.State == ConnectionState.Open)
                Program.connect.Close();
            try
            {
                Program.connectStr = "Data Source=" + Program.serverName + ";Initial Catalog=" +
                      Program.databaseName + ";Trusted_Connection=TRUE;User ID=" +
                      Program.userName + ";password=" + Program.password;
                Program.connect.ConnectionString = Program.connectStr;
                Program.connect.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.connect);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.connect.State == ConnectionState.Closed) Program.connect.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.connect.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.connect.State == ConnectionState.Closed) Program.connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, connect);
            da.Fill(dt);
            connect.Close();
            return dt;
        }

        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, connect);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (connect.State == ConnectionState.Closed) connect.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); connect.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                else MessageBox.Show(ex.Message);
                connect.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            var loginForm = new frmLogin();
            Application.Run(loginForm);
        }

        public static void getInforUserLoginSuccess(String serverName, String userName, String pass)
        {
            currentServer = serverName;
            currentUserName = userName;
            password = pass;
        }

        public class UndoObject
        {
            public Object objectUndo;
            public Method method;
            public UndoObject(Object obj, Method Method)
            {
                objectUndo = obj;
                method = Method;
            }
        }
    }
}
