﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bal
{
  class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;

        public Functions()
        {
            ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Iniya Vishal\\Documents\\MobileRepairDb.mdf\";Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        } 

        public DataTable GetData(string Query)
        {
            dt=new DataTable();
            sda = new SqlDataAdapter(Query,ConStr);
            sda.Fill(dt);
            return dt;
        }
        public int setData(string Query)
        {
            int Cnt = 0;
            if(Con.State== ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();
            return Cnt;

        }


    }
}