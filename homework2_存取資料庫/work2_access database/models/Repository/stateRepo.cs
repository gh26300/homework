using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHC.Repository
{
    public class stateRepo
    {
        private const string _connectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Source\Repos\homework\homework2_存取資料庫\work2_access database\Console\app_data\bus.mdf;Integrated Security=True";
        public void CreateDatabase(List<Modles.State> states)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectString;
            connection.Open();

            foreach (var state in states)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
            INSERT INTO State(Id,nameZh,ddesc,departureZh,destinationZh,CreateTime)
            VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", state.Id, state.nameZh, state.ddesc
                , state.departureZh, state.destinationZh, state.CreateTime.ToString("yyyy/MM/dd"));

              //  command.ExecuteNonQuery();
              //  有疑問
            }
                connection.Close();
        }
    }
}
