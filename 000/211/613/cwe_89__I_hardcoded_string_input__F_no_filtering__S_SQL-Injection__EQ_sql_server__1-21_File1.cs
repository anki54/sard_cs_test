
/*
Hardcoded string input
no filtering
sink : SQL query
*/
/*
Copyright 2016 Bertrand STIVALET

Permission is hereby granted, without written agreement or royalty fee, to
use, copy, modify, and distribute this software and its documentation for
any purpose, provided that the above copyright notice and the following
three paragraphs appear in all copies of this software.

IN NO EVENT SHALL AUTHORS BE LIABLE TO ANY PARTY FOR DIRECT,
INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE
USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF AUTHORS HAVE
BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

AUTHORS SPECIFICALLY DISCLAIM ANY WARRANTIES INCLUDING, BUT NOT
LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE, AND NON-INFRINGEMENT.

THE SOFTWARE IS PROVIDED ON AN "AS-IS" BASIS AND AUTHORS HAVE NO
OBLIGATION TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR
MODIFICATIONS.

*/
using System;
using System.Data.SqlClient;

namespace default_namespace{
    class MainClass28866{
        public static void Main(string[] args){
            string tainted_2 = null;
string tainted_3 = null;
string tainted_1 = null;

            
                tainted_1 = "hardcoded";
            
tainted_3 = tainted_1;
            
                Class_28865 var_28865 = new Class_28865(tainted_1);
                tainted_2 = var_28865.get_var_28865();
                
                //No filtering (sanitization)
                tainted_3 = tainted_2;
            
            
                
                string query = "SELECT * FROM Articles WHERE id="+tainted_3;
            
            
            string connectionString =  @"server=localhost;uid=sql_user;password=sql_password;database=dbname";
            SqlConnection dbConnection = null;
            try {
                dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    Console.WriteLine(reader.ToString());
                }
                dbConnection.Close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        
        }
        
    }
}