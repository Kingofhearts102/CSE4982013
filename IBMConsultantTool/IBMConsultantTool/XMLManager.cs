using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace IBMConsultantTool
{
    public class XMLManager
    {

        public void Save(object obj, string filename)
        {
            Category cat = (Category)obj;
            XElement category =
                new XElement("Objectives");

            Console.WriteLine(category);

        }

    }
}
