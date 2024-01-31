using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NEA_Password_manager
{
    internal class SaveXML
    {
        public static void SaveData(object obj, string filename)
        {
           
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();

            
        }
        public static void AddXML()
        {
            


        }
    }
}
