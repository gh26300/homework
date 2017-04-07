using PHC.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHC.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = new PHC.Services.ImportService();
            var db = new PHC.Repository.stateRepo();
            var states = import.findState(@"http://ibus.tbkc.gov.tw/xmlbus/StaticData/GetRoute.xml");
            showState(states);
            //                .Where(x=>x.CreateTime>DateTime.Now.AddDays(-1))
//                .Where(x=>x.Id.Length==10)
            db.CreateDatabase(states);
            /*states.ToList().ForEach(state => {
                db.CreateDatabase(states);
            });*/
            Console.ReadKey();
            
        }
        public static void showState(List<State> states)
        {
            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", states.Count));
            states.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 {0} , 路徑 {1}", x.nameZh, x.ddesc));
            });
        }
    }
}
