
/*
input : direct user input in string
filtering : remove all '\', '*', '(', ')', 'u0000', '/' in parameter
construction : concatenation with simple quote
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
using System.Data.OracleClient;
using System;
using System.Text;

namespace default_namespace{
    class MainClass17384{
        public static void Main(string[] args){
            string tainted_2 = null;
string tainted_3 = null;
string tainted_4 = null;

            
                tainted_2 = Console.ReadLine();
            
tainted_4 = tainted_2;
            
                
                StringBuilder escape = new StringBuilder();
                for (int i = 0; i < tainted_2.Length; ++i){
                    char current = tainted_2[i];
                    switch (current){
                        case '\\':
                            escape.Append(@"\5c");
                            break;
                        case '*':
                            escape.Append(@"\2a");
                            break;
                        case '(':
                            escape.Append(@"\28");
                            break;
                        case ')':
                            escape.Append(@"\29");
                            break;
                        case '\u0000':
                            escape.Append(@"\00");
                            break;
                        case '/':
                            escape.Append(@"\2f");
                            break;
                        default:
                            escape.Append(current);
                            break;
                    }
                }
                tainted_3 = escape.ToString();
            
                tainted_4 = function_17383(tainted_3);
            
                //flaw

                string query = "SELECT * FROM '" + tainted_4 + "'";
            
            
            string connectionString = "Data Source=localhost;User ID=oracle_user;Password=oracle_password";
            OracleConnection dbConnection = null;
            try{
                dbConnection = new OracleConnection(connectionString);
                dbConnection.Open();
                OracleCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    Console.WriteLine(reader.ToString());
                }
                dbConnection.Close();
            }catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        
        }
        
                public static string function_17383(string param_17383 ){
                    return param_17383 ;
                }


    }
}