
/*
input : shell commands
no filtering
sink : LDAP Query
LDAP Query
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
using System.DirectoryServices;
using System.IO;
using System.Diagnostics;

namespace default_namespace{
    class MainClass49023{
        public static void Main(string[] args){
            string tainted_0 = null;
string tainted_5 = null;

            
                Process process = new Process();
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = "-c 'cat /tmp/tainted.txt'";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                using(StreamReader reader = process.StandardOutput) {
                    tainted_0 = reader.ReadToEnd();
                    process.WaitForExit();
                    process.Close();
                }
            
tainted_5 = tainted_0;
            tainted_5 = function_49022(tainted_0);
            
                //flaw

                string query = "(&(objectClass=person)(sn=" + tainted_5 + "))";
            
            
            string strConnect = "LDAP://my.site.com/o=site,c=com";
            using (System.DirectoryServices.DirectoryEntry CN_Main = new System.DirectoryServices.DirectoryEntry(strConnect)){
                string strResult = "";
                System.DirectoryServices.DirectorySearcher DirSearcher = new System.DirectoryServices.DirectorySearcher(CN_Main, query);
                System.DirectoryServices.DirectoryEntry CN_Result;
                CN_Main.AuthenticationType = AuthenticationTypes.None;
                foreach (System.DirectoryServices.SearchResult ResultSearch in DirSearcher.FindAll()){
                    if (ResultSearch != null){
                        CN_Result = ResultSearch.GetDirectoryEntry();
                        if ((string)CN_Result.Properties["userclass"][0] == "noname"){
                            strResult = strResult + "Name : " + CN_Result.InvokeGet("sn");
                        }
                    }
                }
                Console.WriteLine(strResult);
            }
        
        }
        
                public static string function_49022(string param_49022 ){
                    string tainted_2 = null;
string tainted_3 = null;

                    tainted_2 = param_49022;
                    
                //No filtering (sanitization)
                tainted_3 = tainted_2;
            
                    return tainted_3;
                }
    }
}