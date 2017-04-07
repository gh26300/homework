using PHC.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PHC.Services
{
   public class ImportService
    {

     
       public List<State> findState(string URLString)
       {
           //String URLString = " http://ibus.tbkc.gov.tw/xmlbus/StaticData/GetRoute.xml";
           List<State> States = new List<State>();
           var xml = XElement.Load(URLString);
           var stateNode = xml.Descendants("Route").ToList();
           for (var i = 0; i < stateNode.Count(); i++)
           {
               var statesNode = stateNode[i];
           }
           stateNode.Where(x => x.IsEmpty).ToList().ForEach(statesNode =>
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

    }
}
