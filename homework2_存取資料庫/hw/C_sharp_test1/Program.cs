using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace C_sharp_test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var states = findState();
            showState(states);
            /* 其中一項
            String URLString = " http://ibus.tbkc.gov.tw/xmlbus/StaticData/GetRoute.xml";
            XmlTextReader reader = new XmlTextReader(URLString);
            XDocument doc = XDocument.Load(URLString);
            var routes = doc.Descendants("Route");
            foreach (var route in routes)
            {
                var ddesc = route.Attribute("ddesc").Value.Trim();
                var nameZh = route.Attribute("nameZh").Value.Trim();
                var departureZh = route.Attribute("departureZh").Value.Trim();
                var  destinationZh = route.Attribute("destinationZh").Value.Trim();
                Console.WriteLine(ddesc + "  " + nameZh);
                Console.WriteLine(" from "+departureZh + " to " + destinationZh);
            }
            *****************************************************************************
            /*
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);
                        while (reader.MoveToNextAttribute()) // Read the attributes.
                        Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Console.Write(">");
                        Console.WriteLine(">");
                        break;
                 
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                 
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }*/
            Console.ReadLine();
        }

        static public List<State> findState()
        {
            String URLString = " http://ibus.tbkc.gov.tw/xmlbus/StaticData/GetRoute.xml";
            List<State> States =new List<State>();
            var xml = XElement.Load(URLString);
            var stateNode = xml.Descendants("Route").ToList();
            for (var i = 0; i < stateNode.Count(); i++)
            {
                var statesNode = stateNode[i];
            }
            stateNode.Where(x=>x.IsEmpty).ToList().ForEach(statesNode =>
            {
                var Id = statesNode.Attribute("ID").Value.Trim();
                var destinationZh = statesNode.Attribute("destinationZh").Value.Trim();
                var departureZh = statesNode.Attribute("departureZh").Value.Trim();
                var nameZh = statesNode.Attribute("nameZh").Value.Trim();
                var ddesc = statesNode.Attribute("ddesc").Value.Trim();

                State stateData = new State();
                stateData.Id = Id;
                stateData.ddesc = ddesc;
                stateData.departureZh = departureZh;
                stateData.destinationZh = destinationZh;
                stateData.nameZh = nameZh;
                stateData.CreateTime = DateTime.Now;
                States.Add(stateData);
            });

            return States;
        }

        static public void showState(List<State> states)
        {
            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", states.Count));
            states.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 {0} , 路徑 {1},", x.nameZh, x.ddesc));
            });
        }

    }
}
