
/*
input : shell commands
no filtering
sink : XPATH Query
exec_query : xpath
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
using System.Xml;
using System;
using System.Xml.XPath;
using System.IO;
using System.Diagnostics;

namespace default_namespace{
    class MainClass56417{
        public static void Main(string[] args){
            string tainted_2 = null;
string tainted_3 = null;
string tainted_1 = null;

            
                Process process = new Process();
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = "-c 'cat /tmp/tainted.txt'";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                using(StreamReader reader = process.StandardOutput) {
                    tainted_1 = reader.ReadToEnd();
                    process.WaitForExit();
                    process.Close();
                }
            
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
                        
                //No filtering (sanitization)
                tainted_3 = tainted_2;
            
                    }
                }
            
                //flaw

                string query = string.Format("//user[@name='{0}']",tainted_3);
            
            
            string filename = "file.xml";
            XmlDocument document = new XmlDocument( );
            document.Load(filename);
            XmlTextWriter writer = new XmlTextWriter(Console.Out);
            writer.Formatting = Formatting.Indented;

            XmlNode node = document.SelectSingleNode(query);
            node.WriteTo(writer);

            writer.Close( );
        
        }
        
    }
}