using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsStatistics
    {
        #region "CRUD"  
        public ClientResponse Get_Statistics()
        {
            List<StatVowel> result = new();
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    result = ctx.Database.SqlQuery<StatVowel>("Select 0 as'Id',Max (Date) as Date, sum(SingleVowelCount) as 'SingleVowelCount', sum(PairVowelCount) as " +
                        "'PairVowelCount', sum(TotalWordCount) as 'TotalWordCount', Max(Post) as Post, 0 as PostId  from StatVowel group by Date;").ToList();

                }
                return new ClientResponse { Message = "", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
        #endregion
    }
}
