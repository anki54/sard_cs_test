
                /*
                Hardcoded string input
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
                using System.Text;
                namespace default_namespace{
                    class Class_44033{
                        string var_44033;
                        public Class_44033(string tainted_2_44033){
                            var_44033 = tainted_2_44033;
                        }
                        public string get_var_44033(){
                            string tainted_2 = null;
string tainted_3 = null;

                            tainted_2 = var_44033;
                            
                StringBuilder text = new StringBuilder(tainted_2);
                text.Replace("&", "&amp;");
                text.Replace("'", "&apos;");
                text.Replace(@"""", "&quot;");
                text.Replace("<", "&lt;");
                text.Replace(">", "&gt;");
                tainted_3 = text.ToString();
            
                            return tainted_3;
                        }
                        
                    }
                }