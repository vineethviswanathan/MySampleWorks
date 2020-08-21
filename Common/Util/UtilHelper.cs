using System.Collections.Generic;
using System.Linq;

namespace Common.Util
{
    public static class UtilHelper
    {
       public static int  GetMatchingCount(string word,string searchTerm)
        {
            char[] source = word.ToLowerInvariant().ToCharArray();
            char[] des= searchTerm.ToLowerInvariant().ToCharArray();
            // Create the query.  Use ToLowerInvariant to match "data" and "Data"
            var matchQuery = from s in source
                             join d in des on s equals d
                             select s;

            // Count the matches, which executes the query.  
            var count= matchQuery.Count();
            return count;
        }
    }
}
