
/*
input : direct user input in string
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
using System;
using System.Xml.XPath;
using System.Xml;

namespace default_namespace{
    class MainClass52806{
        public static void Main(string[] args){
            string tainted_2 = null;
string tainted_3 = null;

            
                tainted_2 = Console.ReadLine();
            
tainted_3 = tainted_2;
            
                if((4+2>=42)){
                    {}
                }else if(!(4+2>=42)){
                    
                //No filtering (sanitization)
                tainted_3 = tainted_2;
            
                }
            
                //flaw

                string query = "//user[@name='" + tainted_3 + "']";
            
            
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