
/*
Command line args
Xpath replace char
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
using Npgsql;
using System;
using System.Text;
using System.Linq;
using System.Data;

namespace default_namespace{
    class MainClass44762{
        public static void Main(string[] args){
            string tainted_2 = null;
string tainted_3 = null;
string tainted_1 = null;

            
                tainted_1 = args[1];
            
tainted_3 = tainted_1;
            
                string[] arr_1 = new string[4]; // declaring array
                //Storing value in array element
                arr_1[0] = null;
                arr_1[1] = null;
                arr_1[2] = null;
                arr_1[3] = tainted_1;
                foreach(string val_1 in arr_1){
                    if(val_1!=null){
                        tainted_2 = val_1;
                        
                StringBuilder text = new StringBuilder(tainted_2);
                text.Replace("&", "&amp;");
                text.Replace("'", "&apos;");
                text.Replace(@"""", "&quot;");
                text.Replace("<", "&lt;");
                text.Replace(">", "&gt;");
                tainted_3 = text.ToString();
            
                    }
                }
            
                //flaw

                string query = "SELECT * FROM Articles WHERE id="+tainted_3;
            
            
            string connectionString = "Server=localhost;port=1337;User Id=postgre_user;Password=postgre_password;Database=dbname";
            NpgsqlConnection dbConnection = null;
            try{
                dbConnection = new NpgsqlConnection(connectionString);
                dbConnection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, dbConnection);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()){
                    Console.Write("{0}\n", dr[0]);
                }
                dbConnection.Close();
            }catch (Exception e){
                Console.WriteLine(e.ToString());
            }
        
        }
        
    }
}